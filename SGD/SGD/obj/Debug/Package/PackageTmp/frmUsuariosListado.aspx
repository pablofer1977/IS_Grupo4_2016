<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmUsuariosListado.aspx.vb" Inherits="SGD.frmUsuariosListado" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="UsuariosListado" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Filtros de Búsqueda</h4>
                </div>

                <div class="panel-body">
                    <div class="col-sm-10">
                        <label class="control-label col-sm-2" for="usuario">Usuario:</label>
                        <asp:TextBox ID="txtUsuario" runat="server" MaxLength="20"></asp:TextBox>
                    </div>

                    <div class="col-sm-10">
                        <label class="control-label col-sm-2" for="nombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" MaxLength="100"></asp:TextBox>
                    </div>

                    <div class="col-sm-10">
                        <label class="control-label col-sm-2" for="perfil">Perfil:</label>
                        <asp:DropDownList ID="cmdPerfil" runat="server"></asp:DropDownList>
                    </div>

                    <div class="col-sm-10">
                        <label class="control-label col-sm-2" for="estado">Estado:</label>
                        <asp:DropDownList ID="cmdEstado" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CommandName="Buscar" CssClass="btn btn-primary"/>
                </div>

            </div>
        </div>

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Listado de Usuarios</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                      <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Usuarios para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            CommandName="Modificar" 
                                            CommandArgument='<%# Eval("Usuario") %>'
                                            ImageUrl ="~/Resources/Modificar.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Dar de Baja" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            Enabled='<%# HabilitarEstado_Obtener(Eval("Id_Estado").ToString())%>'
                                            CommandName="Estado" 
                                            CommandArgument='<%# Eval("Usuario") %>'
                                            ImageUrl='<%# ImagenEstado_Obtener(Eval("Id_Estado").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Usuario" HeaderText="Usuario"/>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                                <asp:BoundField DataField="Id_TipoPerfil" Visible="false"/> 
                                <asp:BoundField DataField="Perfil" HeaderText="Perfil"/>
                                <asp:BoundField DataField="Id_Estado" Visible="false"/> 
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta"/>
                                <asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja"/>
                            </Columns>  
                        </asp:GridView>
                    </div>  
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnNuevo" runat="server" PostBackUrl="~/frmUsuariosAlta.aspx" Text="Nuevo Usuario" CssClass="btn btn-primary" />
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