Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmCampaniasModificacion
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
        Dim CampaniasN As CampaniasN
        Dim CampaniasE As CampaniasE
        Dim dt As DataTable

        Try
            CampaniasN = New CampaniasN
            CampaniasE = New CampaniasE
            dt = New DataTable

            CampaniasE.nId = nId

            dt = CampaniasN.Obtener(CampaniasE)

            If dt.Rows.Count > 0 Then
                _nId = dt.Rows(0).Item("Id")
                txtNombre.Text = dt.Rows(0).Item("Campania")
                txtDescripcion.Text = dt.Rows(0).Item("Descripcion")
                lblEstado.Text = dt.Rows(0).Item("Estado")
                If Not IsDBNull(dt.Rows(0).Item("FechaAlta")) Then lblFechaAlta.Text = dt.Rows(0).Item("FechaAlta")
                If Not IsDBNull(dt.Rows(0).Item("FechaBaja")) Then lblFechaBaja.Text = dt.Rows(0).Item("FechaBaja")
            End If

            CampaniasN = Nothing
            CampaniasE = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Function Aceptar() As Boolean
        Dim CampaniasN As CampaniasN
        Dim CampaniasE As CampaniasE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            CampaniasN = New CampaniasN
            CampaniasE = New CampaniasE
            dt = New DataTable

            CampaniasE.nId = Val(Request.QueryString("id"))
            If Trim(txtNombre.Text) <> "" Then CampaniasE.sCampania = Trim(txtNombre.Text)
            If Trim(txtDescripcion.Text) <> "" Then CampaniasE.sDescripcion = Trim(txtDescripcion.Text)

            dt = CampaniasN.Modificar(CampaniasE)

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
                        lblTituloError.Text = "Modificación de Campaña - Error"
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

            CampaniasN = Nothing
            CampaniasE = Nothing
            dt = Nothing

            Return bResultado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

    Private Sub Cancelar()
        Response.Redirect("frmCampaniasListado.aspx", True)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim nId As Integer = 0

            nId = Val(Request.QueryString("id"))

            CargarDatos(nId)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Aceptar() Then
            Response.Redirect("frmCampaniasListado.aspx", True)
        End If
    End Sub
End Class