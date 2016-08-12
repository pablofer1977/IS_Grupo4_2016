Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmCampaniasListado
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarGrilla()
        Dim CampaniasN As CampaniasN
        Dim CampaniasE As CampaniasE

        Try
            CampaniasN = New CampaniasN
            CampaniasE = New CampaniasE

            grd.DataSource = CampaniasN.Listado(CampaniasE)
            grd.DataBind()

            CampaniasN = Nothing
            CampaniasE = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub Modificar(nFila As Integer)
        Dim nId As Integer = 0

        If grd.Rows.Count > 0 Then
            nId = grd.Rows(nFila).Cells(3).Text

            Response.Redirect("/frmCampaniasModificacion.aspx?id=" & nId.ToString, True)
        End If
    End Sub
    Private Sub Eliminar(nFila As Integer)
        Dim nId As Integer = 0

        If grd.Rows.Count > 0 Then
            nId = grd.Rows(nFila).Cells(3).Text

            'Response.Redirect("~/frmCampaniasABM.aspx?id=" & nId.ToString, True)
        End If
    End Sub
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarGrilla()
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("/frmCampaniasAlta.aspx", True)
    End Sub

    Private Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        If e.CommandName = "Modificar" Then
            Modificar(Convert.ToInt32(e.CommandArgument))
        ElseIf e.CommandName = "Eliminar" Then
            Eliminar(Convert.ToInt32(e.CommandArgument))
        End If
    End Sub
End Class