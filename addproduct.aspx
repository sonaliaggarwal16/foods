<%@ Page Title="" Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="addproduct.aspx.cs" Inherits="addproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="main1">
        <div class="header1">
            
            <h1 class="auto-style1">ADD PRODUCT DETAILS</h1>
        </div>
        <div class="content">
            <div class="table">
            <table border="2" >
                <tr>
                    <td>Product Name</td><td>
                        
                    <asp:TextBox ID="txtproductname"  runat="server" ValidationGroup="a"></asp:TextBox>
                        
                    </td><td>
                        <asp:requiredfieldvalidator runat="server" errormessage="Please Enter the Product Name" ControlToValidate="txtproductname" ValidationGroup="a"></asp:requiredfieldvalidator>
                    </td>
                </tr>
                 <tr>
                    <td>Product Catagory</td><td>
                        
                    <asp:TextBox ID="txtpcata" runat="server" ValidationGroup="a"></asp:TextBox>
                        
                    </td><td>
                        <asp:requiredfieldvalidator runat="server" errormessage="Please Enter the Product catagory" ControlToValidate="txtpcata" ValidationGroup="a"></asp:requiredfieldvalidator >
                    </td>
                </tr>
                 <tr>
                     <td>
                        
                         <br />
                         <br />
                        
                         <asp:Image ID="imgproduct" runat="server" Width="146px" ValidationGroup="b"  />
                        
                     </td>
                     <td>

                         <br />
                         <br />
                         <asp:FileUpload ID="imageuploader" runat="server" ValidationGroup="b" CssClass="button1" />

                     </td>
                 </tr>
                 <tr>
                     <td colspan="2" style="text-align: center">
                        
                         <br />
                         <asp:Button ID="btnupload" runat="server"  style="text-align: center" Text="Upload" Width="163px" ValidationGroup="b" CssClass="button" OnClick="btnupload_Click" />
                         <br />
                         <br />
                         <br />
                        
                     </td>
                 </tr>
                 <tr>
                    <td>Product Price</td><td>
                        
                    <asp:TextBox ID="txtprice" runat="server" ValidationGroup="a"></asp:TextBox>
                        
                    </td><td>
                        <asp:requiredfieldvalidator runat="server" errormessage="Please Enter price" ControlToValidate="txtproductname" ValidationGroup="a"></asp:requiredfieldvalidator>
                    </td>
                </tr>
                 <tr>
                    <td colspan="3" style="text-align: center">
                        <br />
                        <asp:Button ID="btnaddproduct" runat="server"  Text="ADD PRODUCT" Width="193px"  ValidationGroup="a" CssClass="button" OnClick="btnaddproduct_Click" />
                        <br />
                        <br />
                     </td>
                </tr>
            </table>
                <br />


























      <asp:GridView ID="gvproductdetails" runat="server"  AutoGenerateColumns="False" OnRowCancelingEdit="gvproductdetails_RowCancelingEdit" OnRowDeleting="gvproductdetails_RowDeleting" OnRowUpdating="gvproductdetails_RowUpdating" OnRowEditing="gvproductdetails_RowEditing" Width="804px" OnSelectedIndexChanged="gvproductdetails_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField>
                            <HeaderTemplate>
                                PRODUCT ID
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblproductid" runat="server" Text='<%#Bind("product_id") %>'></asp:Label>
                            </ItemTemplate>
                            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    PRODUCT IMAGE
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Image ID="Imgproducts" runat="server" Height="54px" Width="223px" ImageUrl='<%#Bind("product_img_url") %>' />
                </ItemTemplate>


                <EditItemTemplate>
                                <asp:FileUpload ID="fuimageuploadergridview" runat="server" />
                            </EditItemTemplate>
            </asp:TemplateField>



            <asp:TemplateField>
                <HeaderTemplate>
                    PRODUCT NAME
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Label ID="lblproductname" runat="server" Text='<%#Bind("p_name") %>'></asp:Label>
                  
                </ItemTemplate>


                 <EditItemTemplate>
                                <asp:TextBox ID="txtproname" runat="server" Text='<%#Bind("p_name") %>'></asp:TextBox>
                            </EditItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField>
                <HeaderTemplate>
                    PRODUCT CATEGORY
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Label ID="lblproductcategory"  runat="server" Text='<%#Bind("p_categor") %>'></asp:Label>
                   
                </ItemTemplate>

                 <EditItemTemplate>
                                <asp:TextBox ID="txtprocata" runat="server" Text='<%#Bind("p_categor") %>'></asp:TextBox>
                            </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <HeaderTemplate>
                    PRODUCT PRICE
                </HeaderTemplate>
                <ItemTemplate>
                   <asp:Label ID="lblproductprice" runat="server" Text='<%#Bind("p_price") %>'></asp:Label>
                  
                </ItemTemplate>

                 <EditItemTemplate>
                                <asp:TextBox ID="txtproprice" runat="server" Text='<%#Bind("p_price") %>'></asp:TextBox>
                            </EditItemTemplate>
            </asp:TemplateField>
        <asp:CommandField ShowEditButton="True"  HeaderText="EDIT"/>
                        <asp:CommandField ShowDeleteButton="True" HeaderText="DELETE" />
                    </Columns>
    </asp:GridView>
</asp:Content>
