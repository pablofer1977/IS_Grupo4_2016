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
                    MsgBox("El Nombre de la Campaña es Obligatoria", vbInformation, "Robin")

                    Return False
                End If

                If Verificar(eAccion.Agregar, pCampanias) > 0 Then
                    MsgBox("El Nombre de la Campaña ya Existe", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Agregar(pCampanias) Then
                    MsgBox("Acción Realizada Correctamente", vbInformation, "Robin")

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
                    MsgBox("Debe Seleccionar una Campaña de la Grilla", vbInformation, "SALES")

                    Return False
                End If

                If IsNothing(pCampanias.sCampania) Then
                    MsgBox("El Nombre de la Campaña es Obligatoria", vbInformation, "SALES")

                    Return False
                End If

                If Verificar(eAccion.Modificar, pCampanias) > 0 Then
                    MsgBox("El Nombre de la Campaña ya Existe", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Modificar(pCampanias) Then
                    MsgBox("Acción Realizada Correctamente", vbInformation, "Robin")

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
                    MsgBox("Debe Seleccionar una Campaña de la Grilla", vbInformation, "SALES")

                    Return False
                End If

                If FK_Verificar(pCampanias) > 0 Then
                    MsgBox("La Campaña Existe en Donaciones", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Eliminar(pCampanias) Then
                    MsgBox("Acción Realizada Correctamente", vbInformation, "Robin")

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
                    MsgBox("Debe Seleccionar una Campaña de la Grilla", vbInformation, "SALES")

                    Return False
                End If

                'realizo la actualizacion
                If CampaniasD.Estado(pCampanias) Then
                    MsgBox("Acción Realizada Correctamente", vbInformation, "Robin")

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

        Public Sub ExportarExcel(ByVal sNombreExcel As String, ByVal pCampanias As CampaniasE)
            Dim CampaniasD As CampaniasD

            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                CampaniasD = New CampaniasD
                dt = New DataTable

                'obtengo los datos
                dt = CampaniasD.Listado(pCampanias)

                'Creamos un objeto Excel
                Dim oExcel As Excel.Application

                'Creamos un objeto WorkBook 
                Dim oLibroExcel As Excel.Workbook

                'Creamos un objeto WorkSheet
                Dim oHojaExcel As Excel.Worksheet

                'Iniciamos una instancia a Excel
                oExcel = New Excel.Application

                'sacamos todos los alertas
                oExcel.DisplayAlerts = False

                'Creamos una instancia del Workbooks de Excel
                'Creamos una instancia de la primera hoja de trabajo de Excel
                oLibroExcel = oExcel.Workbooks.Add()
                oHojaExcel = oLibroExcel.Worksheets(1)
                oHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible

                'nombre a la hoja
                oHojaExcel.Name = "Campañas"

                oHojaExcel.Activate()

                'achico el ancho de la primer columna
                oHojaExcel.Columns("A:A").ColumnWidth = 6
                oHojaExcel.Columns("B:B").ColumnWidth = 50
                oHojaExcel.Columns("C:C").ColumnWidth = 250
                oHojaExcel.Columns("D:D").ColumnWidth = 10
                oHojaExcel.Columns("E:E").ColumnWidth = 11
                oHojaExcel.Columns("F:F").ColumnWidth = 11

                oHojaExcel.Columns("A:A").HorizontalAlignment = 3
                oHojaExcel.Columns("D:D").HorizontalAlignment = 3
                oHojaExcel.Columns("E:E").HorizontalAlignment = 3
                oHojaExcel.Columns("F:F").HorizontalAlignment = 3

                'Crear el encabezado de nuestro informe
                oHojaExcel.Range("A1:F1").Merge()
                oHojaExcel.Range("A1:F1").Value = "Campañas"
                oHojaExcel.Range("A1:F1").Font.Bold = True
                oHojaExcel.Range("A1:F1").Font.Italic = True
                oHojaExcel.Range("A1:F1").Font.Size = 13

                Dim oCelda As Excel.Range

                oCelda = oHojaExcel.Range("A2", Type.Missing)
                oCelda.Value = "Id"
                oCelda.EntireColumn.NumberFormat = "#0"

                oCelda = oHojaExcel.Range("B2", Type.Missing)
                oCelda.Value = "Campaña"

                oCelda = oHojaExcel.Range("C2", Type.Missing)
                oCelda.Value = "Descripción"

                oCelda = oHojaExcel.Range("D2", Type.Missing)
                oCelda.Value = "Estado"

                oCelda = oHojaExcel.Range("E2", Type.Missing)
                oCelda.Value = "Fecha Alta"
                oCelda.EntireColumn.NumberFormat = "dd/MM/yyyy"

                oCelda = oHojaExcel.Range("F2", Type.Missing)
                oCelda.Value = "Fecha Baja"
                oCelda.EntireColumn.NumberFormat = "dd/MM/yyyy"

                oHojaExcel.Range("A1:F2").Font.Bold = True

                'color interior
                oHojaExcel.Range("A1:F2").Interior.Color = RGB(200, 200, 200)

                'bordes
                oHojaExcel.Range("A1:F2").Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                oHojaExcel.Range("A1:F2").Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
                oHojaExcel.Range("A1:F2").BorderAround(, Excel.XlBorderWeight.xlMedium)

                If dt.Rows.Count > 0 Then
                    'copio los datos al excel
                    Dim sRange As String = "A3:F" & (dt.Rows.Count - 1 + 3).ToString
                    Dim oData(dt.Rows.Count, dt.Columns.Count - 1) As Object

                    For nCol = 0 To dt.Columns.Count - 1
                        For nRow = 0 To dt.Rows.Count - 1
                            oData(nRow, nCol) = dt.Rows(nRow).ItemArray(nCol)
                        Next
                    Next

                    oHojaExcel.Range(sRange, Type.Missing).Value2 = oData
                End If

                oLibroExcel.SaveAs(Filename:=sNombreExcel)

                'cierro el excel
                If Not oExcel Is Nothing Then
                    oExcel.Quit()
                    oExcel = Nothing
                End If

                CampaniasD = Nothing
                dt = Nothing

                MsgBox("Archivo Generado Correctamente", MsgBoxStyle.Information, "Robin")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
            End Try

        End Sub
    End Class
End Namespace
