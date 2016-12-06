Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonantesListado
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim DonantesN As DonantesN
        Dim DonacionesN As DonacionesN
        Dim TarjetasN As TarjetasN
        Dim CampaniasN As CampaniasN

        DonantesN = New DonantesN
        DonacionesN = New DonacionesN
        TarjetasN = New TarjetasN
        CampaniasN = New CampaniasN

        'With cmbTipoDonante
        '    .DataSource = DonantesN.TiposDonantes_CargarCombo(True, False)
        '    .DataValueField = "Id"
        '    .DataTextField = "Campo"
        '    .DataBind()

        '    .SelectedIndex = -1
        'End With

        With cmbProvincia
            .DataSource = DonantesN.Provincias_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbEstado
            .DataSource = DonacionesN.Estados_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        'With cmbTipoDonacion
        '    .DataSource = DonacionesN.TiposDonaciones_CargarCombo(True, False)
        '    .DataValueField = "Id"
        '    .DataTextField = "Campo"
        '    .DataBind()

        '    .SelectedIndex = -1
        'End With

        'With cmbTarjeta
        '    .DataSource = TarjetasN.CargarCombo(True, False, 0)
        '    .DataValueField = "Id"
        '    .DataTextField = "Campo"
        '    .DataBind()

        '    .SelectedIndex = -1
        'End With

        With cmbCampania
            .DataSource = CampaniasN.CargarCombo(True, False, "")
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        DonantesN = Nothing
        DonacionesN = Nothing
        TarjetasN = Nothing
        CampaniasN = Nothing
    End Sub

    Private Sub CargarGrilla()
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim DonacionesE As DonacionesE

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            DonacionesE = New DonacionesE

            If Val(txtNroDonante.Text) <> 0 Then DonantesE.nId = Val(txtNroDonante.Text)
            'If cmbTipoDonante.SelectedValue > 0 Then DonantesE.nId_TipoDonante = cmbTipoDonante.SelectedValue
            If Trim(txtNombre.Text) <> "" Then DonantesE.sApellido_Nombre_RazonSocial = Trim(txtNombre.Text)
            If Trim(txtDireccion.Text) <> "" Then DonantesE.sDireccion = Trim(txtDireccion.Text)
            If Trim(txtLocalidad.Text) <> "" Then DonantesE.sLocalidad = Trim(txtLocalidad.Text)
            If Trim(txtCodigoPostal.Text) <> "" Then DonantesE.sCP = Trim(txtCodigoPostal.Text)
            If cmbProvincia.SelectedValue > 0 Then DonantesE.nId_Provincia = cmbProvincia.SelectedValue
            'If Val(txtNroDocumento.Text) <> 0 Then DonantesE.sDNI_CUIL_CUIT = Trim(txtNroDocumento.Text)
            'If Trim(txtTE.Text) <> "" Then DonantesE.sTE_Linea_Celular_Laboral = Trim(txtTE.Text)
            'If Trim(txtEMail.Text) <> "" Then DonantesE.sEMail = Trim(txtEMail.Text)

            If Trim(txtNroDonacion.Text) <> "" Then DonacionesE.nId = Trim(txtNroDonacion.Text)
            If Trim(cmbEstado.SelectedValue) <> "-1" Then DonacionesE.sEstado = cmbEstado.SelectedValue
            'If cmbTipoDonacion.SelectedValue > 0 Then DonacionesE.nId_TipoDonacion = cmbTipoDonacion.SelectedValue
            'If Trim(cmbTarjeta.SelectedValue) <> "-1" Then DonacionesE.sId_Tarjeta = cmbTarjeta.SelectedValue
            'If Trim(txtNroTarjetaCBU.Text) <> "" Then DonacionesE.sNroTarjeta_CBU = Trim(txtNroTarjetaCBU.Text)
            If cmbCampania.SelectedValue > 0 Then DonacionesE.nId_Campania = cmbCampania.SelectedValue

            grd.DataSource = DonantesN.Listado(DonantesE, DonacionesE)
            grd.DataBind()

            DonantesN = Nothing
            DonantesE = Nothing
            DonacionesE = Nothing

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

            DonacionesE.nId_Donante = nId_Donante

            dt = DonacionesN.Listado(DonacionesE)

            If dt.Rows.Count > 0 Then
                lblDonante.Text = "Donaciones - Nro. de Donante " & DonacionesE.nId_Donante.ToString
            Else
                lblDonante.Text = "Donaciones"
            End If

            grdD.DataSource = dt
            grdD.DataBind()

            DonacionesN = Nothing
            DonacionesE = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Function BajaDonacion(nId_Donacion As Integer) As Boolean
        Dim DonacionesN As DonacionesN
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable
        Dim bResultado = False

        Try
            DonacionesN = New DonacionesN
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonacionesE.nId = nId_Donacion
            DonacionesE.sEstado = "B"

            dt = DonacionesN.Estado(DonacionesE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then
                    bResultado = True
                ElseIf dt.Select("Id = -1").Count = 1 Then
                    bResultado = False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Baja de Donación - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    bResultado = False
                End If
            End If

            DonacionesN = Nothing
            DonacionesE = Nothing
            dt = Nothing

            Return bResultado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

    Public Function ImagenEstado_Obtener(sId_Estado As String) As String
        Dim sURL As String = ""

        If sId_Estado = "A" Then
            sURL = "~/Resources/Baja.png"
        ElseIf sId_Estado = "B" Then
            sURL = "~/Resources/Baja_Deshabilitado.png"
        End If

        Return sURL
    End Function

    Public Function ImagenModificar_Obtener(sId_Estado As String) As String
        Dim sURL As String = ""

        If sId_Estado = "A" Then
            sURL = "~/Resources/Modificar.png"
        ElseIf sId_Estado = "B" Then
            sURL = "~/Resources/Modificar_Deshabilitado.png"
        End If

        Return sURL
    End Function

    Public Function HabilitarEstado_Obtener(sId_Estado As String) As Boolean
        Dim bEstado As Boolean = False

        If sId_Estado = "A" Then
            bEstado = True
        ElseIf sId_Estado = "B" Then
            bEstado = False
        End If

        Return bEstado
    End Function

    Private Function Estado(nId As Integer) As Boolean
        Dim DonacionesN As DonacionesN
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            DonacionesN = New DonacionesN
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonacionesE.nId = nId
            DonacionesE.sEstado = "B"

            dt = DonacionesN.Estado(DonacionesE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then
                    bResultado = True
                ElseIf dt.Select("Id = -1").Count = 1 Then
                    bResultado = False
                Else
                    If dt.Select("Id = 0").Count = 1 Then
                        bResultado = True
                    ElseIf dt.Select("Id = -1").Count = 1 Then
                        bResultado = False
                    Else
                        'mostrar mensaje de error
                        lblTituloError.Text = "Baja de Donación - Error"
                        lblError.Text = ""

                        For i = 0 To dt.Rows.Count - 1
                            If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                            lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                        Next

                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                        upModal_Error.Update()

                        bResultado = False
                    End If
                End If
            End If

            DonacionesN = Nothing
            DonacionesE = Nothing
            dt = Nothing

            Return bResultado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

    Private Sub Detalle(nId_Donacion As Integer)
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonantesE.nId = nId_Donacion

            dt = DonantesN.Listado(DonantesE, DonacionesE)

            If dt.Rows.Count > 0 Then
                'mostrar detalle
                lblTituloDetalle.Text = "Donante - Detalle"

                lblNroDonante.Text = dt.Rows(0).Item("Id")
                If Not IsDBNull(dt.Rows(0).Item("FechaIng")) Then lblFechaIng.Text = dt.Rows(0).Item("FechaIng") Else lblFechaIng.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("TipoDonante")) Then lblTipoDonante.Text = dt.Rows(0).Item("TipoDonante") Else lblTipoDonante.Text = ""

                If Not IsDBNull(dt.Rows(0).Item("Nombre")) Then lblNombre.Text = dt.Rows(0).Item("Nombre") Else lblNombre.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("Direccion")) Then lblDireccion.Text = dt.Rows(0).Item("Direccion") Else lblDireccion.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("Localidad")) Then lblLocalidad.Text = dt.Rows(0).Item("Localidad") Else lblLocalidad.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("CP")) Then lblCodigoPostal.Text = dt.Rows(0).Item("CP") Else lblCodigoPostal.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("Provincia")) Then lblProvincia.Text = dt.Rows(0).Item("Provincia") Else lblProvincia.Text = ""

                If Not IsDBNull(dt.Rows(0).Item("DNI")) Then lblNroDocumento.Text = dt.Rows(0).Item("DNI") Else lblNroDocumento.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("CUIL_CUIT")) Then lblCUIT.Text = dt.Rows(0).Item("CUIL_CUIT") Else lblCUIT.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("TE")) Then lblTE.Text = dt.Rows(0).Item("TE") Else lblTE.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("EMail")) Then lblEMail.Text = dt.Rows(0).Item("EMail") Else lblEMail.Text = ""
                If Not IsDBNull(dt.Rows(0).Item("Comentarios")) Then lblComentarios.Text = dt.Rows(0).Item("Comentarios") Else lblComentarios.Text = ""

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

            Dim nNroDonacion As Integer = Request.QueryString("nrodonacion")
            Dim sEstado As String = Request.QueryString("id_estado")
            Dim nTipoDonacion As Integer = Request.QueryString("id_tipodonacion")
            Dim sTarjeta As String = Request.QueryString("id_tarjeta")
            Dim sNroTarjetaCBU As String = Request.QueryString("nrotarjeta")
            Dim nCampania As Integer = Request.QueryString("id_campania")

            If nNroDonante <> 0 Then txtNroDonante.Text = nNroDonante
            'If nTipoDonante <> 0 Then cmbTipoDonante.SelectedValue = Trim(nTipoDonante)
            If Not IsNothing(sNombre) Then txtNombre.Text = Trim(sNombre)
            If Not IsNothing(sDireccion) Then txtDireccion.Text = Trim(sDireccion)
            If Not IsNothing(sLocalidad) Then txtLocalidad.Text = Trim(sLocalidad)
            If Not IsNothing(sCodigoPostal) Then txtCodigoPostal.Text = Trim(sCodigoPostal)
            If nProvincia <> 0 Then cmbProvincia.SelectedValue = nProvincia
            'If nNroDocumento <> 0 Then txtNroDocumento.Text = nNroDocumento
            'If Not IsNothing(sTE) Then txtTE.Text = Trim(sTE)
            'If Not IsNothing(sEMail) Then txtEMail.Text = Trim(sEMail)

            If nNroDonacion <> 0 Then txtNroDonacion.Text = nNroDonacion
            If Not IsNothing(sEstado) Then cmbEstado.SelectedValue = Trim(sEstado)
            'If nTipoDonacion <> 0 Then cmbTipoDonacion.SelectedValue = nTipoDonacion
            'If Not IsNothing(sTarjeta) Then cmbTarjeta.SelectedValue = Trim(sTarjeta)
            'If Not IsNothing(sNroTarjetaCBU) Then txtNroTarjetaCBU.Text = Trim(sNroTarjetaCBU)
            If nCampania <> 0 Then cmbCampania.SelectedValue = nCampania

            CargarGrilla()

            CargarGrilla_Donaciones()
        End If
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("/frmDonantesAlta.aspx", True)
    End Sub

    Protected Sub btnNuevoD_Click(sender As Object, e As EventArgs) Handles btnNuevoD.Click
        Dim nId_Donante As Integer = Val(Request.QueryString("id_donante"))

        If nId_Donante <> 0 Then Response.Redirect("/frmDonacionesAlta.aspx?id_donante=" & nId_Donante.ToString, True)
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nNroDonante As Integer = Val(txtNroDonante.Text)
        'Dim nTipoDonante As Integer = cmbTipoDonante.SelectedValue
        Dim sNombre As String = Trim(txtNombre.Text)
        Dim sDireccion As String = Trim(txtDireccion.Text)
        Dim sLocalidad As String = Trim(txtLocalidad.Text)
        Dim sCodigoPostal As String = Trim(txtCodigoPostal.Text)
        Dim nProvincia As Integer = cmbProvincia.SelectedValue
        'Dim nNroDocumento As Integer = Val(txtNroDocumento.Text)
        'Dim sTE As String = Trim(txtTE.Text)
        'Dim sEMail As String = Trim(txtEMail.Text)

        Dim nNroDonacion As Integer = Val(txtNroDonacion.Text)
        Dim sEstado As String = cmbEstado.SelectedValue
        'Dim nTipoDonacion As Integer = cmbTipoDonacion.SelectedValue
        'Dim sTarjeta As String = cmbTarjeta.SelectedValue
        'Dim sNroTarjetaCBU As String = Trim(txtNroTarjetaCBU.Text)
        Dim nCampania As Integer = cmbCampania.SelectedValue

        'Response.Redirect("/frmDonantesListado.aspx?nrodonante=" & nNroDonante.ToString &
        '                                            "&id_tipodonante=" & nTipoDonante.ToString &
        '                                            "&nombre=" & sNombre &
        '                                            "&direccion=" & sDireccion &
        '                                            "&localidad=" & sLocalidad &
        '                                            "&codigopostal=" & sCodigoPostal &
        '                                            "&id_provincia=" & nProvincia.ToString &
        '                                            "&nrodocumento=" & nNroDocumento.ToString &
        '                                            "&telefono=" & sTE &
        '                                            "&email=" & sEMail &
        '                                            "&nrodonacion=" & nNroDonacion.ToString &
        '                                            "&id_estado=" & sEstado &
        '                                            "&id_tipodonacion=" & nTipoDonacion.ToString &
        '                                            "&id_tarjeta=" & sTarjeta &
        '                                            "&nrotarjeta=" & sNroTarjetaCBU &
        '                                            "&id_campania=" & nCampania.ToString, True)

        Response.Redirect("/frmDonantesListado.aspx?nrodonante=" & nNroDonante.ToString &
                                                "&nombre=" & sNombre &
                                                "&direccion=" & sDireccion &
                                                "&localidad=" & sLocalidad &
                                                "&codigopostal=" & sCodigoPostal &
                                                "&id_provincia=" & nProvincia.ToString &
                                                "&nrodonacion=" & nNroDonacion.ToString &
                                                "&id_estado=" & sEstado &
                                                "&id_campania=" & nCampania.ToString, True)
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
        If e.CommandName = "Modificar" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmDonantesModificacion.aspx?id=" & nId.ToString, True)

        ElseIf e.CommandName = "Detalle" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Detalle(nId)

        ElseIf e.CommandName = "VerDonaciones" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmDonantesListado.aspx?id_donante=" & nId.ToString, True)
        End If
    End Sub

    Protected Sub grdD_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdD.RowCommand
        Dim nId As Integer = 0
        If e.CommandName = "ModificarD" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmDonacionesModificacion.aspx?id=" & nId.ToString, True)

        ElseIf e.CommandName = "Baja" Then

            If MsgBox("Desea Dar de Baja la Donación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.Yes Then
                nId = Convert.ToInt32(e.CommandArgument)

                If BajaDonacion(nId) Then
                    MsgBox("La Donación fue Dada de Baja.", MsgBoxStyle.Information, "Robin")

                    Response.Redirect("/frmDonantesListado.aspx", True)
                End If
            End If
        End If
    End Sub
End Class