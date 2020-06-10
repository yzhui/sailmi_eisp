<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Main.aspx.cs" Inherits="Eisp.Web.Admin.Admin_Main" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
  <table width="80%" height="255" border="0" align="center" cellpadding="0" cellspacing="1" bgColor="#000000">
  <tr bgColor="#eaeaea" height="18"> 
    <td height="18" colspan="2" align="center" bgColor="#006600" class="STYLE5">&nbsp;[.NET服务器常用参数]</td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td width="168" height="20" align="left" class="tt2">&nbsp;服务器名称：</td>
    <td width="623" height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="MachineName" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;服务器IP地址：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="LOCAL_ADDR" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;服务器域名：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp;<asp:Label ID="SERVER_NAME" runat="server"></asp:Label>
    
    </td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;HTTP访问端口：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="SERVER_PORT" runat="server" /> 
    </td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;服务器本机时间：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="ServerDateTime" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;服务器IIS版本：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="SERVER_SOFTWARE" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;服务端脚本执行超时：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="ScriptTimeout" runat="server" /> 
      秒</td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;虚拟目录绝对路径：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="APPL_PHYSICAL_PATH" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;执行文件绝对路径：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="PATH_TRANSLATED" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;服务器浏览器版本：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="ServerView" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;.NET解释引擎版本：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label id="runtime" runat="server" /></td>
  </tr>
  <tr bgColor="#eaeaea" height="18"> 
    <td height="20" align="left" class="tt2">&nbsp;服务器操作系统：</td>
    <td height="18" bgColor="#F5F5F5">&nbsp; <asp:label ID="OS" runat="server" /></td>
  </tr>
</table>
<br>		
<table width="80%" height="229" border="0" align="center" cellpadding="0" cellspacing="1" bgColor="#000000">
  
    <TBODY>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="18" colspan="2" align="center" bgColor="#006600" class="tt1"><font Color=#ffffff>&nbsp;[.NET服务器常用组件]</font></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td width="170" height="20" align="left" bgColor="#EFF7F7">&nbsp;Sqlserver2000数据库组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="access" runat="server" /></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;FSO文件操作组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="fso" runat="server" /> </td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;CDONTS邮件发送组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="sendmail" runat="server" /></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;JMAIL邮件发送组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="jmail" runat="server" /></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;ASPEmail邮件发送组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="aspemail" runat="server" /></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;LyfUpload上传组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="lyupload" runat="server" /></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;ASPUpload上传组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="aspupload" runat="server" /></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;ASPCN上传组件：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="aspcn" runat="server" /></td>
      </tr>
      <tr bgColor="#eaeaea" height="18"> 
        <td height="20" align="left" bgColor="#EFF7F7">&nbsp;其他组件安装检测：</td>
        <td height="18" bgColor="#F7F7F7">&nbsp; <asp:TextBox id="other" OnTextChanged="checkinput" cssclass="csstext" runat="server" /> <asp:button id="submit" text="检 测" cssclass="input" runat="server" /></td>
      </tr>
      <tr bgColor="#eeeeee" height="18"> 
        <td height="20" colspan="2" align="center"> <font Color="#ff0000"> 
          <asp:label ID="checkok" runat="server" />
          </font></td>
      </tr>
  
</table>
<div align="center"><font Color="#ff0000"> </font><br>

  <table width="80%" height="58" border="0" cellpadding="0" cellspacing="1" bgColor="#000000">
    <tr bgColor="#eaeaea" height="18"> 
      <td height="20" colspan="2" align="center" bgColor="#006600" class="tt1"><font Color=#ffffff>&nbsp;[当前虚拟目录资源状况]</font>      </td>
    </tr>
    <tr bgColor="#eaeaea" height="18"> 
      <td width="170" height="20" align="left" class="tt2">&nbsp;虚拟目录Session总数：</td>
      <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="sessioncount" runat="server" />
        个</td>
    </tr>
    <tr bgColor="#eaeaea" height="18"> 
      <td height="20" align="left" class="tt2">&nbsp;虚拟目录Application总数：</td>
      <td height="18" bgColor="#F7F7F7">&nbsp; <asp:label id="appcount" runat="server" />
        个</td>
    </tr>
  </table>
  <br>
  
  <table width="80%" height="39" border="0" cellpadding="0" cellspacing="1" bgColor="#000000">
    <tr bgColor="#eaeaea" height="18"> 
      <td colspan="2" align="center" bgColor="#006600" class="tt1"><font Color=#ffffff>&nbsp;[.NET虚拟主机速度测试]</font>      </td>
    </tr>
    <tr bgColor="#eaeaea" height="18"> 
      <td width="170" height="20" align="left" class="tt2">&nbsp;执行本页.NET代码时间：</td>
      <td bgColor="#F7F7F7">&nbsp; <font Color="#ff0000"> 
        <asp:label id="fast" runat="server" />
        </font>毫秒</td>
    </tr>
  </table>
  
                    </div>
        
    </form>
</body>
</html>
