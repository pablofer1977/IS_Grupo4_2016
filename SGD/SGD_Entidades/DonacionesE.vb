Namespace Entidades
    Public Class DonacionesE
        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
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

        Private _fFechaDon As Date
        Public Property fFechaDon() As Date
            Get
                Return _fFechaDon
            End Get
            Set(ByVal value As Date)
                _fFechaDon = value
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

        Private _fFechaBaja As Date
        Public Property fFechaBaja() As Date
            Get
                Return _fFechaBaja
            End Get
            Set(ByVal value As Date)
                _fFechaBaja = value
            End Set
        End Property

        Private _nId_TipoDonacion As Integer
        Public Property nId_TipoDonacion() As Integer
            Get
                Return _nId_TipoDonacion
            End Get
            Set(ByVal value As Integer)
                _nId_TipoDonacion = value
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

        Private _sNroTarjeta As String
        Public Property sNroTarjeta() As String
            Get
                Return _sNroTarjeta
            End Get
            Set(ByVal value As String)
                _sNroTarjeta = value
            End Set
        End Property

        Private _sBanco As String
        Public Property sBanco() As String
            Get
                Return _sBanco
            End Get
            Set(ByVal value As String)
                _sBanco = value
            End Set
        End Property

        Private _sVto As String
        Public Property sVto() As String
            Get
                Return _sVto
            End Get
            Set(ByVal value As String)
                _sVto = value
            End Set
        End Property

        Private _sCBU As String
        Public Property sCBU() As String
            Get
                Return _sCBU
            End Get
            Set(ByVal value As String)
                _sCBU = value
            End Set
        End Property

        Private _nMonto As Decimal
        Public Property nMonto() As Decimal
            Get
                Return _nMonto
            End Get
            Set(ByVal value As Decimal)
                _nMonto = value
            End Set
        End Property

        Private _nTiempo As Integer
        Public Property nTiempo() As Integer
            Get
                Return _nTiempo
            End Get
            Set(ByVal value As Integer)
                _nTiempo = value
            End Set
        End Property

        Private _nId_Campania As Integer
        Public Property nId_Campania() As Integer
            Get
                Return _nId_Campania
            End Get
            Set(ByVal value As Integer)
                _nId_Campania = value
            End Set
        End Property
    End Class
End Namespace