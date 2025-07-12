<%@ Page Title="" Language="C#" MasterPageFile="~/Member/MemberMP.Master" AutoEventWireup="true" CodeBehind="_Single.aspx.cs" Inherits="diseasePrediction.Member._Single" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelAdminHome" runat="server">
<div class="container">

<br />

<h2>LUNG CANCER PREDICTION (NB ALGORITHM)</h2>
<hr class="colorgraph">
			
    <br />
           
   <table style="width: 55%; height: 124px;">
                <tr>
                    <td class="style2">
                        <strong>Name</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtPatientName" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="txtPatientName" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter PatientName" ValidationGroup="user">Enter PatientName</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
                            ControlToValidate="txtPatientName" ErrorMessage="Only Alphabets" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Alphabets" 
                            ValidationExpression="^[a-zA-Z ]*$" ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="style2">
                        <strong>Age</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtAge" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="txtAge" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter Age" ValidationGroup="user">Enter Age</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" 
                            ControlToValidate="txtAge" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                            ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="style2">
                        <strong>Gender</strong></td>
                    <td class="style4">
                        
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="1">Male</asp:ListItem>
                            <asp:ListItem Value="2">Female</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                      
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
               
                <tr>
                    <td class="style2">
                        <strong>BP</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtBP" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                            ControlToValidate="txtBP" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter BP" ValidationGroup="user">Enter BP</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" 
                            ControlToValidate="txtBP" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                            ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>Weight</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtWeight" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtWeight" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter Weight" ValidationGroup="user">Enter Weight</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" 
                            ControlToValidate="txtWeight" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>sugartested</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtsugartested" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtsugartested" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter sugartested" ValidationGroup="user">Enter sugartested</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" 
                            ControlToValidate="txtsugartested" ErrorMessage="Only Numbers" Font-Size="X-Small" 
                            ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>familyhistory</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtfamilyhistory" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                            ControlToValidate="txtfamilyhistory" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter familyhistory" ValidationGroup="user">Enter familyhistory</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" 
                            runat="server" ControlToValidate="txtfamilyhistory" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <strong>smokes</strong></td>
                    <td class="style1">
                        <asp:TextBox ID="txtsmokes" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                            ControlToValidate="txtsmokes" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter smokes" ValidationGroup="user">Enter smokes</asp:RequiredFieldValidator>
                    </td>
                    <td class="style1">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" 
                            runat="server" ControlToValidate="txtsmokes" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>alcohol</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtalcohol" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="txtalcohol" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter alcohol" ValidationGroup="user">Enter alcohol</asp:RequiredFieldValidator>
                        &nbsp;</td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" 
                            runat="server" ControlToValidate="txtalcohol" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>anemia</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtanemia" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="txtanemia" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter anemia" ValidationGroup="user">Enter anemia</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" 
                            runat="server" ControlToValidate="txtanemia" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                       <strong> heart_disease</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtheart_disease" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtheart_disease" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter heart_disease" ValidationGroup="user">Enter heart_disease</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" 
                            runat="server" ControlToValidate="txtheart_disease" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong>diabetes</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtdiabetes" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                            ControlToValidate="txtdiabetes" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter diabetes" ValidationGroup="user">Enter diabetes</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" 
                            runat="server" ControlToValidate="txtdiabetes" 
                            ErrorMessage="Only Numbers" Font-Size="X-Small" ForeColor="Red" 
                            ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        <strong> cholesterol</strong></td>
                    <td class="style4">
                        <asp:TextBox ID="txtcholesterol" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                            ControlToValidate="txtcholesterol" ErrorMessage="*" Font-Size="X-Small" 
                            ForeColor="#FF3300" ToolTip="Enter cholesterol" ValidationGroup="user">Enter cholesterol</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" 
                            runat="server" ControlToValidate="txtcholesterol" ErrorMessage="Only Numbers" 
                            Font-Size="X-Small" ForeColor="Red" ToolTip="Only Numbers" 
                            ValidationExpression="^[+-]?([0-9]+([.][0-9]*)?|[.][0-9]+)$" 
                            ValidationGroup="user"></asp:RegularExpressionValidator>
                    </td>
                </tr>
               
               
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        &nbsp;</td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2">
                        &nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                            Text="Predict" ValidationGroup="user" Height="50px" Width="200px" />
                    </td>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>

        <br />

   
                        <h2 class="title">
                            <asp:Label ID="lblResult" runat="server"></asp:Label>
            </h2>
                             <h1>    0- NO and 1- YES</h1><br />
   
           
   </div>
 
   </asp:Panel>

</asp:Content>
