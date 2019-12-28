Public Class frmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Shell($"{Environment.CurrentDirectory}\ejecutar.bat {Environment.CurrentDirectory}\openssl.cnf", AppWinStyle.Hide, True)
    End Sub

    Private Sub txtNombreArchivoClave_Leave(sender As Object, e As EventArgs) Handles txtNombreArchivoClave.Leave
        Utils.EsCampoVacio(txtNombreArchivoClave, err)
    End Sub

    Private Sub txtNombreEmpresa_Leave(sender As Object, e As EventArgs) Handles txtNombreEmpresa.Leave
        Utils.EsCampoVacio(txtNombreEmpresa, err)
    End Sub

    Private Sub txtNombrePersona_Leave(sender As Object, e As EventArgs) Handles txtNombrePersona.Leave
        Utils.EsCampoVacio(txtNombrePersona, err)
    End Sub

    Private Sub txtCuit_Leave(sender As Object, e As EventArgs) Handles txtCuit.Leave
        Utils.EsCampoVacio(txtCuit, err)
    End Sub

    Private Sub txtNombreArchivoCSR_Leave(sender As Object, e As EventArgs) Handles txtNombreArchivoCSR.Leave
        Utils.EsCampoVacio(txtNombreArchivoCSR, err)
    End Sub
End Class
