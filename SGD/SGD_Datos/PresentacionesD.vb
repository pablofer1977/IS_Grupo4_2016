Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class PresentacionesD
        Private Shared configurationAppSettings As New System.Configuration.AppSettingsReader

#Region "Constructor"
        Sub New()
            sCadConn = ConfigurationManager.ConnectionStrings("sCadConn").ConnectionString
        End Sub
#End Region

        Public Function Verificar(ByVal PresentacionesE As PresentacionesE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Presentaciones_Verificar"

                com.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = PresentacionesE.nId_TipoPresentacion
                com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = PresentacionesE.sId_Tarjeta
                com.Parameters.Add("@pMes", SqlDbType.Int).Value = PresentacionesE.nMes
                com.Parameters.Add("@pAnio", SqlDbType.Int).Value = PresentacionesE.nAnio

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function Agregar(ByVal PresentacionesE As PresentacionesE, dt As DataTable) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Presentaciones_Agregar"

                com.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = PresentacionesE.nId_TipoPresentacion
                com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = PresentacionesE.sId_Tarjeta
                com.Parameters.Add("@pMes", SqlDbType.Int).Value = PresentacionesE.nMes
                com.Parameters.Add("@pAnio", SqlDbType.Int).Value = PresentacionesE.nAnio
                com.Parameters.Add("@pListPresentaciones_Agregar", SqlDbType.Structured).Value = dt

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

        Public Function Listado(ByVal PresentacionesE As PresentacionesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Presentaciones_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = IIf(PresentacionesE.nId <> 0, PresentacionesE.nId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = IIf(PresentacionesE.nId_TipoPresentacion <> 0, PresentacionesE.nId_TipoPresentacion, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(PresentacionesE.sId_Tarjeta), PresentacionesE.sId_Tarjeta, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pMes", SqlDbType.Int).Value = IIf(PresentacionesE.nMes <> 0, PresentacionesE.nMes, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pAnio", SqlDbType.Int).Value = IIf(PresentacionesE.nAnio <> 0, PresentacionesE.nAnio, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Detalles_Listado(ByVal PresentacionesE As PresentacionesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("PresentacionesDetalles_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId_Presentacion", SqlDbType.Int).Value = PresentacionesE.nId

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Donaciones_Obtener(ByVal PresentacionesE As PresentacionesE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Presentaciones_Donaciones_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = PresentacionesE.nId_TipoPresentacion
                da.SelectCommand.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = PresentacionesE.sId_Tarjeta

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Retornos_Agregar(ByVal PresentacionesE As PresentacionesE, dt As DataTable) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Presentaciones_Retornos_Agregar"

                com.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = PresentacionesE.nId_TipoPresentacion
                com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = PresentacionesE.sId_Tarjeta
                com.Parameters.Add("@pMes", SqlDbType.Int).Value = PresentacionesE.nMes
                com.Parameters.Add("@pAnio", SqlDbType.Int).Value = PresentacionesE.nAnio
                com.Parameters.Add("@pListPresentaciones_Retornos_Agregar", SqlDbType.Structured).Value = dt

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
    End Class
End Namespace