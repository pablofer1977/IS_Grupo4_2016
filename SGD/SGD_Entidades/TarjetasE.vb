Namespace Entidades
    Public Class TarjetasE
        Private _sId As String
        Public Property sId() As String
            Get
                Return _sId
            End Get
            Set(ByVal value As String)
                _sId = value
            End Set
        End Property

        Private _sTarjeta As String
        Public Property sTarjeta() As String
            Get
                Return _sTarjeta
            End Get
            Set(ByVal value As String)
                _sTarjeta = value
            End Set
        End Property
		
        Private _nId_TipoPresentacion As Integer
        Public Property nId_TipoPresentacion() As Integer
            Get
                Return _nId_TipoPresentacion
            End Get
            Set(ByVal value As Integer)
                _nId_TipoPresentacion = value
            End Set
        End Property

        Private _sNombreArchivo As String
        Public Property sNombreArchivo() As String
            Get
                Return _sNombreArchivo
            End Get
            Set(ByVal value As String)
                _sNombreArchivo = value
            End Set
        End Property

        Private _sNroComercio As String
        Public Property sNroComercio() As String
            Get
                Return _sNroComercio
            End Get
            Set(ByVal value As String)
                _sNroComercio = value
            End Set
        End Property
    End Class
End Namespace