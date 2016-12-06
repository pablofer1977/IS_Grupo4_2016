<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDonacionesConsulta.aspx.vb" Inherits="SGD.frmDonacionesConsulta" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="DonantesConsulta" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Filtros de Búsqueda</h4>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <label class="control-label col-sm-2" for="apellido">Nro. de Donante:</label>
                            <asp:TextBox ID="txtNroDonante" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="apellido">Nro. de Donación:</label>
                            <asp:TextBox ID="txtNroDonacion" runat="server" MaxLength="8" TextMode="Number"></asp:TextBox>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tipodonacion">Estado:</label>
                            <asp:DropDownList ID="cmbEstado" runat="server"></asp:DropDownList>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tipodonacion">Tipo de Donación:</label>
                            <asp:DropDownList ID="cmbTipoDonacion" runat="server"></asp:DropDownList>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="tarjeta">Nombre de Tarjeta:</label>
                            <asp:DropDownList ID="cmbTarjeta" runat="server"></asp:DropDownList>
                        </div>
                  
                        <div class="row">
                            <label class="control-label col-sm-2" for="nrotarjeta">Número de Tarjeta o CBU:</label>
                            <asp:TextBox ID="txtNroTarjetaCBU" runat="server" MaxLength="22"></asp:TextBox>
                        </div>

                        <div class="row">
                            <label class="control-label col-sm-2" for="campania">Campaña:</label>
                            <asp:DropDownList ID="cmbCampania" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="panel-footer">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CommandName="Buscar" CssClass="btn btn-primary"/>  
                    </div>
            
                </div>
            </div>

           <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Listado de Donaciones</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Donaciones para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Ver Donantes" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            CommandName="VerDonantes" 
                                            CommandArgument='<%# Eval("Id_Donante") %>'
                                            ImageUrl ="~/Resources/Ver.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id_Donante" HeaderText="Nro. de Donante"/>
                                <asp:BoundField DataField="Id" HeaderText="Nro. de Donación"/>
                                <asp:BoundField DataField="Id_TipoDonacion" Visible="False"/>
                                <asp:BoundField DataField="TipoDonacion" HeaderText="Tipo de Donación"/>
                                <asp:BoundField DataField="Id_Tarjeta" Visible="False"/>
                                <asp:BoundField DataField="Tarjeta" HeaderText="Tarjeta"/>
                                <asp:BoundField DataField="NroTarjeta" HeaderText="Número de Tarjeta"/>
                                <asp:BoundField DataField="CBU" HeaderText="Número de CBU"/>
                                <asp:BoundField DataField="Monto" HeaderText="Monto"/>
                                <asp:BoundField DataField="Tiempo" HeaderText="Tiempo"/>
                                <asp:BoundField DataField="Id_Campania" Visible="False"/> 
                                <asp:BoundField DataField="Campania" HeaderText="Campaña"/>
                                <asp:BoundField DataField="Id_Estado" Visible="False"/> 
                                <asp:BoundField DataField="Estado" HeaderText="Estado"/>
                                <asp:BoundField DataField="FechaDon" HeaderText="Fecha de Alta"/>
                                <asp:BoundField DataField="FechaBaja" HeaderText="Fecha de Baja"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>
            </div>
        </div>

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">   
                    <h4><asp:Label ID="lblDonante" runat="server">Datos del Donante</asp:Label></h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grdD" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="5"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Donantes para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Detalle" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Detalle" runat="server" 
                                            CommandName="Detalle" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Detalles.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" HeaderText="Nro. de Donante"/>
                                <asp:BoundField DataField="FechaIng" HeaderText="Fecha de Alta"/>
                                <asp:BoundField DataField="Id_TipoDonante" Visible="False" />
                                <asp:BoundField DataField="TipoDonante" Visible="False" />
                                <asp:BoundField DataField="Nombre" HeaderText="Apellido/s y Nombre/s o Razón Social"/>
                                <asp:BoundField DataField="Direccion" Visible="False" />
                                <asp:BoundField DataField="Localidad" Visible="False" />
                                <asp:BoundField DataField="CP" Visible="False" />
                                <asp:BoundField DataField="Id_Provincia" Visible="False" />
                                <asp:BoundField DataField="Provincia" Visible="False" />
                                <asp:BoundField DataField="DNI" Visible="False" />
                                <asp:BoundField DataField="CUIL_CUIT" Visible="False" />
                                <asp:BoundField DataField="TE" HeaderText="Teléfono/s"/>
                                <asp:BoundField DataField="EMail" HeaderText="Correo Electrónico"/>
                                <asp:BoundField DataField="Comentarios" Visible="False" />
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

    <!-- Bootstrap Modal Dialog -->
    <div class="modal fade" id="Modal_Detalle" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <asp:UpdatePanel ID="upModal_Detalle" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title"><asp:Label ID="lblTituloDetalle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        
                        <div class="modal-body">
                            <label for="nrodonante">Nro. de Donante:</label>
                            <asp:Label ID="lblNroDonante" runat="server"></asp:Label>
                        </div>
                    
                        <div class="modal-body">
                            <label for="nrodonante">Fecha de Alta:</label>
                            <asp:Label ID="lblFechaIng" runat="server"></asp:Label>
                        </div>
                    
                        <div class="modal-body">
                            <label for="tipodonante">Tipo de Donante:</label>
                            <asp:Label ID="lblTipoDonante" runat="server"></asp:Label>
                        </div>
                  
                        <div class="modal-body">
                            <label for="nombre">Apellido/s y Nombre/s o Razón Social:</label>
                            <asp:Label ID="lblNombre" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="direccion">Dirección:</label>
                            <asp:Label ID="lblDireccion" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="localidad">Localidad:</label>
                            <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="codigopostal">Código Postal:</label>
                            <asp:Label ID="lblCodigoPostal" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="provincia">Provincia:</label>
                            <asp:Label ID="lblProvincia" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="nrodocumento">Nro. de Documento:</label>
                            <asp:Label ID="lblNroDocumento" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="cuit">Nro. de CUIL/CUIT:</label>
                            <asp:Label ID="lblCUIT" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="telinea">Teléfono/s:</label>
                            <asp:Label ID="lblTE" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="email">Correo Electrónico:</label>
                            <asp:Label ID="lblEMail" runat="server"></asp:Label>
                        </div>

                        <div class="modal-body">
                            <label for="comentarios">Comentarios:</label>
                            <asp:Label ID="lblComentarios" runat="server"></asp:Label>
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