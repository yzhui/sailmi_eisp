<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Link.aspx.cs" Inherits="Eisp.Web.Admin.link.Admin_Link" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>友情链接</title>
<link href="../../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
<link rel="stylesheet" type="text/css" href="../HtmlEditor/editorArea.css">
<script language="javascript" type="text/javascript" src="function.js"></script>
</head>

<body>
    <form id="form1" runat="server" method="post">
     <div>
    <table cellpadding="0" cellspacing="0" class="twidth" width="600">
		<tr>
			<td align="center">
				<div class="mframe">
					<table cellpadding="0" cellspacing="0">
						<tr>
							<td class="tl"></td>
							<td class="tm"><span class="tt">友情链接管理</span></td>
							<td class="tr"></td>
						</tr>
					</table>
					
					<table cellpadding="0" cellspacing="0">
					<tr>
					<td class="tl" ></td>
					<td class="mm" style=" margin-left:0px;">
                       名称 ：<asp:TextBox ID="txtName" runat="server" Width="137px"></asp:TextBox>地址：<asp:TextBox 
                            ID="txtUrl" runat="server" Height="16px" Width="127px" ></asp:TextBox> 
                        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
					<asp:Label ID="Label1" runat="server"></asp:Label>
					</td>
					<td class="tr"></td>
					</tr>
					</table>
					<table cellpadding="0" cellspacing="0">
						<tr>
							<td class="ml"></td>
							<td class="mm">
                                &nbsp;<table cellpadding="0" cellspacing="0" style="height: 30px" width="98%">
										<tr>
                                            <td align="center" colspan="2">
                                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" ForeColor="#333333" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                     <Columns>
                                                     <asp:BoundField DataField="ID" HeaderText="序号" ReadOnly="True" />
                                                         <asp:BoundField DataField="F_LinkName" HeaderText="名称"  />
                                                         <asp:BoundField DataField="F_LinkUrl" HeaderText="地址" />
                                                         <asp:CommandField HeaderText="操作" ShowEditButton="True" ShowDeleteButton="True" />
                                                     </Columns>
                                                </asp:GridView>
                                              
                                            </td>
										</tr>
									</table>
									
								
							</td>
							<td class="mr"></td>
						</tr>
					</table>
				</div>
			</td>
		</tr>
	</table>
    </div>

    </form>
</body>
</html>
