<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmUsuariosModificacion.aspx.vb" Inherits="SGD.frmUsuariosModificacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="UsuariosModificacion" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Modificación de Usuario</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <label class="control-label col-sm-2" for="usuario">Usuario:</label>
                        <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                    </div>
        
                    <div class="row">
                        <label class="control-label col-sm-2" for="nombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio]</label>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="perfil">Perfil:</label>
                        <asp:DropDownList ID="cmdPerfil" runat="server"></asp:DropDownList>
                        <label style="font-size: xx-small; font-style: italic"> [Obligatorio]</label>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="estado">Estado:</label>
                        <asp:Label ID="lblEstado" runat="server"></asp:Label>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="fechaalta">Fecha de Alta:</label>
                        <asp:Label ID="lblFechaAlta" runat="server"></asp:Label>
                    </div>

                    <div class="row">
                        <label class="control-label col-sm-2" for="fechabaja">Fecha de Baja:</label>
                        <asp:Label ID="lblFechaBaja" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnAceptar" runat="server" Text="Guardar" CssClass="btn btn-primary" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

    <asp:ScriptManager ID="sManager" runat="server"></asp:ScriptManager>
                
    <!-- Bootstrap Modal Dialog -->
    <div class="modal fade" id="Modal_Error" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
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
</asp:Content>
