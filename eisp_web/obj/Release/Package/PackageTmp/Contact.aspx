<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Eisp.Web.Contact" Title=""  ModuleName="Contact"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptAndStyel" runat="server">
    <link href="Css/ProductList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <!--Right Start-->
            <!--ShowNewsBox Start-->
            <div class="ShowProductBox">
               <%=AboutBind("2")%>
            </div>
            <!--ShowNewsBox End-->
</asp:Content>