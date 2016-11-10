Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables
Imports System.Windows.Forms
Imports System.Threading

Public Class frmPresentacionesRetornos
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarCombos()
        Dim DonacionesN As DonacionesN
        Dim TarjetasN As TarjetasN
        Dim PresentacionesN As PresentacionesN

        DonacionesN = New DonacionesN
        TarjetasN = New TarjetasN
        PresentacionesN = New PresentacionesN

        With cmbTipoPresentacion
            .DataSource = DonacionesN.TiposDonaciones_CargarCombo(False, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedValue = 1
        End With

        With cmbTarjeta
            .DataSource = TarjetasN.CargarCombo(False, False, cmbTipoPresentacion.SelectedValue)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        With cmbMes
            .DataSource = PresentacionesN.Meses_CargarCombo(False, False)
            .DataValueField = "Id"
            .DataTextField = "Campo"
            .DataBind()

            .SelectedIndex = -1
        End With

        DonacionesN = Nothing
        TarjetasN = Nothing
        PresentacionesN = Nothing
    End Sub

    Private Sub HabilitarCampos(nId_TipoDonacion As eDonaciones_Tipos)
        If nId_TipoDonacion = eDonaciones_Tipos.Tarjeta Then
            cmbTarjeta.Enabled = True
        ElseIf nId_TipoDonacion = eDonaciones_Tipos.CBU Then
            cmbTarjeta.Enabled = False
        Else
            cmbTarjeta.Enabled = False
        End If
    End Sub

    Private Function Aceptar() As Boolean
        Dim PresentacionesN As PresentacionesN
        Dim PresentacionesE As PresentacionesE
        Dim dt As DataTable
        Dim dtD As DataTable

        Try
            PresentacionesN = New PresentacionesN
            PresentacionesE = New PresentacionesE
            dt = New DataTable
            dtD = New DataTable

            PresentacionesE.nId_TipoPresentacion = cmbTipoPresentacion.SelectedValue

            If PresentacionesE.nId_TipoPresentacion = eDonaciones_Tipos.Tarjeta Then
                PresentacionesE.sId_Tarjeta = cmbTarjeta.SelectedValue
            End If

            If cmbMes.SelectedValue > 0 Then PresentacionesE.nMes = cmbMes.SelectedValue
            If Val(txtAnio.Text) > 0 Then PresentacionesE.nAnio = Val(txtAnio.Text)
            If FileUpload.HasFile Then PresentacionesE.sCarpetaTXT = FileUpload.PostedFile.FileName

            'valido los datos ingresados
            dt = PresentacionesN.Retornos_Validar(PresentacionesE)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then

                ElseIf dt.Select("Id = -1").Count = 1 Then
                    'error de aplicacion
                    Return False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Procesar Archivos de Retornos - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    Return False
                End If
            End If

            'obtengo una tabla con los retornos
            dtD = PresentacionesN.ProcesarRechazos(PresentacionesE)

            'actualizo los retornos
            dt = PresentacionesN.Retornos_Agregar(PresentacionesE, dtD)

            If dt.Rows.Count > 0 Then
                If dt.Select("Id = 0").Count = 1 Then

                ElseIf dt.Select("Id = -1").Count = 1 Then
                    'error de aplicacion
                    Return False
                Else
                    'mostrar mensaje de error
                    lblTituloError.Text = "Procesar Archivos de Retornos - Error"
                    lblError.Text = ""

                    For i = 0 To dt.Rows.Count - 1
                        If Trim(lblError.Text) <> "" Then lblError.Text = lblError.Text & "<br>"
                        lblError.Text = lblError.Text & dt.Rows(i).Item("Mensaje").ToString
                    Next

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Modal_Error", "$('#Modal_Error').modal();", True)
                    upModal_Error.Update()

                    Return False
                End If
            End If

            PresentacionesN = Nothing
            PresentacionesE = Nothing
            dt = Nothing
            dtD = Nothing

            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

            Return False
        End Try
    End Function

    Private Sub Cancelar()
        Response.Redirect("frmPresentacionesListado.aspx", True)
    End Sub
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarCombos()

            HabilitarCampos(cmbTipoPresentacion.SelectedValue)

            cmbMes.SelectedValue = Month(Now)
            txtAnio.Text = Year(Now)
        End If
    End Sub

    Protected Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Protected Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        If Aceptar() Then
            MsgBox("Se Procesó la Presentación Seleccionada", MsgBoxStyle.Information, "Robin")

            Response.Redirect("/frmPresentacionesListado.aspx", True)
        End If
    End Sub

    Protected Sub cmbTipoPresentacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPresentacion.SelectedIndexChanged
        HabilitarCampos(cmbTipoPresentacion.SelectedValue)
    End Sub
End Class