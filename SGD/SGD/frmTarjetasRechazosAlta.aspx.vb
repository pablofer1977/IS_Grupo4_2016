Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmTarjetasRechazosAlta
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarDatos(sId_Tarjeta As String)
        Dim TarjetasN As TarjetasN
        Dim TarjetasE As TarjetasE
        Dim dt As DataTable

        Try
            TarjetasN = New TarjetasN
            TarjetasE = New TarjetasE
            dt = New DataTable

            TarjetasE.sId = sId_Tarjeta

            dt = TarjetasN.Obtener(TarjetasE)

            If dt.Rows.Count > 0 Then
                lblIdTarjeta.Text = dt.Rows(0).Item("Id")
                lblNombreTarjeta.Text = dt.Rows(0).Item("Tarjeta")
                lblTipoPresentacion.Text = dt.Rows(0).Item("TipoPresentacion")
            End If

            TarjetasN = Nothing
            TarjetasE = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Function Aceptar() As Boolean
        Dim TarjetasRechazosN As TarjetasRechazosN
        Dim TarjetasRechazosE As TarjetasRechazosE
        Dim dt As DataTable
        Dim bResultado As Boolean = False

        Try
            TarjetasRechazosN = New TarjetasRechazosN
            TarjetasRechazosE = New TarjetasRechazosE
            dt = New DataTable

            TarjetasRechazosE.sId_Tarjeta = UCase(lblIdTarjeta.Text)
            If Trim(txtCodBanco.Text) <> "" Then TarjetasRechazosE.sCodBanco = UCase(Trim(txtCodBanco.Text))
            If Trim(txtCausaRechazo.Text) <> "" Then TarjetasRechazosE.sCausaRechazo = Trim(txtCausaRechazo.Text)

            If optCausaOK_SI.Checked Then
                TarjetasRechazosE.bCausaOK = True
            Else
                TarjetasRechazosE.bCausaOK = False
            End If

            dt = TarjetasRechazosN.Agregar(TarjetasRechazosE)

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
                        lblTituloError.Text = "Alta de Causa de Rechazo - Error"
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

    Private Sub Cancelar()
        Dim sId_Tarjeta As String = ""

        sId_Tarjeta = Request.QueryString("id_tarjeta")

        Response.Redirect("frmTarjetasListado.aspx?id_tarjeta=" & sId_Tarjeta.ToString, True)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sId_Tarjeta As String = ""

        sId_Tarjeta = Request.QueryString("id_tarjeta")

        CargarDatos(sId_Tarjeta)
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Aceptar() Then
            Dim sId_Tarjeta As String = ""

            sId_Tarjeta = Request.QueryString("id_tarjeta")

            Response.Redirect("frmTarjetasListado.aspx?id_tarjeta=" & sId_Tarjeta.ToString, True)
        End If
    End Sub
End Class