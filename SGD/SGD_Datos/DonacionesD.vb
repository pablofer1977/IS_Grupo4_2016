Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class DonacionesD

        Private Shared configurationAppSettings As New System.Configuration.AppSettingsReader

#Region "Constructor"
        Sub New()
            sCadConn = ConfigurationManager.ConnectionStrings("sCadConn").ConnectionString
        End Sub
#End Region
        Public Function TiposDonaciones_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("TiposDonaciones_Combo", cn)

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

        Public Function Listado(ByVal DonacionesE As DonacionesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Donaciones_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId_Donacion", SqlDbType.Int).Value = IIf(DonacionesE.nId <> 0, DonacionesE.nId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_Donante", SqlDbType.Int).Value = IIf(DonacionesE.nId_Donante <> 0, DonacionesE.nId_Donante, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Consulta_Listado(DonacionesE As DonacionesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Donaciones_Consulta_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId_Donacion", SqlDbType.Int).Value = IIf(DonacionesE.nId <> 0, DonacionesE.nId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_Donante", SqlDbType.Int).Value = IIf(DonacionesE.nId_Donante <> 0, DonacionesE.nId_Donante, DBNull.Value)
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

        Public Function Obtener(ByVal DonacionesE As DonacionesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Donaciones_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = DonacionesE.nId

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal DonacionesE As DonacionesE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand
            Dim nId_Donacion As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donaciones_Agregar"

                com.Parameters.Add("@pId_Donante", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nId_Donante), DonacionesE.nId_Donante, DBNull.Value)
                com.Parameters.Add("@pId_TipoDonacion", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nId_TipoDonacion), DonacionesE.nId_TipoDonacion, DBNull.Value)
                com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(DonacionesE.sId_Tarjeta), DonacionesE.sId_Tarjeta, DBNull.Value)
                com.Parameters.Add("@pNroTarjeta", SqlDbType.VarChar, 16).Value = IIf(Not IsNothing(DonacionesE.sNroTarjeta), DonacionesE.sNroTarjeta, DBNull.Value)
                com.Parameters.Add("@pBanco", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonacionesE.sBanco), DonacionesE.sBanco, DBNull.Value)
                com.Parameters.Add("@pVto", SqlDbType.VarChar, 10).Value = IIf(Not IsNothing(DonacionesE.sVto), DonacionesE.sVto, DBNull.Value)
                com.Parameters.Add("@pCBU", SqlDbType.VarChar, 22).Value = IIf(Not IsNothing(DonacionesE.sCBU), DonacionesE.sCBU, DBNull.Value)
                com.Parameters.Add("@pMonto", SqlDbType.Decimal, 10, 2).Value = IIf(Not IsNothing(DonacionesE.nMonto), DonacionesE.nMonto, DBNull.Value)
                com.Parameters.Add("@pTiempo", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nTiempo), DonacionesE.nTiempo, DBNull.Value)
                com.Parameters.Add("@pId_Campania", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nId_Campania), DonacionesE.nId_Campania, DBNull.Value)

                nId_Donacion = com.ExecuteScalar
                com.Parameters.Clear()

                com.Dispose()
                cn.Close()

                Return nId_Donacion

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")

                Return nId_Donacion
            End Try
        End Function

        Public Function Modificar(ByVal DonacionesE As DonacionesE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donaciones_Modificar"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = DonacionesE.nId
                com.Parameters.Add("@pId_Donante", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nId_Donante), DonacionesE.nId_Donante, DBNull.Value)
                com.Parameters.Add("@pId_TipoDonacion", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nId_TipoDonacion), DonacionesE.nId_TipoDonacion, DBNull.Value)
                com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(DonacionesE.sId_Tarjeta), DonacionesE.sId_Tarjeta, DBNull.Value)
                com.Parameters.Add("@pNroTarjeta", SqlDbType.VarChar, 16).Value = IIf(Not IsNothing(DonacionesE.sNroTarjeta), DonacionesE.sNroTarjeta, DBNull.Value)
                com.Parameters.Add("@pBanco", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(DonacionesE.sBanco), DonacionesE.sBanco, DBNull.Value)
                com.Parameters.Add("@pVto", SqlDbType.VarChar, 10).Value = IIf(Not IsNothing(DonacionesE.sVto), DonacionesE.sVto, DBNull.Value)
                com.Parameters.Add("@pCBU", SqlDbType.VarChar, 22).Value = IIf(Not IsNothing(DonacionesE.sCBU), DonacionesE.sCBU, DBNull.Value)
                com.Parameters.Add("@pMonto", SqlDbType.Decimal, 10, 2).Value = IIf(Not IsNothing(DonacionesE.nMonto), DonacionesE.nMonto, DBNull.Value)
                com.Parameters.Add("@pTiempo", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nTiempo), DonacionesE.nTiempo, DBNull.Value)
                com.Parameters.Add("@pId_Campania", SqlDbType.Int).Value = IIf(Not IsNothing(DonacionesE.nId_Campania), DonacionesE.nId_Campania, DBNull.Value)

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

        Public Function Estado(ByVal DonacionesE As DonacionesE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donaciones_Estado"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = DonacionesE.nId
                com.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = DonacionesE.sEstado

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

        Public Function NroTarjeta_Verificar(nAccion As Integer, ByVal DonacionesE As DonacionesE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donaciones_NroTarjeta_Verificar"

                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
                com.Parameters.Add("@pId", SqlDbType.Int).Value = DonacionesE.nId
                com.Parameters.Add("@pNroTarjeta", SqlDbType.VarChar, 16).Value = DonacionesE.sNroTarjeta

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function CBU_Verificar(nAccion As Integer, ByVal DonacionesE As DonacionesE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Donaciones_CBU_Verificar"

                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
                com.Parameters.Add("@pId", SqlDbType.Int).Value = DonacionesE.nId
                com.Parameters.Add("@pCBU", SqlDbType.VarChar, 22).Value = DonacionesE.sCBU

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function
    End Class
End Namespace
