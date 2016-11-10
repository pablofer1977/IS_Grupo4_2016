Imports SGD_Negocios.Negocios
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Public Class frmDonantesImportacion
    Inherits System.Web.UI.Page

#Region " PROPIEDADES "

#End Region

#Region " FUNCIONES INTERNAS "
    Private Sub CargarGrilla()
        Dim DonantesImportacionN As DonantesImportacionN

        Try
            DonantesImportacionN = New DonantesImportacionN

            grd.DataSource = DonantesImportacionN.Listado()
            grd.DataBind()

            DonantesImportacionN = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Private Sub CargarGrilla_Validaciones()
        Dim DonantesImportacionN As DonantesImportacionN
        Dim dt As DataTable

        Dim nId As Integer = Request.QueryString("id")

        Try
            DonantesImportacionN = New DonantesImportacionN
            dt = New DataTable

            dt = DonantesImportacionN.Validaciones_Listado(nId)

            If dt.Rows.Count > 0 Then
                lblNro.Text = "Listado de Validaciones [Nro.: " & nId.ToString & "]"
            Else
                lblNro.Text = "Listado de Validaciones"
            End If

            grdV.DataSource = dt
            grdV.DataBind()

            DonantesImportacionN = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Public Sub Importar()
        Dim DonantesImportacionN As DonantesImportacionN
        Dim sNombreArchivo As String = ""

        Try
            DonantesImportacionN = New DonantesImportacionN

            If FileUpload.HasFile Then
                sNombreArchivo = FileUpload.PostedFile.FileName

                'guardo el excel en la tabla sql y lo valido
                DonantesImportacionN.Importar(sNombreArchivo)
            End If

            DonantesImportacionN = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Public Sub Grabar()
        Dim DonantesImportacionN As DonantesImportacionN
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim Id_Donante As Integer = 0

        Try
            DonantesImportacionN = New DonantesImportacionN
            dt = New DataTable

            dt.Columns.Add("Id_Donante", Type.GetType("System.Int32"))

            For Each oRow As GridViewRow In grd.Rows
                If oRow.RowType = DataControlRowType.DataRow Then
                    Dim chkRow As CheckBox = TryCast(oRow.Cells(1).FindControl("Guardar"), CheckBox)

                    'grabo sólo los que tienen check true
                    If chkRow.Checked Then
                        Id_Donante = oRow.Cells(3).Text

                        dt.Rows.Add(Id_Donante)
                    End If
                End If
            Next

            If dt.Rows.Count > 0 Then
                If MsgBox("Desea Grabar los Donantes/Donaciones Seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.Yes Then
                    'grabo los donantes/donaciones OK
                    DonantesImportacionN.Grabar(dt)
                End If
            End If

            DonantesImportacionN = Nothing
            dt = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Public Sub Eliminar()
        Dim DonantesImportacionN As DonantesImportacionN

        Try
            DonantesImportacionN = New DonantesImportacionN

            If grd.Rows.Count > 0 Then
                If MsgBox("Desea Eliminar los Donantes/Donaciones Importados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Robin") = MsgBoxResult.Yes Then
                    'elimino los datos importados
                    DonantesImportacionN.Excel_Eliminar()
                End If
            End If

            DonantesImportacionN = Nothing
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
        End Try
    End Sub

    Public Function ImagenResultado_Obtener(nId_Validacion As eValidaciones_Tipos) As String
        Dim sURL As String = ""

        If nId_Validacion = eValidaciones_Tipos.OK Then
            sURL = "~/Resources/Resultado_OK.png"
        ElseIf nId_Validacion = eValidaciones_Tipos.Advertencia Then
            sURL = "~/Resources/Resultado_Advertencia.png"
        ElseIf nId_Validacion = eValidaciones_Tipos.Error_ Then
            sURL = "~/Resources/Resultado_Error.png"
        End If

        Return sURL
    End Function

    Public Function ImagenLog_Obtener(nId_Validacion As eValidaciones_Tipos) As String
        Dim sURL As String = ""

        If nId_Validacion = eValidaciones_Tipos.OK Then
            sURL = "~/Resources/Ver_Deshabilitado.png"
        ElseIf nId_Validacion = eValidaciones_Tipos.Advertencia Then
            sURL = "~/Resources/Ver.png"
        ElseIf nId_Validacion = eValidaciones_Tipos.Error_ Then
            sURL = "~/Resources/Ver.png"
        End If

        Return sURL
    End Function

    Public Function HabilitarGuardar_Obtener(nId_Validacion As eValidaciones_Tipos) As Boolean
        Dim bEstado As Boolean = False

        If nId_Validacion = eValidaciones_Tipos.OK Then
            bEstado = True
        ElseIf nId_Validacion = eValidaciones_Tipos.Advertencia Then
            bEstado = True
        ElseIf nId_Validacion = eValidaciones_Tipos.Error_ Then
            bEstado = False
        End If

        Return bEstado
    End Function

    Public Function HabilitarLog_Obtener(nId_Validacion As eValidaciones_Tipos) As Boolean
        Dim bEstado As Boolean = False

        If nId_Validacion = eValidaciones_Tipos.OK Then
            bEstado = False
        ElseIf nId_Validacion = eValidaciones_Tipos.Advertencia Then
            bEstado = True
        ElseIf nId_Validacion = eValidaciones_Tipos.Error_ Then
            bEstado = True
        End If

        Return bEstado
    End Function

    Public Function CheckedGuardar_Obtener(nId_Validacion As eValidaciones_Tipos) As Boolean
        Dim bEstado As Boolean = False

        If nId_Validacion = eValidaciones_Tipos.OK Then
            bEstado = True
        ElseIf nId_Validacion = eValidaciones_Tipos.Advertencia Then
            bEstado = False
        ElseIf nId_Validacion = eValidaciones_Tipos.Error_ Then
            bEstado = False
        End If

        Return bEstado
    End Function

#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarGrilla()

            CargarGrilla_Validaciones()
        End If
    End Sub

    Protected Sub grd_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles grd.RowCommand
        Dim nId As Integer = 0

        If e.CommandName = "Ver_Log" Then
            nId = Convert.ToInt32(e.CommandArgument)

            Response.Redirect("/frmDonantesImportacion.aspx?id=" & nId.ToString, True)
        End If
    End Sub

    Protected Sub grd_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex

        CargarGrilla()
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Importar()

        CargarGrilla()

        CargarGrilla_Validaciones()
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Grabar()

        CargarGrilla()

        CargarGrilla_Validaciones()
    End Sub

    Protected Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Eliminar()

        CargarGrilla()

        CargarGrilla_Validaciones()
    End Sub
End Class