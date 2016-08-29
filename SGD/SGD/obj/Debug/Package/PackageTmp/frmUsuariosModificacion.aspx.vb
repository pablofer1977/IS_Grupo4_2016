Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmUsuariosModificacion
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "
    Private _sUsuario As String
    Public Property sUsuario() As String
        Get
            Return _sUsuario
        End Get
        Set(ByVal value As String)
            _sUsuario = value
        End Set
    End Property
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

    Private Sub CargarDatos(sUsuario As String)
        Dim UsuariosN As UsuariosN
        Dim UsuariosE As UsuariosE
        Dim dt As DataTable

        Try
            UsuariosN = New UsuariosN
            UsuariosE = New UsuariosE
            dt = New DataTable

            UsuariosE.sUsuario = sUsuario

            dt = UsuariosN.Obtener(UsuariosE)

            If dt.Rows.Count > 0 Then
                lblUsuario.Text = dt.Rows(0).Item("Usuario")
                txtNombre.Text = dt.Rows(0).Item("Nombre")
                cmdPerfil.SelectedValue = dt.Rows(0).Item("Id_TipoPerfil")
                lblEstado.Text = dt.Rows(0).Item("Estado")
                If Not IsDBNull(dt.Rows(0).Item("FechaAlta")) Then lblFechaAlta.Text = dt.Rows(0).Item("FechaAlta")
                If Not IsDBNull(dt.Rows(0).Item("FechaBaja")) Then lblFechaBaja.Text = dt.Rows(0).Item("FechaBaja")
            End If

            UsuariosN = Nothing
            UsuariosE = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Function Aceptar() As Boolean
        Dim UsuariosN As UsuariosN
        Dim UsuariosE As UsuariosE
        Dim bResultado As Boolean = False

        Try
            UsuariosN = New UsuariosN
            UsuariosE = New UsuariosE

            UsuariosE.sUsuario = Request.QueryString("usuario")
            UsuariosE.sNombre = Trim(txtNombre.Text)
            UsuariosE.nId_TipoPerfil = cmdPerfil.SelectedValue

            bResultado = UsuariosN.Modificar(UsuariosE)

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
            Dim sUsuario As String = ""

            sUsuario = Request.QueryString("usuario")

            CargarCombos()
            CargarDatos(sUsuario)
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