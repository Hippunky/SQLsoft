Imports System.Globalization
Imports Microsoft.Win32
Imports SQLsoftTools

Public Class Options
    Public Shared m_WorkingDays As String = "0111110"
    Public Shared m_WorkingDaysBack As Integer = 1
    Public Shared m_StoreSession As Boolean = True
    Public Shared m_LongRunningJobSecs As Integer = 120
    Public Shared m_RefreshInterval As Integer = 5 * 60
    Public Shared m_ZoomToFitByDefault As Boolean = False

    Public Shared m_Colours As New List(Of UiColour)

    Shared Function GetColour(ByVal Name As String)
        For Each UIC As UiColour In m_Colours
            If UIC.m_Name = Name Then
                Return UIC.m_Colour
            End If
        Next

        Return Color.Red
    End Function

    Shared Function GetDefaultColours() As List(Of UiColour)
        Dim Result As New List(Of UiColour)

        Result.Add(New UiColour("Succeeded", Color.Green, False))
        Result.Add(New UiColour("Failed", Color.Red, False))
        Result.Add(New UiColour("Cancelled", Color.Gray, False))
        Result.Add(New UiColour("Retried", Color.Yellow, False))
        Result.Add(New UiColour("In Progress", Color.Cyan, False))
        Result.Add(New UiColour("Long Running", Color.Green, False))
        Result.Add(New UiColour("Disabled", Color.Black, True))

        Return Result
    End Function


    Shared Sub New()
        Try
            m_Colours = GetDefaultColours()

            Using RK As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\SQLsoft\SQLjobvis", RegistryKeyPermissionCheck.ReadWriteSubTree)
                m_WorkingDays = RK.GetValue("WorkingDays", "0111110")
                m_WorkingDaysBack = RK.GetValue("WorkingDaysBack", 1)
                m_StoreSession = (RK.GetValue("StoreSession", 1) <> 0)
                m_LongRunningJobSecs = RK.GetValue("LongRunningJobSecs", 120)
                m_RefreshInterval = RK.GetValue("RefreshInterval", 5 * 60)
                m_ZoomToFitByDefault = (RK.GetValue("ZoomToFitByDefault", 0) <> 0)

                For Each UIC As UiColour In m_Colours
                    If Not IsNothing(RK.GetValue("Colour_" & UIC.m_Name)) Then
                        UIC.m_Colour = Color.FromArgb(RK.GetValue("Colour_" & UIC.m_Name))
                    End If
                Next

                RK.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Sub Save()
        Try
            Using RK As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\SQLsoft\SQLjobvis", RegistryKeyPermissionCheck.ReadWriteSubTree)
                RK.SetValue("WorkingDays", m_WorkingDays)
                RK.SetValue("WorkingDaysBack", m_WorkingDaysBack)
                RK.SetValue("StoreSession", If(m_StoreSession, 1, 0))
                RK.SetValue("LongRunningJobSecs", m_LongRunningJobSecs)
                RK.SetValue("RefreshInterval", m_RefreshInterval)
                RK.SetValue("ZoomToFitByDefault", If(m_ZoomToFitByDefault, 1, 0))

                For Each UIC As UiColour In m_Colours
                    RK.SetValue("Colour_" & UIC.m_Name, UIC.m_Colour.ToArgb)
                Next

                RK.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Function GetStartDate() As DateTime
        Dim WorkingDaysBack As Integer = m_WorkingDaysBack
        Dim WorkingDays As New List(Of String)

        For I As Integer = 0 To 6
            If m_WorkingDays(I) = "1" Then
                WorkingDays.Add(CultureInfo.CurrentCulture().DateTimeFormat.DayNames(I).ToUpper())
            End If
        Next

        Dim StartDate = DateTime.Now.Date
        While WorkingDaysBack <> 0
            StartDate = StartDate.AddDays(-1.0)
            If WorkingDays.Contains(StartDate.ToString("dddd").ToUpper()) Then
                WorkingDaysBack -= 1
            End If
        End While

        Return StartDate
    End Function
End Class
