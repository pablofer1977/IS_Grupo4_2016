Namespace Entidades
    Public Class ProvinciasE

        Private _nId As Integer
        Public Property nId() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal value As Integer)
                _nId = value
            End Set
        End Property

        Private _sProvincia As String
        Public Property sProvincia() As String
            Get
                Return _sProvincia
            End Get
            Set(ByVal value As String)
                _sProvincia = value
            End Set
        End Property
    End Class
End Namespace