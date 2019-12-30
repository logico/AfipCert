Public Class frmMain
    Private Sub btnSeleccionDirectorioSalida_Click(sender As Object, e As EventArgs) Handles btnSeleccionDirectorioSalida.Click
        If fdSeleccionDirectorio.ShowDialog(Me) = DialogResult.OK Then
            txtDirectorioSalida.Text = fdSeleccionDirectorio.SelectedPath
        End If
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
            Dim codigoSalida As Integer = Shell($"{Environment.CurrentDirectory}\generar.bat {Environment.CurrentDirectory}\openssl.cnf ""{txtDirectorioSalida.Text}\{txtNombreArchivoClave.Text}.key"" ""{txtNombreEmpresa.Text}"" ""{txtNombrePersona.Text}"" {txtCuit.Text} ""{txtDirectorioSalida.Text}\{txtNombreArchivoCSR.Text}.csr""", AppWinStyle.Hide, True)
            If codigoSalida = 0 Then
                MsgBox("El certificado fue generado correctamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AfipCert")
            Else
                MsgBox($"Hubo un error al generar el certificado. Por favor verifique que los archivos necesarios se encuentren en el directorio. {vbCrLf} Para más información vaya a https://logico.ar/", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AfipCert")
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        End
    End Sub

    Private Sub lnkSoporte_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSoporte.LinkClicked
        Process.Start("https://logico.ar/blog/2019/12/28/afipcert-crea-y-convierte-de-manera-facil-certificados-digitales-afip")
    End Sub

    Private Sub btnConvertir_Click(sender As Object, e As EventArgs) Handles btnConvertir.Click
        If Utils.ArchivoExiste(txtClavePrivadaPath, btnSeleccionarClavePrivada, err) And
           Utils.ArchivoExiste(txtCertificadoPath, btnSeleccionarCertificado, err) And
           Utils.DirectorioExiste(txtDirectorioSalidaPfx, btnSeleccionarDirectorioPfx, err) And
           Utils.EsCampoVacio(txtNombreArchivoPfx, err) And
           Utils.ContraseniasCoinciden(txtContrasenia, txtContraseniaConfirmar, err) Then
            Debug.Print($"{Environment.CurrentDirectory}\convertir.bat {Environment.CurrentDirectory}\openssl.cnf ""{txtClavePrivadaPath.Text}"" ""{txtCertificadoPath.Text}"" ""{txtDirectorioSalidaPfx.Text}\{txtNombreArchivoPfx.Text}.pfx"" ""{txtContrasenia.Text}""")
            Dim codigoSalida As Integer = Shell($"{Environment.CurrentDirectory}\convertir.bat {Environment.CurrentDirectory}\openssl.cnf ""{txtClavePrivadaPath.Text}"" ""{txtCertificadoPath.Text}"" ""{txtDirectorioSalidaPfx.Text}\{txtNombreArchivoPfx.Text}.pfx"" ""{txtContrasenia.Text}""", AppWinStyle.Hide, True)
            If codigoSalida = 0 Then
                MsgBox("El certificado fue exportado correctamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AfipCert")
            Else
                MsgBox($"Hubo un error al exportar el certificado. Por favor verifique que los archivos necesarios se encuentren en el directorio. {vbCrLf} Para más información vaya a https://logico.ar/", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "AfipCert")
            End If
        End If
    End Sub

    Private Sub txtContrasenia_TextChanged(sender As Object, e As EventArgs) Handles txtContrasenia.TextChanged
        Utils.ContraseniasCoinciden(txtContrasenia, txtContraseniaConfirmar, err)
    End Sub

    Private Sub txtContraseniaConfirmar_TextChanged(sender As Object, e As EventArgs) Handles txtContraseniaConfirmar.TextChanged
        Utils.ContraseniasCoinciden(txtContrasenia, txtContraseniaConfirmar, err)
    End Sub

    Private Sub txtContrasenia_Leave(sender As Object, e As EventArgs) Handles txtContrasenia.Leave
        Utils.ContraseniasCoinciden(txtContrasenia, txtContraseniaConfirmar, err)
    End Sub

    Private Sub txtContraseniaConfirmar_Leave(sender As Object, e As EventArgs) Handles txtContraseniaConfirmar.Leave
        Utils.ContraseniasCoinciden(txtContrasenia, txtContraseniaConfirmar, err)
    End Sub

    Private Sub txtNombreArchivoPfx_Leave(sender As Object, e As EventArgs) Handles txtNombreArchivoPfx.Leave
        Utils.EsCampoVacio(txtNombreArchivoPfx, err)
    End Sub

    Private Sub btnSeleccionarClavePrivada_Click(sender As Object, e As EventArgs) Handles btnSeleccionarClavePrivada.Click
        With oFile
            .Filter = "Clave privada|*.key|Todos los archivos|*.*"
            .FilterIndex = 0
            .FileName = ""
            If .ShowDialog(Me) = DialogResult.OK Then
                txtClavePrivadaPath.Text = .FileName
            End If
        End With
    End Sub

    Private Sub btnSeleccionarCertificado_Click(sender As Object, e As EventArgs) Handles btnSeleccionarCertificado.Click
        With oFile
            .Filter = "Certificado|*.crt|Todos los archivos|*.*"
            .FilterIndex = 0
            .FileName = ""
            If oFile.ShowDialog(Me) = DialogResult.OK Then
                txtCertificadoPath.Text = oFile.FileName
            End If
        End With
    End Sub

    Private Sub btnSeleccionarDirectorioPfx_Click(sender As Object, e As EventArgs) Handles btnSeleccionarDirectorioPfx.Click
        If fdSeleccionDirectorio.ShowDialog(Me) = DialogResult.OK Then
            txtDirectorioSalidaPfx.Text = fdSeleccionDirectorio.SelectedPath
        End If
    End Sub
End Class
