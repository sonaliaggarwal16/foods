<%@ Page Title="" Language="C#" MasterPageFile="~/userPage.master" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="reg" ValidateRequest="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style8 {
            background-color: #FFFFFF;
        }
        .auto-style2 {
            background-color: #6600FF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
    <h1>Registration</h1>
    <table style="border-bottom-color :black; background-color: #003300; margin-top: 0px;">   
     <tr>
            <td class="auto-style2">
                NAME:
                </td>
   <td>
       <asp:TextBox ID="txtname" runat="server" ValidationGroup="a" Width="170px"></asp:TextBox>
            </td>         
            <td>
                <asp:requiredfieldvalidator runat="server" errormessage="Please enter name" ValidationGroup="a" ForeColor="Red" ControlToValidate="txtname" >*</asp:requiredfieldvalidator>
            </td></tr>
    <tr>
            <td class="auto-style2">
                E-mail :
                </td>
             <td>
                 <asp:TextBox ID="txtemail" runat="server" ValidationGroup="a" Width="170px"></asp:TextBox></td>       
  
            <td>
                <asp:requiredfieldvalidator runat="server" errormessage="Please enter password" ValidationGroup="a" ForeColor="Red" ControlToValidate="txtemail">*</asp:requiredfieldvalidator></td>
        </tr>
   <tr>
            <td class="auto-style2">
                password :
                </td>
            
             <td>
                 <asp:TextBox ID="txtpassword" runat="server" ValidationGroup="a" Width="170px" TextMode="Password"></asp:TextBox></td>         
  <td><asp:requiredfieldvalidator runat="server" errormessage="Please enter age" ValidationGroup="a" ForeColor="Red" ControlToValidate="txtpassword">*</asp:requiredfieldvalidator></td>

        </tr>

     <tr>
            <td class="auto-style2">
               Contact :
                </td>
            
            
             <td>
                 <asp:TextBox ID="txtcontact" runat="server" ValidationGroup="a" Width="170px"></asp:TextBox></td>         
    <td><asp:requiredfieldvalidator runat="server" errormessage="Please enter gender" ValidationGroup="a" ForeColor="Red" ControlToValidate="txtcontact">*</asp:requiredfieldvalidator></td>
        </tr>
    <tr>
            <td class="auto-style2">
                Address :
                </td>
            
             <td>
                 <asp:TextBox ID="txtadress" runat="server" ValidationGroup="a" Width="170px"></asp:TextBox>
                 </td>         
  <td><asp:requiredfieldvalidator runat="server" errormessage="Please enter address" ValidationGroup="a" ForeColor="Red" ControlToValidate="txtadress">*</asp:requiredfieldvalidator></td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style2">
    
                <center>
            
                        <asp:Button ID="btnsubmit" runat="server" Text="submit"  ValidationGroup="a" OnClick="btnsubmit_Click"/>
            </center>
                    </td>
        </tr>
        <tr> 
   
 <td colspan="3"  class="auto-style2">
            <asp:validationsummary runat="server" ForeColor="Red" ValidationGroup="a"></asp:validationsummary>
             </td></tr>
    
    </table>
</asp:Content>

