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

        <div class="panel-group" style="width: 25%; margin: 0 auto;" >

            <br />
            <br />
            <br />

            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 style="padding-left: 10px">Login</h3>
                </div>

                <div class="panel-body">
                    <div>
                        <div style="padding-left: 10px">
                            <label for="usuario">Usuario:</label>
                        </div>
                        <div style="padding-left: 10px">
                            <asp:TextBox ID="txtUserName" runat="server" MaxLength="15" Width="200px"></asp:TextBox>
                        </div>
                    </div>

                    <br />

                    <div>
                        <div style="padding-left: 10px">
                            <label for="pwd">Password:</label>
                        </div>
                        <div style="padding-left: 10px">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="panel-footer">
                    <div>
                        <div>
                            <asp:Button ID="btnAceptar" runat="server" Text="Entrar" CssClass="btn btn-primary" style="padding: 10px; margin: 10px" OnClick="btnAceptar_Click"></asp:Button>
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