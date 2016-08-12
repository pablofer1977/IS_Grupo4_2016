Namespace Entidades
    Public Class CampaniasE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _sCampania As String
        Public Property sCampania() As String
            Get
                Return _sCampania
            End Get
            Set(ByVal value As String)
                _sCampania = value
            End Set
        End Property

        Private _sDescripcion As String
        Public Property sDescripcion() As String
            Get
                Return _sDescripcion
            End Get
            Set(ByVal value As String)
                _sDescripcion = value
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
