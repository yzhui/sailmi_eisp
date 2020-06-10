<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductAdmin.aspx.cs" Inherits="Eisp.Web.Admin.Products.ProductAdmin" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理产品</title>
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
                        <span class="tt">产品管理</span></td>
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
                                搜索：   <asp:DropDownList ID="drpClass" runat="server">
                                                    </asp:DropDownList> <asp:Button ID="SearchBtn_Click" Text="查询" 
                                        runat="server" onclick="SearchBtn_Click_Click" />
                                </td>
                            </tr>
                        </table>
                        
                        <table cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td align="center" colspan="2" style="height: 30px">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="95%"
                                        CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="id" Text="<%#Bind('ProID') %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="型号">
                                                <ItemTemplate>
                                                    
                                                        <%# Eval("F_ProName").ToString()%>
       
                                                </ItemTemplate>
                                                
                                                
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="所属分类">
                                            <ItemTemplate>
                                            <%#Eval("F_ClassName")%>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                        
                                           <asp:BoundField DataField="F_Date" HeaderText="发布日期" DataFormatString="{0:yyyy年MM月dd日}"
                                                HtmlEncode="False" />
                                          
                                            <asp:TemplateField HeaderText="选择">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chk" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField   HeaderText="操作">
                                              <ItemTemplate>
                                                  <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Edit"    Text="编辑"></asp:LinkButton>
                                                  <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" OnClientClick="javascript:return window.confirm('您确定要删除吗?')"    Text="删除"></asp:LinkButton>
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
                        <table cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td align="left" style="height: 21px">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" FirstPageText="首页"
                                        LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowInputBox="Always"
                                        OnPageChanged="AspNetPager1_PageChanged" ShowBoxThreshold="10" PageSize="20" Width="356px">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                        <div style="margin-top: 10px; width: 100%; text-align: center">
                            <asp:Button ID="btnDelete" runat="server" Text="删除所选" OnClick="btnDelete_Click" OnClientClick="javascript:return window.confirm('您确定要删除吗?')" />
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
