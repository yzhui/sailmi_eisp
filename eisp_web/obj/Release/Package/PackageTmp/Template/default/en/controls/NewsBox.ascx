<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsBox.ascx.cs" Inherits="Eisp.Web.Controls.biz.NewsBox" %>
<div class="NewsBox">
    <div class="NewsTitle">News</div>
    <%=NewsHtml%>
    <div class="ViewMore"><a target="_blank" href="News.aspx">More...</a></div>
</div>