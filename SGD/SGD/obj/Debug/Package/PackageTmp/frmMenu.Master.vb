Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables
Public Class frmMenu
    Inherits System.Web.UI.MasterPage

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "

    Private Function CargarPerfil(sUsuario As String) As Integer
        Dim UsuariosN As UsuariosN
        Dim UsuariosE As UsuariosE
        Dim dt As DataTable
        Dim nId_TipoPerfil As Integer = 0

        Try
            UsuariosN = New UsuariosN
            UsuariosE = New UsuariosE
            dt = New DataTable

            UsuariosE.sUsuario = sUsuario

            dt = UsuariosN.Perfil_Obtener(UsuariosE)

            If dt.Rows.Count > 0 Then
                lblUsuario.Text = "[" & dt.Rows(0).Item("Usuario") & " / " & dt.Rows(0).Item("Perfil") & "]"
                nId_TipoPerfil = dt.Rows(0).Item("Id_TipoPerfil")
            End If

            UsuariosN = Nothing
            UsuariosE = Nothing
            dt = Nothing

            Return nId_TipoPerfil
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
            Return -1
        End Try
    End Function

    Private Sub HabilitarMenu(nId_TipoPerfil As ePerfiles)

        Try
            Select Case nId_TipoPerfil
                Case ePerfiles.Administrador
                    mnu.FindItem("mnuTablas").Enabled = True
                    mnu.FindItem("mnuArchivo").Enabled = True
                    mnu.FindItem("mnuConsultas").Enabled = True

                Case ePerfiles.Usuario_Consulta
                    mnu.FindItem("mnuTablas").Enabled = False
                    mnu.FindItem("mnuArchivo").Enabled = False
                    mnu.FindItem("mnuConsultas").Enabled = True

                Case Else
                    mnu.FindItem("mnuTablas").Enabled = False
                    mnu.FindItem("mnuArchivo").Enabled = False
                    mnu.FindItem("mnuConsultas").Enabled = False
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sUsuario As String = ""
            Dim nId_TipoPerfil As Integer = 0

            sUsuario = CType(Session.Item("Usuario"), String)

            nId_TipoPerfil = CargarPerfil(sUsuario)

            HabilitarMenu(nId_TipoPerfil)
        End If
    End Sub

End Class