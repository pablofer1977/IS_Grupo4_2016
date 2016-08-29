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

        Public Function Agregar(ByVal pTarjetasRechazos As TarjetasRechazosE) As Boolean

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la causa de rechazo
                If IsNothing(pTarjetasRechazos.sCodBanco) Then
                    MsgBox("Debe Ingresar un Código de Banco.", vbInformation, "Robin")

                    Return False
                End If

                If Verificar(eAccion.Agregar, pTarjetasRechazos) > 0 Then
                    MsgBox("Código de Banco ya Ingresado.", vbInformation, "Robin")

                    Return False
                End If

                If IsNothing(pTarjetasRechazos.sCausaRechazo) Then
                    MsgBox("Debe Ingresar un Nombre de Causa de Rechazo.", vbInformation, "Robin")

                    Return False
                End If

                If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Agregar, pTarjetasRechazos) > 0 Then
                        If MsgBox("Ya Existe una Causa de Rechazo OK." & vbCr & vbCr & "Desea Reemplazarla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then Return False
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Agregar(pTarjetasRechazos) Then
                    MsgBox("Se dió de Alta la Causa de Rechazo.", vbInformation, "Robin")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
            End Try
        End Function

        Public Function Modificar(ByVal pTarjetasRechazos As TarjetasRechazosE) As Boolean

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la causa de rechazo
                If pTarjetasRechazos.nId = 0 Then
                    MsgBox("Debe Seleccionar una Causa de Rechazo de la Grilla.", vbInformation, "Robin")

                    Return False
                End If

                If IsNothing(pTarjetasRechazos.sCodBanco) Then
                    MsgBox("Debe Ingresar un Código de Banco.", vbInformation, "Robin")

                    Return False
                End If

                If Verificar(eAccion.Modificar, pTarjetasRechazos) > 0 Then
                    MsgBox("Código de Banco ya Ingresado.", vbInformation, "Robin")

                    Return False
                End If

                If IsNothing(pTarjetasRechazos.sCausaRechazo) Then
                    MsgBox("Debe Ingresar un Nombre de Causa de Rechazo.", vbInformation, "Robin")

                    Return False
                End If

                If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Modificar, pTarjetasRechazos) > 0 Then
                        If MsgBox("Ya Existe una Causa de Rechazo OK." & vbCr & vbCr & "Desea Reemplazarla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then Return False
                    End If
                End If

                If Not pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.ActualizarEstado, pTarjetasRechazos) > 0 Then
                        MsgBox("No Puede Dar de Baja una Causa de Rechazo OK.", vbInformation, "Robin")

                        Return False
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Modificar(pTarjetasRechazos) Then
                    MsgBox("Se Modificaron los Datos de la Causa de Rechazo.", vbInformation, "Robin")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
            End Try
        End Function

        Public Function Eliminar(ByVal pTarjetasRechazos As TarjetasRechazosE) As Boolean

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la causa de rechazo
                If pTarjetasRechazos.nId = 0 Then
                    MsgBox("Debe Seleccionar una Causa de Rechazo de la Grilla.", vbInformation, "Robin")

                    Return False
                End If

                If FK_Verificar(pTarjetasRechazos) > 0 Then
                    MsgBox("La Causa de Rechazo Existe en Detalles de Presentaciones.", vbInformation, "Robin")

                    Return False
                End If

                If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Eliminar, pTarjetasRechazos) > 0 Then
                        MsgBox("No Puede Dar de Baja una Causa de Rechazo OK.", vbInformation, "Robin")

                        Return False
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Eliminar(pTarjetasRechazos) Then
                    MsgBox("Acción Realizada Correctamente.", vbInformation, "Robin")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
            End Try
        End Function

        Public Function Estado(ByVal pTarjetasRechazos As TarjetasRechazosE) As Boolean

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la campaña
                If pTarjetasRechazos.nId = 0 Then
                    MsgBox("Debe Seleccionar una Causa de Rechazo de la Grilla.", vbInformation, "Robin")

                    Return False
                End If

                If pTarjetasRechazos.sEstado = "B" Then
                    If CausaOK_Verificar(eAccion.ActualizarEstado, pTarjetasRechazos) > 0 Then
                        MsgBox("No Puede Dar de Baja una Causa de Rechazo OK.", vbInformation, "Robin")

                        Return False
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Estado(pTarjetasRechazos) Then
                    MsgBox("La Causa de Rechazo Fue Dada de Baja.", vbInformation, "Robin")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
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