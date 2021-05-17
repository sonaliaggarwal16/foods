<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderplacedsuccessfull.aspx.cs" Inherits="orderplacedsuccessfull" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .maincontent {
        background-color:#d8d6fa;
        }
        </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="maincontent">
    <div class="header">
        <h1 style="background-color: #993333">YOUR ORDER SUCCESSFULLY PLACED</h1>
    </div>
      
          <div class="content">
            
            <div class="contentheader">
               <h3> Order Details</h3>
            </div>
            
            <div class="contenttable">
                <table>
                    <tr>
                    <td>Payment ID</td><td><asp:Label ID="lblpaymentid" runat="server"></asp:Label></td>
                        </tr>
                    <tr>
                    <td>No of product</td><td><asp:Label ID="lblnoofproducts" runat="server"></asp:Label></td>
                        </tr>
                
                </table>
                <asp:GridView ID="gvpaymentdetails" runat="server" AutoGenerateColumns="false" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblproductname" runat="server" Text='<%#Bind("p_name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <table>
                    <tr>
                        <td>PRICE</td><td><asp:Label ID="lblprice" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>SHIPING PRICE</td><td><asp:Label ID="lblshipingprice" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>TOTAL PRICE</td><td><asp:Label ID="lbltotalprice" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>
        
    </div>
        
    </form>
</body>
</html>
