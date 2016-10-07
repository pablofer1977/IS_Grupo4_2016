Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class DonantesImportacionN

        Public Function Listado() As DataTable
            Dim DonantesImportacionD As DonantesImportacionD
            Dim dt As DataTable

            Try
                DonantesImportacionD = New DonantesImportacionD
                dt = New DataTable

                dt = DonantesImportacionD.Listado()

                DonantesImportacionD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Validaciones_Listado(nId As Integer) As DataTable
            Dim DonantesImportacionD As DonantesImportacionD
            Dim dt As DataTable

            Try
                DonantesImportacionD = New DonantesImportacionD
                dt = New DataTable

                dt = DonantesImportacionD.Validaciones_Listado(nId)

                DonantesImportacionD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Importar(ByVal sNombreExcel As String) As Boolean
            Dim DonantesImportacionD As DonantesImportacionD

            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                DonantesImportacionD = New DonantesImportacionD
                dt = New DataTable

                'importo el excel
                Excel_Importar(sNombreExcel)

                'valido el excel
                Excel_Validar()

                DonantesImportacionD = Nothing
                dt = Nothing

                MsgBox("Archivo Importado Correctamente", MsgBoxStyle.Information, "Robin")

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try

        End Function

        Public Function Grabar(ByVal dt As DataTable) As Boolean
            Dim DonantesImportacionD As DonantesImportacionD

            Try
                DonantesImportacionD = New DonantesImportacionD

                DonantesImportacionD.Excel_Validaciones_Grabar(dt)

                DonantesImportacionD = Nothing

                MsgBox("Proceso de Importación de Donantes y Donaciones Realizado OK", MsgBoxStyle.Information, "Robin")

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try

        End Function

        Public Function Excel_Importar(ByVal sNombreExcel As String) As Boolean
            Dim DonantesImportacionD As DonantesImportacionD
            Dim DonantesImportacionE As DonantesImportacionE

            Dim dt As DataTable
            Dim i As Integer = 0

            DonantesImportacionD = New DonantesImportacionD
            dt = New DataTable

            'Abrimos un objeto Excel
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
            oLibroExcel = oExcel.Workbooks.Open(sNombreExcel)
            oHojaExcel = oLibroExcel.Worksheets(1)
            oHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible

            oHojaExcel.Activate()

            Try
                'armo el dt
                dt.Columns.Add("TipoDonante", System.Type.GetType("System.String"))
                dt.Columns.Add("Apellido", System.Type.GetType("System.String"))
                dt.Columns.Add("Nombre", System.Type.GetType("System.String"))
                dt.Columns.Add("Razon_Social", System.Type.GetType("System.String"))
                dt.Columns.Add("Direccion", System.Type.GetType("System.String"))
                dt.Columns.Add("Localidad", System.Type.GetType("System.String"))
                dt.Columns.Add("CP", System.Type.GetType("System.String"))
                dt.Columns.Add("Provincia", System.Type.GetType("System.String"))
                dt.Columns.Add("DNI", System.Type.GetType("System.String"))
                dt.Columns.Add("CUIL_CUIT", System.Type.GetType("System.String"))
                dt.Columns.Add("TE_Linea", System.Type.GetType("System.String"))
                dt.Columns.Add("TE_Celular", System.Type.GetType("System.String"))
                dt.Columns.Add("TE_Laboral", System.Type.GetType("System.String"))
                dt.Columns.Add("EMail", System.Type.GetType("System.String"))
                dt.Columns.Add("TipoDonacion", System.Type.GetType("System.String"))
                dt.Columns.Add("Tarjeta", System.Type.GetType("System.String"))
                dt.Columns.Add("NroTarjeta", System.Type.GetType("System.String"))
                dt.Columns.Add("Banco", System.Type.GetType("System.String"))
                dt.Columns.Add("Vto", System.Type.GetType("System.String"))
                dt.Columns.Add("CBU", System.Type.GetType("System.String"))
                dt.Columns.Add("Monto", System.Type.GetType("System.String"))
                dt.Columns.Add("Tiempo", System.Type.GetType("System.String"))
                dt.Columns.Add("Campania", System.Type.GetType("System.String"))

                'recorro el excel
                i = 2

                Do While True
                    DonantesImportacionE = New DonantesImportacionE

                    'obtengo el tipo de donante
                    If Trim(oHojaExcel.Range("A" & i).Value) <> "" Then DonantesImportacionE.sTipoDonante = Trim(oHojaExcel.Range("A" & i).Value)

                    'si no hay mas datos, salgo
                    If IsNothing(DonantesImportacionE.sTipoDonante) Then Exit Do

                    'cargo los datos del excel
                    If Trim(oHojaExcel.Range("B" & i).Value) <> "" Then DonantesImportacionE.sNombre = Trim(oHojaExcel.Range("B" & i).Value)
                    If Trim(oHojaExcel.Range("C" & i).Value) <> "" Then DonantesImportacionE.sApellido = Trim(oHojaExcel.Range("C" & i).Value)
                    If Trim(oHojaExcel.Range("D" & i).Value) <> "" Then DonantesImportacionE.sRazon_Social = Trim(oHojaExcel.Range("D" & i).Value)

                    If Trim(oHojaExcel.Range("E" & i).Value) <> "" Then DonantesImportacionE.sDireccion = Trim(oHojaExcel.Range("E" & i).Value)
                    If Trim(oHojaExcel.Range("F" & i).Value) <> "" Then DonantesImportacionE.sLocalidad = Trim(oHojaExcel.Range("F" & i).Value)
                    If Trim(oHojaExcel.Range("G" & i).Value) <> "" Then DonantesImportacionE.sCP = Trim(oHojaExcel.Range("g" & i).Value)
                    If Trim(oHojaExcel.Range("H" & i).Value) <> "" Then DonantesImportacionE.sProvincia = Trim(oHojaExcel.Range("H" & i).Value)
                    If Trim(oHojaExcel.Range("I" & i).Value) <> "" Then DonantesImportacionE.sDNI = Trim(oHojaExcel.Range("I" & i).Value)
                    If Trim(oHojaExcel.Range("J" & i).Value) <> "" Then DonantesImportacionE.sCUIL_CUIT = Trim(oHojaExcel.Range("J" & i).Value)

                    If Trim(oHojaExcel.Range("K" & i).Value) <> "" Then DonantesImportacionE.sTE_Linea = Trim(oHojaExcel.Range("K" & i).Value)
                    If Trim(oHojaExcel.Range("L" & i).Value) <> "" Then DonantesImportacionE.sTE_Celular = Trim(oHojaExcel.Range("L" & i).Value)
                    If Trim(oHojaExcel.Range("M" & i).Value) <> "" Then DonantesImportacionE.sTE_Laboral = Trim(oHojaExcel.Range("M" & i).Value)

                    If Trim(oHojaExcel.Range("N" & i).Value) <> "" Then DonantesImportacionE.sEMail = Trim(oHojaExcel.Range("N" & i).Value)

                    If Trim(oHojaExcel.Range("O" & i).Value) <> "" Then DonantesImportacionE.sTipoDonacion = Trim(oHojaExcel.Range("O" & i).Value)

                    If Trim(oHojaExcel.Range("P" & i).Value) <> "" Then DonantesImportacionE.sTarjeta = Trim(oHojaExcel.Range("P" & i).Value)
                    If Trim(oHojaExcel.Range("Q" & i).Value) <> "" Then DonantesImportacionE.sNroTarjeta = Trim(oHojaExcel.Range("Q" & i).Value)
                    If Trim(oHojaExcel.Range("R" & i).Value) <> "" Then DonantesImportacionE.sBanco = Trim(oHojaExcel.Range("R" & i).Value)
                    If Trim(oHojaExcel.Range("S" & i).Value) <> "" Then DonantesImportacionE.sVto = Trim(oHojaExcel.Range("S" & i).Value)

                    If Trim(oHojaExcel.Range("T" & i).Value) <> "" Then DonantesImportacionE.sCBU = Trim(oHojaExcel.Range("T" & i).Value)

                    If Trim(oHojaExcel.Range("U" & i).Value) <> "" Then DonantesImportacionE.sMonto = Trim(oHojaExcel.Range("U" & i).Value)
                    If Trim(oHojaExcel.Range("V" & i).Value) <> "" Then DonantesImportacionE.sTiempo = Trim(oHojaExcel.Range("V" & i).Value)
                    If Trim(oHojaExcel.Range("W" & i).Value) <> "" Then DonantesImportacionE.sCampania = Trim(oHojaExcel.Range("W" & i).Value)

                    'por si trunca
                    If Not IsNothing(DonantesImportacionE.sTipoDonante) Then DonantesImportacionE.sTipoDonante = Mid(DonantesImportacionE.sTipoDonante, 1, 10)
                    If Not IsNothing(DonantesImportacionE.sNombre) Then DonantesImportacionE.sNombre = Mid(DonantesImportacionE.sNombre, 1, 50)
                    If Not IsNothing(DonantesImportacionE.sApellido) Then DonantesImportacionE.sApellido = Mid(DonantesImportacionE.sApellido, 1, 50)
                    If Not IsNothing(DonantesImportacionE.sRazon_Social) Then DonantesImportacionE.sRazon_Social = Mid(DonantesImportacionE.sRazon_Social, 1, 100)
                    If Not IsNothing(DonantesImportacionE.sDireccion) Then DonantesImportacionE.sDireccion = Mid(DonantesImportacionE.sDireccion, 1, 100)
                    If Not IsNothing(DonantesImportacionE.sLocalidad) Then DonantesImportacionE.sLocalidad = Mid(DonantesImportacionE.sLocalidad, 1, 50)
                    If Not IsNothing(DonantesImportacionE.sCP) Then DonantesImportacionE.sCP = Mid(DonantesImportacionE.sCP, 1, 10)
                    If Not IsNothing(DonantesImportacionE.sProvincia) Then DonantesImportacionE.sProvincia = Mid(DonantesImportacionE.sProvincia, 1, 20)
                    If Not IsNothing(DonantesImportacionE.sDNI) Then DonantesImportacionE.sDNI = Mid(DonantesImportacionE.sDNI, 1, 8)
                    If Not IsNothing(DonantesImportacionE.sCUIL_CUIT) Then DonantesImportacionE.sCUIL_CUIT = Mid(DonantesImportacionE.sCUIL_CUIT, 1, 11)
                    If Not IsNothing(DonantesImportacionE.sTE_Linea) Then DonantesImportacionE.sTE_Linea = Mid(DonantesImportacionE.sTE_Linea, 1, 15)
                    If Not IsNothing(DonantesImportacionE.sTE_Celular) Then DonantesImportacionE.sTE_Celular = Mid(DonantesImportacionE.sTE_Celular, 1, 15)
                    If Not IsNothing(DonantesImportacionE.sTE_Laboral) Then DonantesImportacionE.sTE_Laboral = Mid(DonantesImportacionE.sTE_Laboral, 1, 15)
                    If Not IsNothing(DonantesImportacionE.sEMail) Then DonantesImportacionE.sEMail = Mid(DonantesImportacionE.sEMail, 1, 150)
                    If Not IsNothing(DonantesImportacionE.sTipoDonacion) Then DonantesImportacionE.sTipoDonacion = Mid(DonantesImportacionE.sTipoDonacion, 1, 10)
                    If Not IsNothing(DonantesImportacionE.sTarjeta) Then DonantesImportacionE.sTarjeta = Mid(DonantesImportacionE.sTarjeta, 1, 30)
                    If Not IsNothing(DonantesImportacionE.sNroTarjeta) Then DonantesImportacionE.sNroTarjeta = Mid(DonantesImportacionE.sNroTarjeta, 1, 16)
                    If Not IsNothing(DonantesImportacionE.sBanco) Then DonantesImportacionE.sBanco = Mid(DonantesImportacionE.sBanco, 1, 50)
                    If Not IsNothing(DonantesImportacionE.sVto) Then DonantesImportacionE.sVto = Mid(DonantesImportacionE.sVto, 1, 10)
                    If Not IsNothing(DonantesImportacionE.sCBU) Then DonantesImportacionE.sCBU = Mid(DonantesImportacionE.sCBU, 1, 22)
                    If Not IsNothing(DonantesImportacionE.sMonto) Then DonantesImportacionE.sMonto = Mid(DonantesImportacionE.sMonto, 1, 15)
                    If Not IsNothing(DonantesImportacionE.sTiempo) Then DonantesImportacionE.sTiempo = Mid(DonantesImportacionE.sTiempo, 1, 15)
                    If Not IsNothing(DonantesImportacionE.sCampania) Then DonantesImportacionE.sCampania = Mid(DonantesImportacionE.sCampania, 1, 50)

                    'cargo la tabla
                    dt.Rows.Add(DonantesImportacionE.sTipoDonante,
                        DonantesImportacionE.sApellido,
                        DonantesImportacionE.sNombre,
                        DonantesImportacionE.sRazon_Social,
                        DonantesImportacionE.sDireccion,
                        DonantesImportacionE.sLocalidad,
                        DonantesImportacionE.sCP,
                        DonantesImportacionE.sProvincia,
                        DonantesImportacionE.sDNI,
                        DonantesImportacionE.sCUIL_CUIT,
                        DonantesImportacionE.sTE_Linea,
                        DonantesImportacionE.sTE_Celular,
                        DonantesImportacionE.sTE_Laboral,
                        DonantesImportacionE.sEMail,
                        DonantesImportacionE.sTipoDonacion,
                        DonantesImportacionE.sTarjeta,
                        DonantesImportacionE.sNroTarjeta,
                        DonantesImportacionE.sBanco,
                        DonantesImportacionE.sVto,
                        DonantesImportacionE.sCBU,
                        DonantesImportacionE.sMonto,
                        DonantesImportacionE.sTiempo,
                        DonantesImportacionE.sCampania)

                    DonantesImportacionE = Nothing

                    i = i + 1
                Loop

                'cierro el excel
                If Not oExcel Is Nothing Then
                    oExcel.Quit()
                    oExcel = Nothing
                End If

                'grabo en la tabla
                DonantesImportacionD.Excel_Agregar(dt)

                DonantesImportacionD = Nothing
                dt = Nothing

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                'cierro el excel
                If Not oExcel Is Nothing Then
                    oExcel.Quit()
                    oExcel = Nothing
                End If

                Return False
            End Try
        End Function

        Public Function Excel_Validar() As Boolean
            Dim DonantesImportacionD As DonantesImportacionD
            Dim DonantesD As DonantesD
            Dim DonacionesD As DonacionesD
            Dim DonantesE As DonantesE
            Dim DonacionesE As DonacionesE

            Dim dt As DataTable
            Dim i As Integer = 0

            Dim nId As Integer = 0

            Dim dtV As DataTable

            Try
                DonantesImportacionD = New DonantesImportacionD
                DonantesD = New DonantesD
                DonacionesD = New DonacionesD
                DonantesE = New DonantesE
                DonacionesE = New DonacionesE

                dt = New DataTable
                dtV = New DataTable

                dt = DonantesImportacionD.Excel_Obtener()

                dtV.Columns.Add("Id_Donante", Type.GetType("System.Int32"))
                dtV.Columns.Add("Id_TipoValidacion", Type.GetType("System.Int32"))
                dtV.Columns.Add("Validacion", Type.GetType("System.String"))

                For i = 0 To dt.Rows.Count - 1
                    'guardo el id en una variable
                    nId = dt.Rows(i).Item("Id")

                    DonantesE = New DonantesE
                    DonacionesE = New DonacionesE

                    'tipo de donante
                    If IsDBNull(dt.Rows(i).Item("TipoDonante")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Tipo de Donante")
                    ElseIf IsDBNull(dt.Rows(i).Item("Id_TipoDonante")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Tipo de Donante Válido")
                    End If

                    If dt.Rows(i).Item("Id_TipoDonante") = eDonantes_Tipos.Fisico Then
                        'Nombre
                        If IsDBNull(dt.Rows(i).Item("Nombre")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nombre")
                        End If

                        'Apellido
                        If IsDBNull(dt.Rows(i).Item("Apellido")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Apellido")
                        End If
                    ElseIf dt.Rows(i).Item("Id_TipoDonante") = eDonantes_Tipos.Juridico Then
                        'Razon_Social
                        If IsDBNull(dt.Rows(i).Item("Razon_Social")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar una Razón Social")
                        End If
                    End If

                    'Provincia
                    If Not IsDBNull(dt.Rows(i).Item("Provincia")) Then
                        If IsDBNull(dt.Rows(i).Item("Id_Provincia")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar una Provincia Válida")
                        End If
                    End If

                    'DNI
                    If Not IsDBNull(dt.Rows(i).Item("DNI")) Then DonantesE.sDNI = dt.Rows(i).Item("DNI")

                    If dt.Rows(i).Item("Id_TipoDonante") = eDonantes_Tipos.Fisico Then
                        If Not IsDBNull(dt.Rows(i).Item("DNI")) Then
                            If Not IsNumeric(dt.Rows(i).Item("DNI")) Then
                                dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de Documento Válido")
                            ElseIf DonantesD.DNI_Verificar(eAccion.Agregar, DonantesE) > 0 Then
                                dtV.Rows.Add(nId, eValidaciones_Tipos.Advertencia, "Existen Donantes con el Mismo Nro. de Documento")
                            End If
                        End If
                    End If

                    'CUIL_CUIT
                    If Not IsDBNull(dt.Rows(i).Item("CUIL_CUIT")) Then DonantesE.sCUIL_CUIT = dt.Rows(i).Item("CUIL_CUIT")

                    If Not IsDBNull(dt.Rows(i).Item("CUIL_CUIT")) Then
                        If Not IsNumeric(dt.Rows(i).Item("CUIL_CUIT")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de CUIL/CUIT Válido")
                        ElseIf DonantesD.CUIT_CUIL_Verificar(eAccion.Agregar, DonantesE) > 0 Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Advertencia, "Existen Donantes con el Mismo Nro. de CUIL/CUIT")
                        End If
                    End If

                    'EMail
                    If Not IsDBNull(dt.Rows(i).Item("EMail")) Then DonantesE.sEMail = dt.Rows(i).Item("EMail")

                    If Not IsDBNull(dt.Rows(i).Item("EMail")) Then
                        If Not DonantesD.EMail_Formato_Validar(DonantesE) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un E-Mail Válido")
                        End If
                    End If

                    'TipoDonacion
                    If IsDBNull(dt.Rows(i).Item("TipoDonacion")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Tipo de Donación")
                    ElseIf IsDBNull(dt.Rows(i).Item("Id_TipoDonacion")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Tipo de Donación Válido")
                    End If

                    If dt.Rows(i).Item("Id_TipoDonacion") = eDonaciones_Tipos.Tarjeta Then
                        'Tarjeta
                        If IsDBNull(dt.Rows(i).Item("Tarjeta")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar una Tarjeta")
                        ElseIf IsDBNull(dt.Rows(i).Item("Id_Tarjeta")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar una Tarjeta Válida")
                        End If

                        'NroTarjeta
                        If Not IsDBNull(dt.Rows(i).Item("NroTarjeta")) Then DonacionesE.sNroTarjeta = dt.Rows(i).Item("NroTarjeta")

                        If IsDBNull(dt.Rows(i).Item("NroTarjeta")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de Tarjeta")
                        ElseIf Not IsNumeric(dt.Rows(i).Item("NroTarjeta")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de Tarjeta Válido")
                        ElseIf Not NroTarjeta_Formato_Verificar(DonacionesE) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de Tarjeta Válido")
                        ElseIf DonacionesD.NroTarjeta_Verificar(eAccion.Agregar, DonacionesE) > 0 Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Advertencia, "Existen Donaciones con el Mismo Nro. de Tarjeta")
                        End If
                    ElseIf dt.Rows(i).Item("Id_TipoDonacion") = eDonaciones_Tipos.CBU Then
                        'CBU
                        If Not IsDBNull(dt.Rows(i).Item("CBU")) Then DonacionesE.sCBU = dt.Rows(i).Item("CBU")

                        If IsDBNull(dt.Rows(i).Item("CBU")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de CBU")
                        ElseIf Not IsNumeric(dt.Rows(i).Item("CBU")) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de CBU Válido")
                        ElseIf Not CBU_Formato_Verificar(DonacionesE) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Nro. de CBU Válido")
                        ElseIf Not DonacionesD.CBU_Verificar(eAccion.Agregar, DonacionesE) Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Advertencia, "Existen Donaciones con el Mismo Nro. de CBU")
                        End If
                    End If

                    'Monto
                    If IsDBNull(dt.Rows(i).Item("Monto")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Monto")
                    ElseIf Not IsNumeric(dt.Rows(i).Item("Monto")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Monto Válido")
                    Else
                        Dim nEntero As Decimal = 0
                        Dim nDecimal As Decimal = 0

                        nEntero = Math.Truncate(dt.Rows(i).Item("Monto"))
                        nDecimal = Math.Truncate((dt.Rows(i).Item("Monto") - Math.Truncate(dt.Rows(i).Item("Monto"))) * 100)

                        If Len(nEntero.ToString) > 5 Or Len(nDecimal.ToString) > 2 Then
                            dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Monto Válido")
                        End If
                    End If

                    'Tiempo
                    If IsDBNull(dt.Rows(i).Item("Tiempo")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Tiempo")
                    ElseIf Not IsNumeric(dt.Rows(i).Item("Tiempo")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar un Tiempo Válido")
                    End If

                    'Campania
                    If IsDBNull(dt.Rows(i).Item("Campania")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar una Campaña")
                    ElseIf IsDBNull(dt.Rows(i).Item("Id_Campania")) Then
                        dtV.Rows.Add(nId, eValidaciones_Tipos.Error_, "Debe Ingresar una Campaña Válido")
                    End If

                    DonantesE = Nothing
                    DonacionesE = Nothing
                Next

                'agrego las validaciones
                DonantesImportacionD.Excel_Validaciones_Agregar(dtV)

                DonantesImportacionD = Nothing
                DonantesD = Nothing
                DonacionesD = Nothing
                DonantesE = Nothing
                DonacionesE = Nothing

                dt = Nothing
                dtV = Nothing

                Return True

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function

        Private Function NroTarjeta_Formato_Verificar(ByVal pDonaciones As DonacionesE) As Boolean
            Try
                Dim nPeso As Integer
                Dim nDigito As Integer
                Dim nSuma As Integer
                Dim nCont As Integer
                Dim sNuevaTarjeta As String = ""
                Dim sCar As String = ""
                Dim bValido As Boolean

                nPeso = 0
                nDigito = 0
                nSuma = 0

                'Reemplazar cualquier no digito por una cadena vac?a
                For nCont = 1 To Len(pDonaciones.sNroTarjeta)
                    sCar = Mid(pDonaciones.sNroTarjeta, nCont, 1)
                    If IsNumeric(sCar) Then
                        sNuevaTarjeta = sNuevaTarjeta & sCar
                    End If
                Next nCont

                ' Si es 0 devolver Falso
                If sNuevaTarjeta = 0 Then
                    bValido = False
                    Return bValido
                End If

                ' Si el n?mero de d?gitos es par el primer peso es 2, de lo 
                ' contrario es 1
                If (Len(sNuevaTarjeta) Mod 2) = 0 Then
                    nPeso = 2
                Else
                    nPeso = 1
                End If

                For iContador = 1 To Len(sNuevaTarjeta)
                    nDigito = Mid(sNuevaTarjeta, iContador, 1) * nPeso
                    If nDigito > 9 Then nDigito = nDigito - 9
                    nSuma = nSuma + nDigito
                    ' Cambiar peso para el siguiente d?gito
                    If nPeso = 2 Then
                        nPeso = 1
                    Else
                        nPeso = 2
                    End If
                Next iContador

                ' Devolver verdadero si la suma es divisible por 10
                If (nSuma Mod 10) = 0 Then
                    bValido = True
                Else
                    bValido = False
                End If

                Return bValido
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function

        Private Function CBU_Formato_Verificar(ByVal pDonaciones As DonacionesE) As Boolean
            Try
                'calcula en digito verificador de un valor para un largo determinado
                Const vPonderador = "97139713971397139713971397139713"
                Dim vBloque1 As String, vBloque2 As String
                Dim vDigVerif1 As String, vDigVerif2 As String
                Dim vTotal As Single
                Dim i As Single
                Dim vDigito As Single
                Dim vDigPond As String

                'separo en bloques y digitos verificadores
                vBloque1 = "0" & Left(Trim(pDonaciones.sCBU), 7)
                vDigVerif1 = Mid(Trim(pDonaciones.sCBU), 8, 1)

                vBloque2 = "000" & Mid(Trim(pDonaciones.sCBU), 9, 21)
                vDigVerif2 = Mid(Trim(pDonaciones.sCBU), 22, 1)

                'verifico el primer bloque
                i = 1
                vTotal = 0
                For i = 1 To 8
                    vDigito = CInt(Mid(vBloque1, i, 1))
                    vDigPond = CInt(Mid(vPonderador, i, 1))
                    vTotal = vTotal + vDigPond * vDigito - Int(vDigPond * vDigito / 10) * 10
                Next i

                i = 0
                Do While Int((vTotal + i) / 10) * 10 <> vTotal + i
                    i = i + 1
                Loop

                If vDigVerif1 <> Trim(Str(i)) Then
                    'bloque 1 incorrecto
                    Return False
                End If

                'verifico el segundo bloque
                i = 1
                vTotal = 0
                For i = 1 To 16
                    vDigito = CInt(Mid(vBloque2, i, 1))
                    vDigPond = CInt(Mid(vPonderador, i, 1))
                    vTotal = vTotal + vDigPond * vDigito - Int(vDigPond * vDigito / 10) * 10
                Next i

                i = 0
                Do While Int((vTotal + i) / 10) * 10 <> vTotal + i
                    i = i + 1
                Loop

                If vDigVerif2 <> Trim(Str(i)) Then
                    'bloque 2 incorrecto
                    Return False
                End If

                'cbu correcto
                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function
    End Class
End Namespace