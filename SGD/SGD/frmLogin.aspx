<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLogin.aspx.vb" Inherits="SGD.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
<title>Robin - Login</title>
</head>
<body>
    <div id="cuerpo">
        <form id="Form1" runat="server">
            <div>
                Login
            </div>

            <div>
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <asp:Label ID="lblMayus" runat="server"></asp:Label>
            </div>

            <div>
                Usuario:
                <asp:TextBox ID="txtUserName" runat="server" MaxLength="15"></asp:TextBox>
            </div>

            <div>
                Password:
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="btnAceptar" runat="server" Text="Entrar" PostBackUrl="~/frmDonantes.aspx"></asp:Button>
            </div>
        </form>
    </div>
</body>
</html>
