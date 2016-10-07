Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmUsuariosAlta
        Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim UsuariosN As UsuariosN

        UsuariosN = New UsuariosN

        With cmdPerfil
            .DataSource = UsuariosN.TiposPerfiles_CargarCombo(False, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        UsuariosN = Nothing
    End Sub

    Private Function Aceptar() As Boolean
        Dim UsuariosN As UsuariosN
        Dim UsuariosE As UsuariosE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            UsuariosN = New UsuariosN
            UsuariosE = New UsuariosE
            dt = New DataTable

            If Trim(txtUsuario.Text) <> "" Then UsuariosE.sUsuario = Trim(txtUsuario.Text)
            If Trim(txtNombre.Text) <> "" Then UsuariosE.sNombre = Trim(txtNombre.Text)
            If Trim(txtPassword.Text) <> "" Then UsuariosE.sPassword = txtPassword.Text
            If Trim(txtPassword2.Text) <> "" Then UsuariosE.sPassword2 = txtPassword2.Text
            UsuariosE.nId_TipoPerfil = cmdPerfil.SelectedValue

            dt = UsuariosN.Agregar(UsuariosE)

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
                        lblTituloError.Text = "Alta de Usuario - Error"
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

            UsuariosN = Nothing
            UsuariosE = Nothing
            dt = Nothing

            Return bResultado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

    Private Sub Cancelar()
        Response.Redirect("frmUsuariosListado.aspx", True)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Aceptar() Then
            Response.Redirect("frmUsuariosListado.aspx", True)
        End If
    End Sub
End Class