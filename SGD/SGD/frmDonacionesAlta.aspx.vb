Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonacionesAlta
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

        With cmbTipoDonacion
            .DataSource = DonacionesN.TiposDonaciones_CargarCombo(False, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 1
        End With

        With cmbTarjeta
            .DataSource = TarjetasN.CargarCombo(False, False, cmbTipoDonacion.SelectedValue)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbCampania
            .DataSource = CampaniasN.CargarCombo(False, False, "A")
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        DonacionesN = Nothing
        TarjetasN = Nothing
        CampaniasN = Nothing
    End Sub

    Private Sub HabilitarCampos(nId_TipoDonacion As eDonaciones_Tipos)
        If nId_TipoDonacion = eDonaciones_Tipos.Tarjeta Then
            cmbTarjeta.Enabled = True
            txtNroTarjeta.Enabled = True
            txtBanco.Enabled = True
            txtVto.Enabled = True
            txtNroCBU.Enabled = False
        ElseIf nId_TipoDonacion = eDonaciones_Tipos.CBU Then
            cmbTarjeta.Enabled = False
            txtNroTarjeta.Enabled = False
            txtBanco.Enabled = False
            txtVto.Enabled = False
            txtNroCBU.Enabled = True
        Else
            cmbTarjeta.Enabled = False
            txtNroTarjeta.Enabled = False
            txtBanco.Enabled = False
            txtVto.Enabled = False
            txtNroCBU.Enabled = False
        End If
    End Sub

    Private Function Aceptar() As Integer
        Dim DonacionesN As DonacionesN
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable
        Dim nId_Donacion As Integer = 0

        Try
            DonacionesN = New DonacionesN
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonacionesE.nId_Donante = Val(lblNroDonante.Text)
            DonacionesE.nId_TipoDonacion = cmbTipoDonacion.SelectedValue

            If DonacionesE.nId_TipoDonacion = eDonaciones_Tipos.Tarjeta Then
                DonacionesE.sId_Tarjeta = cmbTarjeta.SelectedValue
                If Trim(txtNroTarjeta.Text) <> "" Then DonacionesE.sNroTarjeta = Trim(txtNroTarjeta.Text)
                If Trim(txtBanco.Text) <> "" Then DonacionesE.sBanco = Trim(txtBanco.Text)
                If Trim(txtVto.Text) <> "" Then DonacionesE.sVto = Trim(txtVto.Text)
            ElseIf DonacionesE.nId_TipoDonacion = eDonaciones_Tipos.CBU Then
                If Trim(txtNroCBU.Text) <> "" Then DonacionesE.sCBU = Trim(txtNroCBU.Text)
            End If

            If IsNumeric(txtMonto.Text) Then DonacionesE.nMonto = CDec(txtMonto.Text)
            If Val(txtTiempo.Text) > 0 Then DonacionesE.nTiempo = Val(txtTiempo.Text)
            If cmbCampania.SelectedValue > 0 Then DonacionesE.nId_Campania = cmbCampania.SelectedValue

            dt = DonacionesN.Agregar(DonacionesE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then
                    nId_Donacion = dt.Rows(0).Item("Id_Donacion")
                ElseIf dt.Select("Id = -1").Count = 1 Then
                    nId_Donacion = 0
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Alta de Donación - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    nId_Donacion = -1
                End If
            End If

            DonacionesN = Nothing
            DonacionesE = Nothing
            dt = Nothing

            Return nId_Donacion
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return -1
        End Try
    End Function

    Private Sub Cancelar()
        Response.Redirect("frmDonantesListado.aspx", True)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim nId As Integer = 0

            nId = Val(Request.QueryString("id_donante"))

            lblNroDonante.Text = nId

            CargarCombos()

            HabilitarCampos(cmbTipoDonacion.SelectedValue)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim nId_Donacion As Integer = 0

        nId_Donacion = Aceptar()

        If nId_Donacion > 0 Then
            MsgBox("Se Dió de Alta la Donación Nro. " & nId_Donacion.ToString & ".", MsgBoxStyle.Information, "Robin")

            Response.Redirect("/frmDonantesListado.aspx?id_donacion=" & nId_Donacion.ToString, True)
        End If
    End Sub

    Protected Sub cmbTipoDonacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDonacion.SelectedIndexChanged
        HabilitarCampos(cmbTipoDonacion.SelectedValue)
    End Sub
End Class