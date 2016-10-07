Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class DonantesD
        Private Shared configurationAppSettings As New System.Configuration.AppSettingsReader

#Region "Constructor"
        Sub New()
            sCadConn = ConfigurationManager.ConnectionStrings("sCadConn").ConnectionString
        End Sub
#End Region

        Public Function TiposDonantes_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("TiposDonantes_Combo", cn)

                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pTodos", SqlDbType.Bit).Value = IIf(bTodos, 1, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pBlanco", SqlDbType.Bit).Value = IIf(bBlanco, 1, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal DonantesE As DonantesE, DonacionesE As DonacionesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Donantes_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId_Donante", SqlDbType.Int).Value = IIf(DonantesE.nId <> 0, DonantesE.nId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_TipoDonante", SqlDbType.Int).Value = IIf(DonantesE.nId_TipoDonante <> 0, DonantesE.nId_TipoDonante, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sApellido_Nombre_RazonSocial), DonantesE.sNombre, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pDireccion", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sDireccion), DonantesE.sDireccion, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pLocalidad", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonantesE.sLocalidad), DonantesE.sLocalidad, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pCP", SqlDbType.VarChar, 10).Value = IIf(Not IsNothing(DonantesE.sCP), DonantesE.sCP, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_Provincia", SqlDbType.Int).Value = IIf(DonantesE.nId_Provincia <> 0, DonantesE.nId_Provincia, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pDNI_CUIL_CUIT", SqlDbType.VarChar, 11).Value = IIf(Not IsNothing(DonantesE.sDNI_CUIL_CUIT), DonantesE.sDNI_CUIL_CUIT, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pTE", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(DonantesE.sTE_Linea), DonantesE.sTE_Linea_Celular_Laboral, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pEMail", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sEMail), DonantesE.sEMail, DBNull.Value)

                da.SelectCommand.Parameters.Add("@pId_Donacion", SqlDbType.Int).Value = IIf(DonacionesE.nId <> 0, DonacionesE.nId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = IIf(Not IsNothing(DonacionesE.sEstado), DonacionesE.sEstado, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_TipoDonacion", SqlDbType.Int).Value = IIf(DonacionesE.nId_TipoDonacion <> 0, DonacionesE.nId_TipoDonacion, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(DonacionesE.sId_Tarjeta), DonacionesE.sId_Tarjeta, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pNroTarjeta_CBU", SqlDbType.VarChar, 22).Value = IIf(Not IsNothing(DonacionesE.sNroTarjeta_CBU), DonacionesE.sNroTarjeta_CBU, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_Campania", SqlDbType.Int).Value = IIf(DonacionesE.nId_Campania <> 0, DonacionesE.nId_Campania, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal DonantesE As DonantesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Donantes_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = DonantesE.nId

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal DonantesE As DonantesE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand
            Dim nId_Donante As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donantes_Agregar"

                com.Parameters.Add("@pId_TipoDonante", SqlDbType.Int).Value = IIf(DonantesE.nId_TipoDonante <> 0, DonantesE.nId_TipoDonante, DBNull.Value)
                com.Parameters.Add("@pApellido", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonantesE.sApellido), DonantesE.sApellido, DBNull.Value)
                com.Parameters.Add("@pNombre", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonantesE.sNombre), DonantesE.sNombre, DBNull.Value)
                com.Parameters.Add("@pRazon_Social", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sRazon_Social), DonantesE.sRazon_Social, DBNull.Value)
                com.Parameters.Add("@pDireccion", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sDireccion), DonantesE.sDireccion, DBNull.Value)
                com.Parameters.Add("@pLocalidad", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonantesE.sLocalidad), DonantesE.sLocalidad, DBNull.Value)
                com.Parameters.Add("@pCP", SqlDbType.VarChar, 10).Value = IIf(Not IsNothing(DonantesE.sCP), DonantesE.sCP, DBNull.Value)
                com.Parameters.Add("@pId_Provincia", SqlDbType.Int).Value = IIf(DonantesE.nId_Provincia <> 0, DonantesE.nId_Provincia, DBNull.Value)
                com.Parameters.Add("@pDNI", SqlDbType.VarChar, 8).Value = IIf(Not IsNothing(DonantesE.sDNI), DonantesE.sDNI, DBNull.Value)
                com.Parameters.Add("@pCUIL_CUIT", SqlDbType.VarChar, 11).Value = IIf(Not IsNothing(DonantesE.sCUIL_CUIT), DonantesE.sCUIL_CUIT, DBNull.Value)
                com.Parameters.Add("@pTE_Linea", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(DonantesE.sTE_Linea), DonantesE.sTE_Linea, DBNull.Value)
                com.Parameters.Add("@pTE_Celular", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(DonantesE.sTE_Laboral), DonantesE.sTE_Laboral, DBNull.Value)
                com.Parameters.Add("@pTE_Laboral", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(DonantesE.sTE_Celular), DonantesE.sTE_Celular, DBNull.Value)
                com.Parameters.Add("@pEMail", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sEMail), DonantesE.sEMail, DBNull.Value)
                com.Parameters.Add("@pComentarios", SqlDbType.VarChar, 250).Value = IIf(Not IsNothing(DonantesE.sComentarios), DonantesE.sComentarios, DBNull.Value)

                nId_Donante = com.ExecuteScalar
                com.Parameters.Clear()

                com.Dispose()
                cn.Close()

                Return nId_Donante

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nId_Donante
            End Try
        End Function

        Public Function Modificar(ByVal DonantesE As DonantesE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donantes_Modificar"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = DonantesE.nId
                com.Parameters.Add("@pId_TipoDonante", SqlDbType.Int).Value = IIf(DonantesE.nId_TipoDonante <> 0, DonantesE.nId_TipoDonante, DBNull.Value)
                com.Parameters.Add("@pApellido", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonantesE.sApellido), DonantesE.sApellido, DBNull.Value)
                com.Parameters.Add("@pNombre", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonantesE.sNombre), DonantesE.sNombre, DBNull.Value)
                com.Parameters.Add("@pRazon_Social", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sRazon_Social), DonantesE.sRazon_Social, DBNull.Value)
                com.Parameters.Add("@pDireccion", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sDireccion), DonantesE.sDireccion, DBNull.Value)
                com.Parameters.Add("@pLocalidad", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonantesE.sLocalidad), DonantesE.sLocalidad, DBNull.Value)
                com.Parameters.Add("@pCP", SqlDbType.VarChar, 10).Value = IIf(Not IsNothing(DonantesE.sCP), DonantesE.sCP, DBNull.Value)
                com.Parameters.Add("@pId_Provincia", SqlDbType.Int).Value = IIf(DonantesE.nId_Provincia <> 0, DonantesE.nId_Provincia, DBNull.Value)
                com.Parameters.Add("@pDNI", SqlDbType.VarChar, 8).Value = IIf(Not IsNothing(DonantesE.sDNI), DonantesE.sDNI, DBNull.Value)
                com.Parameters.Add("@pCUIL_CUIT", SqlDbType.VarChar, 11).Value = IIf(Not IsNothing(DonantesE.sCUIL_CUIT), DonantesE.sCUIL_CUIT, DBNull.Value)
                com.Parameters.Add("@pTE_Linea", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(DonantesE.sTE_Linea), DonantesE.sTE_Linea, DBNull.Value)
                com.Parameters.Add("@pTE_Celular", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(DonantesE.sTE_Laboral), DonantesE.sTE_Laboral, DBNull.Value)
                com.Parameters.Add("@pTE_Laboral", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(DonantesE.sTE_Celular), DonantesE.sTE_Celular, DBNull.Value)
                com.Parameters.Add("@pEMail", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(DonantesE.sEMail), DonantesE.sEMail, DBNull.Value)
                com.Parameters.Add("@pComentarios", SqlDbType.VarChar, 250).Value = IIf(Not IsNothing(DonantesE.sComentarios), DonantesE.sComentarios, DBNull.Value)

                com.ExecuteNonQuery()
                com.Parameters.Clear()

                com.Dispose()
                cn.Close()

                Return True

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return False
            End Try
        End Function

        Public Function DNI_Verificar(nAccion As Integer, ByVal DonantesE As DonantesE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donantes_DNI_Verificar"

                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
                com.Parameters.Add("@pId", SqlDbType.Int).Value = DonantesE.nId
                com.Parameters.Add("@pDNI", SqlDbType.VarChar, 8).Value = DonantesE.sDNI

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function CUIT_CUIL_Verificar(nAccion As Integer, ByVal DonantesE As DonantesE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donantes_CUIT_CUIL_Verificar"

                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
                com.Parameters.Add("@pId", SqlDbType.Int).Value = DonantesE.nId
                com.Parameters.Add("@pCUIL_CUIT", SqlDbType.VarChar, 8).Value = DonantesE.sCUIL_CUIT

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function EMail_Formato_Validar(DonantesE As DonantesE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim bResultado As Boolean = False

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donantes_EMail_Validar"

                com.Parameters.Add("@pEMail", SqlDbType.VarChar, 150).Value = DonantesE.sEMail

                bResultado = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return bResultado

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return False
            End Try
        End Function
    End Class
End Namespace

