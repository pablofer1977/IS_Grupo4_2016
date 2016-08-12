Namespace Entidades
    Public Class PresentacionesDetallesE
        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _nId_Presentacion As Integer
        Public Property nId_Presentacion() As Integer
            Get
                Return _nId_Presentacion
            End Get
            Set(ByVal value As Integer)
                _nId_Presentacion = value
            End Set
        End Property

        Private _nId_Donante As Integer
        Public Property nId_Donante() As Integer
            Get
                Return _nId_Donante
            End Get
            Set(ByVal value As Integer)
                _nId_Donante = value
            End Set
        End Property

        Private _nId_Donacion As Integer
        Public Property nId_Donacion() As Integer
            Get
                Return _nId_Donacion
            End Get
            Set(ByVal value As Integer)
                _nId_Donacion = value
            End Set
        End Property

        Private _nId_Rechazo As Integer
        Public Property nId_Rechazo() As Integer
            Get
                Return _nId_Rechazo
            End Get
            Set(ByVal value As Integer)
                _nId_Rechazo = value
            End Set
        End Property
    End Class
End Namespace

