Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmTarjetasModificacion
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "
    Private _sId As String
    Public Property sId() As String
        Get
            Return _sId
        End Get
        Set(ByVal value As String)
            _sId = value
        End Set
    End Property
#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarDatos(sId As String)
        Dim TarjetasN As TarjetasN
        Dim TarjetasE As TarjetasE
        Dim dt As DataTable

        Try
            TarjetasN = New TarjetasN
            TarjetasE = New TarjetasE
            dt = New DataTable

            TarjetasE.sId = sId

            dt = TarjetasN.Obtener(TarjetasE)

            If dt.Rows.Count > 0 Then
                _sId = dt.Rows(0).Item("Id")
                lblId.Text = dt.Rows(0).Item("Id")
                txtNombre.Text = dt.Rows(0).Item("Tarjeta")
                lblTipoPresentacion.Text = dt.Rows(0).Item("TipoPresentacion")
                txtNombreArchivo.Text = dt.Rows(0).Item("NombreArchivo")
                txtNroComercio.Text = dt.Rows(0).Item("NroComercio")
            End If

            TarjetasN = Nothing
            TarjetasE = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Function Aceptar() As Boolean
        Dim TarjetasN As TarjetasN
        Dim TarjetasE As TarjetasE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            TarjetasN = New TarjetasN
            TarjetasE = New TarjetasE
            dt = New DataTable

            TarjetasE.sId = UCase(Request.QueryString("id"))
            If Trim(txtNombre.Text) <> "" Then TarjetasE.sTarjeta = Trim(txtNombre.Text)
            If Trim(txtNombreArchivo.Text) <> "" Then TarjetasE.sNombreArchivo = Trim(txtNombreArchivo.Text)
            If Trim(txtNroComercio.Text) <> "" Then TarjetasE.sNroComercio = Trim(txtNroComercio.Text)

            dt = TarjetasN.Modificar(TarjetasE)

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
                        lblTituloError.Text = "Modificación de Tarjeta - Error"
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

            TarjetasN = Nothing
            TarjetasE = Nothing
            dt = Nothing

            Return bResultado
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

    Private Sub Cancelar()
        Dim sId As String = ""

        sId = Request.QueryString("id")

        Response.Redirect("frmTarjetasListado.aspx?id_tarjeta=" & sId.ToString, True)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sId As String = ""

            sId = Request.QueryString("id")

            CargarDatos(sId)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Aceptar() Then
            Dim sId As String = ""

            sId = Request.QueryString("id")

            Response.Redirect("frmTarjetasListado.aspx?id_tarjeta=" & sId.ToString, True)
        End If
    End Sub
End Class