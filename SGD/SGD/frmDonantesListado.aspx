<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDonantesListado.aspx.vb" Inherits="SGD.frmDonantesListado" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="DonantesListado" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h5 style="padding: 1px; margin: 1px"><strong>Filtros de Búsqueda</strong></h5>
                    </div>

                    <div class="panel-body">
                        <div style="clear:both;">
                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small; font-style: normal;" for="nrodonante">Nro. de Donante:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:TextBox ID="txtNroDonante" runat="server" MaxLength="8" TextMode="Number" Width="40%"></asp:TextBox>
                            </div>

                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="localidad">Localidad:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:TextBox ID="txtLocalidad" runat="server" MaxLength="50" Width="100%"></asp:TextBox>
                            </div>

                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="nrodonacion">Nro. de Donación:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:TextBox ID="txtNroDonacion" runat="server" MaxLength="8" TextMode="Number" Width="40%"></asp:TextBox>
                            </div>
                        </div>
                  
                        <div style="clear:both;">
                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="apellido">Nombre:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:TextBox ID="txtNombre" runat="server" MaxLength="100" Width="100%"></asp:TextBox>
                            </div>

                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="codigopostal">Código Postal:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:TextBox ID="txtCodigoPostal" runat="server" MaxLength="10" Width="50%"></asp:TextBox>
                            </div>

                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="tipodonacion">Estado:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:DropDownList ID="cmbEstado" runat="server" Width="100%"></asp:DropDownList>
                            </div>
                        </div>

                        <div style="clear:both;">
                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="direccion">Dirección:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:TextBox ID="txtDireccion" runat="server" MaxLength="100" Width="100%"></asp:TextBox>
                            </div>

                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="provincia">Provincia:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:DropDownList ID="cmbProvincia" runat="server" Width="100%"></asp:DropDownList>
                            </div>

                            <div style="width: 10%; float:left; text-align:right; padding:2px; font-size: small;">
                                <label style="font-size: small" for="campania">Campaña:</label>
                            </div>
                            <div style="width: 20%; float:left; padding:2px; font-size: small;">
                                <asp:DropDownList ID="cmbCampania" runat="server" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <div class="panel-footer" style="padding: 4px; margin: 1px">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CommandName="Buscar" CssClass="btn btn-primary"/>  
                    </div>
            
                </div>
            </div>

           <div class="panel panel-default">
                <div class="panel-heading">
                    <div style="clear:both;">
                        <div style="float:left; text-align:left; padding:2px; font-size: small;">
                            <h5 style="padding: 1px; margin: 1px"><strong>Donantes</strong></h5>
                        </div>
                        <div style="float:right; padding:2px; font-size: small;">
                            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Donante" CssClass="btn btn-primary"/>
                        </div>
                    </div>
                </div>

                <div class="panel-body">
                    <div style="clear:both;">
                        <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="5"
                            CssClass="table table-striped table-bordered table-hover table-condensed pagination-ys"
                            EmptyDataText="No Hay Donantes para Mostrar.">

                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            CommandName="Modificar" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Modificar.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Detalle" runat="server" 
                                            CommandName="Detalle" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Detalles.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            CommandName="VerDonaciones" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl ="~/Resources/Ver.png" />
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" HeaderText="Nro. de Donante"/>
                                <asp:BoundField DataField="FechaIng" HeaderText="Fecha de Alta" />
                                <asp:BoundField DataField="Id_TipoDonante" Visible="False" />
                                <asp:BoundField DataField="TipoDonante" Visible="False" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
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

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div style="clear:both;">
                        <div style="float:left; text-align:left; padding:2px; font-size: small;">
                            <h5 style="padding: 1px; margin: 1px"><strong><asp:Label ID="lblDonante" runat="server">Donaciones</asp:Label></strong></h5>
                        </div>
                        <div style="float:right; padding:2px; font-size: small;">
                            <asp:Button ID="btnNuevoD" runat="server" Text="Nueva Donación" CssClass="btn btn-primary"/>
                        </div>
                    </div>
                </div>

                <div class="panel-body">
                    <div>
                        <asp:GridView ID="grdD" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="5"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Donaciones para Mostrar.">

                            <Columns>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Modificar" runat="server" 
                                            Enabled='<%# HabilitarEstado_Obtener(Eval("Id_Estado").ToString())%>'
                                            CommandName="ModificarD" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl='<%# ImagenModificar_Obtener(Eval("Id_Estado").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Estado" runat="server" 
                                            Enabled='<%# HabilitarEstado_Obtener(Eval("Id_Estado").ToString())%>'
                                            CommandName="Baja" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl='<%# ImagenEstado_Obtener(Eval("Id_Estado").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

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
    </div>

    <asp:ScriptManager ID="sManager" runat="server"></asp:ScriptManager>
                
    <!-- Bootstrap Modal Dialog -->
    <div class="modal fade" id="Modal_Error" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal_Error" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
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
                        <div class="modal-header-detalle">
                            <h5 style="padding: 10px; margin: 1px"><strong><asp:Label ID="lblTituloDetalle" runat="server" Text=""></asp:Label></strong></h5>
                        </div>
                        
                        <div class="modal-body">
							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="nrodonante">Nro. de Donante:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblNroDonante" runat="server"></asp:Label>
								</div>
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="nrodocumento">Nro. de Documento:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblNroDocumento" runat="server"></asp:Label>
								</div>
							</div>  

							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="fechaalta">Fecha de Alta:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblFechaIng" runat="server"></asp:Label>
								</div>
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="cuit">Nro. de CUIL/CUIT:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblCUIT" runat="server"></asp:Label>
								</div>
							</div> 							

							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="tipodonante">Tipo de Donante:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblTipoDonante" runat="server"></asp:Label>
								</div>
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="telinea">Teléfono/s:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblTE" runat="server"></asp:Label>
								</div>
							</div> 
				
							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="nombre">Nombre:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblNombre" runat="server"></asp:Label>
								</div>
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="email">Correo Electrónico:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblEMail" runat="server"></asp:Label>
								</div>
							</div> 	
      
							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="direccion">Dirección:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblDireccion" runat="server"></asp:Label>
								</div>
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="email">Comentarios:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblComentarios" runat="server"></asp:Label>
								</div>
							</div> 	

							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="localidad">Localidad:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblLocalidad" runat="server"></asp:Label>
								</div>
							</div> 	

							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="codigopostal">Código Postal:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblCodigoPostal" runat="server"></asp:Label>
								</div>
							</div> 	

							<div style="clear:both;">
								<div style="width: 20%; float:left; text-align:right; padding:2px; font-size: small;">
									<label style="font-size: small; font-style: normal; font-weight: normal;" for="provincia">Provincia:</label>
								</div>
								<div style="width: 30%; float:left; padding:2px; font-size: small; font-weight: bold;">
									<asp:Label ID="lblProvincia" runat="server"></asp:Label>
								</div>
							</div> 	
                        </div>
                        <br />
                        <div class="modal-footer-detalle" style="padding: 4px; margin: 1px">
							<div style="clear:both;">
								<button class="btn btn-info-detalle" data-dismiss="modal" aria-hidden="true">Cerrar</button>
							</div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>