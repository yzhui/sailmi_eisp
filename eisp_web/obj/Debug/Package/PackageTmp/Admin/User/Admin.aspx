<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Eisp.Web.Admin.user.Admin" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>管理员管理</title>
     <link href="../../Styles/admin_Default.css" media="all" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellpadding="0" cellspacing="0" class="twidth" width="576">
		<tr>
			<td align="center">
				<div class="mframe">
					<table cellpadding="0" cellspacing="0">
						<tr>
							<td class="tl"></td>
							<td class="tm"><span class="tt">管理员管理</span></td>
							<td class="tr"></td>
						</tr>
					</table>
					<table cellpadding="0" cellspacing="0">
					<tr>
					<td>
                       用户名 ：<asp:TextBox ID="UserName" runat="server"></asp:TextBox>密码：<asp:TextBox ID="PassWord" runat="server" TextMode="Password"></asp:TextBox> 
                        <asp:Button ID="Button1" runat="server" Text="添加" OnClick="Button1_Click" />
					<asp:Label ID="Label1" runat="server"></asp:Label>
					</td>
					</tr>
					</table>
					<table cellpadding="0" cellspacing="0">
						<tr>
							<td class="ml"></td>
							<td class="mm">
                                &nbsp;<table cellpadding="0" cellspacing="0" style="height: 30px" width="98%">
										<tr>
                                            <td align="center" colspan="2">
                                                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="95%" ForeColor="#333333" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
                                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="White" />
                                                     <Columns>
                                                     <asp:BoundField DataField="UID" HeaderText="序号" ReadOnly="True" />
                                                         <asp:BoundField DataField="Name" HeaderText="用户名" ReadOnly="True" />
                                                         <asp:BoundField DataField="Pass" HeaderText="密码" />
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
