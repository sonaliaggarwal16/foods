<%@ Page Title="" Language="C#" MasterPageFile="~/userPage.master" AutoEventWireup="true" CodeFile="productdetail.aspx.cs" Inherits="productdetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="productdetailsmain">
        <div class="imagepart">
            <asp:Image ID="imgproduct" runat="server" Height="248px" Width="291px" />
        </div>
        <div class="contentpart">
            <table>
                <tr>
                    <td>PRODUCT NAME</td><td><asp:Label ID="lblproductname" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>PRODUCT CATEGORY</td><td><asp:Label ID="lblpcategory" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>PRODUCT UNIT PRICE</td><td><asp:Label ID="lblprice" runat="server"></asp:Label></td>
                </tr>
                 <tr>
                    <td>PRODUCT TOTAL PRICE</td><td><asp:Label ID="lbltotalprice" runat="server"></asp:Label></td>
                </tr>
                <tr><td colspan="2">
                    <asp:Button ID="btnminus" runat="server" Font-Bold="True" Font-Size="Medium"  Text="-" Width="29px" OnClick="btnminus_Click" />
                    <asp:Label ID="lblquantity" runat="server" BorderColor="Black" BorderStyle="Solid" Height="24px" Text="Label"></asp:Label>
                    <asp:Button ID="btnplus" runat="server" Font-Bold="True" Font-Size="Medium" Text="+" Width="27px" OnClick="btnplus_Click" />
                    </td></tr>
                <tr>
                    <td colspan="2"><asp:LinkButton ID="lbtnaddtocart" runat="server" OnClick="lbtnaddtocart_Click" >ADD TO CART</asp:LinkButton><asp:LinkButton ID="lbtngotocart" runat="server" OnClick="lbtgotocart_Click">GO TO CART</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="lbtnbuy" runat="server" OnClick="lbtnbuy_Click">BUY</asp:LinkButton></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>




