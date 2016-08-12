Namespace Entidades
    Public Class PresentacionesE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _fFechaPresentacion As Date
        Public Property fFechaPresentacion() As Date
            Get
                Return _fFechaPresentacion
            End Get
            Set(ByVal value As Date)
                _fFechaPresentacion = value
            End Set
        End Property

        Private _nMes As Integer
        Public Property nMes() As Integer
            Get
                Return _nMes
            End Get
            Set(ByVal value As Integer)
                _nMes = value
            End Set
        End Property

        Private _nAnio As Integer
        Public Property nAnio() As Integer
            Get
                Return _nAnio
            End Get
            Set(ByVal value As Integer)
                _nAnio = value
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

        Private _sId_Tarjeta As String
        Public Property sId_Tarjeta() As String
            Get
                Return _sId_Tarjeta
            End Get
            Set(ByVal value As String)
                _sId_Tarjeta = value
            End Set
        End Property
    End Class
End Namespace