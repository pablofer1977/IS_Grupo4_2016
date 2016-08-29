Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmUsuariosListado
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim UsuariosN As UsuariosN

        UsuariosN = New UsuariosN

        With cmdPerfil
            .DataSource = UsuariosN.TiposPerfiles_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = -1
        End With

        With cmdEstado
            .DataSource = UsuariosN.Estado_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = "A"
        End With

        UsuariosN = Nothing
    End Sub

    Private Sub CargarGrilla()
        Dim UsuariosN As UsuariosN
        Dim UsuariosE As UsuariosE

        Try
            UsuariosN = New UsuariosN
            UsuariosE = New UsuariosE

            If Trim(txtUsuario.Text) <> "" Then UsuariosE.sUsuario = Trim(txtUsuario.Text)
            If Trim(txtNombre.Text) <> "" Then UsuariosE.sNombre = Trim(txtNombre.Text)
            If cmdPerfil.SelectedValue <> -1 Then UsuariosE.nId_TipoPerfil = cmdPerfil.SelectedValue
            If Trim(cmdEstado.SelectedValue) <> "-1" Then UsuariosE.sEstado = cmdEstado.SelectedValue

            grd.DataSource = UsuariosN.Listado(UsuariosE)
            grd.DataBind()

            UsuariosN = Nothing
            UsuariosE = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Public Function ImagenEstado_Obtener(sId_Estado As String) As String
        Dim sURL As String = ""

        If sId_Estado = "A" Then
            sURL = "~/Resources/Baja.png"
        ElseIf sId_Estado = "B" Then
            sURL = "~/Resources/Baja_Deshabilitado.png"
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

    Private Function Estado(sUsuario As String) As Boolean
        Dim UsuariosN As UsuariosN
        Dim UsuariosE As UsuariosE
        Dim bResultado As Boolean = False

        Try
            UsuariosN = New UsuariosN
            UsuariosE = New UsuariosE

            UsuariosE.sUsuario = sUsuario
            UsuariosE.sEstado = "B"

            bResultado = UsuariosN.Estado(UsuariosE)

            UsuariosN = Nothing
            UsuariosE = Nothing

            Return bResultado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()

            Dim sUsuario As String = ""
            Dim sNombre As String = ""
            Dim sPerfil As String = ""
            Dim sEstado As String = ""

            If Not IsNothing(Request.QueryString("usuario")) Then sUsuario = Request.QueryString("usuario")
            If Not IsNothing(Request.QueryString("nombre")) Then sNombre = Request.QueryString("nombre")
            If Not IsNothing(Request.QueryString("perfil")) Then sPerfil = Request.QueryString("perfil")
            If Not IsNothing(Request.QueryString("estado")) Then sEstado = Request.QueryString("estado")

            If Trim(sUsuario) <> "" Then txtUsuario.Text = Trim(sUsuario)
            If Trim(sNombre) <> "" Then txtNombre.Text = Trim(sNombre)
            If Trim(sPerfil) <> "" Then cmdPerfil.SelectedValue = Trim(sPerfil)
            If Trim(sEstado) <> "" Then cmdEstado.SelectedValue = Trim(sEstado)

            CargarGrilla()
        End If
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("/frmUsuariosAlta.aspx", True)
    End Sub

    Protected Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        Dim sUsuario As String = ""
        If e.CommandName = "Modificar" Then
            sUsuario = e.CommandArgument
            Response.Redirect("/frmUsuariosModificacion.aspx?usuario=" & sUsuario, True)

        ElseIf e.CommandName = "Estado" Then
            sUsuario = e.CommandArgument

            If MsgBox("Desea Dar de Baja al Usuario?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Robin") = MsgBoxResult.Yes Then
                If Estado(sUsuario) Then
                    CargarGrilla()
                End If
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim sUsuario As String = Trim(txtUsuario.Text)
        Dim sNombre As String = Trim(txtNombre.Text)
        Dim sId_Perfil As String = cmdPerfil.SelectedValue
        Dim sEstado As String = cmdEstado.SelectedValue

        Response.Redirect("/frmUsuariosListado.aspx?usuario=" & sUsuario & "&nombre=" & sNombre & "&perfil=" & sId_Perfil & "&estado=" & sEstado, True)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub
End Class