<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmTarjetasListado.aspx.vb" Inherits="SGD.frmTarjetasListado" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="TarjetasListado" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Listado de Tarjetas</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="5"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Tarjetas para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            CommandName="Modificar" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Modificar.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ver Causas" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            CommandName="VerCausas" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Ver.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" HeaderText="Tarjeta"/>
                                <asp:BoundField DataField="Tarjeta" HeaderText="Nombre de Tarjeta o CBU"/>
                                <asp:BoundField DataField="TipoPresentacion" HeaderText="Tipo de Presentación"/>
                                <asp:BoundField DataField="NombreArchivo" HeaderText="Nombre del Archivo"/>
                                <asp:BoundField DataField="NroComercio" HeaderText="Nro. de Comercio"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>
            </div>
        </div>

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">   
                    <h4><asp:Label ID="lblTarjeta" runat="server">Listado de Causas de Rechazos</asp:Label></h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grdR" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Causas de Rechazos para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Modificar" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            CommandName="Modificar" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Modificar.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Dar de Baja" ItemStyle-HorizontalAlign="Center" >
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
                                <asp:BoundField DataField="Id_Tarjeta" Visible="false"/> 
                                <asp:BoundField DataField="Tarjeta" Visible="false"/> 
                                <asp:BoundField DataField="CodBanco" HeaderText="Código Banco"/>
                                <asp:BoundField DataField="CausaRechazo" HeaderText="Causa Rechazo"/>
                                <asp:BoundField DataField="CausaOK" HeaderText="Causa OK"/>
                                <asp:BoundField DataField="Id_Estado" Visible="false"/> 
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                <asp:BoundField DataField="FechaAlta" HeaderText="Fecha de Alta"/>
                                <asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>

                <div class="panel-footer">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nueva Causa de Rechazo" CssClass="btn btn-primary"/>
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