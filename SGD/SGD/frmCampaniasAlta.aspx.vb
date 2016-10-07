Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmCampaniasAlta
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Function Aceptar() As Boolean
        Dim CampaniasN As CampaniasN
        Dim CampaniasE As CampaniasE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            CampaniasN = New CampaniasN
            CampaniasE = New CampaniasE
            dt = New DataTable

            If Trim(txtNombre.Text) <> "" Then CampaniasE.sCampania = Trim(txtNombre.Text)
            If Trim(txtDescripcion.Text) <> "" Then CampaniasE.sDescripcion = Trim(txtDescripcion.Text)

            dt = CampaniasN.Agregar(CampaniasE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then
                    bResultado = True
                ElseIf dt.Select("Id = -1").Count = 1 Then
                    bResultado = False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Alta de Campaña - Error"
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