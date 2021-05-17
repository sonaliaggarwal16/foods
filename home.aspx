<%@ Page Title="" Language="C#" MasterPageFile="~/userPage.master" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Start WOWSlider.com HEAD section -->
<link rel="stylesheet" type="text/css" href="engine1/style.css" />
<script type="text/javascript" src="engine1/jquery.js"></script>
<!-- End WOWSlider.com HEAD section -->
    <style type="text/css">
        backimg {background-image:url('img1/images (1).jpg');
                background-repeat: no-repeat;
                background-attachment:fixed;
                        
                        width: 1256px;
            
       background-size: 1246px;


    height: 830px;

        .style2
        {
            font-family: "Lucida Sans Unicode";
        }
        .auto-style1 {
            text-decoration: underline;
            font-weight: normal;
        }
         .auto-style3 {
        background-color: #CCCCCC;
    }
        .auto-style6 {
            text-decoration: underline;
            background-color: #FF00FF;
        }
        .auto-style7 {
            background-color: #FFFFCC;
        }
        .auto-style8 {
            background-color: #FFFF00;
        }
        .auto-style9 {
            color: rgb(255, 0, 255);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;<!-- Start WOWSlider.com BODY section --><TABLE id="Table2" >
									<tr><td valign="top" colspan="2">
                                        <asp:Image ID="image1" runat="server" Height="142px" 
                                            ImageUrl="~/img/image1.jpg" Width="716px" /> </td>
									
										
										
									</TR>
									
									
									<tr><td valign="top">
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="171px" 
                                            ImageUrl="~/img/FAF012.jpg" Width="426px" />
                                        </td>
									
									    <td valign="top" >
                                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                                ImageUrl="~/img/FAF013.jpg" Height="201px" Width="287px" 
                                                style="margin-left: 0px" />
                                        </td>
									
									
									
									
								</TABLE>
         </asp:Content>
 

