Namespace Entidades
    Public Class TiposDonacionesE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _sTipoDonacion As String
        Public Property sTipoDonacion() As String
            Get
                Return _sTipoDonacion
            End Get
            Set(ByVal value As String)
                _sTipoDonacion = value
            End Set
        End Property
    End Class
End Namespace