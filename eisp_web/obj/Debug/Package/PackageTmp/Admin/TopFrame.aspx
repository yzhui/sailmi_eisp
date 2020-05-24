<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TopFrame.aspx.cs" Inherits="Eisp.Web.Admin.TopFrame" %>
<%@ Import Namespace="Eisp.Common" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>宇帆科技</title>
     <link href="../Styles/TopFrame.css" media="all" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="50" cols="3">
                <img src="Images/Admin_Default/admin_top.gif" height="50"/>
            </td>
        </tr>
		<tr>
			<td align="right" height="20">用户名：<%=username%> &nbsp;<a href="logout.aspx" target="_parent"><strong>退出登陆</strong></a>&nbsp;<a href="<%=SystemConfig.WWWSite %>" target="_blank">首页预览</a></td>
		</tr>
	</table>
    </form>
</body>
</html>
