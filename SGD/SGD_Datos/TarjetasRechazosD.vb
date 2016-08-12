Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class TarjetasRechazosD

        Private Shared configurationAppSettings As New System.Configuration.AppSettingsReader

#Region "Constructor"
        Sub New()
            sCadConn = ConfigurationManager.ConnectionStrings("sCadConn").ConnectionString
        End Sub
#End Region
        Public Function CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean, ByVal sId_Tarjeta As String) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable
 
            Try
                dt = New DataTable
 
                cn.Open()
 
				da = New SqlDataAdapter("TarjetasRechazos_Combo", cn)
 
                da.SelectCommand.CommandType = CommandType.StoredProcedure
 
                da.SelectCommand.Parameters.Add("@pTodos", SqlDbType.Bit).Value = IIf(bTodos, 1, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pBlanco", SqlDbType.Bit).Value = IIf(bBlanco, 1, DBNull.Value)
				da.SelectCommand.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Trim(sId_Tarjeta) <> "", sId_Tarjeta, DBNull.Value)
 
                da.Fill(dt)
 
                cn.Close()
                da = Nothing
 
                Return dt
 
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal TarjetasRechazosE As TarjetasRechazosE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("TarjetasRechazos_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = IIf(TarjetasRechazosE.nId <> 0, TarjetasRechazosE.nId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(TarjetasRechazosE.sId_Tarjeta), TarjetasRechazosE.sId_Tarjeta, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal TarjetasRechazosE As TarjetasRechazosE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("TarjetasRechazos_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = TarjetasRechazosE.nId
                
                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal TarjetasRechazosE As TarjetasRechazosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "TarjetasRechazos_Agregar"

                com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(TarjetasRechazosE.sId_Tarjeta), TarjetasRechazosE.sId_Tarjeta, DBNull.Value)
				com.Parameters.Add("@pCodBanco", SqlDbType.VarChar, 5).Value = IIf(Not IsNothing(TarjetasRechazosE.sCodBanco), TarjetasRechazosE.sCodBanco, DBNull.Value)
				com.Parameters.Add("@pCausaRechazo", SqlDbType.VarChar, 150).Value = IIf(Not IsNothing(TarjetasRechazosE.sCausaRechazo), TarjetasRechazosE.sCausaRechazo, DBNull.Value)
				com.Parameters.Add("@pCausaOK", SqlDbType.Bit).Value = IIf(TarjetasRechazosE.bCausaOK, 1, 0)

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

        Public Function Modificar(ByVal TarjetasRechazosE As TarjetasRechazosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "TarjetasRechazos_Modificar"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = TarjetasRechazosE.nId
				com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(TarjetasRechazosE.sId_Tarjeta), TarjetasRechazosE.sId_Tarjeta, DBNull.Value)
				com.Parameters.Add("@pCodBanco", SqlDbType.VarChar, 5).Value = IIf(Not IsNothing(TarjetasRechazosE.sCodBanco), TarjetasRechazosE.sCodBanco, DBNull.Value)
				com.Parameters.Add("@pCausaRechazo", SqlDbType.VarChar, 150).Value = IIf(Not IsNothing(TarjetasRechazosE.sCausaRechazo), TarjetasRechazosE.sCausaRechazo, DBNull.Value)
				com.Parameters.Add("@pCausaOK", SqlDbType.Bit).Value = IIf(TarjetasRechazosE.bCausaOK, 1, DBNull.Value)

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

        Public Function Eliminar(ByVal TarjetasRechazosE As TarjetasRechazosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "TarjetasRechazos_Eliminar"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = TarjetasRechazosE.nId

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

        Public Function Estado(ByVal TarjetasRechazosE As TarjetasRechazosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "TarjetasRechazos_Estado"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = TarjetasRechazosE.nId
				com.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = TarjetasRechazosE.sEstado

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

        Public Function Verificar(nAccion as Integer, ByVal TarjetasRechazosE As TarjetasRechazosE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "TarjetasRechazos_Verificar"
				
                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
				com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = IIf(Not IsNothing(TarjetasRechazosE.sId_Tarjeta), TarjetasRechazosE.sId_Tarjeta, DBNull.Value)
				com.Parameters.Add("@pCodBanco", SqlDbType.VarChar, 5).Value = IIf(Not IsNothing(TarjetasRechazosE.sCodBanco), TarjetasRechazosE.sCodBanco, DBNull.Value)
				com.Parameters.Add("@pCausaRechazo", SqlDbType.VarChar, 150).Value = IIf(Not IsNothing(TarjetasRechazosE.sCausaRechazo), TarjetasRechazosE.sCausaRechazo, DBNull.Value)

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function CausaOK_Verificar(nAccion as Integer, ByVal TarjetasRechazosE As TarjetasRechazosE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "TarjetasRechazos_CausaOK_Verificar"
				
                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
				com.Parameters.Add("@pId", SqlDbType.Int).Value = TarjetasRechazosE.nId
				com.Parameters.Add("@pId_Tarjeta", SqlDbType.Char, 3).Value = TarjetasRechazosE.sId_Tarjeta

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function
		
        Public Function FK_Verificar(TarjetasRechazosE As TarjetasRechazosE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "TarjetasRechazos_FK_Verificar"
				
                com.Parameters.Add("@pId", SqlDbType.Int).Value = TarjetasRechazosE.nId

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