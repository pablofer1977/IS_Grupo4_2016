<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmPresentacionesConsulta.aspx.vb" Inherits="SGD.frmPresentacionesConsulta" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="PresentacionesConsulta" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Filtros de Búsqueda</h4>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <label class="control-label col-sm-2" for="nropresentacion">Nro. Presentación:</label>
                            <asp:TextBox ID="txtNroPresentacion" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tipopresentacion">Tipo de Presentación:</label>
                            <asp:DropDownList ID="cmbTipoPresentacion" runat="server"></asp:DropDownList>
                        </div>
                       
                        <div class="row">
                            <label class="control-label col-sm-2" for="tarjeta">Nombre de Tarjeta:</label>
                            <asp:DropDownList ID="cmbTarjeta" runat="server"></asp:DropDownList>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="mes">Mes:</label>
                            <asp:DropDownList ID="cmbMes" runat="server"></asp:DropDownList>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="anio">Año:</label>
                            <asp:TextBox ID="txtAnio" runat="server" MaxLength="4"></asp:TextBox>
                        </div>
                    </div>

                    <div class="panel-footer">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CommandName="Buscar" CssClass="btn btn-primary"/>  
                    </div>
            
                </div>
            </div>

           <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Listado de Presentaciones</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Presentaciones para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Ver Detalle" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Detalle" runat="server" 
                                            CommandName="VerDetalles" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Ver.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" HeaderText="Nro. Presentación"/>
                                <asp:BoundField DataField="FechaPresentacion" HeaderText="Fecha"/>
                                <asp:BoundField DataField="TipoPresentacion" HeaderText="Tipo de Presentación"/>
                                <asp:BoundField DataField="Mes" HeaderText="Mes"/>
                                <asp:BoundField DataField="Anio" HeaderText="Año"/>                               
                                <asp:BoundField DataField="Tarjeta" HeaderText="Tarjeta"/>
                                <asp:BoundField DataField="DonPres" HeaderText="Donaciones Presentadas"/>
                                <asp:BoundField DataField="MontoPres" HeaderText="Monto Total Presentado"/>
                                <asp:BoundField DataField="DonAcep" HeaderText="Donaciones Aceptadas"/>
                                <asp:BoundField DataField="MontoAcep" HeaderText="Monto Total Aceptado"/>
                                <asp:BoundField DataField="DonRech" HeaderText="Donaciones Rechazadas"/>
                                <asp:BoundField DataField="MontoRech" HeaderText="Monto Total Rechazado"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>
            </div>
        </div>

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">   
                    <h4><asp:Label ID="lblPresentacion" runat="server">Listado de Detalles</asp:Label></h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grdD" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Donaciones para Mostrar.">

                            <Columns>
                                <asp:BoundField DataField="CodBanco" HeaderText="Código de Rechazo"/>
                                <asp:BoundField DataField="CausaRechazo" HeaderText="Motivo Rechazo"/>
                                <asp:BoundField DataField="Id_Donacion" HeaderText="Nro. de Donación"/>
                                <asp:BoundField DataField="Id_Donante" HeaderText="Nro. de Donante"/>
                                <asp:BoundField DataField="TipoDonacion" HeaderText="Tipo de Donación"/>
                                <asp:BoundField DataField="Id_Tarjeta" HeaderText="Tarjeta"/>
                                <asp:BoundField DataField="NroTarjeta" HeaderText="Nro. de Tarjeta"/>
                                <asp:BoundField DataField="CBU" HeaderText="Nro. de CBU"/>
                                <asp:BoundField DataField="Monto" HeaderText="Monto"/>
                                <asp:BoundField DataField="Tiempo" HeaderText="Tiempo"/>
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
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