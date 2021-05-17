<%@ Page Title="" Language="C#" MasterPageFile="~/userPage.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<asp:GridView ID="gvproductdetails" runat="server"  AutoGenerateColumns="False"  BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="1220px">
    <Columns>
        <asp:TemplateField>
            <HeaderTemplate>
                PRODUCT IMAGE
            </HeaderTemplate>
            <ItemTemplate>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="141px" Width="227px" ImageUrl='<%# Bind("product_img_url") %>' AlternateText='<%# Bind("product_id") %>' OnClick="imgbtn_Click"/> 
            </ItemTemplate>
        </asp:TemplateField>


          <asp:TemplateField>
            <HeaderTemplate>
                PRODUCT NAME
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblproductname" runat="server" Text='<%#Bind("p_name") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField>
            <HeaderTemplate>
                PRODUCT CATEGORY
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblproductcata" runat="server" Text='<%#Bind("p_categor") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField>
            <HeaderTemplate>
                PRODUCT PRICE
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblproductprice" runat="server" Text='<%#Bind("p_price") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    
    </asp:GridView>
</asp:Content>



