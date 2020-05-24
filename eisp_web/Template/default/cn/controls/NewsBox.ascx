<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsBox.ascx.cs" Inherits="Eisp.Web.Controls.biz.NewsBox" %>
<div class="NewsBox">
    <div class="NewsTitle">新闻动态</div>
    <%=NewsHtml%>
    <div class="ViewMore"><a target="_blank" href="News.aspx">更多...</a></div>
</div>