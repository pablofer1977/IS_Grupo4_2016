Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonantesConsulta
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim DonantesN As DonantesN

        DonantesN = New DonantesN

        With cmbTipoDonante
            .DataSource = DonantesN.TiposDonantes_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbProvincia
            .DataSource = DonantesN.Provincias_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        DonantesN = Nothing
    End Sub

    Private Sub CargarGrilla()
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE

            If Val(txtNroDonante.Text) <> 0 Then DonantesE.nId = Val(txtNroDonante.Text)
            If cmbTipoDonante.SelectedValue > 0 Then DonantesE.nId_TipoDonante = cmbTipoDonante.SelectedValue
            If Trim(txtNombre.Text) <> "" Then DonantesE.sApellido_Nombre_RazonSocial = Trim(txtNombre.Text)
            If Trim(txtDireccion.Text) <> "" Then DonantesE.sDireccion = Trim(txtDireccion.Text)
            If Trim(txtLocalidad.Text) <> "" Then DonantesE.sLocalidad = Trim(txtLocalidad.Text)
            If Trim(txtCodigoPostal.Text) <> "" Then DonantesE.sCP = Trim(txtCodigoPostal.Text)
            If cmbProvincia.SelectedValue > 0 Then DonantesE.nId_Provincia = cmbProvincia.SelectedValue
            If Val(txtNroDocumento.Text) <> 0 Then DonantesE.sDNI_CUIL_CUIT = Trim(txtNroDocumento.Text)
            If Trim(txtTE.Text) <> "" Then DonantesE.sTE_Linea_Celular_Laboral = Trim(txtTE.Text)
            If Trim(txtEMail.Text) <> "" Then DonantesE.sEMail = Trim(txtEMail.Text)

            grd.DataSource = DonantesN.Consulta_Listado(DonantesE)
            grd.DataBind()

            DonantesN = Nothing
            DonantesE = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub CargarGrilla_Donaciones()
        Dim DonacionesN As DonacionesN
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable

        Dim nId_Donante As Integer = Request.QueryString("id_donante")

        Try
            DonacionesN = New DonacionesN
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonacionesE.nId_Donante = IIf(nId_Donante <> 0, nId_Donante, -1)

            dt = DonacionesN.Consulta_Listado(DonacionesE)

            If dt.Rows.Count > 0 Then
                lblDonante.Text = "Listado de Donaciones [Donante Nro.: " & DonacionesE.nId_Donante.ToString & "]"
            Else
                lblDonante.Text = "Listado de Donaciones"
            End If

            grdD.DataSource = dt
            grdD.DataBind()

            DonacionesN = Nothing
            DonacionesE = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub Detalle(nId_Donacion As Integer)
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim dt As DataTable

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            dt = New DataTable

            DonantesE.nId = nId_Donacion

            dt = DonantesN.Consulta_Listado(DonantesE)

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
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()

            Dim nNroDonante As Integer = Request.QueryString("nrodonante")
            Dim nTipoDonante As Integer = Request.QueryString("id_tipodonante")
            Dim sNombre As String = Request.QueryString("nombre")
            Dim sDireccion As String = Request.QueryString("direccion")
            Dim sLocalidad As String = Request.QueryString("localidad")
            Dim sCodigoPostal As String = Request.QueryString("codigopostal")
            Dim nProvincia As Integer = Request.QueryString("id_provincia")
            Dim nNroDocumento As Integer = Request.QueryString("nrodocumento")
            Dim sTE As String = Request.QueryString("telefono")
            Dim sEMail As String = Request.QueryString("email")

            If nNroDonante <> 0 Then txtNroDonante.Text = nNroDonante
            If nTipoDonante <> 0 Then cmbTipoDonante.SelectedValue = Trim(nTipoDonante)
            If Not IsNothing(sNombre) Then txtNombre.Text = Trim(sNombre)
            If Not IsNothing(sDireccion) Then txtDireccion.Text = Trim(sDireccion)
            If Not IsNothing(sLocalidad) Then txtLocalidad.Text = Trim(sLocalidad)
            If Not IsNothing(sCodigoPostal) Then txtCodigoPostal.Text = Trim(sCodigoPostal)
            If nProvincia <> 0 Then cmbProvincia.SelectedValue = nProvincia
            If nNroDocumento <> 0 Then txtNroDocumento.Text = nNroDocumento
            If Not IsNothing(sTE) Then txtTE.Text = Trim(sTE)
            If Not IsNothing(sEMail) Then txtEMail.Text = Trim(sEMail)

            CargarGrilla()

            CargarGrilla_Donaciones()
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nNroDonante As Integer = Val(txtNroDonante.Text)
        Dim nTipoDonante As Integer = cmbTipoDonante.SelectedValue
        Dim sNombre As String = Trim(txtNombre.Text)
        Dim sDireccion As String = Trim(txtDireccion.Text)
        Dim sLocalidad As String = Trim(txtLocalidad.Text)
        Dim sCodigoPostal As String = Trim(txtCodigoPostal.Text)
        Dim nProvincia As Integer = cmbProvincia.SelectedValue
        Dim nNroDocumento As Integer = Val(txtNroDocumento.Text)
        Dim sTE As String = Trim(txtTE.Text)
        Dim sEMail As String = Trim(txtEMail.Text)

        Response.Redirect("/frmDonantesConsulta.aspx?nrodonante=" & nNroDonante.ToString &
                                                    "&id_tipodonante=" & nTipoDonante.ToString &
                                                    "&nombre=" & sNombre &
                                                    "&direccion=" & sDireccion &
                                                    "&localidad=" & sLocalidad &
                                                    "&codigopostal=" & sCodigoPostal &
                                                    "&id_provincia=" & nProvincia.ToString &
                                                    "&nrodocumento=" & nNroDocumento.ToString &
                                                    "&telefono=" & sTE &
                                                    "&email=" & sEMail, True)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub

    Protected Sub grdD_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdD.PageIndexChanging
        grdD.PageIndex = e.NewPageIndex

        CargarGrilla_Donaciones()
    End Sub

    Protected Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        Dim nId As Integer = 0
        If e.CommandName = "Detalle" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Detalle(nId)

        ElseIf e.CommandName = "VerDonaciones" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmDonantesConsulta.aspx?id_donante=" & nId.ToString, True)
        End If
    End Sub
End Class