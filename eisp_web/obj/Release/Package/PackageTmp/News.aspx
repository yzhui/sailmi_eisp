<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Eisp.Web.News" Title="" ModuleName="News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptAndStyel" runat="server">
    <link href="Css/css.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
            <!--ShowNewsBox Start-->
            <div class="ShowProductBox">
                <%=NewsHtml %>
            </div>
            <!--ShowNewsBox End-->
            <div class="Pager">
                    <webdiyer:aspnetpager id="AspNetPager" runat="server" horizontalalign="Center" PagingButtonSpacing="8px" onpagechanged="AspNetPager_PageChanged" AlwaysShow="true"
                         urlpaging="True" width="100%" ImagePath="~/images" PagingButtonType="Image" NumericButtonType="Text" NavigationButtonType="image" 
                        ButtonImageExtension="gif" ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ShowNavigationToolTip="true" UrlPageIndexName="pageindex"></webdiyer:aspnetpager>
            </div>
</asp:Content>