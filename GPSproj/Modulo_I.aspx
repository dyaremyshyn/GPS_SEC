<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modulo_I.aspx.cs" Inherits="homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SEC - StudEnt Calculator</title>
    <link href="../acessorios/styleFormat.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="centrarWrappers">
        <div id="logo" class="centrarH margemInf centrarT">
            <div id="logo2">logo</div>
        </div>
    </div>
    <div class="centrarWrappers">
        <div id="wrapperTotal" class="centrarH">
            <div class="titulo" style="padding-top:25px;" >EQUAÇÕES DO 2º GRAU</div>
            <div id="equacao" class="margemInf centrarH">
                <div class="centrarT">
                    <div class="equacaoWrapper centrarH">
                        <asp:Label ID="labelA" runat="server" class="subtitulo" BackColor="#4b5465">ax<sup>2</sup> + </asp:Label>
                        <asp:Label ID="labelB" runat="server">bx + </asp:Label>
                        <asp:Label ID="labelC" runat="server">c</asp:Label>
                    </div>
                </div>
                <div class="centrarT">
                    <div id="caixaTextoWrapper" class="subtitulo">
                        a =<asp:TextBox ID="TextBoxA" runat="server" CssClass="caixaTexto"></asp:TextBox>
                        b =<asp:TextBox ID="TextBoxB" runat="server" CssClass="caixaTexto"></asp:TextBox>
                        c =<asp:TextBox ID="TextBoxC" runat="server" CssClass="caixaTexto"></asp:TextBox>
                        <asp:Button ID="botaoCalcular" runat="server" OnClick="botaoCalcular_Click" Text="Calcular" CssClass="botao" BackColor="#45c8dc" ForeColor="#f7f8f8" Font-Size="14px" Font-Bold="true"/>
                    </div>
                </div>
                <div class="subtitulo" style="margin-left:17px;">Resultado</div>
                <div class="centrarT">
                    <asp:Label ID="label1" runat="server" Text="Label" BorderWidth="1px" Height="80px" Width="516px"></asp:Label>
                </div>
            </div>
            <div class="titulo">GRÁFICO</div>
            <div id="grafico" class="margemInf centrarH">
                <div class="centrarT">
                    <div class="equacaoWrapper centrarH" style="margin-bottom:5px;">
                        <asp:Label ID="label2" runat="server" class="subtitulo">f(x) = ax<sup>2</sup> + </asp:Label>
                        <asp:Label ID="label3" runat="server">bx + </asp:Label>
                        <asp:Label ID="label4" runat="server">c</asp:Label>
                    </div>
                </div>
                <div class="subtitulo" style="margin-left:17px;">Resultado</div>
                <div id="areaGrafico" class="centrarH frame margemInf"></div>
            </div>
        </div>

    </div>
    </form>
</body>
</html>
