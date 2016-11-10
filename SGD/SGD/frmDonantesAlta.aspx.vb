Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonantesAlta
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
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

    Private Function Aceptar() As Integer
        Dim DonantesN As DonantesN
        Dim DonantesE As DonantesE
        Dim dt As DataTable
        Dim nId_Donante As Integer = 0

        Try
            DonantesN = New DonantesN
            DonantesE = New DonantesE
            dt = New DataTable

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

            dt = DonantesN.Agregar(DonantesE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then
                    nId_Donante = dt.Rows(0).Item("Id_Donante")
                ElseIf dt.Select("Id = -1").Count = 1 Then
                    nId_Donante = 0
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Alta de Donante - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    nId_Donante = -1
                End If
            End If

            DonantesN = Nothing
            DonantesE = Nothing
            dt = Nothing

            Return nId_Donante
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
            CargarCombos()

            HabilitarCampos(cmbTipoDonante.SelectedValue)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim nId_Donante As Integer = 0

        nId_Donante = Aceptar()

        If nId_Donante > 0 Then
            If MsgBox("Se Dió de Alta al Donante Nro. " & nId_Donante.ToString & "." & vbCr & vbCr & "Desea Dar de Alta su Donación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.Yes Then
                Response.Redirect("/frmDonacionesAlta.aspx?id_donante=" & nId_Donante.ToString, True)
            Else
                Response.Redirect("frmDonantesListado.aspx", True)
            End If
        End If
    End Sub

    Protected Sub cmbTipoDonante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoDonante.SelectedIndexChanged
        HabilitarCampos(cmbTipoDonante.SelectedValue)
    End Sub
End Class