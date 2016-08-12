Namespace Entidades
    Public Class TiposPerfilesE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _sPerfil As String
        Public Property sPerfil() As String
            Get
                Return _sPerfil
            End Get
            Set(ByVal value As String)
                _sPerfil = value
            End Set
        End Property
    End Class
End Namespace