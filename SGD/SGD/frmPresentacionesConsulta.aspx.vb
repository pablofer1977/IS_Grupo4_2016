Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmPresentacionesConsulta
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

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
            .DataSource = DonacionesN.TiposDonaciones_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 0
        End With

        With cmbTarjeta
            .DataSource = TarjetasN.CargarCombo(True, False, 0)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 0
        End With

        With cmbMes
            .DataSource = PresentacionesN.Meses_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 0
        End With

        DonacionesN = Nothing
        TarjetasN = Nothing
        PresentacionesN = Nothing
    End Sub

    Private Sub CargarGrilla()
        Dim PresentacionesN As PresentacionesN
        Dim PresentacionesE As PresentacionesE

        Try
            PresentacionesN = New PresentacionesN
            PresentacionesE = New PresentacionesE

            If Val(txtNroPresentacion.Text) > 0 Then PresentacionesE.nId = Val(txtNroPresentacion.Text)
            If cmbTipoPresentacion.SelectedValue > 0 Then PresentacionesE.nId_TipoPresentacion = cmbTipoPresentacion.SelectedValue
            If Trim(cmbTarjeta.SelectedValue) <> "-1" Then PresentacionesE.sId_Tarjeta = cmbTarjeta.SelectedValue
            If cmbMes.SelectedValue > 0 Then PresentacionesE.nMes = cmbMes.SelectedValue
            If Val(txtAnio.Text) > 0 Then PresentacionesE.nAnio = Val(txtAnio.Text)

            grd.DataSource = PresentacionesN.Listado(PresentacionesE)
            grd.DataBind()

            PresentacionesN = Nothing
            PresentacionesE = Nothing

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub CargarGrilla_Detalles()
        Dim PresentacionesN As PresentacionesN
        Dim PresentacionesE As PresentacionesE
        Dim dt As DataTable

        Dim nId_Presentacion As Integer = Request.QueryString("id_presentacion")

        Try
            PresentacionesN = New PresentacionesN
            PresentacionesE = New PresentacionesE
            dt = New DataTable

            PresentacionesE.nId = nId_Presentacion

            dt = PresentacionesN.Detalles_Listado(PresentacionesE)

            If dt.Rows.Count > 0 Then
                lblPresentacion.Text = "Listado de Detalles [Presentación Nro.: " & PresentacionesE.nId.ToString & "]"
            Else
                lblPresentacion.Text = "Listado de Detalles"
            End If

            grdD.DataSource = dt
            grdD.DataBind()

            PresentacionesN = Nothing
            PresentacionesE = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()

            Dim nNroPresentacion As Integer = Request.QueryString("nropresentacion")
            Dim nTipoPresentacion As Integer = Request.QueryString("id_tipopresentacion")
            Dim sTarjeta As String = Request.QueryString("id_tarjeta")
            Dim nMes As String = Request.QueryString("mes")
            Dim nAnio As String = Request.QueryString("anio")

            If nNroPresentacion <> 0 Then txtNroPresentacion.Text = Trim(nNroPresentacion)
            If nTipoPresentacion <> 0 Then cmbTipoPresentacion.SelectedValue = Trim(nTipoPresentacion)
            If Not IsNothing(sTarjeta) Then cmbTarjeta.SelectedValue = Trim(sTarjeta)
            If nMes <> 0 Then cmbMes.SelectedValue = Trim(nMes)
            If nAnio <> 0 Then txtAnio.Text = Trim(nAnio)

            CargarGrilla()

            CargarGrilla_Detalles()
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim nNroPresentacion As Integer = Val(txtNroPresentacion.Text)
        Dim nTipoPresentacion As Integer = cmbTipoPresentacion.SelectedValue
        Dim sTarjeta As String = cmbTarjeta.SelectedValue
        Dim nMes As Integer = cmbMes.SelectedValue
        Dim nAnio As Integer = Val(txtAnio.Text)

        Response.Redirect("/frmPresentacionesConsulta.aspx?nropresentacion=" & nNroPresentacion.ToString &
                                                    "&id_tipopresentacion=" & nTipoPresentacion.ToString &
                                                    "&id_tarjeta=" & sTarjeta &
                                                    "&mes=" & nMes.ToString &
                                                    "&anio=" & nAnio.ToString, True)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub

    Protected Sub grdD_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdD.PageIndexChanging
        grdD.PageIndex = e.NewPageIndex

        CargarGrilla_Detalles()
    End Sub

    Protected Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        Dim nId As Integer = 0

        If e.CommandName = "VerDetalles" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmPresentacionesConsulta.aspx?id_presentacion=" & nId.ToString, True)
        End If
    End Sub
End Class