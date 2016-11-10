Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables
Imports System.IO

Public Class frmPresentacionesAlta
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "
    Dim sCarpeta As String = ""
#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim DonacionesN As DonacionesN
        Dim TarjetasN As TarjetasN
        Dim PresentacionesN As PresentacionesN

        DonacionesN = New DonacionesN
        TarjetasN = New TarjetasN
        PresentacionesN = New PresentacionesN

        With cmbTipoPresentacion
            .DataSource = DonacionesN.TiposDonaciones_CargarCombo(False, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 1
        End With

        With cmbTarjeta
            .DataSource = TarjetasN.CargarCombo(False, False, cmbTipoPresentacion.SelectedValue)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbMes
            .DataSource = PresentacionesN.Meses_CargarCombo(False, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        DonacionesN = Nothing
        TarjetasN = Nothing
        PresentacionesN = Nothing
    End Sub

    Private Sub HabilitarCampos(nId_TipoDonacion As eDonaciones_Tipos)
        If nId_TipoDonacion = eDonaciones_Tipos.Tarjeta Then
            cmbTarjeta.Enabled = True
        ElseIf nId_TipoDonacion = eDonaciones_Tipos.CBU Then
            cmbTarjeta.Enabled = False
        Else
            cmbTarjeta.Enabled = False
        End If
    End Sub

    Private Sub Archivo_Bajar(PresentacionesE As PresentacionesE)
        Dim PresentacionesN As PresentacionesN

        PresentacionesN = New PresentacionesN

        Dim sCarpetaTXT As String = Trim(ConfigurationManager.AppSettings.Get("sArchivosPresentacionesTXT"))
        Dim sNombreTXT As String = PresentacionesN.NombreTXT(PresentacionesE)

        Dim sRutaTXT = sCarpetaTXT & "\" & sNombreTXT

        Dim toDownload As New FileInfo(sRutaTXT)

        If (toDownload.Exists) Then
            Response.Clear()
            Response.ContentType = "text/plain"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & toDownload.Name)
            Response.AddHeader("Content-Length", toDownload.Length.ToString())
            Response.WriteFile(sRutaTXT)
            'Response.End()
            HttpContext.Current.ApplicationInstance.CompleteRequest()
        Else
            MsgBox("Primero Debe Generar una Nueva Presentación", MsgBoxStyle.Information, "Robin")
        End If

        PresentacionesN = Nothing
    End Sub

    Private Function Aceptar() As Boolean
        Dim PresentacionesN As PresentacionesN
        Dim PresentacionesE As PresentacionesE
        Dim dt As DataTable
        Dim dtD As DataTable

        Try
            PresentacionesN = New PresentacionesN
            PresentacionesE = New PresentacionesE
            dt = New DataTable
            dtD = New DataTable

            PresentacionesE.nId_TipoPresentacion = cmbTipoPresentacion.SelectedValue

            If PresentacionesE.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
                PresentacionesE.sId_Tarjeta = cmbTarjeta.SelectedValue
            End If

            If cmbMes.SelectedValue > 0 Then PresentacionesE.nMes = cmbMes.SelectedValue
            If Val(txtAnio.Text) > 0 Then PresentacionesE.nAnio = Val(txtAnio.Text)
            PresentacionesE.sCarpetaTXT = Trim(ConfigurationManager.AppSettings.Get("sArchivosPresentacionesTXT"))

            'obtengo los datos a presentar
            dtD = PresentacionesN.Donaciones_Obtener(PresentacionesE)

            'valido los datos ingresados
            dt = PresentacionesN.Validar(PresentacionesE, dtD)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then

                ElseIf dt.Select("Id = -1").Count = 1 Then
                    'error de aplicacion
                    Return False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Generación Archivos para Presentaciones - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    Return False
                End If
            End If

            'genero el TXT
            dt = PresentacionesN.GenerarTXT(PresentacionesE, dtD)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then

                ElseIf dt.Select("Id = -1").Count = 1 Then
                    'error de aplicacion

                    Return False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Generación Archivos para Presentaciones - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    Return False
                End If
            End If

            'agrego la presentacion
            dt = PresentacionesN.Agregar(PresentacionesE, dtD)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then

                ElseIf dt.Select("Id = -1").Count = 1 Then
                    'error de aplicacion

                    Return False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Generación Archivos para Presentaciones - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    Return False
                End If
            End If

            'abro un cuadro de dialogo para bajar el txt generado
            Archivo_Bajar(PresentacionesE)

            PresentacionesN = Nothing
            PresentacionesE = Nothing
            dt = Nothing
            dtD = Nothing

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

    Private Sub Cancelar()
        Response.Redirect("frmDonantesListado.aspx", True)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()

            HabilitarCampos(cmbTipoPresentacion.SelectedValue)

            cmbMes.SelectedValue = Month(Now)
            txtAnio.Text = Year(Now)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        If Aceptar() Then
            MsgBox("Se generó una Nueva Presentación", MsgBoxStyle.Information, "Robin")
        End If
    End Sub

    Protected Sub cmbTipoPresentacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPresentacion.SelectedIndexChanged
        HabilitarCampos(cmbTipoPresentacion.SelectedValue)
    End Sub

    Protected Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        Dim PresentacionesE As PresentacionesE

        PresentacionesE = New PresentacionesE

        PresentacionesE.nId_TipoPresentacion = cmbTipoPresentacion.SelectedValue

        If PresentacionesE.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
            PresentacionesE.sId_Tarjeta = cmbTarjeta.SelectedValue
        End If

        Archivo_Bajar(PresentacionesE)

        PresentacionesE = Nothing
    End Sub
End Class