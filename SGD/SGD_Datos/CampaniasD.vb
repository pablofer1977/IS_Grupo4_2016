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
        Public Function CargarCombo(ByVal sEstado As String, ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Campanias_Combo", cn)

                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = IIf(Trim(sEstado) <> "", sEstado, DBNull.Value)
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

                'dt.Columns.Add("Nro.", Type.GetType("System.Int32"))
                'dt.Columns.Add("Campaña", Type.GetType("System.String"))
                'dt.Columns.Add("Descripción", Type.GetType("System.String"))
                'dt.Columns.Add("Estado", Type.GetType("System.String"))
                'dt.Columns.Add("Fecha Alta", Type.GetType("System.DateTime"))
                'dt.Columns.Add("Fecha Baja", Type.GetType("System.DateTime"))

                'dt.Rows.Add(1, "Campaña 1", "Descripción de la Campaña 1", "Activo", "01/06/2015", DBNull.Value)
                'dt.Rows.Add(2, "Campaña 2", "Descripción de la Campaña 2", "Activo", "01/03/2015", DBNull.Value)
                'dt.Rows.Add(3, "Campaña 3", "Descripción de la Campaña 3", "Activo", "01/01/2015", DBNull.Value)

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

        Public Function Eliminar(ByVal CampaniasE As CampaniasE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Campanias_Eliminar"

                com.Parameters.Add("@pId", SqlDbType.Int).Value = CampaniasE.nId

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
