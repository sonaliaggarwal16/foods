<%@ Page Title="" Language="C#" MasterPageFile="~/userPage.master" AutoEventWireup="true" CodeFile="~/payment.aspx.cs" Inherits="payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .paymentheader{
            text-align:center;
        }
        .rightimage {    
                         width: 457px;
            height: 440px;
        }
        .leftimagepart {
            width: 289px;
            
        }
        .maincontent {
            width: 284px;
            border-style:groove;
            border-color:white;
                margin: -185 0 0 144px;
           
            
        }
        .maintablepart {
            border-style: groove;
            border-color: white;
        }
        .newStyle1 {color: black;
            border-style: double;
        }
        .auto-style2 {
            border-style: double;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="paymentheader">
          <h1><span class="auto-style2">CHECKOUT/ ONLINE FOODS PAYMENT MODULE</span> </h1>
            </div>
        <div class="leftimagepart">
            <asp:Image ID="imgpayment1" runat="server" ImageUrl="~/img/images (10).jpg" Width="294px" Height="71px" /> 
            </div>
        <div class="maincontent">
            <div class="maintablepart">
            <table style="width: 285px">
                
               <tr>
                   <td>Payment Id</td><td align="center">
                       <asp:Label ID="lblpaymentid" runat="server" ></asp:Label>
                       </td></tr>
                    <tr><td>No Of Products</td><td align="center"><asp:Label ID="lblnoofproducts" runat="server"></asp:Label></td></tr></table>
                <asp:GridView ID="productdetails" runat="server" AutoGenerateColumns="false" Width="278px" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                              <asp:Label ID="lblproductname" runat="server" Text='<%#Bind("p_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                    </Columns>
                </asp:GridView>
                           
                    <table style="width: 283px; height: 124px;">
                    <tr><td>Product Price</td><td><asp:Label ID="lblpriceofproduct" runat="server"></asp:Label></td></tr>
                    <tr><td>Shiping Address</td><td><asp:Label ID="lblshipingaddress" runat="server"></asp:Label></td></tr>
                    <tr><td>Shiping Price</td><td><asp:Label ID="lblshipingcharges" runat="server"></asp:Label></td></tr>
                    <tr><td>Total Price</td><td><asp:Label ID="lbltotalprice" runat="server"></asp:Label></td></tr>
                <tr>
                    <td colspan="2" style="text-align: center"><asp:Button ID="btnconfirmandpay" CssClass="button" runat="server" Text="CONFIRM AND PAY" OnClick="btnconfirmandpay_Click" /></td>
                </tr>
            </table>
                </div>
        </div>
       
    <div class="rightimage">
      


        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/images (11).jpg" Width="294px" Height="71px" /> 
        </div>
</asp:Content>

