Namespace Entidades
    Public Class TiposPresentacionesE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _sTipoPresentacion As String
        Public Property sTipoPresentacion() As String
            Get
                Return _sTipoPresentacion
            End Get
            Set(ByVal value As String)
                _sTipoPresentacion = value
            End Set
        End Property
    End Class
End Namespace


