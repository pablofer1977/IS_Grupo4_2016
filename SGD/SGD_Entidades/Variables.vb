Namespace Entidades
    Public Class Variables
        '--------------- Variables de logeo ---------------
        Public Shared sDataSource As String
        Public Shared sInitialCatalog As String
        Public Shared sPersistSecurityInfo As String
        Public Shared sCadConn As String

        Public Shared sUserName As String
        Public Shared sPassword As String
        Public Shared nPerfil As Integer

        '--------------- Variables para las acciones en las SP ---------------
        Public Enum eAccion
            Agregar = 1
            Modificar = 2
            ActualizarEstado = 3
            Eliminar = 4
        End Enum
    End Class
End Namespace