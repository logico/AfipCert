Public Class frmMain
    Private Sub Button1_Click(sender As Object, e As EventArgs)

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
        Utils.EsCuitValido(txtCuit, err)
    End Sub

    Private Sub txtNombreArchivoCSR_Leave(sender As Object, e As EventArgs) Handles txtNombreArchivoCSR.Leave
        Utils.EsCampoVacio(txtNombreArchivoCSR, err)
    End Sub

    Private Sub btnCrearCertificado_Click(sender As Object, e As EventArgs) Handles btnCrearCertificado.Click
        If Utils.EsCampoVacio(txtNombreArchivoClave, err) And
            Utils.EsCampoVacio(txtNombreEmpresa, err) And
            Utils.EsCampoVacio(txtNombrePersona, err) And
            Utils.EsCuitValido(txtCuit, err) And
            Utils.EsCampoVacio(txtNombreArchivoCSR, err) And
            Utils.DirectorioExiste(txtDirectorioSalida, btnSeleccionDirectorioSalida, err) Then
            Shell($"{Environment.CurrentDirectory}\ejecutar.bat 
                    {Environment.CurrentDirectory}\openssl.cnf 
                    {Environment.CurrentDirectory}\{txtNombreArchivoClave} 
                    {txtNombreEmpresa.Text} 
                    {txtNombrePersona.Text} 
                    {txtCuit.Text} 
                    {txtNombreArchivoCSR.Text}", AppWinStyle.Hide, True)
        End If
    End Sub
End Class
