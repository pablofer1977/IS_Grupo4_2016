<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmDonantesImportacion.aspx.vb" Inherits="SGD.frmDonantesImportacion" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="DonantesImportacion" ContentPlaceHolderID="body" runat="server">
    <div class="container"> 
        <div class="panel-group">
            <div class="panel-group">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4>Seleccionar Archivo a Importar</h4>
                    </div>

                    <div class="panel-body">
                        <div class="row">
                            <asp:FileUpload ID="FileUpload" runat="server" />
                        </div>
                    </div>

                    <div class="panel-footer">
                        <asp:Button ID="btnImportar" runat="server" Text="Importar Archivo" CommandName="Importar_Archivo" CssClass="btn btn-primary"/>  
                        <asp:Button ID="btnGrabar" runat="server" Text="Grabar Donantes/Donaciones" CommandName="Importar_Donantes" CssClass="btn btn-primary"/>  
                        <asp:Button ID="btnEliminar" runat="server" Text="Borrar Datos Archivo" CommandName="Eliminar_Archivo" CssClass="btn btn-primary"/>  
                    </div>      
                </div>
            </div>

           <div class="panel panel-default">
                <div class="panel-heading">
                    <h4>Listado de Donantes/Donaciones Validados</h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grd" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="10"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Donantes/Donaciones para Mostrar.">

                            <Columns>
                                <asp:TemplateField HeaderText="Resultado" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Resultado" runat="server" 
                                            CommandName="Resultado" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl='<%# ImagenResultado_Obtener(Eval("Id_TipoValidacion").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Guardar" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:CheckBox Id="Guardar" runat="server"
                                            Datafield="Guardar"
                                            Enabled='<%# HabilitarGuardar_Obtener(Eval("Id_TipoValidacion").ToString())%>'
                                            Checked='<%# CheckedGuardar_Obtener(Eval("Id_TipoValidacion").ToString())%>'
                                            CommandArgument='<%# Eval("Id") %>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ver Log" ItemStyle-HorizontalAlign="Center" >
                                    <ItemTemplate>
                                        <asp:ImageButton Id="Ver_Log" runat="server" 
                                            Enabled='<%# HabilitarLog_Obtener(Eval("Id_TipoValidacion").ToString())%>'
                                            CommandName="Ver_Log" 
                                            CommandArgument='<%# Eval("Id") %>'
                                            ImageUrl='<%# ImagenLog_Obtener(Eval("Id_TipoValidacion").ToString())%>'/>
                                    </ItemTemplate>

                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Id" HeaderText="Nro."/>
                                <asp:BoundField DataField="Id_TipoValidacion" Visible="False" />
                                <asp:BoundField DataField="Id_TipoDonante" Visible="False" />
                                <asp:BoundField DataField="TipoDonante" HeaderText="Tipo de Donante"/>
                                <asp:BoundField DataField="Apellido" HeaderText="Apellido/s"/>
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre/s"/>
                                <asp:BoundField DataField="Razon_Social" HeaderText="Razón Social"/>
                                <asp:BoundField DataField="Direccion" HeaderText="Dirección"/>
                                <asp:BoundField DataField="Localidad" HeaderText="Localidad"/>
                                <asp:BoundField DataField="CP" HeaderText="Código Postal"/>
                                <asp:BoundField DataField="Id_Provincia" Visible="False" />
                                <asp:BoundField DataField="Provincia" HeaderText="Provincia"/>
                                <asp:BoundField DataField="DNI" HeaderText="Nro. de Documento"/>
                                <asp:BoundField DataField="CUIL_CUIT" HeaderText="Nro. de CUIL/CUIT"/>
                                <asp:BoundField DataField="TE_Linea" HeaderText="Teléfono de Línea"/>
                                <asp:BoundField DataField="TE_Celular" HeaderText="Teléfono Celular"/>
                                <asp:BoundField DataField="TE_Laboral" HeaderText="Teléfono Laboral"/>
                                <asp:BoundField DataField="EMail" HeaderText="Correo Electrónico"/>
                                <asp:BoundField DataField="Id_TipoDonacion" Visible="False"/>
                                <asp:BoundField DataField="TipoDonacion" HeaderText="Tipo de Donación"/>
                                <asp:BoundField DataField="Id_Tarjeta" Visible="False"/>
                                <asp:BoundField DataField="Tarjeta" HeaderText="Nombre de la Tarjeta"/>
                                <asp:BoundField DataField="NroTarjeta" HeaderText="Número de Tarjeta"/>
                                <asp:BoundField DataField="Banco" HeaderText="Banco Emitente"/>
                                <asp:BoundField DataField="Vto" HeaderText="Vencimiento Tarjeta"/>
                                <asp:BoundField DataField="CBU" HeaderText="Número de CBU"/>
                                <asp:BoundField DataField="Monto" HeaderText="Monto"/>
                                <asp:BoundField DataField="Tiempo" HeaderText="Tiempo"/>
                                <asp:BoundField DataField="Id_Campania" Visible="False"/> 
                                <asp:BoundField DataField="Campania" HeaderText="Campaña"/>
                            </Columns>  
                        </asp:GridView>   
                    </div>  
                </div>
            </div>
        </div>

        <div class="panel-group">
            <div class="panel panel-default">
                <div class="panel-heading">   
                    <h4><asp:Label ID="lblNro" runat="server">Listado de Validaciones</asp:Label></h4>
                </div>

                <div class="panel-body">
                    <div class="row">
                        <asp:GridView ID="grdV" 
                            runat="server" 
                            AutoGenerateColumns="False" 
                            AllowPaging="True" 
                            PageSize="5"
                            CssClass="table table-striped table-bordered table-hover table-condensed"
                            EmptyDataText="No Hay Validaciones para Mostrar.">

                            <Columns>
                                <asp:BoundField DataField="TipoValidacion" HeaderText="Tipo de Validación"/>
                                <asp:BoundField DataField="Validacion" HeaderText="Descripción Validación"/>
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