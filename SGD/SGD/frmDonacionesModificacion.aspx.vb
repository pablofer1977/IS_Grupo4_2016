Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonacionesModificacion
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "
    Private _nId As Integer
    Public Property nId() As Integer
        Get
            Return _nId
        End Get
        Set(ByVal value As Integer)
            _nId = value
        End Set
    End Property
#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarDatos(nId As Integer)
        Dim DonacionesN As DonacionesN
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable

        Try
            DonacionesN = New DonacionesN
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonacionesE.nId = nId

            dt = DonacionesN.Obtener(DonacionesE)

            If dt.Rows.Count > 0 Then
                _nId = dt.Rows(0).Item("Id")
                lblNroDonante.Text = dt.Rows(0).Item("Id_Donante")
                lblNroDonacion.Text = dt.Rows(0).Item("Id")
                If Not IsDBNull(dt.Rows(0).Item("Id_TipoDonacion")) Then cmbTipoDonacion.SelectedValue = dt.Rows(0).Item("Id_TipoDonacion")

                If Not IsDBNull(dt.Rows(0).Item("Id_Tarjeta")) Then cmbTarjeta.SelectedValue = dt.Rows(0).Item("Id_Tarjeta")
                If Not IsDBNull(dt.Rows(0).Item("NroTarjeta")) Then txtNroTarjeta.Text = dt.Rows(0).Item("NroTarjeta")
                If Not IsDBNull(dt.Rows(0).Item("Banco")) Then txtBanco.Text = dt.Rows(0).Item("Banco")
                If Not IsDBNull(dt.Rows(0).Item("Vto")) Then txtVto.Text = dt.Rows(0).Item("Vto")
                If Not IsDBNull(dt.Rows(0).Item("CBU")) Then txtNroCBU.Text = dt.Rows(0).Item("CBU")
                If Not IsDBNull(dt.Rows(0).Item("Monto")) Then txtMonto.Text = dt.Rows(0).Item("Monto")
                If Not IsDBNull(dt.Rows(0).Item("Tiempo")) Then txtTiempo.Text = dt.Rows(0).Item("Tiempo")
                If Not IsDBNull(dt.Rows(0).Item("Id_Campania")) Then cmbCampania.SelectedValue = dt.Rows(0).Item("Id_Campania")

                lblEstado.Text = dt.Rows(0).Item("Estado")
                If Not IsDBNull(dt.Rows(0).Item("FechaDon")) Then lblFechaAlta.Text = dt.Rows(0).Item("FechaDon")
                If Not IsDBNull(dt.Rows(0).Item("FechaBaja")) Then lblFechaBaja.Text = dt.Rows(0).Item("FechaBaja")
            End If

            DonacionesN = Nothing
            DonacionesE = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

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

    Private Function Aceptar() As Boolean
        Dim DonacionesN As DonacionesN
        Dim DonacionesE As DonacionesE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            DonacionesN = New DonacionesN
            DonacionesE = New DonacionesE
            dt = New DataTable

            DonacionesE.nId = Val(lblNroDonacion.Text)
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

            dt = DonacionesN.Modificar(DonacionesE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then
                    bResultado = True
                ElseIf dt.Select("Id = -1").Count = 1 Then
                    bResultado = False
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

                    bResultado = False
                End If
            End If

            DonacionesN = Nothing
            DonacionesE = Nothing
            dt = Nothing

            Return bResultado
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

            nId = Val(Request.QueryString("id"))

            CargarCombos()
            CargarDatos(nId)

            HabilitarCampos(cmbTipoDonacion.SelectedValue)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Aceptar() Then
            Response.Redirect("frmDonantesListado.aspx", True)
        End If
    End Sub

    Protected Sub cmbTipoDonacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDonacion.SelectedIndexChanged
        HabilitarCampos(cmbTipoDonacion.SelectedValue)
    End Sub
End Class