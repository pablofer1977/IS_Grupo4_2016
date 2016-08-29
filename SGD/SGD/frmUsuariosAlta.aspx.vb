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
        Dim bResultado As Boolean = False

        Try
            UsuariosN = New UsuariosN
            UsuariosE = New UsuariosE

            UsuariosE.sUsuario = Trim(txtUsuario.Text)
            UsuariosE.sNombre = Trim(txtNombre.Text)
            UsuariosE.sPassword = txtPassword.Text
            UsuariosE.sPassword2 = txtPassword2.Text
            UsuariosE.nId_TipoPerfil = cmdPerfil.SelectedValue

            bResultado = UsuariosN.Agregar(UsuariosE)

            UsuariosN = Nothing
            UsuariosE = Nothing

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