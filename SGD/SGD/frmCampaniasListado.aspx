<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="frmCampaniasListado.aspx.vb" Inherits="SGD.frmCampaniasListado" MasterPageFile="~/frmMenu.Master" %>

<asp:Content ID="CampaniasListado" ContentPlaceHolderID="body" runat="server">
    
    <div>
        <div>

        </div>
    </div>

    <div>
        <div>
            <asp:GridView ID="grd" runat="server">
                <Columns>
                    <asp:ButtonField ButtonType="Image" CommandName="Modificar" Text="Modificar" />
                    <asp:ButtonField CommandName="Eliminar" Text="Eliminar" ButtonType="Image" />
                    <asp:ButtonField ButtonType="Image" CommandName="Actualizar_Estado" Text="Actualizar Estado" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div>
        <div>
            <asp:Button ID="btnNuevo" runat="server" PostBackUrl="~/frmCampaniasAlta.aspx" Text="Nuevo" />
        </div>
    </div>
</asp:Content>