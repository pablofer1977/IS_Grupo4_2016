Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class CampaniasN

        Public Function CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean, ByVal sEstado As String) As DataTable
            Dim CampaniasD As CampaniasD
            Dim dt As DataTable

            Try
                CampaniasD = New CampaniasD
                dt = New DataTable

                dt = CampaniasD.CargarCombo(bTodos, bBlanco, sEstado)

                CampaniasD = Nothing

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

        Public Function Listado(ByVal pCampanias As CampaniasE) As DataTable
            Dim CampaniasD As CampaniasD
            Dim dt As DataTable

            Try
                CampaniasD = New CampaniasD
                dt = New DataTable

                dt = CampaniasD.Listado(pCampanias)

                CampaniasD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal pCampanias As CampaniasE) As DataTable
            Dim CampaniasD As CampaniasD
            Dim dt As DataTable

            Try
                CampaniasD = New CampaniasD
                dt = New DataTable

                dt = CampaniasD.Obtener(pCampanias)

                CampaniasD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal pCampanias As CampaniasE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim CampaniasD As CampaniasD

                CampaniasD = New CampaniasD

                'valido los datos segun la campaña
                If IsNothing(pCampanias.sCampania) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una Campaña.")

                    Return dt
                End If

                If Verificar(eAccion.Agregar, pCampanias) > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Campaña ya ingresada.")

                    Return dt
                End If

                'realizo la actualizacion
                If CampaniasD.Agregar(pCampanias) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se dió de Alta la Campaña.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Modificar(ByVal pCampanias As CampaniasE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim CampaniasD As CampaniasD

                CampaniasD = New CampaniasD

                'valido los datos segun la campaña
                If pCampanias.nId = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Campaña de la Grilla.")

                    Return dt
                End If

                If IsNothing(pCampanias.sCampania) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una Campaña.")

                    Return dt
                End If

                If Verificar(eAccion.Modificar, pCampanias) > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Campaña ya ingresada.")

                    Return dt
                End If

                'realizo la actualizacion
                If CampaniasD.Modificar(pCampanias) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se modificaron los datos de la Campaña.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Estado(ByVal pCampanias As CampaniasE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim CampaniasD As CampaniasD

                CampaniasD = New CampaniasD

                'valido los datos segun la campaña
                If pCampanias.nId = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Campaña de la Grilla.")

                    Return dt
                End If

                'realizo la actualizacion
                If CampaniasD.Estado(pCampanias) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "La Campaña Fue Dada de Baja.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function Verificar(ByVal nAccion As eAccion, ByVal pCampanias As CampaniasE) As Integer
            Dim CampaniasD As CampaniasD

            Dim nCant As Integer = 0

            Try
                CampaniasD = New CampaniasD

                nCant = CampaniasD.Verificar(nAccion, pCampanias)

                CampaniasD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Private Function FK_Verificar(ByVal pCampanias As CampaniasE) As Integer
            Dim CampaniasD As CampaniasD

            Dim nCant As Integer = 0

            Try
                CampaniasD = New CampaniasD

                nCant = CampaniasD.FK_Verificar(pCampanias)

                CampaniasD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function
    End Class
End Namespace
