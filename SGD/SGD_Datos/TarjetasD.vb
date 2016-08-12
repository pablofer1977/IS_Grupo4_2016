Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class TarjetasD

        Private Shared configurationAppSettings As New System.Configuration.AppSettingsReader

#Region "Constructor"
        Sub New()
            sCadConn = ConfigurationManager.ConnectionStrings("sCadConn").ConnectionString
        End Sub
#End Region
        Public Function CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean, ByVal nId_TipoPresentacion As Integer) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable
 
            Try
                dt = New DataTable
 
                cn.Open()
 
				da = New SqlDataAdapter("Tarjetas_Combo", cn)
 
                da.SelectCommand.CommandType = CommandType.StoredProcedure
 
                da.SelectCommand.Parameters.Add("@pTodos", SqlDbType.Bit).Value = IIf(bTodos, 1, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pBlanco", SqlDbType.Bit).Value = IIf(bBlanco, 1, DBNull.Value)
				da.SelectCommand.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = IIf(Val(nId_TipoPresentacion) <> 0, nId_TipoPresentacion, DBNull.Value)
 
                da.Fill(dt)
 
                cn.Close()
                da = Nothing
 
                Return dt
 
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal TarjetasE As TarjetasE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Tarjetas_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Char, 3).Value = IIf(Not IsNothing(TarjetasE.sId), TarjetasE.sId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pTarjeta", SqlDbType.VarChar, 30).Value = IIf(Not IsNothing(TarjetasE.sTarjeta), TarjetasE.sTarjeta, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = IIf(TarjetasE.nId_TipoPresentacion <> 0, TarjetasE.nId_TipoPresentacion, DBNull.Value)
				da.SelectCommand.Parameters.Add("@pNombreArchivo", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(TarjetasE.sNombreArchivo), TarjetasE.sNombreArchivo, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pNroComercio", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(TarjetasE.sNroComercio), TarjetasE.sNroComercio, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal TarjetasE As TarjetasE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Tarjetas_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Char, 3).Value = TarjetasE.sId
                
                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Modificar(ByVal TarjetasE As TarjetasE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Tarjetas_Modificar"

                com.Parameters.Add("@pId", SqlDbType.Char, 3).Value = TarjetasE.sId
				com.Parameters.Add("@pTarjeta", SqlDbType.VarChar, 30).Value = IIf(Not IsNothing(TarjetasE.sTarjeta), TarjetasE.sTarjeta, DBNull.Value)
				com.Parameters.Add("@pId_TipoPresentacion", SqlDbType.Int).Value = IIf(TarjetasE.nId_TipoPresentacion <> 0, TarjetasE.nId_TipoPresentacion, DBNull.Value)
				com.Parameters.Add("@pNombreArchivo", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(TarjetasE.sNombreArchivo), TarjetasE.sNombreArchivo, DBNull.Value)
				com.Parameters.Add("@pNroComercio", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(TarjetasE.sNroComercio), TarjetasE.sNroComercio, DBNull.Value)

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

        Public Function Verificar(nAccion as Integer, ByVal TarjetasE As TarjetasE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Tarjetas_Verificar"
				
                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
				com.Parameters.Add("@pId", SqlDbType.Char, 3).Value = TarjetasE.sId
				com.Parameters.Add("@pTarjeta", SqlDbType.VarChar, 30).Value = IIf(Not IsNothing(TarjetasE.sTarjeta), TarjetasE.sTarjeta, DBNull.Value)
				com.Parameters.Add("@pNombreArchivo", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(TarjetasE.sNombreArchivo), TarjetasE.sNombreArchivo, DBNull.Value)
				com.Parameters.Add("@pNroComercio", SqlDbType.VarChar, 15).Value = IIf(Not IsNothing(TarjetasE.sNroComercio), TarjetasE.sNroComercio, DBNull.Value)

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function
		
        Public Function FK_Verificar(TarjetasE As TarjetasE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Tarjetas_FK_Verificar"
				
                com.Parameters.Add("@pId", SqlDbType.Char, 3).Value = TarjetasE.sId

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