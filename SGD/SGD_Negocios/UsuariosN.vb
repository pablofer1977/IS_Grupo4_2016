Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class UsuariosN
        Public Function CargarCombo(ByVal sEstado As String, ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim UsuariosD As UsuariosD
            Dim dt As DataTable

            Try
                UsuariosD = New UsuariosD
                dt = New DataTable

                dt = UsuariosD.CargarCombo(sEstado, bTodos, bBlanco)

                UsuariosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Estados_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim GeneralD As GeneralD
            Dim dt As DataTable

            Try
                GeneralD = New GeneralD
                dt = New DataTable

                dt = GeneralD.Estados_CargarCombo(bTodos, bBlanco)

                GeneralD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function TiposPerfiles_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim UsuariosD As UsuariosD
            Dim dt As DataTable

            Try
                UsuariosD = New UsuariosD
                dt = New DataTable

                dt = UsuariosD.TiposPerfiles_CargarCombo(bTodos, bBlanco)

                UsuariosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal pUsuarios As UsuariosE) As DataTable
            Dim UsuariosD As UsuariosD
            Dim dt As DataTable

            Try
                UsuariosD = New UsuariosD
                dt = New DataTable

                dt = UsuariosD.Listado(pUsuarios)

                UsuariosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal pUsuarios As UsuariosE) As DataTable
            Dim UsuariosD As UsuariosD
            Dim dt As DataTable

            Try
                UsuariosD = New UsuariosD
                dt = New DataTable

                dt = UsuariosD.Obtener(pUsuarios)

                UsuariosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal pUsuarios As UsuariosE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim UsuariosD As UsuariosD

                UsuariosD = New UsuariosD

                'valido los datos
                If IsNothing(pUsuarios.sUsuario) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Usuario.")

                    Return dt
                End If

                If Verificar(eAccion.Agregar, pUsuarios) > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Usuario ya Ingresado.")

                    Return dt
                End If

                If IsNothing(pUsuarios.sPassword) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una Password.")

                    Return dt
                End If

                If IsNothing(pUsuarios.sPassword2) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Confirmar la Password.")

                    Return dt
                End If

                If pUsuarios.sPassword <> pUsuarios.sPassword2 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Las Password no Coinciden.")

                    Return dt
                End If

                If IsNothing(pUsuarios.sNombre) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre y Apellido.")

                    Return dt
                End If

                If pUsuarios.nId_TipoPerfil = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Perfil.")

                    Return dt
                End If

                'realizo la actualizacion
                If UsuariosD.Agregar(pUsuarios) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se dió de Alta al Usuario.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Modificar(ByVal pUsuarios As UsuariosE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim UsuariosD As UsuariosD

                UsuariosD = New UsuariosD

                'valido los datos
                If IsNothing(pUsuarios.sUsuario) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Usuario.")

                    Return dt
                End If

                If IsNothing(pUsuarios.sNombre) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre y Apellido.")

                    Return dt
                End If

                If pUsuarios.nId_TipoPerfil = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Perfil.")

                    Return dt
                End If

                'realizo la actualizacion
                If UsuariosD.Modificar(pUsuarios) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Modificaron los Datos del Usuario.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Estado(ByVal pUsuarios As UsuariosE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim UsuariosD As UsuariosD

                UsuariosD = New UsuariosD

                'valido los datos
                If IsNothing(pUsuarios.sUsuario) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Usuario de la Grilla")

                    Return dt
                End If

                'realizo la actualizacion
                If UsuariosD.Estado(pUsuarios) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "El Usuario fue Dado de Baja.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function Verificar(ByVal nAccion As eAccion, ByVal pUsuarios As UsuariosE) As Integer
            Dim UsuariosD As UsuariosD

            Dim nCant As Integer = 0

            Try
                UsuariosD = New UsuariosD

                nCant = UsuariosD.Verificar(nAccion, pUsuarios)

                UsuariosD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function Estado_Verificar(ByVal pUsuarios As UsuariosE) As Integer
            Dim UsuariosD As UsuariosD

            Dim nCant As Integer = 0

            Try
                UsuariosD = New UsuariosD

                nCant = UsuariosD.Estado_Verificar(pUsuarios)

                UsuariosD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function Password_Verificar(ByVal pUsuarios As UsuariosE) As Integer
            Dim UsuariosD As UsuariosD

            Dim nCant As Integer = 0

            Try
                UsuariosD = New UsuariosD

                nCant = UsuariosD.Password_Verificar(pUsuarios)

                UsuariosD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Public Function Ingresar(ByVal pUsuarios As UsuariosE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim UsuariosD As UsuariosD

                UsuariosD = New UsuariosD

                'valido los datos
                If IsNothing(pUsuarios.sUsuario) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe ingresar un Usuario/Password Válidos.")

                ElseIf IsNothing(pUsuarios.sPassword) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe ingresar un Usuario/Password Válidos.")

                ElseIf Estado_Verificar(pUsuarios) <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe ingresar un Usuario/Password Válidos.")

                ElseIf Password_Verificar(pUsuarios) <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe ingresar un Usuario/Password Válidos.")

                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        'Public Function Ingresar(ByVal pUsuarios As UsuariosE) As Boolean
        '    Try
        '        Dim UsuariosD As UsuariosD

        '        UsuariosD = New UsuariosD

        '        'valido los datos
        '        If IsNothing(pUsuarios.sUsuario) Then
        '            MsgBox("Debe ingresar un Usuario/Password Válidos.", vbInformation, "Robin")

        '            Return False
        '        End If

        '        If IsNothing(pUsuarios.sPassword) Then
        '            MsgBox("Debe ingresar un Usuario/Password Válidos.", vbInformation, "Robin")

        '            Return False
        '        End If

        '        If Estado_Verificar(pUsuarios) <= 0 Then
        '            MsgBox("Debe ingresar un Usuario/Password Válidos.", vbInformation, "Robin")

        '            Return False
        '        End If

        '        If Password_Verificar(pUsuarios) <= 0 Then
        '            MsgBox("Debe ingresar un Usuario/Password Válidos.", vbInformation, "Robin")

        '            Return False
        '        End If

        '        Return True
        '    Catch ex As Exception
        '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        '        Return False
        '    End Try
        'End Function

        Public Function Perfil_Obtener(ByVal pUsuarios As UsuariosE) As DataTable
            Dim UsuariosD As UsuariosD
            Dim dt As DataTable

            Try
                UsuariosD = New UsuariosD
                dt = New DataTable

                dt = UsuariosD.Perfil_Obtener(pUsuarios)

                UsuariosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function
    End Class
End Namespace