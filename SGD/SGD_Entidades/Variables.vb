Namespace Entidades
    Public Class Variables
        '--------------- Variables de logeo ---------------
        Public Shared sCadConn As String

        Public Shared nPerfil As Integer

        '--------------- Variables para las acciones en las SP ---------------
        Public Enum eAccion
            Agregar = 1
            Modificar = 2
            ActualizarEstado = 3
            Eliminar = 4
        End Enum

        Public Enum ePerfiles
            Administrador = 1
            Usuario_Consulta = 2
        End Enum
    End Class
End Namespace