Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class TarjetasRechazosN

        Public Function CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean, ByVal sId_Tarjeta As String) As DataTable
            Dim TarjetasRechazosD As TarjetasRechazosD
            Dim dt As DataTable

            Try
                TarjetasRechazosD = New TarjetasRechazosD
                dt = New DataTable

                dt = TarjetasRechazosD.CargarCombo(bTodos, bBlanco, sId_Tarjeta)

                TarjetasRechazosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal pTarjetasRechazos As TarjetasRechazosE) As DataTable
            Dim TarjetasRechazosD As TarjetasRechazosD
            Dim dt As DataTable

            Try
                TarjetasRechazosD = New TarjetasRechazosD
                dt = New DataTable

                dt = TarjetasRechazosD.Listado(pTarjetasRechazos)

                TarjetasRechazosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal pTarjetasRechazos As TarjetasRechazosE) As DataTable
            Dim TarjetasRechazosD As TarjetasRechazosD
            Dim dt As DataTable

            Try
                TarjetasRechazosD = New TarjetasRechazosD
                dt = New DataTable

                dt = TarjetasRechazosD.Obtener(pTarjetasRechazos)

                TarjetasRechazosD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal pTarjetasRechazos As TarjetasRechazosE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la causa de rechazo
                If IsNothing(pTarjetasRechazos.sCodBanco) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Código de Banco.")

                    Return dt
                End If

                If Verificar(eAccion.Agregar, pTarjetasRechazos) > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Código de Banco ya Ingresado.")

                    Return dt
                End If

                If IsNothing(pTarjetasRechazos.sCausaRechazo) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre de Causa de Rechazo.")

                    Return dt
                End If

                If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Agregar, pTarjetasRechazos) > 0 Then
                        If MsgBox("Ya Existe una Causa de Rechazo OK." & vbCr & vbCr & "Desea Reemplazarla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Ya Existe una Causa de Rechazo OK.")

                            Return dt
                        End If
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Agregar(pTarjetasRechazos) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se dió de Alta la Causa de Rechazo.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Modificar(ByVal pTarjetasRechazos As TarjetasRechazosE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la causa de rechazo
                If pTarjetasRechazos.nId = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Causa de Rechazo de la Grilla.")

                    Return dt
                End If

                If IsNothing(pTarjetasRechazos.sCodBanco) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Código de Banco.")

                    Return dt
                End If

                If Verificar(eAccion.Modificar, pTarjetasRechazos) > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Código de Banco ya Ingresado.")

                    Return dt
                End If

                If IsNothing(pTarjetasRechazos.sCausaRechazo) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre de Causa de Rechazo.")

                    Return dt
                End If

                If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Modificar, pTarjetasRechazos) > 0 Then
                        If MsgBox("Ya Existe una Causa de Rechazo OK." & vbCr & vbCr & "Desea Reemplazarla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Ya Existe una Causa de Rechazo OK.")

                            Return dt
                        End If
                    End If
                End If

                If Not pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.ActualizarEstado, pTarjetasRechazos) > 0 Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "No Puede Dar de Baja una Causa de Rechazo OK.")

                        Return dt
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Modificar(pTarjetasRechazos) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Modificaron los Datos de la Causa de Rechazo.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Estado(ByVal pTarjetasRechazos As TarjetasRechazosE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la campaña
                If pTarjetasRechazos.nId = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Causa de Rechazo de la Grilla.")

                    Return dt
                End If

                If pTarjetasRechazos.sEstado = "B" Then
                    If CausaOK_Verificar(eAccion.ActualizarEstado, pTarjetasRechazos) > 0 Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "No Puede Dar de Baja una Causa de Rechazo OK.")

                        Return dt
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Estado(pTarjetasRechazos) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "La Causa de Rechazo Fue Dada de Baja.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function Verificar(ByVal nAccion As eAccion, ByVal pTarjetasRechazos As TarjetasRechazosE) As Integer
            Dim TarjetasRechazosD As TarjetasRechazosD

            Dim nCant As Integer = 0

            Try
                TarjetasRechazosD = New TarjetasRechazosD

                nCant = TarjetasRechazosD.Verificar(nAccion, pTarjetasRechazos)

                TarjetasRechazosD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function CausaOK_Verificar(ByVal nAccion As eAccion, ByVal pTarjetasRechazos As TarjetasRechazosE) As Integer
            Dim TarjetasRechazosD As TarjetasRechazosD

            Dim nCant As Integer = 0

            Try
                TarjetasRechazosD = New TarjetasRechazosD

                nCant = TarjetasRechazosD.CausaOK_Verificar(nAccion, pTarjetasRechazos)

                TarjetasRechazosD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function FK_Verificar(ByVal pTarjetasRechazos As TarjetasRechazosE) As Integer
            Dim TarjetasRechazosD As TarjetasRechazosD

            Dim nCant As Integer = 0

            Try
                TarjetasRechazosD = New TarjetasRechazosD

                nCant = TarjetasRechazosD.FK_Verificar(pTarjetasRechazos)

                TarjetasRechazosD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function
    End Class
End Namespace