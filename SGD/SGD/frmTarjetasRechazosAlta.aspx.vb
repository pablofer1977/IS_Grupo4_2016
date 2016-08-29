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
        Dim bResultado As Boolean = False

        Try
            TarjetasRechazosN = New TarjetasRechazosN
            TarjetasRechazosE = New TarjetasRechazosE

            TarjetasRechazosE.sId_Tarjeta = UCase(lblIdTarjeta.Text)
            TarjetasRechazosE.sCodBanco = UCase(Trim(txtCodBanco.Text))
            TarjetasRechazosE.sCausaRechazo = Trim(txtCausaRechazo.Text)

            If optCausaOK_SI.Checked Then
                TarjetasRechazosE.bCausaOK = True
            Else
                TarjetasRechazosE.bCausaOK = False
            End If

            bResultado = TarjetasRechazosN.Agregar(TarjetasRechazosE)

            TarjetasRechazosN = Nothing
            TarjetasRechazosE = Nothing

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