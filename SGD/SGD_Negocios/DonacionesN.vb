Imports Microsoft.Office.Interop
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Namespace Negocios
    Public Class DonacionesN

        Public Function TiposDonaciones_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim DonacionesD As DonacionesD
            Dim dt As DataTable

            Try
                DonacionesD = New DonacionesD
                dt = New DataTable

                dt = DonacionesD.TiposDonaciones_CargarCombo(bTodos, bBlanco)

                DonacionesD = Nothing

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

        Public Function Listado(ByVal pDonaciones As DonacionesE) As DataTable
            Dim DonacionesD As DonacionesD
            Dim dt As DataTable

            Try
                DonacionesD = New DonacionesD
                dt = New DataTable

                dt = DonacionesD.Listado(pDonaciones)

                DonacionesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal pDonaciones As DonacionesE) As DataTable
            Dim DonacionesD As DonacionesD
            Dim dt As DataTable

            Try
                DonacionesD = New DonacionesD
                dt = New DataTable

                dt = DonacionesD.Obtener(pDonaciones)

                DonacionesD = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal pDonaciones As DonacionesE) As DataTable
            Dim dt As New DataTable
            Dim nId_Donacion As Integer = 0

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))
            dt.Columns.Add("Id_Donacion", Type.GetType("System.Int32"))

            Try
                Dim DonacionesD As DonacionesD

                DonacionesD = New DonacionesD

                'valido los datos
                If pDonaciones.nId_TipoDonacion = eDonaciones_Tipos.Tarjeta Then
                    If IsNothing(pDonaciones.sId_Tarjeta) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una Tarjeta.", 0)

                        Return dt
                    End If

                    If IsNothing(pDonaciones.sNroTarjeta) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de Tarjeta.", 0)

                        Return dt
                    End If

                    If Not NroTarjeta_Formato_Verificar(pDonaciones) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de Tarjeta Válido.", 0)

                        Return dt
                    End If

                    If NroTarjeta_Verificar(eAccion.Agregar, pDonaciones) > 0 Then
                        If MsgBox("Existen Donaciones de otros Donantes con el Mismo Nro. de Tarjeta." & vbCr & vbCr & "Desea Continuar con el Alta de la Donación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donaciones de otros Donantes con el Mismo Nro. de Tarjeta.", 0)

                            Return dt
                        End If
                    End If

                ElseIf pDonaciones.nId_TipoDonacion = eDonaciones_Tipos.CBU Then
                    If IsNothing(pDonaciones.sCBU) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de CBU.", 0)

                        Return dt
                    End If

                    If CBU_Formato_Verificar(pDonaciones) > 0 Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de CBU Válido.", 0)

                        Return dt
                    End If

                    If CBU_Verificar(eAccion.Agregar, pDonaciones) > 0 Then
                        If MsgBox("Existen Donaciones de otros Donantes con el Mismo Nro. de CBU." & vbCr & vbCr & "Desea Continuar con el Alta de la Donación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donaciones de otros Donantes con el Mismo Nro. de CBU.", 0)

                            Return dt
                        End If
                    End If
                End If

                If pDonaciones.nMonto <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Monto.", 0)

                    Return dt
                ElseIf (pDonaciones.nMonto * 100) - (Math.Truncate(pDonaciones.nMonto * 100)) <> 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Monto Válido.", 0)

                    Return dt
                End If

                If pDonaciones.nTiempo <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Tiempo.", 0)

                    Return dt
                End If

                If pDonaciones.nId_Campania = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una Campaña.", 0)

                    Return dt
                End If

                'realizo la actualizacion
                nId_Donacion = DonacionesD.Agregar(pDonaciones)

                If nId_Donacion > 0 Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Dió de Alta la Donación Nro. " & nId_Donacion.ToString & ".", nId_Donacion)
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message, 0)

                Return dt
            End Try
        End Function

        Public Function Modificar(ByVal pDonaciones As DonacionesE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim DonacionesD As DonacionesD

                DonacionesD = New DonacionesD

                'valido los datos
                If pDonaciones.nId_TipoDonacion = eDonaciones_Tipos.Tarjeta Then
                    If IsNothing(pDonaciones.sId_Tarjeta) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una Tarjeta.")

                        Return dt
                    End If

                    If IsNothing(pDonaciones.sNroTarjeta) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de Tarjeta.")

                        Return dt
                    End If

                    If Not NroTarjeta_Formato_Verificar(pDonaciones) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de Tarjeta Válido.")

                        Return dt
                    End If

                    If NroTarjeta_Verificar(eAccion.Modificar, pDonaciones) > 0 Then
                        If MsgBox("Existen Donaciones de otros Donantes con el Mismo Nro. de Tarjeta." & vbCr & vbCr & "Desea Continuar con el Alta de la Donación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donaciones de otros Donantes con el Mismo Nro. de Tarjeta.")

                            Return dt
                        End If
                    End If

                ElseIf pDonaciones.nId_TipoDonacion = eDonaciones_Tipos.CBU Then
                    If IsNothing(pDonaciones.sCBU) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de CBU.")

                        Return dt
                    End If

                    If Not CBU_Formato_Verificar(pDonaciones) Then
                        dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Nro. de CBU Válido.")

                        Return dt
                    End If

                    If CBU_Verificar(eAccion.Modificar, pDonaciones) > 0 Then
                        If MsgBox("Existen Donaciones de otros Donantes con el Mismo Nro. de CBU." & vbCr & vbCr & "Desea Continuar con el Alta de la Donación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.No Then
                            dt.Rows.Add(eMensajes_Tipos.PreguntaSiNo, "Existen Donaciones de otros Donantes con el Mismo Nro. de CBU.")

                            Return dt
                        End If
                    End If
                End If

                If pDonaciones.nMonto <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Monto.")

                    Return dt
                ElseIf (pDonaciones.nMonto * 100) - (Math.Truncate(pDonaciones.nMonto * 100)) <> 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Monto Válido.")

                    Return dt
                End If

                If pDonaciones.nTiempo <= 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar un Tiempo.")

                    Return dt
                End If

                If pDonaciones.nId_Campania = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Ingresar una Campaña.")

                    Return dt
                End If

                'realizo la actualizacion
                If DonacionesD.Modificar(pDonaciones) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "Se Modificaron los Datos del Donante.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Public Function Estado(ByVal pDonaciones As DonacionesE) As DataTable
            Dim dt As New DataTable

            dt.Columns.Add("Id", Type.GetType("System.Int32"))
            dt.Columns.Add("Mensaje", Type.GetType("System.String"))

            Try
                Dim DonacionesD As DonacionesD

                DonacionesD = New DonacionesD

                'valido los datos segun la campaña
                If pDonaciones.nId = 0 Then
                    dt.Rows.Add(eMensajes_Tipos.Error_Validacion, "Debe Seleccionar una Donación de la Grilla.")

                    Return dt
                End If

                'realizo la actualizacion
                If DonacionesD.Estado(pDonaciones) Then
                    dt.Rows.Add(eMensajes_Tipos.AccionOK, "La Donación Fue Dada de Baja.")
                End If

                Return dt
            Catch ex As Exception
                dt.Rows.Add(eMensajes_Tipos.Error_Aplicacion, ex.Message)

                Return dt
            End Try
        End Function

        Private Function NroTarjeta_Verificar(ByVal nAccion As eAccion, ByVal pDonaciones As DonacionesE) As Integer
            Dim DonacionesD As DonacionesD

            Dim nCant As Integer = 0

            Try
                DonacionesD = New DonacionesD

                nCant = DonacionesD.NroTarjeta_Verificar(nAccion, pDonaciones)

                DonacionesD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
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

        Private Function CBU_Verificar(ByVal nAccion As eAccion, ByVal pDonaciones As DonacionesE) As Integer
            Dim DonacionesD As DonacionesD

            Dim nCant As Integer = 0

            Try
                DonacionesD = New DonacionesD

                nCant = DonacionesD.CBU_Verificar(nAccion, pDonaciones)

                DonacionesD = Nothing

                Return nCant
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return -1
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