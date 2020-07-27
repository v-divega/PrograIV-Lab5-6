<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridAvanzado.aspx.cs" Inherits="Lab5y6.GridAvanzado" EnableEventValidation="False" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="gridCarro" 
            runat="server" 
            BackColor="White" 
            BorderColor="#DEDFDE" 
            BorderStyle="None"
            BorderWidth="1px" 
            CellPadding="4" 
            ForeColor="Black" 
            GridLines="Vertical"
             AutoGenerateColumns ="false"
                DataKeyNames ="idCarro"
                OnRowCommand="gridCarro_RowCommand"
                OnRowEditing="gridCarro_RowEditing"
                OnRowCancelingEdit="gridCarro_RowCancelingEdit"
                OnRowUpdating="gridCarro_RowUpdating"
                OnRowDeleting="gridCarro_RowDeleting"
                ShowHeaderWhenEmpty="false"
                ShowFooter="true"

            >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />

             <Columns>
                    <asp:TemplateField HeaderText="idCarro">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("idCarro")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtidCarro" Text='<%# Eval("idCarro")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtidCarroPie" Text='<%# Eval("idCarro")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Marca">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Marca")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMarca" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMarcaPie" Text='<%# Eval("Marca")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Modelo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Modelo")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtModelo" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtModeloPie" Text='<%# Eval("Modelo")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Pais">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Pais")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPais" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtPaisPie" Text='<%# Eval("Pais")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Costo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Costo")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCosto" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCostoPie" Text='<%# Eval("Costo")  %>' runat="server"></asp:TextBox>
                        </FooterTemplate>

                    </asp:TemplateField>

                     <asp:TemplateField>
                        <ItemTemplate> 
                        <asp:ImageButton ImageUrl="Imagenes/editar.png" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />    
                        <asp:ImageButton ImageUrl="Imagenes/eliminar.png" runat="server" CommandName="Delete" ToolTip="Eliminar" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="Imagenes/actualizar.png" runat="server" CommandName="Update" ToolTip="Actualizar" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="Imagenes/cancelar.png" runat="server" CommandName="Cancel" ToolTip="Cancelar" Width="20px" Height="20px" />
                        </EditItemTemplate>
                        <FooterTemplate>
                        <asp:ImageButton ImageUrl="Imagenes/nuevo.png" runat="server" CommandName="New" ToolTip="Nuevo" Width="20px" Height="20px" />
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>







        </asp:GridView>

        <br />
            <br />

            <asp:label ID="lblExitoso" runat="server" ForeColor="Green"></asp:label>
            <asp:label ID="lblError" runat="server" ForeColor="Red"></asp:label>

    </form>
</body>
</html>
