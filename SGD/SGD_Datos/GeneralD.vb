Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades
Imports SGD_Entidades.Entidades.Variables

Imports System.Configuration
Imports System.Data.SqlClient

Namespace Datos
    Public Class GeneralD
        Public Function Estado_CargarCombo(ByVal bTodos As Boolean, ByVal bBlanco As Boolean) As DataTable
            Dim cn As New SqlConnection(sCadConn)
            Dim da As SqlDataAdapter
            Dim dt As DataTable

            Try
                dt = New DataTable

                cn.Open()

                da = New SqlDataAdapter("Estados_Combo", cn)

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
    End Class
End Namespace

