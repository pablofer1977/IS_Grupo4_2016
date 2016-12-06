Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonacionesConsulta
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim DonacionesN As DonacionesN
        Dim TarjetasN As TarjetasN
        Dim CampaniasN As CampaniasN

        DonacionesN = New DonacionesN
        TarjetasN = New TarjetasN
        CampaniasN = New CampaniasN

        With cmbEstado
            .DataSource = DonacionesN.Estados_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbTipoDonacion
            .DataSource = DonacionesN.TiposDonaciones_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbTarjeta
            .DataSource = TarjetasN.CargarCombo(True, False, 0)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbCampania
            .DataSource = CampaniasN.CargarCombo(True, False, "")
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        DonacionesN = Nothing
        TarjetasN = Nothing
        CampaniasN = Nothing
    End Sub

    Private Sub CargarGrilla()
        Dim DonacionesN As DonacionesN
        Dim DonacionesE As DonacionesE

        Try
            DonacionesN = New DonacionesN
            DonacionesE = New DonacionesE

            If Trim(txtNroDonacion.Text) <> "" Then DonacionesE.nId = Trim(txtNroDonacion.Text)
            If Trim(txtNroDonante.Text) <> "" Then DonacionesE.nId_Donante = Trim(txtNroDonante.Text)
            If Trim(cmbEstado.SelectedValue) <> "-1" Then DonacionesE.sEstado = cmbEstado.SelectedValue
            If cmbTipoDonacion.SelectedValue > 0 Then DonacionesE.nId_TipoDonacion = cmbTipoDonacion.SelectedValue
            If Trim(cmbTarjeta.SelectedValue) <> "-1" Then DonacionesE.sId_Tarjeta = cmbTarjeta.SelectedValue
            If Trim(txtNroTarjetaCBU.Text) <> "" Then DonacionesE.sNroTarjeta_CBU = Trim(txtNroTarjetaCBU.Text)
            If cmbCampania.SelectedValue > 0 Then DonacionesE.nId_Campania = cmbCampania.SelectedValue

            grd.DataSource = DonacionesN.Consulta_Listado(DonacionesE)
            grd.DataBind()

            DonacionesN = Nothing
            DonacionesE = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub CargarGrilla_Donantes()
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim dt As DataTable

        Dim nId_Donante As Integer = Request.QueryString("id_donante")

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            dt = New DataTable

            DonantesE.nId = IIf(nId_Donante <> 0, nId_Donante, -1)

            dt = DonantesN.Consulta_Listado(DonantesE)

            If dt.Rows.Count > 0 Then
                lblDonante.Text = "Datos del Donante [Donante Nro.: " & DonantesE.nId.ToString & "]"
            Else
                lblDonante.Text = "Datos del Donante"
            End If

            grdD.DataSource = dt
            grdD.DataBind()

            DonantesN = Nothing
            DonantesE = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub Detalle(nId_Donante As Integer)
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonantesE.nId = nId_Donante

            dt = DonantesN.Listado(DonantesE, DonacionesE)

            If dt.Rows.Count > 0 Then
                'mostrar detalle
                lblTituloDetalle.Text = "Donante - Detalle"

                lblNroDonante.Text = dt.Rows(0).Item("Id")
                If Not IsDBNull(dt.Rows(0).Item("FechaIng")) Then lblFechaIng.Text = dt.Rows(0).Item("FechaIng")
                If Not IsDBNull(dt.Rows(0).Item("TipoDonante")) Then lblTipoDonante.Text = dt.Rows(0).Item("TipoDonante")

                If Not IsDBNull(dt.Rows(0).Item("Nombre")) Then lblNombre.Text = dt.Rows(0).Item("Nombre")
                If Not IsDBNull(dt.Rows(0).Item("Direccion")) Then lblDireccion.Text = dt.Rows(0).Item("Direccion")
                If Not IsDBNull(dt.Rows(0).Item("Localidad")) Then lblLocalidad.Text = dt.Rows(0).Item("Localidad")
                If Not IsDBNull(dt.Rows(0).Item("CP")) Then lblCodigoPostal.Text = dt.Rows(0).Item("CP")
                If Not IsDBNull(dt.Rows(0).Item("Provincia")) Then lblProvincia.Text = dt.Rows(0).Item("Provincia")

                If Not IsDBNull(dt.Rows(0).Item("DNI")) Then lblNroDocumento.Text = dt.Rows(0).Item("DNI")
                If Not IsDBNull(dt.Rows(0).Item("CUIL_CUIT")) Then lblCUIT.Text = dt.Rows(0).Item("CUIL_CUIT")
                If Not IsDBNull(dt.Rows(0).Item("TE")) Then lblTE.Text = dt.Rows(0).Item("TE")
                If Not IsDBNull(dt.Rows(0).Item("EMail")) Then lblEMail.Text = dt.Rows(0).Item("EMail")
                If Not IsDBNull(dt.Rows(0).Item("Comentarios")) Then lblComentarios.Text = dt.Rows(0).Item("Comentarios")

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Detalle", "$('#Modal_Detalle').modal();", True)

                upModal_Detalle.Update()
            End If

            DonantesN = Nothing
            DonantesE = Nothing
            DonacionesE = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()

            Dim nNroDonacion As Integer = Request.QueryString("nrodonacion")
            Dim nNroDonante As Integer = Request.QueryString("nrodonante")
            Dim sEstado As String = Request.QueryString("id_estado")
            Dim nTipoDonacion As Integer = Request.QueryString("id_tipodonacion")
            Dim sTarjeta As String = Request.QueryString("id_tarjeta")
            Dim sNroTarjetaCBU As String = Request.QueryString("nrotarjeta")
            Dim nCampania As Integer = Request.QueryString("id_campania")

            If nNroDonacion <> 0 Then txtNroDonacion.Text = nNroDonacion
            If nNroDonante <> 0 Then txtNroDonante.Text = nNroDonante
            If Not IsNothing(sEstado) Then cmbEstado.SelectedValue = Trim(sEstado)
            If nTipoDonacion <> 0 Then cmbTipoDonacion.SelectedValue = nTipoDonacion
            If Not IsNothing(sTarjeta) Then cmbTarjeta.SelectedValue = Trim(sTarjeta)
            If Not IsNothing(sNroTarjetaCBU) Then txtNroTarjetaCBU.Text = Trim(sNroTarjetaCBU)
            If nCampania <> 0 Then cmbCampania.SelectedValue = nCampania

            CargarGrilla()

            CargarGrilla_Donantes()
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nNroDonacion As Integer = Val(txtNroDonacion.Text)
        Dim nNroDonante As Integer = Val(txtNroDonante.Text)
        Dim sEstado As String = cmbEstado.SelectedValue
        Dim nTipoDonacion As Integer = cmbTipoDonacion.SelectedValue
        Dim sTarjeta As String = cmbTarjeta.SelectedValue
        Dim sNroTarjetaCBU As String = Trim(txtNroTarjetaCBU.Text)
        Dim nCampania As Integer = cmbCampania.SelectedValue

        Response.Redirect("/frmDonacionesConsulta.aspx?nrodonacion=" & nNroDonacion.ToString &
                                                    "&nrodonante=" & nNroDonante.ToString &
                                                    "&id_estado=" & sEstado &
                                                    "&id_tipodonacion=" & nTipoDonacion.ToString &
                                                    "&id_tarjeta=" & sTarjeta &
                                                    "&nrotarjeta=" & sNroTarjetaCBU &
                                                    "&id_campania=" & nCampania.ToString, True)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub

    Protected Sub grdD_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdD.PageIndexChanging
        grdD.PageIndex = e.NewPageIndex

        CargarGrilla_Donantes()
    End Sub

    Protected Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        Dim nId As Integer = 0
        If e.CommandName = "VerDonantes" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmDonacionesConsulta.aspx?id_donante=" & nId.ToString, True)
        End If
    End Sub

    Protected Sub grdD_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdD.RowCommand
        Dim nId As Integer = 0
        If e.CommandName = "Detalle" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Detalle(nId)
        End If
    End Sub
End Class