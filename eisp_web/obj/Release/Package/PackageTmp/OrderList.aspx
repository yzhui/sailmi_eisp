<%@ Page Language="C#"   AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="Eisp.Web.OrderList" ModuleName="Order"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ScriptAndStyel" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
            <div class="SourceCategory">当前产品<%=classname%></div>
            <!--ShowProductBox Start-->
            <div class="ShowProductBox">
              <%=ProductHtml%>
            </div>
            <!--ShowProductBox End-->
            <div class="Pager">
                    <webdiyer:aspnetpager id="AspNetPager" runat="server" horizontalalign="Center" PagingButtonSpacing="8px" onpagechanged="AspNetPager_PageChanged" AlwaysShow="true"
                         urlpaging="True" width="100%" ImagePath="~/images" PagingButtonType="Image" NumericButtonType="Text" NavigationButtonType="image" 
                        ButtonImageExtension="gif" ButtonImageNameExtension="n" DisabledButtonImageNameExtension="g" ShowNavigationToolTip="true" UrlPageIndexName="pageindex"></webdiyer:aspnetpager>
            </div>
</asp:Content>