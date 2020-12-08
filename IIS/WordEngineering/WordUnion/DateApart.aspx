<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DateApart.aspx.cs" Inherits="DateApart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Date Apart</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label
                        ID="labelDated"
                        runat="server"
                        AssociatedControlID="dated"
                        Text="Date"
                    />
                </td>
                <td>                    
                    <asp:TextBox 
                        ID="dated"
                        runat="server"
                    />                        
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Panel
                        ID="labelApart"
                        runat="server"
                        GroupingText="Apart"
                    >
					
						<table>
							<tr>
								<td>
									<asp:Label
										ID="labelYears"
										runat="server"
										AssociatedControlID="years"
										Text="Years"
									/>
								</td>
								<td>		
									<asp:TextBox 
										ID="years"
										runat="server"
									/>
								</td>
							</tr>

							<tr>
								<td>
									<asp:Label
										ID="labelMonths"
										runat="server"
										AssociatedControlID="months"
										Text="Months"
									/>
								</td>
								<td>		
									<asp:TextBox 
										ID="months"
										runat="server"
									/>
								</td>
							</tr>	

							<tr>
								<td>
									<asp:Label
										ID="labelDays"
										runat="server"
										AssociatedControlID="days"
										Text="Days"
									/>
								</td>
								<td>		
									<asp:TextBox 
										ID="days"
										runat="server"
									/>
								</td>
							</tr>	
							
						</table>
					</asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button
                        ID="submit"
                        runat="server"
                        OnClick="Submit_Click"
                        Text="Submit"
                    />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Literal
                        ID="feedBack"
                        runat="server"
                    />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
