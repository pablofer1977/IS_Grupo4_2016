Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class CampaniasD

        Private Shared configurationAppSettings As New System.Configuration.AppSettingsReader

#Region "Constructor"
        Sub New()
            sCadConn = ConfigurationManager.ConnectionStrings("sCadConn").ConnectionString
        End Sub
#End Region
        Public Function CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean, ByVal sEstado As String) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Campanias_Combo", cn)

                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pTodos", SqlDbType.Bit).Value = IIf(bTodos, 1, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pBlanco", SqlDbType.Bit).Value = IIf(bBlanco, 1, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = IIf(Trim(sEstado) <> "", sEstado, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Listado(ByVal CampaniasE As CampaniasE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Campanias_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = IIf(CampaniasE.nId <> 0, CampaniasE.nId, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pCampania", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(CampaniasE.sCampania), CampaniasE.sCampania, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 250).Value = IIf(Not IsNothing(CampaniasE.sDescripcion), CampaniasE.sDescripcion, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = IIf(Not IsNothing(CampaniasE.sEstado), CampaniasE.sEstado, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal CampaniasE As CampaniasE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Campanias_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pId", SqlDbType.Int).Value = CampaniasE.nId
                
                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal CampaniasE As CampaniasE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Campanias_Agregar"

                com.Parameters.Add("@pCampania", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(CampaniasE.sCampania), CampaniasE.sCampania, DBNull.Value)
				com.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 250).Value = IIf(Not IsNothing(CampaniasE.sDescripcion), CampaniasE.sDescripcion, DBNull.Value)

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

        Public Function Modificar(ByVal CampaniasE As CampaniasE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Campanias_Modificar"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = CampaniasE.nId
				com.Parameters.Add("@pCampania", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(CampaniasE.sCampania), CampaniasE.sCampania, DBNull.Value)
				com.Parameters.Add("@pDescripcion", SqlDbType.VarChar, 250).Value = IIf(Not IsNothing(CampaniasE.sDescripcion), CampaniasE.sDescripcion, DBNull.Value)

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

        Public Function Estado(ByVal CampaniasE As CampaniasE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Campanias_Estado"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = CampaniasE.nId
				com.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = CampaniasE.sEstado

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

        Public Function Verificar(nAccion as Integer, ByVal CampaniasE As CampaniasE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Campanias_Verificar"
				
                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
				com.Parameters.Add("@pId", SqlDbType.Int).Value = CampaniasE.nId
				com.Parameters.Add("@pCampania", SqlDbType.varChar, 50).Value = CampaniasE.sCampania

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function
		
        Public Function FK_Verificar(CampaniasE As CampaniasE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Campanias_FK_Verificar"
				
                com.Parameters.Add("@pId", SqlDbType.Int).Value = CampaniasE.nId

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
