﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Interface.aspx.cs" Inherits="homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SEC - StudEnt Calculator</title>
    <link href="../acessorios/styleFormat.css" rel="stylesheet" type="text/css"/>
    <script src="https://www.desmos.com/api/v0.5/calculator.js?apiKey=dcb31709b452b1cf9dc26972add0fda6"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="centrarWrappers">
        <div id="logo" class="centrarH margemInf centrarT">
            <div id="logo2"></div>
        </div>
    </div>
    <div class="centrarWrappers">
        <div id="wrapperTotal" class="centrarH">
            <div class="titulo" style="padding-top:25px;" >EQUAÇÕES DO 2º GRAU</div>
            <div id="equacao" class="margemInf centrarH">
                <div class="centrarT">
                    <div class="equacaoWrapper centrarH">
                        <asp:Label ID="labelA" runat="server" class="subtitulo" BackColor="">ax<sup>2</sup> </asp:Label>
                        <asp:Label ID="labelB" runat="server" class="subtitulo" BackColor="">+ bx </asp:Label>
                        <asp:Label ID="labelC" runat="server" class="subtitulo" BackColor="">+ c = 0</asp:Label>
                    </div>
                </div>
                <div class="centrarT">
                    <div id="caixaTextoWrapper" class="subtitulo">
                        a = <asp:TextBox ID="TextBoxA" runat="server" CssClass="caixaTexto" AutoPostBack="true" OnTextChanged="TextBoxA_TextChanged"></asp:TextBox>
                        b = <asp:TextBox ID="TextBoxB" runat="server" CssClass="caixaTexto" AutoPostBack="true" OnTextChanged="TextBoxB_TextChanged"></asp:TextBox>
                        c = <asp:TextBox ID="TextBoxC" runat="server" CssClass="caixaTexto" AutoPostBack="true" OnTextChanged="TextBoxC_TextChanged"></asp:TextBox>
                        <asp:Button ID="botaoCalcular" runat="server" OnClick="botaoCalcular_Click" Text="Calcular" CssClass="botao" BorderWidth="0px"   BackColor="#45c8dc" ForeColor="#f7f8f8" Font-Size="14px" Font-Bold="true"/>
                    </div>
                </div>
                <div class="subtitulo" style="margin-left:17px;">Resultado</div>
                <div class="centrarT">
                    <div style="border:1px solid black; background-color:#f7f8f8; Width:516px; display:inline-block;">
                        <div style="margin-top:10px; margin-bottom:10px;">
                            <asp:Label ID="resultado" runat="server"  Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="titulo">GRÁFICO</div>
            <div id="grafico" class="margemInf centrarH">
                <div class="centrarT">
                    <div class="equacaoWrapper centrarH" style="margin-bottom:5px;">
                        <asp:Label ID="label2" runat="server" class="subtitulo">f(x) = </asp:Label>
                        <asp:Label ID="labelA1" runat="server" class="subtitulo" BackColor="">ax<sup>2</sup> </asp:Label>
                        <asp:Label ID="labelB1" runat="server" class="subtitulo" BackColor="">+ bx </asp:Label>
                        <asp:Label ID="labelC1" runat="server" class="subtitulo" BackColor="">+ c </asp:Label>
                    </div>
                </div>
                <br />
                    <div id="calculator" class="centrarH margemInf" style="width: 516px; height: 400px;" ></div>
                    <script type="text/javascript">
                        var elt = document.getElementById('calculator');
                        var calculator = Desmos.Calculator(elt, { keypad: false, expressions: false });
                        var equacao = '<%=getq()%>'
                        calculator.setExpression({ id: 'graph1', latex: equacao });
                    </script>
                
                    
            </div>
        </div>
    </div>
    </form>
</body>
</html>
