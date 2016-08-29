Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim UsuariosN As UsuariosN
        Dim UsuariosE As UsuariosE

        UsuariosN = New UsuariosN
        UsuariosE = New UsuariosE

        If Trim(txtUserName.Text) <> "" Then UsuariosE.sUsuario = txtUserName.Text
        If Trim(txtPassword.Text) <> "" Then UsuariosE.sPassword = txtPassword.Text
        UsuariosE.sEstado = "A"

        If UsuariosN.Ingresar(UsuariosE) Then
            Session("Usuario") = txtUserName.Text

            Response.Redirect("~/frmDonantes.aspx", True)
        End If

        UsuariosN = Nothing
        UsuariosE = Nothing
    End Sub
End Class