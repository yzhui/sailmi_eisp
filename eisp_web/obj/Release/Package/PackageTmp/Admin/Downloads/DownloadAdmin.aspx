<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadAdmin.aspx.cs" Inherits="Eisp.Web.Admin.Downloads.DownloadAdmin" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理新闻</title>
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
                        <span class="tt">资料下载管理</span></td>
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
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="95%"
                                        CellPadding="4" ForeColor="#333333" GridLines="None">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="id" Text="<%#Bind('ID') %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="名称">
                                                <ItemTemplate>
                                                    
                                                        <%# Eval("F_Title")%>
                                                    
            <%--                                        <%# (string.IsNullOrEmpty(Eval("F_Pic").ToString())) ? "" : "<img alt='图片新闻' src='Images/Admin_Default/admin_img.gif' />"%>--%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="F_Keywords" HeaderText="关键词" />
                                            <asp:BoundField DataField="F_Date" HeaderText="发布日期" DataFormatString="{0:yyyy年MM月dd日}"
                                                HtmlEncode="False" />
                                          
                                            <asp:TemplateField HeaderText="选择">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chk" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" BackColor="LightSteelBlue" Font-Bold="True"
                                            ForeColor="White" />
                                        <RowStyle HorizontalAlign="Center" BackColor="#EFF3FB" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <AlternatingRowStyle BackColor="White" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
              
                        <div style="margin-top: 10px; width: 100%; text-align: center">
                            <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click" />
                          
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
