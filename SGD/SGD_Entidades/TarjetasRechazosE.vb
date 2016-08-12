Namespace Entidades
    Public Class TarjetasRechazosE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _sId_Tarjeta As String
        Public Property sId_Tarjeta() As String
            Get
                Return _sId_Tarjeta
            End Get
            Set(ByVal value As String)
                _sId_Tarjeta = value
            End Set
        End Property

        Private _sCodBanco As String
        Public Property sCodBanco() As String
            Get
                Return _sCodBanco
            End Get
            Set(ByVal value As String)
                _sCodBanco = value
            End Set
        End Property

        Private _sCausaRechazo As String
        Public Property sCausaRechazo() As String
            Get
                Return _sCausaRechazo
            End Get
            Set(ByVal value As String)
                _sCausaRechazo = value
            End Set
        End Property

        Private _bCausaOK As Boolean
        Public Property bCausaOK() As Boolean
            Get
                Return _bCausaOK
            End Get
            Set(ByVal value As Boolean)
                _bCausaOK = value
            End Set
        End Property

        Private _sEstado As String
        Public Property sEstado() As String
            Get
                Return _sEstado
            End Get
            Set(ByVal value As String)
                _sEstado = value
            End Set
        End Property

        Private _fFechaAlta As Date
        Public Property fFechaAlta() As Date
            Get
                Return _fFechaAlta
            End Get
            Set(ByVal value As Date)
                _fFechaAlta = value
            End Set
        End Property

        Private _fFechaBaja As Date
        Public Property fFechaBaja() As Date
            Get
                Return _fFechaBaja
            End Get
            Set(ByVal value As Date)
                _fFechaBaja = value
            End Set
        End Property
    End Class
End Namespace