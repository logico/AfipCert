Public Class frmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Shell($"{Environment.CurrentDirectory}\ejecutar.bat {Environment.CurrentDirectory}\openssl.cnf", AppWinStyle.Hide, True)
    End Sub

    Private Sub btnCrearCertificado_Click(sender As Object, e As EventArgs) Handles btnCrearCertificado.Click

    End Sub

    Private Sub txtNombreArchivoClave_TextChanged(sender As Object, e As EventArgs) Handles txtNombreArchivoClave.TextChanged

    End Sub

    Private Sub txtNombreArchivoClave_Leave(sender As Object, e As EventArgs) Handles txtNombreArchivoClave.Leave
        If txtNombreArchivoClave.Text.Trim.Length = 0 Then
            err.SetError(txtNombreArchivoClave, "El nombre de archivo es obligatorio")
        Else
            err.SetError(txtNombreArchivoClave, "")
        End If
    End Sub
End Class
