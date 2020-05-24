<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderBox.ascx.cs" Inherits="Eisp.Web.Controls.biz.HeaderBox" %>
       <div class="Header">
            <img src="<%=getTemplateRoot(lang) %>images/au_top.jpg" width="980" height="120"/>
        </div>
    <div class="Menu">
        <table border="0" background="<%=getTemplateRoot(lang) %>/images/au_menubg.jpg" width="100%" height="26">
            <tr>
                <td height="26">
                    <table border="0" width="100%" height="26">
                        <tr>
                            <td>
                                <a target="_self" href="Index.aspx"><b>首页</b></a> 
                            </td>
                            <td>
                                <a target="_self" href="Profile.aspx"><b>公司简介</b></a> 
                            </td>
                            <td>
                                <a target="_self" href="ProductList.aspx"><b>产品目录</b></a> 
                            </td>
                            <td>
                                <a target="_self" href="News.aspx"><b>新闻通知</b></a> 
                            </td>
                            <td>
                                <a target="_self" href="Downloads.aspx"><b>文件下载</b></a>
                            </td>
                            <td>
                                <a target="_self" href="OrderList.aspx"><b>采购招标</b></a>
                            </td>
                            <!--
                           <td>
                                <a target="_blank" href="Industry.aspx"><b>人才招聘</b></a> 
                            </td>
                            -->
                            <td>
                                <a target="_self" href="guestbook.aspx"><b>在线留言</b></a> 
                            </td>
                            <td>
                                <a target="_self" href="Contact.aspx"><b>联系我们</b></a>
                            </td>
                            <td width="150" align="right">
                                <a target="_self" href="/index.aspx?lang=1"><font size="2" color="white">中文</font></a> <a target="_self" href="/index.aspx?lang=2"><font size="2" color="white">English</font></a>
                            </td>
                        </tr>
                    </table>                
                </td>
                <td>
                </td>
            </tr>
        </table>
      </div>