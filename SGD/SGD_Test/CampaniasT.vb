Imports NUnit.Framework
Imports SGD_Datos.Datos
Imports SGD_Entidades.Entidades

Namespace Test
    <TestFixture()>
    Public Class CampaniasT
        <Test()>
        Public Sub Listado()
            'creamos origen
            Dim CampaniasD As New CampaniasD
            Dim CampaniasE As New CampaniasE

            Dim dt As New DataTable

            dt = CampaniasD.Listado(CampaniasE)

            'CampaniasE.nId = 10

            ''creamos la cuenta destino con un saldo de 150.00
            'Dim Destino_CampaniasN As New CampaniasN
            'destino.Deposito(150.0)

            ''transferimos 100.00 de la cuenta origen a la destino
            'origen.Transferencia(destino, 100.0)

            ''sí todo ha salido bien, debemos tener
            ''un balance de 250.00 en la cuenta destino
            ''y de 100.00 en la origen
            'Assert.AreEqual(250.0, destino.Balance)
            'Assert.AreEqual(10, CampaniasE.nId)

            Assert.IsNotNull(dt)
        End Sub

        <Test()>
        Public Sub Prueba()
            'creamos origen
            Dim nId As Integer = 10

            'CampaniasE.nId = 10

            ''creamos la cuenta destino con un saldo de 150.00
            'Dim Destino_CampaniasN As New CampaniasN
            'destino.Deposito(150.0)

            ''transferimos 100.00 de la cuenta origen a la destino
            'origen.Transferencia(destino, 100.0)

            ''sí todo ha salido bien, debemos tener
            ''un balance de 250.00 en la cuenta destino
            ''y de 100.00 en la origen
            'Assert.AreEqual(250.0, destino.Balance)
            'Assert.AreEqual(10, CampaniasE.nId)

            'Assert.IsNotEmpty(CampaniasD.Listado(CampaniasE))

            Assert.AreEqual(10, nId)
        End Sub

    End Class
End Namespace


