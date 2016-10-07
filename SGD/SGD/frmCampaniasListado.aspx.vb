Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmCampaniasListado
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim CampaniasN As CampaniasN

        CampaniasN = New CampaniasN

        With cmdEstado
            .DataSource = CampaniasN.Estados_CargarCombo(True, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        CampaniasN = Nothing
    End Sub

    Private Sub CargarGrilla()
        Dim CampaniasN As CampaniasN
        Dim CampaniasE As CampaniasE

        Try
            CampaniasN = New CampaniasN
            CampaniasE = New CampaniasE

            If Trim(txtCampania.Text) <> "" Then CampaniasE.sCampania = Trim(txtCampania.Text)
            If Trim(cmdEstado.SelectedValue) <> "-1" Then CampaniasE.sEstado = cmdEstado.SelectedValue

            grd.DataSource = CampaniasN.Listado(CampaniasE)
            grd.DataBind()

            CampaniasN = Nothing
            CampaniasE = Nothing
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

    Private Function Estado(nId As Integer) As Boolean
        Dim CampaniasN As CampaniasN
        Dim CampaniasE As CampaniasE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            CampaniasN = New CampaniasN
            CampaniasE = New CampaniasE
            dt = New DataTable

            CampaniasE.nId = nId
            CampaniasE.sEstado = "B"

            dt = CampaniasN.Estado(CampaniasE)

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
                        lblTituloError.Text = "Baja de Campaña - Error"
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

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()

            Dim sCampania As String = Request.QueryString("campania")
            Dim sEstado As String = Request.QueryString("estado")

            If Not IsNothing(sCampania) Then txtCampania.Text = Trim(sCampania)
            If Not IsNothing(sEstado) Then cmdEstado.SelectedValue = Trim(sEstado)

            CargarGrilla()
        End If
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Response.Redirect("/frmCampaniasAlta.aspx", True)
    End Sub

    Protected Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        Dim nId As Integer = 0
        If e.CommandName = "Modificar" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmCampaniasModificacion.aspx?id=" & nId.ToString, True)

        ElseIf e.CommandName = "Estado" Then
            nId = Convert.ToInt32(e.CommandArgument)

            If MsgBox("Desea Dar de Baja la Campaña?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Robin") = MsgBoxResult.Yes Then
                If Estado(nId) Then
                    CargarGrilla()
                End If
            End If
        End If
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim sCampania As String = Trim(txtCampania.Text)
        Dim sEstado As String = cmdEstado.SelectedValue

        Response.Redirect("/frmCampaniasListado.aspx?campania=" & sCampania & "&estado=" & sEstado, True)
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub
End Class