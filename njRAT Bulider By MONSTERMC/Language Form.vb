Imports System.Threading.Thread
Imports System.Globalization
Public Class Language_Form
    Private Sub HuraButton1_Click(sender As Object, e As EventArgs) Handles HuraButton1.Click
        CurrentThread.CurrentUICulture = New CultureInfo("AR")
        Dim fromAR As New Form1
        fromAR.Show()
        Me.Hide()
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub
    Private Sub HuraButton2_Click(sender As Object, e As EventArgs) Handles HuraButton2.Click
        CurrentThread.CurrentUICulture = New CultureInfo("EN")
        Dim fromAR As New Form1
        fromAR.Show()
        Me.Hide()
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages(1)
    End Sub

    Private Sub HuraControlBox1_Click(sender As Object, e As EventArgs) Handles HuraControlBox1.Click
        End
    End Sub
End Class