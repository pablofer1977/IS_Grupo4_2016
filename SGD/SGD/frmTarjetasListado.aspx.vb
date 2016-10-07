Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmTarjetasListado
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarGrilla()
        Dim TarjetasN As TarjetasN
        Dim TarjetasE As TarjetasE

        Try
            TarjetasN = New TarjetasN
            TarjetasE = New TarjetasE

            grd.DataSource = TarjetasN.Listado(TarjetasE)
            grd.DataBind()

            TarjetasN = Nothing
            TarjetasE = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub CargarGrilla_Rechazos()
        Dim TarjetasRechazosN As TarjetasRechazosN
        Dim TarjetasRechazosE As TarjetasRechazosE
        Dim dt As DataTable

        Dim sId_Tarjeta As String = ""
        Dim sId_Tarjeta_AUX As String = Request.QueryString("id_tarjeta")

        Try
            TarjetasRechazosN = New TarjetasRechazosN
            TarjetasRechazosE = New TarjetasRechazosE
            dt = New DataTable

            If Not IsNothing(sId_Tarjeta_AUX) Then sId_Tarjeta = Trim(sId_Tarjeta_AUX)

            If Trim(sId_Tarjeta) <> "" Then TarjetasRechazosE.sId_Tarjeta = Trim(sId_Tarjeta)

            dt = TarjetasRechazosN.Listado(TarjetasRechazosE)

            If dt.Rows.Count > 0 Then
                lblTarjeta.Text = "Listado de Causas de Rechazos [" & dt.Rows(0).Item("Tarjeta").ToString & "]"
                btnNuevo.Enabled = True
            Else
                lblTarjeta.Text = "Listado de Causas de Rechazos"
                btnNuevo.Enabled = False
            End If

            grdR.DataSource = dt
            grdR.DataBind()

            TarjetasRechazosN = Nothing
            TarjetasRechazosE = Nothing
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

    Private Function Estado(nId As Integer, sId_Tarjeta As String) As Boolean
        Dim TarjetasRechazosN As TarjetasRechazosN
        Dim TarjetasRechazosE As TarjetasRechazosE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            TarjetasRechazosN = New TarjetasRechazosN
            TarjetasRechazosE = New TarjetasRechazosE
            dt = New DataTable

            TarjetasRechazosE.nId = nId
            TarjetasRechazosE.sId_Tarjeta = sId_Tarjeta
            TarjetasRechazosE.sEstado = "B"

            dt = TarjetasRechazosN.Estado(TarjetasRechazosE)

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
                        lblTituloError.Text = "Baja de Causa de Rechazo - Error"
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

            TarjetasRechazosN = Nothing
            TarjetasRechazosE = Nothing
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
            CargarGrilla()

            CargarGrilla_Rechazos()
        End If
    End Sub

    Protected Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim sId_Tarjeta As String = Request.QueryString("id_tarjeta")

        If Not IsNothing(sId_Tarjeta) Then Response.Redirect("/frmTarjetasRechazosAlta.aspx?id_tarjeta=" & sId_Tarjeta.ToString, True)
    End Sub

    Protected Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        Dim sId As String = ""

        If e.CommandName = "Modificar" Then
            sId = e.CommandArgument
            Response.Redirect("/frmTarjetasModificacion.aspx?id=" & sId.ToString, True)
        ElseIf e.CommandName = "VerCausas" Then
            sId = e.CommandArgument
            Response.Redirect("/frmTarjetasListado.aspx?id_tarjeta=" & sId.ToString, True)
        End If
    End Sub

    Protected Sub grdR_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grdR.RowCommand
        Dim nId As Integer = 0
        Dim sId_Tarjeta As String = ""

        If e.CommandName = "Modificar" Then
            nId = Convert.ToInt32(e.CommandArgument)
            Response.Redirect("/frmTarjetasRechazosModificacion.aspx?id=" & nId.ToString, True)

        ElseIf e.CommandName = "Estado" Then
            nId = Convert.ToInt32(e.CommandArgument)
            sId_Tarjeta = Request.QueryString("id_tarjeta")

            If MsgBox("Desea Dar de Baja la Causa de Rechazo?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Robin") = MsgBoxResult.Yes Then
                If Estado(nId, sId_Tarjeta) Then
                    CargarGrilla_Rechazos()
                End If
            End If
        End If
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub

    Protected Sub grdR_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grdR.PageIndexChanging
        grdR.PageIndex = e.NewPageIndex

        CargarGrilla_Rechazos()
    End Sub
End Class