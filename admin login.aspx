<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="admin login.aspx.cs" Inherits="admin_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="background-color: #9966FF;width: 297px;height: 260px;margin: 91px 0 0 547px;" border="5" ;="" "="">   
      <tbody><tr>
            <td rowspan="9">
  <asp:Image ID="Image1" runat="server" Height="132px" ImageUrl="~/img1/download (12).jpg" style="margin-right: 0px; margin-top: 0px;" Width="86px" /></td>
        </tr>
    <tr>
        <td>
            Username: 
        </td>

<td>
    <asp:TextBox ID="Txtusername" runat="server"></asp:TextBox></td>
    </tr>
    
    <tr>
  
        <td>
            Password:
        </td>
<td>
    <asp:TextBox ID="Txtpassword" runat="server" TextMode="Password"></asp:TextBox>
    </td>
    </tr>
    <tr>
 <td colspan="2" style="text-align: center">
            <br />
          <asp:Button ID="btnlogin" runat="server" Text="Submit" OnClick="btnlogin_Click" style="font-weight: 700"/></td>
    </tr>
    </table>
</asp:Content>

