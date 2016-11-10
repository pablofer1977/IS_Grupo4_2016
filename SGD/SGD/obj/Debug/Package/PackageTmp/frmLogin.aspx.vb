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
        Dim dt As DataTable

        UsuariosN = New UsuariosN
        UsuariosE = New UsuariosE
        dt = New DataTable

        If Trim(txtUserName.Text) <> "" Then UsuariosE.sUsuario = txtUserName.Text
        If Trim(txtPassword.Text) <> "" Then UsuariosE.sPassword = txtPassword.Text
        UsuariosE.sEstado = "A"

        'valido los datos ingresados
        dt = UsuariosN.Ingresar(UsuariosE)

        If dt.Rows.Count = 0 Then
            Session("Usuario") = txtUserName.Text

            Response.Redirect("~/frmDonantesListado.aspx", True)
        Else
            'mostrar mensaje de error
            lblTituloError.Text = "Login - Error"
            lblError.Text = ""

            For i = 0 To dt.Rows.Count - 1
                If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
            Next

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
            upModal_Error.Update()
        End If

        UsuariosN = Nothing
        UsuariosE = Nothing
        dt = Nothing
    End Sub
End Class