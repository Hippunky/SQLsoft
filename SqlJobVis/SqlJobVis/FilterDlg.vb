

Public Class FilterDlg

    Public Sub New(ByVal FT As FilterType, ByVal suppressedCats() As String, ByVal cats() As String)
        InitializeComponent()

        Clb_Filters.Items.Add("Failed", (FT And SqlJobVis.FilterType.Failed) <> 0)
        Clb_Filters.Items.Add("Long Running", (FT And SqlJobVis.FilterType.LongRunning) <> 0)
        Clb_Filters.Items.Add("Clashing", (FT And SqlJobVis.FilterType.Clashing) <> 0)

        For Each cat As String In cats
            Clb_Categories.Items.Add(cat, Array.IndexOf(suppressedCats, cat) < 0)
        Next

        Chk_HideDisabled.Checked = ((FT And SqlJobVis.FilterType.Disabled) <> 0)
        Chk_HideInactive.Checked = ((FT And SqlJobVis.FilterType.Inactive) <> 0)
    End Sub

    Public ReadOnly Property FilterType() As FilterType
        Get
            Dim Result As FilterType = 0
            For I As Integer = 0 To Clb_Filters.Items.Count - 1
                If Clb_Filters.GetItemChecked(I) Then
                    Result = Result Or (1 << I)
                End If
            Next

            If Chk_HideDisabled.Checked Then
                Result = Result Or SqlJobVis.FilterType.Disabled
            End If

            If Chk_HideInactive.Checked Then
                Result = Result Or SqlJobVis.FilterType.Inactive
            End If

            Return Result
        End Get
    End Property

    Public ReadOnly Property SuppressedCategories() As String()
        Get
            Dim result As New List(Of String)

            For I As Integer = 0 To Clb_Categories.Items.Count - 1
                If Not Clb_Categories.GetItemChecked(I) Then
                    result.Add(Clb_Categories.Items(I))
                End If
            Next

            Return result.ToArray()
        End Get
    End Property

    Private Sub Btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_OK.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class