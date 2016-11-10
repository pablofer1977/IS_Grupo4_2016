<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmLogin.aspx.vb" Inherits="SGD.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8"/>
<link href="Content/css/bootstrap.css" rel="stylesheet" />
<script src="Scripts/jquery-1.12.4.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<title>Robin - Login</title>
</head>
<body>
    <form id="frmLogin" runat="server" class="form-horizontal" role="form">
        <div class="container-login">
            <div class="panel-group">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4>Login</h4>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <label class="control-label col-sm-2" for="usuario">Usuario:</label>

                            <div class="col-sm-10">
                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="15" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="pwd">Password:</label>

                            <div class="col-sm-10"> 
                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="btnAceptar" runat="server" Text="Entrar" CssClass="btn btn-primary" OnClick="btnAceptar_Click"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Bootstrap Modal Dialog -->
        <div class="modal fade" id="Modal_Error" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:ScriptManager ID="sManager" runat="server"></asp:ScriptManager>
                
                <asp:UpdatePanel ID="upModal_Error" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                <h4 class="modal-title"><asp:Label ID="lblTituloError" runat="server" Text=""></asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Cerrar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>