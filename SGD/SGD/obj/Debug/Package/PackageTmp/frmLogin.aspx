<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLogin.aspx.vb" Inherits="SGD.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
<link href="Content/css/bootstrap.css" rel="stylesheet" type="text/css"/>
<title>Robin - Login</title>
</head>
<body>
    <div class="container-login">
        <h2>Login</h2>
        <form id="Form1" runat="server" class="form-horizontal" role="form">
            <div class="form-group">
                <label class="control-label col-sm-2" for="usuario">Usuario:</label>

                <div class="col-sm-10">
                    <asp:TextBox ID="txtUserName" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

           <div class="form-group">
                <label class="control-label col-sm-2" for="pwd">Password:</label>

                <div class="col-sm-10"> 
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-sm-offset-2 col-sm-10">
                    <asp:Button ID="btnAceptar" runat="server" Text="Entrar" CssClass="btn btn-primary"></asp:Button>
                </div>
            </div>
        </form>
    </div>
</body>
</html>