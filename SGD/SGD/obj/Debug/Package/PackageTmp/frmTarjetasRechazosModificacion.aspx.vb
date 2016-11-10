Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmTarjetasRechazosModificacion
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
        Dim TarjetasRechazosN As TarjetasRechazosN
        Dim TarjetasRechazosE As TarjetasRechazosE
        Dim dt As DataTable

        Try
            TarjetasRechazosN = New TarjetasRechazosN
            TarjetasRechazosE = New TarjetasRechazosE
            dt = New DataTable

            TarjetasRechazosE.nId = nId

            dt = TarjetasRechazosN.Obtener(TarjetasRechazosE)

            If dt.Rows.Count > 0 Then
                _nId = dt.Rows(0).Item("Id")
                lblIdTarjeta.Text = dt.Rows(0).Item("Id_Tarjeta")
                lblNombreTarjeta.Text = dt.Rows(0).Item("Tarjeta")
                lblTipoPresentacion.Text = dt.Rows(0).Item("TipoPresentacion")
                txtCodBanco.Text = dt.Rows(0).Item("CodBanco")
                txtCausaRechazo.Text = dt.Rows(0).Item("CausaRechazo")

                If dt.Rows(0).Item("CausaOK") = True Then
                    optCausaOK_SI.Checked = True
                    optCausaOK_NO.Checked = False
                Else
                    optCausaOK_SI.Checked = False
                    optCausaOK_NO.Checked = True
                End If

                lblEstado.Text = dt.Rows(0).Item("Estado")
                If Not IsDBNull(dt.Rows(0).Item("FechaAlta")) Then lblFechaAlta.Text = dt.Rows(0).Item("FechaAlta")
                If Not IsDBNull(dt.Rows(0).Item("FechaBaja")) Then lblFechaBaja.Text = dt.Rows(0).Item("FechaBaja")
            End If

            TarjetasRechazosN = Nothing
            TarjetasRechazosE = Nothing
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

            TarjetasRechazosE.nId = Val(Request.QueryString("id"))
            TarjetasRechazosE.sId_Tarjeta = UCase(lblIdTarjeta.Text)
            If Trim(txtCodBanco.Text) <> "" Then TarjetasRechazosE.sCodBanco = UCase(Trim(txtCodBanco.Text))
            If Trim(txtCausaRechazo.Text) <> "" Then TarjetasRechazosE.sCausaRechazo = Trim(txtCausaRechazo.Text)

            If optCausaOK_SI.Checked Then
                TarjetasRechazosE.bCausaOK = True
            Else
                TarjetasRechazosE.bCausaOK = False
            End If

            dt = TarjetasRechazosN.Modificar(TarjetasRechazosE)

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
                        lblTituloError.Text = "Modificación de Causa de Rechazo - Error"
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
        Response.Redirect("frmTarjetasListado.aspx?id_tarjeta=" & lblIdTarjeta.Text, True)
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
            Response.Redirect("frmTarjetasListado.aspx?id_tarjeta=" & lblIdTarjeta.Text, True)
        End If
    End Sub
End Class