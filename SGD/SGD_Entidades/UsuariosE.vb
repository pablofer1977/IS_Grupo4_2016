Namespace Entidades
    Public Class UsuariosE

        Private _sUsuario As String
        Public Property sUsuario() As String
            Get
                Return _sUsuario
            End Get
            Set(ByVal value As String)
                _sUsuario = value
            End Set
        End Property

        Private _sPassword As String
        Public Property sPassword() As String
            Get
                Return _sPassword
            End Get
            Set(ByVal value As String)
                _sPassword = value
            End Set
        End Property

        Private _sPassword2 As String
        Public Property sPassword2() As String
            Get
                Return _sPassword2
            End Get
            Set(ByVal value As String)
                _sPassword2 = value
            End Set
        End Property

        Private _sNombre As String
        Public Property sNombre() As String
            Get
                Return _sNombre
            End Get
            Set(ByVal value As String)
                _sNombre = value
            End Set
        End Property

        Private _nId_TipoPerfil As Integer
        Public Property nId_TipoPerfil() As Integer
            Get
                Return _nId_TipoPerfil
            End Get
            Set(ByVal value As Integer)
                _nId_TipoPerfil = value
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