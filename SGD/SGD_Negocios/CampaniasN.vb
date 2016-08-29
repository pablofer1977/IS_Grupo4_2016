Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class CampaniasN

        Public Function CargarCombo(ByVal sEstado As String, ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim CampaniasD As CampaniasD
            Dim dt As DataTable

            Try
                CampaniasD = New CampaniasD
                dt = New DataTable

                dt = CampaniasD.CargarCombo(sEstado, bTodos, bBlanco)

                CampaniasD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Estado_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim GeneralD As GeneralD
            Dim dt As DataTable

            Try
                GeneralD = New GeneralD
                dt = New DataTable

                dt = GeneralD.Estado_CargarCombo(bTodos, bBlanco)

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

        Public Function Agregar(ByVal pCampanias As CampaniasE) As Boolean

            Try
                Dim CampaniasD As CampaniasD

                CampaniasD = New CampaniasD

                'valido los datos segun la campaña
                If IsNothing(pCampanias.sCampania) Then
                    MsgBox("Debe Ingresar una Campaña.", vbInformation, "Robin")

                    Return False
                End If

                If Verificar(eAccion.Agregar, pCampanias) > 0 Then
                    MsgBox("Campaña ya ingresada.", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Agregar(pCampanias) Then
                    MsgBox("Se dió de Alta la Campaña.", vbInformation, "Robin")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
            End Try
        End Function

        Public Function Modificar(ByVal pCampanias As CampaniasE) As Boolean

            Try
                Dim CampaniasD As CampaniasD

                CampaniasD = New CampaniasD

                'valido los datos segun la campaña
                If pCampanias.nId = 0 Then
                    MsgBox("Debe Seleccionar una Campaña de la Grilla.", vbInformation, "Robin")

                    Return False
                End If

                If IsNothing(pCampanias.sCampania) Then
                    MsgBox("Debe Ingresar una Campaña.", vbInformation, "Robin")

                    Return False
                End If

                If Verificar(eAccion.Modificar, pCampanias) > 0 Then
                    MsgBox("Campaña ya ingresada.", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Modificar(pCampanias) Then
                    MsgBox("Se modificaron los datos de la Campaña.", vbInformation, "Robin")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
            End Try
        End Function

        Public Function Eliminar(ByVal pCampanias As CampaniasE) As Boolean

            Try
                Dim CampaniasD As CampaniasD

                CampaniasD = New CampaniasD

                'valido los datos segun la campaña
                If pCampanias.nId = 0 Then
                    MsgBox("Debe Seleccionar una Campaña de la Grilla.", vbInformation, "Robin")

                    Return False
                End If

                If FK_Verificar(pCampanias) > 0 Then
                    MsgBox("La Campaña Existe en Donaciones.", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Eliminar(pCampanias) Then
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

        Public Function Estado(ByVal pCampanias As CampaniasE) As Boolean

            Try
                Dim CampaniasD As CampaniasD

                CampaniasD = New CampaniasD

                'valido los datos segun la campaña
                If pCampanias.nId = 0 Then
                    MsgBox("Debe Seleccionar una Campaña de la Grilla.", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Estado(pCampanias) Then
                    MsgBox("La Campaña Fue Dada de Baja.", vbInformation, "Robin")

                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
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
