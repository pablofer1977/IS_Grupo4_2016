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

        Public Enum eDonantes_Tipos
            Fisico = 1
            Juridico = 2
        End Enum

        Public Enum eDonaciones_Tipos
            Tarjeta = 1
            CBU = 2
        End Enum

        Public Enum eMensajes_Tipos
            Error_Aplicacion = -1
            Error_Validacion = 1
            PreguntaSiNo = 2
            AccionOK = 0
        End Enum

        Public Enum eValidaciones_Tipos
            OK = 1
            Advertencia = 2
            Error_ = 3
        End Enum
    End Class
End Namespace