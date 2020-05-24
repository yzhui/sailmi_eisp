<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GuestBook.aspx.cs" Inherits="Eisp.Web.Admin.guestbook.GuestBook" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>留言管理</title>
    <link href="../../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="mframe">
            <table cellpadding="0" cellspacing="0" width="80%" align="center">
                <tr>
                    <td class="tl">
                    </td>
                    <td class="tm">
                        <span class="tt">留言管理</span></td>
                    <td class="tr">
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" width="80%" align="center">
                <tr>
                    <td class="ml">
                    </td>
                    <td class="mm" style="width: 100%">
                        <table cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td align="center">
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td align="center" colspan="2" style="height: 30px">
                                    <asp:GridView ID="GridView1" runat="server"  Width="100%" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:TemplateField >
                                                <ItemTemplate>
              
    
    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgColor="#CCCCCC">
  <tr>
    <td width="80" height="20" bgColor="#FFFFFF">联系人：</td>
    <td width="160" height="20" bgColor="#FFFFFF"><%# Eval("F_Contacts").ToString()%></td>
    <td width="90" height="20" bgColor="#FFFFFF">联系方式：</td>
    <td width="349" height="20" bgColor="#FFFFFF"><%# Eval("F_Way").ToString()%></td>
    <td width="60" height="20" bgColor="#FFFFFF">日期：</td>
    <td width="338" height="20" bgColor="#FFFFFF"><%# Eval("F_Date").ToString()%></td>
  </tr>
  <tr>
    <td height="40" bgColor="#FFFFFF">内容：</td>
    <td height="40" bgColor="#FFFFFF" colspan="5" valign="top"><div style="height:auto; word-break:break-all; dispaly: block; margin-top:3px; margin-left:4px;"><%# Eval("F_Content").ToString()%></div></td>
  </tr>
  <tr>
    <td colspan="3" bgColor="#FFFFFF">用户IP：<%# Eval("F_IP").ToString()%></td>
    <td colspan="2" bgColor="#FFFFFF">来源：<%=getLangDesc(lang) %></td>
    <td bgColor="#FFFFFF"><asp:CheckBox runat="server" ID="chk" /><div style="display:none;"><asp:Label runat="server" ID="id" Text="<%#Bind('ID') %>"></asp:Label></div></td>
  </tr>
</table>
<div style="height:8px;"></div>

                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                            

                                        </Columns>
                                        
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td align="left" style="height: 21px">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowInputBox="Always"
                                        OnPageChanged="AspNetPager1_PageChanged" ShowBoxThreshold="10" PageSize="5" Width="356px">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                        <div style="margin-top: 10px; width: 100%; text-align: center">
                            <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
                            <%-- <asp:Button ID ="btnDoHtml" runat="server" Text="生成Html" OnClick="btnDoHtml_Click" />--%>
                            &nbsp;
                        </div>
                    </td>
                    <td class="mr">
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

