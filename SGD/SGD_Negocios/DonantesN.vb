Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class DonantesN

        Public Function TiposDonantes_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim DonantesD As DonantesD
            Dim dt As DataTable

            Try
                DonantesD = New DonantesD
                dt = New DataTable

                dt = DonantesD.TiposDonantes_CargarCombo(bTodos, bBlanco)

                DonantesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Provincias_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim GeneralD As GeneralD
            Dim dt As DataTable

            Try
                GeneralD = New GeneralD
                dt = New DataTable

                dt = GeneralD.Provincias_CargarCombo(bTodos, bBlanco)

                GeneralD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal pDonantes As DonantesE, pDonaciones As DonacionesE) As DataTable
            Dim DonantesD As DonantesD
            Dim dt As DataTable

            Try
                DonantesD = New DonantesD
                dt = New DataTable

                dt = DonantesD.Listado(pDonantes, pDonaciones)

                DonantesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Consulta_Listado(ByVal pDonantes As DonantesE) As DataTable
            Dim DonantesD As DonantesD
            Dim dt As DataTable

            Try
                DonantesD = New DonantesD
                dt = New DataTable

                dt = DonantesD.Consulta_Listado(pDonantes)

                DonantesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal pDonantes As DonantesE) As DataTable
            Dim DonantesD As DonantesD
            Dim dt As DataTable

            Try
                DonantesD = New DonantesD
                dt = New DataTable

                dt = DonantesD.Obtener(pDonantes)

                DonantesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal pDonantes As DonantesE) As DataTable
            Dim dt As New DataTable
            Dim nId_Donante As Integer = 0

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))
            dt.Columns.Add("Id_Donante", Type.GetType("System.Int32"))

            Try
                Dim DonantesD As DonantesD

                DonantesD = New DonantesD

                'valido los datos
                If pDonantes.nId_TipoDonante = eDonantes_Tipos.Fisico Then
                    If IsNothing(pDonantes.sNombre) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre.", 0)

                        Return dt
                    End If

                    If IsNothing(pDonantes.sApellido) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Apellido.", 0)

                        Return dt
                    End If

                    If Not IsNothing(pDonantes.sDNI) Then
                        If DNI_Verificar(eAccion.Agregar, pDonantes) > 0 Then
                            If MsgBox("Existen Donantes con el Mismo Nro. de Documento." & vbCr & vbCr & "Desea Continuar con el Alta del Donante?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                                dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donantes con el Mismo Nro. de Documento.", 0)

                                Return dt
                            End If
                        End If
                    End If

                ElseIf pDonantes.nId_TipoDonante = eDonantes_Tipos.Juridico Then
                    If IsNothing(pDonantes.sRazon_Social) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una razón Social.", 0)

                        Return dt
                    End If
                End If

                If Not IsNothing(pDonantes.sCUIL_CUIT) Then
                    If CUIT_CUIL_Verificar(eAccion.Agregar, pDonantes) > 0 Then
                        If MsgBox("Existen Donantes con el Mismo Nro. de CUIL/CUIT." & vbCr & vbCr & "Desea Continuar con el Alta del Donante?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donantes con el Mismo Nro. de CUIL/CUIT.", 0)

                            Return dt
                        End If
                    End If
                End If

                If Not IsNothing(pDonantes.sEMail) Then
                    If Not EMail_Formato_Validar(pDonantes) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Correo Válido.", 0)

                        Return dt
                    End If
                End If

                'realizo la actualizacion
                nId_Donante = DonantesD.Agregar(pDonantes)

                If nId_Donante > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Dió de Alta al Donante Nro. " & nId_Donante.ToString & ".", nId_Donante)
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message, 0)

                Return dt
            End Try
        End Function

        Public Function Modificar(ByVal pDonantes As DonantesE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim DonantesD As DonantesD

                DonantesD = New DonantesD

                'valido los datos
                If pDonantes.nId_TipoDonante = eDonantes_Tipos.Fisico Then
                    If IsNothing(pDonantes.sNombre) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre.")

                        Return dt
                    End If

                    If IsNothing(pDonantes.sApellido) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Apellido.")

                        Return dt
                    End If

                    If Not IsNothing(pDonantes.sDNI) Then
                        If DNI_Verificar(eAccion.Modificar, pDonantes) > 0 Then
                            If MsgBox("Existen Donantes con el Mismo Nro. de Documento." & vbCr & vbCr & "Desea Continuar con el Alta del Donante?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                                dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donantes con el Mismo Nro. de Documento.")

                                Return dt
                            End If
                        End If
                    End If

                ElseIf pDonantes.nId_TipoDonante = eDonantes_Tipos.Juridico Then
                    If IsNothing(pDonantes.sRazon_Social) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una razón Social.")

                        Return dt
                    End If
                End If

                If Not IsNothing(pDonantes.sCUIL_CUIT) Then
                    If CUIT_CUIL_Verificar(eAccion.Modificar, pDonantes) > 0 Then
                        If MsgBox("Existen Donantes con el Mismo Nro. de CUIL/CUIT." & vbCr & vbCr & "Desea Continuar con el Alta del Donante?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donantes con el Mismo Nro. de CUIL/CUIT.")

                            Return dt
                        End If
                    End If
                End If

                If Not IsNothing(pDonantes.sEMail) Then
                    If Not EMail_Formato_Validar(pDonantes) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Correo Válido.")

                        Return dt
                    End If
                End If

                'realizo la actualizacion
                If DonantesD.Modificar(pDonantes) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Modificaron los Datos del Donante.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function DNI_Verificar(ByVal nAccion As eAccion, ByVal pDonantes As DonantesE) As Integer
            Dim DonantesD As DonantesD

            Dim nCant As Integer = 0

            Try
                DonantesD = New DonantesD

                nCant = DonantesD.DNI_Verificar(nAccion, pDonantes)

                DonantesD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function CUIT_CUIL_Verificar(ByVal nAccion As eAccion, ByVal pDonantes As DonantesE) As Integer
            Dim DonantesD As DonantesD

            Dim nCant As Integer = 0

            Try
                DonantesD = New DonantesD

                nCant = DonantesD.CUIT_CUIL_Verificar(nAccion, pDonantes)

                DonantesD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function EMail_Formato_Validar(ByVal pDonantes As DonantesE) As Integer
            Dim DonantesD As DonantesD

            Dim bResultado As Boolean = False

            Try
                DonantesD = New DonantesD

                bResultado = DonantesD.EMail_Formato_Validar(pDonantes)

                DonantesD = Nothing

                Return bResultado
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function
    End Class
End Namespace