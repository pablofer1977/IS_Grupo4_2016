Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonantesModificacion
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
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim dt As DataTable

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            dt = New DataTable

            DonantesE.nId = nId

            dt = DonantesN.Obtener(DonantesE)

            If dt.Rows.Count > 0 Then
                _nId = dt.Rows(0).Item("Id")
                lblNroDonante.Text = dt.Rows(0).Item("Id")
                If Not IsDBNull(dt.Rows(0).Item("FechaIng")) Then lblFechaIng.Text = dt.Rows(0).Item("FechaIng")
                If Not IsDBNull(dt.Rows(0).Item("Id_TipoDonante")) Then cmbTipoDonante.SelectedValue = dt.Rows(0).Item("Id_TipoDonante")

                If Not IsDBNull(dt.Rows(0).Item("Apellido")) Then txtApellido.Text = dt.Rows(0).Item("Apellido")
                If Not IsDBNull(dt.Rows(0).Item("Nombre")) Then txtNombre.Text = dt.Rows(0).Item("Nombre")
                If Not IsDBNull(dt.Rows(0).Item("Razon_Social")) Then txtRazonSocial.Text = dt.Rows(0).Item("Razon_Social")
                If Not IsDBNull(dt.Rows(0).Item("Direccion")) Then txtDireccion.Text = dt.Rows(0).Item("Direccion")
                If Not IsDBNull(dt.Rows(0).Item("Localidad")) Then txtLocalidad.Text = dt.Rows(0).Item("Localidad")
                If Not IsDBNull(dt.Rows(0).Item("CP")) Then txtCodigoPostal.Text = dt.Rows(0).Item("CP")
                If Not IsDBNull(dt.Rows(0).Item("Id_Provincia")) Then cmbProvincia.SelectedValue = dt.Rows(0).Item("Id_Provincia")

                If Not IsDBNull(dt.Rows(0).Item("DNI")) Then txtNroDocumento.Text = dt.Rows(0).Item("DNI")
                If Not IsDBNull(dt.Rows(0).Item("CUIL_CUIT")) Then txtCUIT.Text = dt.Rows(0).Item("CUIL_CUIT")
                If Not IsDBNull(dt.Rows(0).Item("TE_Linea")) Then txtTE_Linea.Text = dt.Rows(0).Item("TE_Linea")
                If Not IsDBNull(dt.Rows(0).Item("TE_Celular")) Then txtTE_Celular.Text = dt.Rows(0).Item("TE_Celular")
                If Not IsDBNull(dt.Rows(0).Item("TE_Laboral")) Then txtTE_Laboral.Text = dt.Rows(0).Item("TE_Laboral")
                If Not IsDBNull(dt.Rows(0).Item("EMail")) Then txtEMail.Text = dt.Rows(0).Item("EMail")
                If Not IsDBNull(dt.Rows(0).Item("Comentarios")) Then txtComentarios.Text = dt.Rows(0).Item("Comentarios")
            End If

            DonantesN = Nothing
            DonantesE = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub CargarCombos()
        Dim DonantesN As DonantesN

        DonantesN = New DonantesN

        With cmbTipoDonante
            .DataSource = DonantesN.TiposDonantes_CargarCombo(False, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 1
        End With

        With cmbProvincia
            .DataSource = DonantesN.Provincias_CargarCombo(False, True)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 0
        End With

        DonantesN = Nothing
    End Sub

    Private Sub HabilitarCampos(nId_TipoDonante As eDonantes_Tipos)
        If nId_TipoDonante = eDonantes_Tipos.Fisico Then
            txtApellido.Enabled = True
            txtNombre.Enabled = True
            txtRazonSocial.Enabled = False
            txtNroDocumento.Enabled = True
        ElseIf nId_TipoDonante = eDonantes_Tipos.Juridico Then
            txtApellido.Enabled = False
            txtNombre.Enabled = False
            txtRazonSocial.Enabled = True
            txtNroDocumento.Enabled = False
        Else
            txtApellido.Enabled = False
            txtNombre.Enabled = False
            txtRazonSocial.Enabled = False
            txtNroDocumento.Enabled = False
        End If
    End Sub

    Private Function Aceptar() As Boolean
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            dt = New DataTable

            DonantesE.nId = Val(lblNroDonante.Text)
            DonantesE.nId_TipoDonante = cmbTipoDonante.SelectedValue

            If DonantesE.nId_TipoDonante = eDonantes_Tipos.Fisico Then
                If Trim(txtApellido.Text) <> "" Then DonantesE.sApellido = Trim(txtApellido.Text)
                If Trim(txtNombre.Text) <> "" Then DonantesE.sNombre = Trim(txtNombre.Text)
            ElseIf DonantesE.nId_TipoDonante = eDonantes_Tipos.Juridico Then
                If Trim(txtRazonSocial.Text) <> "" Then DonantesE.sRazon_Social = Trim(txtRazonSocial.Text)
            End If

            If Trim(txtDireccion.Text) <> "" Then DonantesE.sDireccion = Trim(txtDireccion.Text)
            If Trim(txtLocalidad.Text) <> "" Then DonantesE.sLocalidad = Trim(txtLocalidad.Text)
            If Trim(txtCodigoPostal.Text) <> "" Then DonantesE.sCP = Trim(txtCodigoPostal.Text)
            If cmbProvincia.SelectedValue > 0 Then DonantesE.nId_Provincia = cmbProvincia.SelectedValue

            If DonantesE.nId_TipoDonante = eDonantes_Tipos.Fisico Then
                If Trim(txtNroDocumento.Text) <> "" Then DonantesE.sDNI = Trim(txtNroDocumento.Text)
            End If

            If Trim(txtCUIT.Text) <> "" Then DonantesE.sCUIL_CUIT = Trim(txtCUIT.Text)
            If Trim(txtTE_Linea.Text) <> "" Then DonantesE.sTE_Linea = Trim(txtTE_Linea.Text)
            If Trim(txtTE_Celular.Text) <> "" Then DonantesE.sTE_Celular = Trim(txtTE_Celular.Text)
            If Trim(txtTE_Laboral.Text) <> "" Then DonantesE.sTE_Laboral = Trim(txtTE_Laboral.Text)
            If Trim(txtEMail.Text) <> "" Then DonantesE.sEMail = Trim(txtEMail.Text)
            If Trim(txtComentarios.Text) <> "" Then DonantesE.sComentarios = Trim(txtComentarios.Text)

            dt = DonantesN.Modificar(DonantesE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then
                    bResultado = True
                ElseIf dt.Select("Id = -1").Count = 1 Then
                    bResultado = False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Modificación de Donante - Error"
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

            DonantesN = Nothing
            DonantesE = Nothing
            dt = Nothing

            Return bResultado
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
            Dim nId As Integer = 0

            nId = Val(Request.QueryString("id"))

            CargarCombos()
            CargarDatos(nId)

            HabilitarCampos(cmbTipoDonante.SelectedValue)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Aceptar() Then
            MsgBox("Se Modificaron los Datos del Donante", MsgBoxStyle.Information, "Robin")

            Response.Redirect("frmDonantesListado.aspx", True)
        End If
    End Sub

    Protected Sub cmbTipoDonante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDonante.SelectedIndexChanged
        HabilitarCampos(cmbTipoDonante.SelectedValue)
    End Sub
End Class