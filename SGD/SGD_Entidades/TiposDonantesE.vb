Namespace Entidades
    Public Class TiposDonantesE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _sTipoDonante As String
        Public Property sTipoDonante() As String
            Get
                Return _sTipoDonante
            End Get
            Set(ByVal value As String)
                _sTipoDonante = value
            End Set
        End Property
    End Class
End Namespace