Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class TarjetasN

        Public Function CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean, ByVal nId_TipoPresentacion As Integer) As DataTable
            Dim TarjetasD As TarjetasD
            Dim dt As DataTable

            Try
                TarjetasD = New TarjetasD
                dt = New DataTable

                dt = TarjetasD.CargarCombo(bTodos, bBlanco, nId_TipoPresentacion)

                TarjetasD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal pTarjetas As TarjetasE) As DataTable
            Dim TarjetasD As TarjetasD
            Dim dt As DataTable

            Try
                TarjetasD = New TarjetasD
                dt = New DataTable

                dt = TarjetasD.Listado(pTarjetas)

                TarjetasD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal pTarjetas As TarjetasE) As DataTable
            Dim TarjetasD As TarjetasD
            Dim dt As DataTable

            Try
                TarjetasD = New TarjetasD
                dt = New DataTable

                dt = TarjetasD.Obtener(pTarjetas)

                TarjetasD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Modificar(ByVal pTarjetas As TarjetasE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim TarjetasD As TarjetasD

                TarjetasD = New TarjetasD

                'valido los datos segun la tarjeta
                If IsNothing(pTarjetas.sId) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Tarjeta o CBU de la Grilla")

                    Return dt
                End If

                If IsNothing(pTarjetas.sTarjeta) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre de Tarjeta o CBU")

                    Return dt
                End If

                If Verificar(eAccion.Modificar, pTarjetas) > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Tarjeta o CBU ya Ingresado", vbInformation)

                    Return dt
                End If

                If IsNothing(pTarjetas.sTarjeta) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nombre de Archivo", vbInformation)

                    Return dt
                End If

                If IsNothing(pTarjetas.sTarjeta) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de Comercio", vbInformation)

                    Return dt
                End If

                'realizo la actualizacion
                If TarjetasD.Modificar(pTarjetas) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Modificaron los Datos de la Tarjeta o CBU")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function Verificar(ByVal nAccion As eAccion, ByVal pTarjetas As TarjetasE) As Integer
            Dim TarjetasD As TarjetasD

            Dim nCant As Integer = 0

            Try
                TarjetasD = New TarjetasD

                nCant = TarjetasD.Verificar(nAccion, pTarjetas)

                TarjetasD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function FK_Verificar(ByVal pTarjetas As TarjetasE) As Integer
            Dim TarjetasD As TarjetasD

            Dim nCant As Integer = 0

            Try
                TarjetasD = New TarjetasD

                nCant = TarjetasD.FK_Verificar(pTarjetas)

                TarjetasD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function
    End Class
End Namespace