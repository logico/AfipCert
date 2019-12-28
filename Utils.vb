Public Class Utils
    ''' <summary>
    ''' Verifica que el campo no esté vacio
    ''' </summary>
    ''' <param name="campo">Control TextBox a verificar</param>
    ''' <param name="Err">Control para el seteo de errores</param>
    ''' <returns>True si el campo está vacio de lo contrario False </returns>
    Public Shared Function EsCampoVacio(ByRef campo As TextBox, ByRef Err As ErrorProvider) As Boolean
        If campo.Text.Trim.Length = 0 Then
            Err.SetIconPadding(campo, 5)
            Err.SetError(campo, "El nombre de archivo es obligatorio")
            Return False
        Else
            Err.SetError(campo, "")
            Return True
        End If
    End Function

    Public Shared Function EsCuitValido(ByRef campo As TextBox, ByRef Err As ErrorProvider) As Boolean
        If Not ValidarCUIT(campo.Text) Then
            Err.SetIconPadding(campo, 5)
            Err.SetError(campo, "La CUIT no es válida")
            Return False
        Else
            Err.SetError(campo, "")
            Return True
        End If
    End Function

    ''' <summary>
    ''' Valida el formato y digito verificador de un número de CUIT.
    ''' </summary>
    ''' <param name="cuit">El número de CUIT a validar</param>
    ''' <returns>True si el número es válido, False si no lo es.</returns>
    Public Shared Function ValidarCUIT(ByVal cuit As String) As Boolean
        ' En caso que la CUIT venga en formato con guiones
        cuit = cuit.Replace("-", "")
        If IsNumeric(cuit) Then
            Try
                If (cuit.Length <> 11) Then Return False

                Dim tmpCuit As String = cuit.Substring(0, 10)
                Dim total As Integer = 0
                Dim tabla() As Integer = {5, 4, 3, 2, 7, 6, 5, 4, 3, 2}

                For i = 0 To tmpCuit.Length - 1
                    Dim currChar As Integer = CInt(tmpCuit.Substring(i, 1))
                    total += currChar * tabla(i)
                Next
                Dim preDV As Integer = 11 - (total Mod 11)
                If preDV >= 10 Then
                    preDV = 0
                End If
                tmpCuit &= preDV
                If cuit = tmpCuit Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If
    End Function
End Class
