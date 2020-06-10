<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftFrame.aspx.cs" Inherits="Eisp.Web.Admin.LeftFrame" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>菜单</title>
    <link href="../Styles/LeftFrame.css" media="all" rel="stylesheet" type="text/css" />
    <style type="text/css">
</style>
</head>
<body>
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr>
            <td valign="bottom" style="height:42px">
                <a href="admin_main.aspx?lang=<%=lang %>" target="MainFrame">
                    <img alt="挂历" height="38" src="images/admin_default/admin_title.gif" width="158" /></a>
            </td>
        </tr>
        <tr><td height="5"></td></tr>
        <tr>
            <td height="25">
                <table width="100%" height="100%"><tr><td bgcolor="<%=cn_bgcolor %>" align="center"><a href="Index.aspx?lang=1" target="_parent"><font color="<%=cn_fontcolor %>"><b>中文版</b></font></a></td><td align="center" bgcolor="<% =en_bgcolor %>"><a href="Index.aspx?lang=2" target="_parent"><font color="<%=en_fontcolor %>"><b>英文版</b></font></a></td></tr></table>
            </td>
        </tr>
    </table>
    <br />
    
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td style=" background-image:url(images/admin_default/admin_title_bg_show.gif); height:25px"
            class="menu_title">
                <span>公司信息</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuSort">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td style="height:20px" >
                                <a href="about/about.aspx?lang=<%=lang %>" target="MainFrame">公司简介</a></td>
                        </tr>                      
                    </table>
                </div>
            </td>
        </tr>
    </table>
     </br>
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td  class="menu_title" style=" background-image:url(images/admin_default/admin_title_bg_show.gif); height:25px">
                <span>资讯管理</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="Div3">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                         <tr>
                            <td  style="height:20px" >
                              <a href="News/NewsADD.aspx?lang=<%=lang %>" target="MainFrame">添加资讯</a> |  <a href="News/NewsAdmin.aspx?lang=<%=lang %>" target="MainFrame">资讯管理</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <a href="News/NewsClassAdmin.aspx?lang=<%=lang %>" target="MainFrame">资讯分类管理</a>
                            </td>
                        </tr>                   
                       
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td style=" background-image:url(images/admin_default/admin_title_bg_show.gif); height:25px"
             class="menu_title" >
                <span>产品管理</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="Div2">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                             <tr>
                            <td  style="height:20px" >
                              <a href="products/productadd.aspx?lang=<%=lang %>"
                                    target="MainFrame">产品添加</a>|
                              <a href="products/productadmin.aspx?lang=<%=lang %>"
                                    target="MainFrame">产品管理</a></td>
                        </tr>
                        <tr>
                            <td  style="height:20px" >
                              <a href="products/ProClassAdmin.aspx?lang=<%=lang %>"
                                    target="MainFrame">产品类别管理</a></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table> 
    </br>
    

    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td  class="menu_title" style=" background-image:url(images/admin_default/admin_title_bg_show.gif); height:25px">
                <span>在线咨询</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="Div4">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td  style="height:20px" >
                                <a href="guestbook/GuestBook.aspx?lang=<%=lang %>" target="MainFrame">留言管理</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </br>
    
    
        <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td  class="menu_title" style=" background-image:url(images/admin_default/admin_title_bg_show.gif); height:25px">
                <span>资料下载</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="Div5">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                    
                        <tr>
                            <td  style="height:20px" >
                                <a href="Downloads/DownloadAdd.aspx?lang=<%=lang %>" target="MainFrame">资料添加</a> | <a href="Downloads/DownloadAdmin.aspx?lang=<%=lang %>" target="MainFrame">资料管理</a>
                            </td>
                        </tr>
                        
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </br>
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td style=" background-image:url(images/admin_default/admin_title_bg_show.gif); height:25px" class="menu_title">
                <span>系统管理</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuNews">
                    <table cellspacing="0" cellpadding="0" width="140" align="center" border="0">
                    
                        <tr>
                            <td style="height:20px" >
                                <a href="user/Admin.aspx?lang=<%=lang %>" target="MainFrame">管理员管理</a></td>
                        </tr>
                        <!--
                        <tr>
                            <td style="height:20px" >
                                <a href="ad/AdAdmin.aspx?lang=<%=lang %>" target="MainFrame">广告管理</a>|
                                <a href="link/Admin_Link.aspx?lang=<%=lang %>" target="MainFrame">链接管理</a>
                            </td>
                        </tr>
                       -->
                    </table>
                </div>
            </td>
        </tr>
    </table>
    </br>
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td  class="menu_title" style=" background-image:url(images/admin_default/admin_title_bg_show.gif); height:25px">
                <span>版权信息</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="Div1">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                     <tr>
                            <td  style="height:20px" >
                               版权所有：<br />
                               <font color="red"><b>PDGrid.com</b></font>
                            </td>
                        </tr>
                        <tr>
                            <td  style="height:20px" >
                               MSN ：<br />
                               <font color="red"><b>yzh_adam@hotmail.com</b></font>
                            </td>
                        </tr>
                        <tr>
                            <td  style="height:20px" >
                               邮   件：<br />
                               <font color="red"><b>zhaohui.yin@gmail.com</b></font>
                            </td>
                        </tr>
                        <tr>

                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</body>
</html>

