Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class UsuariosD

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

                da = New SqlDataAdapter("Usuarios_Combo", cn)

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

        Public Function TiposPerfiles_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Usuarios_TiposPerfiles_Combo", cn)

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

        Public Function Listado(ByVal UsuariosE As UsuariosE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Usuarios_Listado", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pUsuario", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(UsuariosE.sUsuario), UsuariosE.sUsuario, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(UsuariosE.sNombre), UsuariosE.sNombre, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pId_TipoPerfil", SqlDbType.Int).Value = IIf(UsuariosE.nId_TipoPerfil <> 0, UsuariosE.nId_TipoPerfil, DBNull.Value)
                da.SelectCommand.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = IIf(Not IsNothing(UsuariosE.sEstado), UsuariosE.sEstado, DBNull.Value)

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Obtener(ByVal UsuariosE As UsuariosE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Usuarios_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = UsuariosE.sUsuario

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function

        Public Function Agregar(ByVal UsuariosE As UsuariosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Usuarios_Agregar"

                com.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = IIf(Not IsNothing(UsuariosE.sUsuario), UsuariosE.sUsuario, DBNull.Value)
                com.Parameters.Add("@pPassword", SqlDbType.VarChar, 50).Value = IIf(Not IsNothing(UsuariosE.sPassword), UsuariosE.sPassword, DBNull.Value)
                com.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(UsuariosE.sNombre), UsuariosE.sNombre, DBNull.Value)
                com.Parameters.Add("@pId_TipoPerfil", SqlDbType.Int).Value = IIf(UsuariosE.nId_TipoPerfil <> 0, UsuariosE.nId_TipoPerfil, DBNull.Value)

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

        Public Function Modificar(ByVal UsuariosE As UsuariosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Usuarios_Modificar"

                com.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = IIf(Not IsNothing(UsuariosE.sUsuario), UsuariosE.sUsuario, DBNull.Value)
                com.Parameters.Add("@pNombre", SqlDbType.VarChar, 100).Value = IIf(Not IsNothing(UsuariosE.sNombre), UsuariosE.sNombre, DBNull.Value)
                com.Parameters.Add("@pId_TipoPerfil", SqlDbType.Int).Value = IIf(UsuariosE.nId_TipoPerfil <> 0, UsuariosE.nId_TipoPerfil, DBNull.Value)

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

        Public Function Eliminar(ByVal UsuariosE As UsuariosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Usuarios_Eliminar"

                com.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = UsuariosE.sUsuario

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

        Public Function Estado(ByVal UsuariosE As UsuariosE) As Boolean
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Usuarios_Estado"

                com.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = UsuariosE.sUsuario
                com.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = UsuariosE.sEstado

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

        Public Function Verificar(nAccion As Integer, ByVal UsuariosE As UsuariosE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Usuarios_Verificar"

                com.Parameters.Add("@pAccion", SqlDbType.Int).Value = nAccion
                com.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = UsuariosE.sUsuario

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function Estado_Verificar(ByVal UsuariosE As UsuariosE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Usuarios_Estado_Verificar"

                com.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = UsuariosE.sUsuario
                com.Parameters.Add("@pEstado", SqlDbType.Char, 1).Value = UsuariosE.sEstado

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function Password_Verificar(ByVal UsuariosE As UsuariosE) As Integer
            Dim cn As New SqlConnection(sCadConn)
            Dim com As New SqlCommand

            Dim nCantidad As Integer = 0

            Try
                cn.Open()

                com.Connection = cn
                com.CommandType = CommandType.StoredProcedure

                com.CommandText = "Usuarios_Password_Verificar"

                com.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = UsuariosE.sUsuario
                com.Parameters.Add("@pPassword", SqlDbType.VarChar, 50).Value = UsuariosE.sPassword

                nCantidad = com.ExecuteScalar

                com.Dispose()
                cn.Close()

                Return nCantidad

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return nCantidad
            End Try
        End Function

        Public Function Perfil_Obtener(ByVal UsuariosE As UsuariosE) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Usuarios_Perfiles_Obtener", cn)
                da.SelectCommand.CommandType = CommandType.StoredProcedure

                da.SelectCommand.Parameters.Add("@pUsuario", SqlDbType.VarChar, 20).Value = UsuariosE.sUsuario

                da.Fill(dt)

                cn.Close()
                da = Nothing

                Return dt

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Robin")
                Return Nothing
            End Try
        End Function
    End Class
End Namespace
