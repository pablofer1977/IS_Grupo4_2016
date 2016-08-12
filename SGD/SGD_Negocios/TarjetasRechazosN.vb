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
                    MsgBox("Debe Ingresar un Código de Banco", vbInformation, "Robin")

                    Return False
                End If

                If Verificar(eAccion.Agregar, pTarjetasRechazos) > 0 Then
                    MsgBox("Código de Banco ya Ingresado", vbInformation, "Robin")

                    Return False
                End If

                If IsNothing(pTarjetasRechazos.sCausaRechazo) Then
                    MsgBox("Debe Ingresar un Nombre de Causa de Rechazo", vbInformation, "Robin")

                    Return False
                End If

				If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Agregar, pTarjetasRechazos) > 0 Then
                        If MsgBox("Ya Existe una Causa de Rechazo OK." & vbCr & vbCr & "Desea Reemplazarla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then Return False
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Agregar(pTarjetasRechazos) Then
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

        Public Function Modificar(ByVal pTarjetasRechazos As TarjetasRechazosE) As Boolean

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la causa de rechazo
                If pTarjetasRechazos.nId = 0 Then
                    MsgBox("Debe Seleccionar una Causa de Rechazo de la Grilla", vbInformation, "Robin")

                    Return False
                End If

                If IsNothing(pTarjetasRechazos.sCodBanco) Then
                    MsgBox("Debe Ingresar un Código de Banco", vbInformation, "Robin")

                    Return False
                End If

                If Verificar(eAccion.Agregar, pTarjetasRechazos) > 0 Then
                    MsgBox("Código de Banco ya Ingresado", vbInformation, "Robin")

                    Return False
                End If

                If IsNothing(pTarjetasRechazos.sCausaRechazo) Then
                    MsgBox("Debe Ingresar un Nombre de Causa de Rechazo", vbInformation, "Robin")

                    Return False
                End If

				If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Modificar, pTarjetasRechazos) > 0 Then
                        If MsgBox("Ya Existe una Causa de Rechazo OK." & vbCr & vbCr & "Desea Reemplazarla?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then Return False
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Modificar(pTarjetasRechazos) Then
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

        Public Function Eliminar(ByVal pTarjetasRechazos As TarjetasRechazosE) As Boolean

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la causa de rechazo
                If pTarjetasRechazos.nId = 0 Then
                    MsgBox("Debe Seleccionar una Causa de Rechazo de la Grilla", vbInformation, "Robin")

                    Return False
                End If

                If FK_Verificar(pTarjetasRechazos) > 0 Then
                    MsgBox("La Causa de Rechazo Existe en Detalles de Presentaciones", vbInformation, "Robin")

                    Return False
                End If

				If pTarjetasRechazos.bCausaOK Then
                    If CausaOK_Verificar(eAccion.Eliminar, pTarjetasRechazos) > 0 Then
                        MsgBox("No Puede Dar de Baja una Causa de Rechazo OK", vbInformation, "Robin")

                        Return False
                    End If
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Eliminar(pTarjetasRechazos) Then
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

        Public Function Estado(ByVal pTarjetasRechazos As TarjetasRechazosE) As Boolean

            Try
                Dim TarjetasRechazosD As TarjetasRechazosD

                TarjetasRechazosD = New TarjetasRechazosD

                'valido los datos segun la campaña
                If pTarjetasRechazos.nId = 0 Then
                    MsgBox("Debe Seleccionar una Causa de Rechazo de la Grilla", vbInformation, "Robin")

                    Return False
                End If

                'realizo la actualizacion
                If TarjetasRechazosD.Estado(pTarjetasRechazos) Then
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

        Public Sub ExportarExcel(ByVal sNombreExcel As String, ByVal pTarjetasRechazos As TarjetasRechazosE)
            Dim TarjetasRechazosD As TarjetasRechazosD

            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                TarjetasRechazosD = New TarjetasRechazosD
                dt = New DataTable

                'obtengo los datos
                dt = TarjetasRechazosD.Listado(pTarjetasRechazos)

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

                TarjetasRechazosD = Nothing
                dt = Nothing

                MsgBox("Archivo Generado Correctamente", MsgBoxStyle.Information, "Robin")
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
            End Try

        End Sub
    End Class
End Namespace