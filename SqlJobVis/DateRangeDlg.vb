Imports System.Windows.Forms

Public Class DateRangeDlg
    Public Property FromDate() As DateTime
        Get
            Return Dtp_From.Value.Date
        End Get
        Set(ByVal value As DateTime)
            Dtp_From.Value = value.Date
        End Set
    End Property

    Public Property ToDate() As DateTime
        Get
            Return Dtp_To.Value.Date
        End Get
        Set(ByVal value As DateTime)
            Dtp_To.Value = value.Date
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Btn_Yesterday_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Yesterday.Click
        Dtp_From.Value = DateTime.Now().Date.AddDays(-1.0)
        Dtp_To.Value = Dtp_From.Value
    End Sub

    Private Sub Btn_Today_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Today.Click
        Dtp_From.Value = DateTime.Now().Date
        Dtp_To.Value = Dtp_From.Value
    End Sub

    Private Sub Dtp_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtp_From.ValueChanged
        If Dtp_To.Value.Date < Dtp_From.Value.Date Then
            Dtp_To.Value = Dtp_From.Value.Date
        End If
    End Sub

    Private Sub Dtp_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Dtp_To.ValueChanged
        If Dtp_To.Value.Date < Dtp_From.Value.Date Then
            Dtp_From.Value = Dtp_To.Value.Date
        End If
    End Sub
End Class
