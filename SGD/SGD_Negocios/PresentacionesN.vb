Imports System.IO
Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class PresentacionesN

        Public Function Meses_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim GeneralD As GeneralD
            Dim dt As DataTable

            Try
                GeneralD = New GeneralD
                dt = New DataTable

                dt = GeneralD.Meses_CargarCombo(bTodos, bBlanco)

                GeneralD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal pPresentaciones As PresentacionesE) As DataTable
            Dim PresentacionesD As PresentacionesD
            Dim dt As DataTable

            Try
                PresentacionesD = New PresentacionesD
                dt = New DataTable

                dt = PresentacionesD.Listado(pPresentaciones)

                PresentacionesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Detalles_Listado(ByVal pPresentaciones As PresentacionesE) As DataTable
            Dim PresentacionesD As PresentacionesD
            Dim dt As DataTable

            Try
                PresentacionesD = New PresentacionesD
                dt = New DataTable

                dt = PresentacionesD.Detalles_Listado(pPresentaciones)

                PresentacionesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Donaciones_Obtener(ByVal pPresentaciones As PresentacionesE) As DataTable
            Dim PresentacionesD As PresentacionesD
            Dim dt As DataTable

            Try
                PresentacionesD = New PresentacionesD
                dt = New DataTable

                dt = PresentacionesD.Donaciones_Obtener(pPresentaciones)

                PresentacionesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Validar(ByVal pPresentaciones As PresentacionesE, dtD As DataTable) As DataTable
            Dim dt As New DataTable
            Dim nId_Presentacion As Integer = 0

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim PresentacionesD As PresentacionesD

                PresentacionesD = New PresentacionesD

                'valido los datos
                If pPresentaciones.nId_TipoPresentacion <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Tipo de Presentación.")

                    Return dt
                End If

                If pPresentaciones.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
                    If IsNothing(pPresentaciones.sId_Tarjeta) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Tarjeta.")

                        Return dt
                    End If
                End If

                If pPresentaciones.nMes <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Mes.")

                    Return dt
                End If

                If pPresentaciones.nAnio <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Año.")

                    Return dt
                End If

                If pPresentaciones.nAnio.ToString.Length <> 4 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Año de 4 Dígitos.")

                    Return dt
                End If

                If pPresentaciones.nAnio > Year(Now) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Año Menor o Igual al Año Corriente.")

                    Return dt
                End If

                If pPresentaciones.nAnio = Year(Now) And pPresentaciones.nMes > Month(Now) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Período Menor o Igual al Período Corriente.")

                    Return dt
                End If

                If Verificar(pPresentaciones) > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Existe una Presentación con los Mismos Datos.")

                    Return dt
                End If

                If dtD.Rows.Count = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "No Existen Donaciones a Presentar para la Tarjeta/CBU Seleccionada.")

                    Return dt
                End If

                'valido si la carpeta existe
                If Not Directory.Exists(pPresentaciones.sCarpetaTXT) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "La Carpeta '" & pPresentaciones.sCarpetaTXT & "' No Existe.")

                    Return dt
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Agregar(ByVal pPresentaciones As PresentacionesE, dtD As DataTable) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim PresentacionesD As PresentacionesD

                PresentacionesD = New PresentacionesD

                'realizo la actualizacion
                If PresentacionesD.Agregar(pPresentaciones, dtD) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Generó una Nueva Presentación.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function Verificar(ByVal pPresentaciones As PresentacionesE) As Integer
            Dim PresentacionesD As PresentacionesD

            Dim nCant As Integer = 0

            Try
                PresentacionesD = New PresentacionesD

                nCant = PresentacionesD.Verificar(pPresentaciones)

                PresentacionesD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
            End Try
        End Function

        Public Function GenerarTXT(PresentacionesE As PresentacionesE, dtD As DataTable) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim PresentacionesD As PresentacionesD

                PresentacionesD = New PresentacionesD

                If Not IsNothing(dtD) Then
                    If dtD.Rows.Count <> 0 Then
                        'veo que presentacion es y genero el txt
                        If PresentacionesE.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
                            If PresentacionesE.sId_Tarjeta = "AME" Then
                                If Not PresentarAME(PresentacionesE, dtD) Then
                                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Error al Generar Archivo a Presentar.")

                                    Return dt
                                End If
                            ElseIf PresentacionesE.sId_Tarjeta = "MAS" Then
                                If Not PresentarMAS(PresentacionesE, dtD) Then
                                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Error al Generar Archivo a Presentar.")

                                    Return dt
                                End If
                            ElseIf PresentacionesE.sId_Tarjeta = "VIS" Then
                                If Not PresentarVIS(PresentacionesE, dtD) Then
                                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Error al Generar Archivo a Presentar.")

                                    Return dt
                                End If
                            End If

                            dt.Rows.Add(eMensajes_Tipos.AccionOK, "El Archivo de Presentación fue Generado Correctamente.")
                        ElseIf PresentacionesE.nId_TipoPresentacion = eDonaciones_Tipos.CBU Then
                            If Not PresentarCBU(PresentacionesE, dtD) Then
                                dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Error al Generar Archivo a Presentar.")

                                Return dt
                            End If

                            dt.Rows.Add(eMensajes_Tipos.AccionOK, "El Archivo de Presentación fue Generado Correctamente.")
                        End If
                    End If
                End If

                PresentacionesD = Nothing

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function PresentarAME(ByVal PresentacionesE As PresentacionesE, ByVal dt As DataTable) As Boolean
            Dim sCarpetaTXT As String = ""
            Dim sNombreTXT As String = ""
            Dim sRutaTXT As String = ""

            Dim sNroEstablecimiento As String = ""
            Dim sNroTarjeta As String = ""
            Dim sCodServicio As String = ""
            Dim sNroServicio As String = ""
            Dim sFrecuenciaDeb As String = ""
            Dim sPeriodoFac As String = ""
            Dim sMonto As String = ""
            Dim sLiteral As String = ""
            Dim sFiller As String = ""

            Dim sLinea As String = ""

            Try
                'obtengo la carpeta y nombre de archivo
                sCarpetaTXT = PresentacionesE.sCarpetaTXT
                sNombreTXT = NombreTXT(PresentacionesE)

                'valido si la ruta existe
                If Not Directory.Exists(sCarpetaTXT) Then
                    MsgBox("La Carpeta Destino """ & sCarpetaTXT & """ No Existe", MsgBoxStyle.Critical, "Robin")
                    Return False
                End If

                'armo la ruta completa del TXT
                sRutaTXT = sCarpetaTXT & "\" & sNombreTXT

                If File.Exists(sRutaTXT) Then
                    File.Delete(sRutaTXT)
                End If

                'armo el archivo
                sNroEstablecimiento = Right("0000000000" & NroComercio(PresentacionesE), 10)
                sCodServicio = "00001"
                sFrecuenciaDeb = "01"
                sPeriodoFac = Right(Year(Now.AddMonths(1)).ToString, 2) & Format(Month(Now.AddMonths(1)), "00")
                sLiteral = Format(Month(Now), "00") & "\" & Right(Year(Now).ToString, 2)
                sFiller = Space(38)

                Dim sw As New StreamWriter(sRutaTXT)

                For i = 0 To dt.Rows.Count - 1
                    sNroTarjeta = Right("000000000000000" & dt.Rows(i).Item("Nro").ToString, 15)
                    sNroServicio = Format(Val(dt.Rows(i).Item("Id_Donacion").ToString), "0000000000")
                    sMonto = Format(dt.Rows(i).Item("Monto") * 100, "00000000000")

                    sLinea = sNroEstablecimiento &
                            sNroTarjeta &
                            sCodServicio &
                            sNroServicio &
                            sFrecuenciaDeb &
                            sPeriodoFac &
                            sMonto &
                            sLiteral &
                            sFiller

                    sw.WriteLine(sLinea)
                Next

                sw.Close()

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function

        Private Function PresentarMAS(ByVal PresentacionesE As PresentacionesE, ByVal dt As DataTable) As Boolean
            Dim sCarpetaTXT As String = ""
            Dim sNombreTXT As String = ""
            Dim sRutaTXT As String = ""

            Dim sNroComercio As String = ""
            Dim sTipoRegH As String = ""
            Dim sFechaPres As String = ""
            Dim sCantReg As String = ""
            Dim sSignoH As String = ""
            Dim sImporteH As String = ""
            Dim sFillerH As String = ""

            Dim sTipoRegD As String = ""
            Dim sNroTarjeta As String = ""
            Dim sReferencia As String = ""
            Dim sCuotas As String = ""
            Dim sCutasPlan As String = ""
            Dim sFrecDB As String = ""
            Dim sImporteD As String = ""
            Dim sPeriodo As String = ""
            Dim sFillerD As String = ""
            Dim sFechaVtoPago As String = ""
            Dim sFiller2D As String = ""

            Dim sLinea As String = ""

            Try
                'obtengo la carpeta y nombre de archivo
                sCarpetaTXT = PresentacionesE.sCarpetaTXT
                sNombreTXT = NombreTXT(PresentacionesE)

                'valido si la ruta existe
                If Not Directory.Exists(sCarpetaTXT) Then
                    MsgBox("La Carpeta Destino """ & sCarpetaTXT & """ No Existe", MsgBoxStyle.Critical, "Robin")
                    Return False
                End If

                'armo la ruta completa del TXT
                sRutaTXT = sCarpetaTXT & "\" & sNombreTXT

                If File.Exists(sRutaTXT) Then
                    File.Delete(sRutaTXT)
                End If

                'armo el archivo
                sNroComercio = Right("00000000" & NroComercio(PresentacionesE), 8)
                sTipoRegH = "1"
                sFechaPres = Format(Day(Now), "00") & Format(Month(Now), "00") & Right(Year(Now).ToString, 2)
                sCantReg = Format(dt.Compute("Count(Monto)", ""), "0000000")
                sSignoH = "0"
                sImporteH = Format(dt.Compute("Sum(Monto)", "") * 100, "00000000000000")
                sFillerH = Space(91)

                sTipoRegD = "2"
                sCuotas = "001"
                sCutasPlan = "999"
                sFrecDB = "01"
                sPeriodo = Format(Month(Now), "00") & "/" & Right(Year(Now).ToString, 2)
                sFillerD = Space(1)
                sFechaVtoPago = Format(Day(Now), "00") & Format(Month(Now), "00") & Right(Year(Now).ToString, 2)
                sFiller2D = Space(60)

                'armo la cabecera
                sLinea = sNroComercio &
                        sTipoRegH &
                        sFechaPres &
                        sCantReg &
                        sSignoH &
                        sImporteH &
                        sFillerH

                Dim sw As New StreamWriter(sRutaTXT)
                sw.WriteLine(sLinea)

                'armo los detalles
                For i = 0 To dt.Rows.Count - 1

                    sNroTarjeta = Right("0000000000000000" & dt.Rows(i).Item("Nro").ToString, 16)
                    sReferencia = Format(Val(dt.Rows(i).Item("Id_Donacion").ToString), "000000000000")
                    sImporteD = Format(dt.Rows(i).Item("Monto") * 100, "00000000000")

                    sLinea = sNroComercio &
                            sTipoRegD &
                            sNroTarjeta &
                            sReferencia &
                            sCuotas &
                            sCutasPlan &
                            sFrecDB &
                            sImporteD &
                            sPeriodo &
                            sFillerD &
                            sFechaVtoPago &
                            sFiller2D

                    sw.WriteLine(sLinea)
                Next
                sw.Close()

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function

        Private Function PresentarVIS(ByVal PresentacionesE As PresentacionesE, ByVal dt As DataTable) As Boolean
            Dim sCarpetaTXT As String = ""
            Dim sNombreTXT As String = ""
            Dim sRutaTXT As String = ""

            Dim dtP As DataTable
            Dim c As Integer = 0
            Dim r As Integer = 0

            'variables para calcular los lotes
            Dim nCantRegLote As Integer = 99
            Dim nContLote As Integer = 0
            Dim nIdMIN As Integer = 0
            Dim nIdMAX As Integer = 0
            Dim nTotal As Integer = 0
            Dim bLoop As Boolean = True

            Dim sTipoRegH As String = ""
            Dim sDB As String = ""
            Dim sFechaTransH As String = ""
            Dim sCodBanco As String = ""
            Dim sCodSucursal As String = ""
            Dim sNroLote As String = ""
            Dim sFillerH As String = ""
            Dim sCodTrans As String = ""
            Dim sNroEstablecimiento As String = ""
            Dim sCantCompLoteH As String = ""
            Dim sImporteH As String = ""
            Dim sFiller2H As String = ""
            Dim sNroCaja As String = ""
            Dim sFiller3H As String = ""

            Dim sTipoRegD As String = ""
            Dim sFillerD As String = ""
            Dim sNroTarjeta As String = ""
            Dim sFiller2D As String = ""
            Dim sNroCupon As String = ""
            Dim sFechaTransD As String = ""
            Dim sFiller3D As String = ""
            Dim sFiller4D As String = ""
            Dim sImporteD As String = ""
            Dim sFiller5D As String = ""
            Dim sCodDebito As String = ""
            Dim sCodAlta As String = ""

            Dim sLinea As String = ""

            Try
                'obtengo la carpeta y nombre de archivo
                sCarpetaTXT = PresentacionesE.sCarpetaTXT
                sNombreTXT = NombreTXT(PresentacionesE)

                'valido si la ruta existe
                If Not Directory.Exists(sCarpetaTXT) Then
                    MsgBox("La Carpeta Destino """ & sCarpetaTXT & """ No Existe", MsgBoxStyle.Critical, "Robin")
                    Return False
                End If

                'armo la ruta completa del TXT
                sRutaTXT = sCarpetaTXT & "\" & sNombreTXT

                If File.Exists(sRutaTXT) Then
                    File.Delete(sRutaTXT)
                End If

                'tomo por lotes
                dtP = New DataTable

                'cargo las columnas del dt auxiliar
                For c = 0 To dt.Columns.Count - 1
                    dtP.Columns.Add(dt.Columns(c).ColumnName)
                    dtP.Columns(c).DataType = dt.Columns(c).DataType
                Next

                'obtengo el total de registros
                nTotal = dt.Rows.Count
                nContLote = 0

                'armo el archivo
                sTipoRegH = "0"
                sDB = "DB"
                sFechaTransH = Format(Day(Now), "00") & Format(Month(Now), "00") & Right(Year(Now).ToString, 2)
                sCodBanco = "017"
                sCodSucursal = "305"
                sFillerH = Space(7)
                sCodTrans = "0005"
                sNroEstablecimiento = Right("0000000000" & NroComercio(PresentacionesE), 10)
                sFiller2H = Space(1)
                sNroCaja = "9941"
                sFiller3H = Space(18)

                Dim sw As New StreamWriter(sRutaTXT)

                Do While bLoop
                    'calculo los id min y max
                    nIdMIN = nContLote * nCantRegLote
                    nIdMAX = ((nContLote + 1) * nCantRegLote) - 1

                    dtP.Rows.Clear()
                    For r = nIdMIN To nIdMAX
                        If r < nTotal Then
                            'armo el dt por lote
                            dtP.Rows.Add(dt.Rows(r).ItemArray)
                        Else
                            'salgo del for porque llegue al ultimo registro
                            'aviso que no tengo que seguir el while
                            bLoop = False
                            Exit For
                        End If
                    Next

                    If dtP.Rows.Count > 0 Then
                        sCantCompLoteH = Format(dtP.Compute("Count(Id)", ""), "00")
                        sImporteH = Format(dtP.Compute("Sum(Monto)", "") * 100, "000000000000000")
                        sNroLote = Format(nContLote + 1, "0000")

                        'armo la cabecera
                        sLinea = sTipoRegH &
                                sDB &
                                sFechaTransH &
                                sCodBanco &
                                sCodSucursal &
                                sNroLote &
                                sFillerH &
                                sCodTrans &
                                sNroEstablecimiento &
                                sCantCompLoteH &
                                sImporteH &
                                sFiller2H &
                                sNroCaja &
                                sFiller3H

                        sw.WriteLine(sLinea)

                        sTipoRegD = Space(1)
                        sFillerD = Space(2)
                        sFiller2D = Space(1)
                        sFechaTransD = Format(Day(Now), "00") & Format(Month(Now), "00") & Right(Year(Now).ToString, 2)
                        sFiller3D = Space(3)
                        sFiller4D = Space(5)
                        sFiller5D = Space(7)

                        'armo los detalles
                        For i = 0 To dtP.Rows.Count - 1

                            sNroTarjeta = Right("0000000000000000" & dtP.Rows(i).Item("Nro").ToString, 16)
                            sNroCupon = Format(Val(dtP.Rows(i).Item("Id").ToString), "00000000")
                            sImporteD = Format(dtP.Rows(i).Item("Monto") * 100, "000000000000000")
                            sCodDebito = Format(Val(dtP.Rows(i).Item("Id_Donacion").ToString), "000000000000000")

                            If dtP.Rows(i).Item("CantPres") = 0 Then
                                sCodAlta = "E"
                            Else
                                sCodAlta = Space(1)
                            End If

                            sLinea = sTipoRegD &
                                    sFillerD &
                                    sNroTarjeta &
                                    sFiller2D &
                                    sNroCupon &
                                    sFechaTransD &
                                    sFiller3D &
                                    sFiller4D &
                                    sImporteD &
                                    sFiller5D &
                                    sCodDebito &
                                    sCodAlta

                            sw.WriteLine(sLinea)
                        Next

                        'preparo el contador para el siguiente lote
                        nContLote = nContLote + 1
                    End If
                Loop

                sw.Close()

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function

        Private Function PresentarCBU(ByVal PresentacionesE As PresentacionesE, ByVal dt As DataTable) As Boolean
            Dim sCarpetaTXT As String = ""
            Dim sNombreTXT As String = ""
            Dim sRutaTXT As String = ""

            Dim sCodTransaccion As String = ""
            Dim sVechaVto As String = ""
            Dim sCodEmpresa As String = ""
            Dim sIdentCliente As String = ""
            Dim sMoneda As String = ""
            Dim sCBU As String = ""
            Dim sImporte As String = ""
            Dim sCUIT As String = ""
            Dim sPrestacion As String = ""
            Dim sRefOperacion As String = ""
            Dim sRefUnivoca As String = ""
            Dim sCtaEmpresa As String = ""
            Dim sIdCliente As String = ""
            Dim sCodRechazo As String = ""

            Dim sLinea As String = ""

            Try
                'obtengo la carpeta y nombre de archivo
                sCarpetaTXT = PresentacionesE.sCarpetaTXT
                sNombreTXT = NombreTXT(PresentacionesE)

                'le pongo el nro de comercio
                sCodEmpresa = Right("00000" & NroComercio(PresentacionesE), 5)
                sVechaVto = Format(Year(Now), "0000") & Format(Month(Now), "00") & Format(Day(Now), "00")

                'valido si la ruta existe
                If Not Directory.Exists(sCarpetaTXT) Then
                    MsgBox("La Carpeta Destino """ & sCarpetaTXT & """ No Existe", MsgBoxStyle.Critical, "Robin")
                    Return False
                End If

                'armo la ruta completa del TXT
                sRutaTXT = sCarpetaTXT & "\" & sNombreTXT

                If File.Exists(sRutaTXT) Then
                    File.Delete(sRutaTXT)
                End If

                'armo el archivo
                sCodTransaccion = "057"
                sMoneda = "0"
                sCUIT = "30618862077"
                sPrestacion = "FUNDAROBIN"
                sRefOperacion = Space(15)
                sRefUnivoca = Left("DONACION" & Space(15), 15)
                sCtaEmpresa = "000000390000130"
                sIdCliente = Space(22)
                sCodRechazo = Space(3)

                Dim sw As New StreamWriter(sRutaTXT)

                For i = 0 To dt.Rows.Count - 1

                    sIdentCliente = Left(Right("000000" & Trim(dt.Rows(i).Item("Id_Donacion").ToString), 6) & Space(22), 22)
                    sCBU = Right("0000000000000000000000" & Trim(dt.Rows(i).Item("Nro").ToString), 22)
                    sImporte = Format(dt.Rows(i).Item("Monto") * 100, "0000000000")

                    sLinea = sCodTransaccion &
                            sVechaVto &
                            sCodEmpresa &
                            sIdentCliente &
                            sMoneda &
                            sCBU &
                            sImporte &
                            sCUIT &
                            sPrestacion &
                            sRefOperacion &
                            sRefUnivoca &
                            sCtaEmpresa &
                            sIdCliente &
                            sCodRechazo

                    sw.WriteLine(sLinea)
                Next

                sw.Close()

                Return True
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function

        Public Function NombreTXT(ByVal PresentacionesE As PresentacionesE) As String
            Dim TarjetasD As TarjetasD
            Dim TarjetasE As TarjetasE

            Dim dt As DataTable
            Dim sNombreTXT As String = ""

            Try
                TarjetasD = New TarjetasD
                TarjetasE = New TarjetasE
                dt = New DataTable

                TarjetasE.nId_TipoPresentacion = PresentacionesE.nId_TipoPresentacion
                TarjetasE.sId = PresentacionesE.sId_Tarjeta

                dt = TarjetasD.Listado(TarjetasE)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        sNombreTXT = dt.Rows(0).Item("NombreArchivo").ToString
                    End If
                End If

                TarjetasD = Nothing
                TarjetasE = Nothing
                dt = Nothing

                Return sNombreTXT

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return ""
            End Try
        End Function

        Private Function NroComercio(ByVal PresentacionesE As PresentacionesE) As String
            Dim TarjetasD As TarjetasD
            Dim TarjetasE As TarjetasE

            Dim dt As DataTable
            Dim sNroComercio As String = ""

            Try
                TarjetasD = New TarjetasD
                TarjetasE = New TarjetasE
                dt = New DataTable

                TarjetasE.nId_TipoPresentacion = PresentacionesE.nId_TipoPresentacion
                TarjetasE.sId = PresentacionesE.sId_Tarjeta

                dt = TarjetasD.Listado(TarjetasE)

                If Not IsNothing(dt) Then
                    If dt.Rows.Count > 0 Then
                        sNroComercio = dt.Rows(0).Item("NroComercio").ToString
                    End If
                End If

                TarjetasD = Nothing
                TarjetasE = Nothing
                dt = Nothing

                Return sNroComercio

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return ""
            End Try
        End Function

        Public Function Retornos_Agregar(ByVal pPresentaciones As PresentacionesE, dtD As DataTable) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim PresentacionesD As PresentacionesD

                PresentacionesD = New PresentacionesD

                'realizo la actualizacion
                If PresentacionesD.Retornos_Agregar(pPresentaciones, dtD) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Procesó la Presentación Seleccionada.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Retornos_Validar(ByVal pPresentaciones As PresentacionesE) As DataTable
            Dim dt As New DataTable
            Dim nId_Presentacion As Integer = 0

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim PresentacionesD As PresentacionesD

                PresentacionesD = New PresentacionesD

                'valido los datos
                If pPresentaciones.nId_TipoPresentacion <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Tipo de Presentación.")

                    Return dt
                End If

                If pPresentaciones.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
                    If IsNothing(pPresentaciones.sId_Tarjeta) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Tarjeta.")

                        Return dt
                    End If
                End If

                If pPresentaciones.nMes <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Mes.")

                    Return dt
                End If

                If pPresentaciones.nAnio <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Año.")

                    Return dt
                End If

                If pPresentaciones.nAnio.ToString.Length <> 4 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Año de 4 Dígitos.")

                    Return dt
                End If

                If pPresentaciones.nAnio > Year(Now) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Año Menor o Igual al Año Corriente.")

                    Return dt
                End If

                If pPresentaciones.nAnio = Year(Now) And pPresentaciones.nMes > Month(Now) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Período Menor o Igual al Período Corriente.")

                    Return dt
                End If

                If Verificar(pPresentaciones) <> 1 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "NO Existe Presentación para los Datos Ingresados.")

                    Return dt
                End If

                'valido si ingreso un archivo
                If IsNothing(pPresentaciones.sCarpetaTXT) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar un Archivo a Procesar.")

                    Return dt
                End If

                'valido si el archivo existe
                If Not File.Exists(pPresentaciones.sCarpetaTXT) Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "El Archivo '" & pPresentaciones.sCarpetaTXT & "' No Existe.")

                    Return dt
                End If

                'valido el formato
                Dim sr As New StreamReader(pPresentaciones.sCarpetaTXT)
                Dim sLinea As String = ""

                'leo la primer linea
                sLinea = sr.ReadLine()

                'veo que presentacion es y proceso el txt
                If pPresentaciones.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
                    If pPresentaciones.sId_Tarjeta = "AME" Then
                        If Val(Mid(sLinea, 1, 10)) <> NroComercio(pPresentaciones) Then
                            dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "El Archivo '" & pPresentaciones.sCarpetaTXT & "' No Pertenece a una Archivo de Rendición " & pPresentaciones.sId_Tarjeta & ".")
                        End If

                    ElseIf pPresentaciones.sId_Tarjeta = "MAS" Then
                        If Val(Mid(sLinea, 1, 8)) <> NroComercio(pPresentaciones) Then
                            dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "El Archivo '" & pPresentaciones.sCarpetaTXT & "' No Pertenece a una Archivo de Rendición " & pPresentaciones.sId_Tarjeta & ".")
                        End If

                    ElseIf pPresentaciones.sId_Tarjeta = "VIS" Then
                        If Mid(sLinea, 1, 3) <> "0DB" Then
                            dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "El Archivo '" & pPresentaciones.sCarpetaTXT & "' No Posee un Formato Válido.")
                        End If

                        If Val(Mid(sLinea, 10, 6)) <> NroComercio(pPresentaciones) Then
                            dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "El Archivo '" & pPresentaciones.sCarpetaTXT & "' No Pertenece a una Archivo de Rendición " & pPresentaciones.sId_Tarjeta & ".")
                        End If
                    End If

                ElseIf pPresentaciones.nId_TipoPresentacion = eDonaciones_Tipos.CBU Then
                    If Val(Mid(sLinea, 12, 5)) <> NroComercio(pPresentaciones) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "El Archivo '" & pPresentaciones.sCarpetaTXT & "' No Pertenece a una Archivo de Rendición " & eDonaciones_Tipos.CBU.ToString & ".")
                    End If

                End If

                ' Cerrar el fichero
                sr.Close()

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function ProcesarRechazos(ByVal PresentacionesE As PresentacionesE) As DataTable
            Dim dt As DataTable

            Dim sLinea As String = ""

            Dim nId_Donacion As Integer = 0
            Dim sCodBanco As String = ""

            'creo los campos del dt
            dt = New DataTable
            dt.Columns.Add("Id_Donacion", Type.GetType("System.Int32"))
            dt.Columns.Add("CodBanco", Type.GetType("System.String"))

            ' Leer el contenido mientras no se llegue al final
            Dim sr As New StreamReader(PresentacionesE.sCarpetaTXT)
            While sr.Peek() <> -1

                'leo la primer linea
                sLinea = sr.ReadLine()

                'veo que presentacion es y proceso el txt
                If PresentacionesE.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
                    If PresentacionesE.sId_Tarjeta = "AME" Then
                        nId_Donacion = Val(Mid(sLinea, 31, 10))
                        sCodBanco = Mid(sLinea, 63, 2)

                        If nId_Donacion > 0 Then dt.Rows.Add(nId_Donacion, sCodBanco)

                    ElseIf PresentacionesE.sId_Tarjeta = "MAS" Then
                        If Mid(sLinea, 9, 1) = "2" Then
                            nId_Donacion = Val(Mid(sLinea, 26, 12))
                            sCodBanco = Mid(sLinea, 69, 3)

                            If nId_Donacion > 0 Then dt.Rows.Add(nId_Donacion, sCodBanco)
                        End If

                    ElseIf PresentacionesE.sId_Tarjeta = "VIS" Then
                        If Mid(sLinea, 1, 3) <> "0DB" Then
                            nId_Donacion = Val(Mid(sLinea, 65, 15))
                            sCodBanco = Mid(sLinea, 81, 3)

                            If nId_Donacion > 0 Then dt.Rows.Add(nId_Donacion, sCodBanco)
                        End If
                    End If

                ElseIf PresentacionesE.nId_TipoPresentacion = eDonaciones_Tipos.CBU Then
                    nId_Donacion = Val(Mid(sLinea, 17, 6))
                    sCodBanco = Mid(sLinea, 160, 3)

                    If nId_Donacion > 0 Then dt.Rows.Add(nId_Donacion, sCodBanco)

                End If
            End While

            ' Cerrar el fichero
            sr.Close()

            Return dt
        End Function
    End Class
End Namespace
