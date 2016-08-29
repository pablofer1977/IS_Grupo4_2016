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
        Dim bResultado As Boolean = False

        Try
            CampaniasN = New CampaniasN
            CampaniasE = New CampaniasE

            CampaniasE.sCampania = Trim(txtNombre.Text)
            CampaniasE.sDescripcion = Trim(txtDescripcion.Text)

            bResultado = CampaniasN.Agregar(CampaniasE)

            CampaniasN = Nothing
            CampaniasE = Nothing

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