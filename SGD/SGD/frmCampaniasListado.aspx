<%@ Page Language="vb" AutoEventWireup="false" EnableEventValidation="false" CodeBehind="frmCampaniasListado.aspx.vb" Inherits="SGD.frmCampaniasListado" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="CampaniasListado" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h5 style="padding: 1px; margin: 1px"><strong>Filtros de Búsqueda</strong></h5>
                </div>

                <div class="panel-body">
                    <div style="clear:both;">
                        <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                            <label style="font-size: small; font-style: normal;" for="campania">Campaña:</label>
                        </div>
                        <div style="width: 20%; float:left; padding:2px; font-size: small;">
                            <asp:TextBox ID="txtCampania" runat="server" MaxLength="50"></asp:TextBox>
                        </div>

                        <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                            <label style="font-size: small" for="estado">Estado:</label>
                        </div>
                        <div style="width: 20%; float:left; padding:2px; font-size: small;">
                            <asp:DropDownList ID="cmdEstado" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CommandName="Buscar" CssClass="btn btn-primary"/>  
                </div>
            
            </div>
        </div>

        <div class="panel-group">
            <div class="panel panel-default">
                <div style="clear:both;">
                    <div style="float:left; text-align:left; padding:2px; font-size: small;">
                        <h5 style="padding: 1px; margin: 1px"><strong>Campañas</strong></h5>
                    </div>
                </div>

                <div class="panel-body">
                    <div style="clear:both;">
                        <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed pagination-ys"
                            EmptyDataText="No Hay Campañas para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            CommandName="Modificar" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Modificar.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            Enabled='<%# HabilitarEstado_Obtener(Eval("Id_Estado").ToString())%>'
                                            CommandName="Estado" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl='<%# ImagenEstado_Obtener(Eval("Id_Estado").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" Visible="false"/> 
                                <asp:BoundField DataField="Campania" HeaderText="Campaña"/>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripción"/>
                                <asp:BoundField DataField="Id_Estado" Visible="false"/> 
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta"/>
                                <asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnNuevo" runat="server" PostBackUrl="~/frmCampaniasAlta.aspx" Text="Nueva Campaña" CssClass="btn btn-primary"/>
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