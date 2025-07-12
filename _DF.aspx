<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMP.Master" AutoEventWireup="true" CodeBehind="_DF.aspx.cs" Inherits="diseasePrediction._DF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Panel1" runat="server">

 <div class="container">

        <div class="section-title">
           <h2><span>DISCUSSION</span> FORUM</h2>
        </div>
        <hr class="colorgraph">
        <div class="row">

   

     
     
      <br />

        <table align="center" style="width: 95%;">
            <tr style="font-size: small">
                <td align="left">
                    <asp:Table ID="Table1" runat="server">
                    </asp:Table>
                </td>
            </tr>
        </table>
      
        </div>
        </div>

        <br />
        <br />
    </asp:Panel>
</asp:Content>
