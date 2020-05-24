<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="Eisp.Web.NewsDetail" Title="" ModuleName="News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptAndStyel" runat="server">
    <link href="Css/ProductList.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
        <!--Right Start-->
        <div class="NewsList">
            <div class="Title"><%=NewsTitle %></div>
            <div class="ProfileContent">
                  <%=NewsContent%>
            </div>
        </div>
        <!--Right End-->
</asp:Content>
