using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using VtrFramework.Domain;

namespace VtrFramework.Extensions
{
    /// <summary>
    /// Enum que define como os nós de um ddl hierárquico serão exibidos
    /// </summary>
    public enum FormatacaoDeArvore
    {
        PermitirNosComFilhos,
        SugerirApenasFolhas,
        PermitirApenasFolhas
    }


    /// <summary>
    /// Extensões de classes web
    /// </summary>
    public static class WebExtensions
    {

        #region constantes privadas

        /// <summary>
        /// chave da session que define a url o lugar onde será armazenada a string da url para onde redirecionar depois do login
        /// não usar fora dessa classe, não usar sem um acessor/getter
        /// </summary>
        private const string CHAVE_URL_PRE_LOGIN = "urlPreLogin";


        #endregion





        #region métodos estáticos públicos de extensão de databind de lista hierárquica

        /// <summary>
        /// percorre uma lista hierárquica em usa profundidade para adicionar os itend em um dropdownlost
        /// </summary>
        /// <param name="ddl">DropDownList - combo onde serão adicionados os itens hierárquicos estilizados</param>
        /// <param name="lista">HierarchicalList - lisa hierárquica a ser exibida em um combo</param>
        /// <param name="useValorpath">bool - define se deve ser criado um hint/tooltip com o caminho completo do item</param>
        /// <param name="formato">define se é permitido ou não nodes com filhos, e se eles são selecionáveis ou não</param>
        public static void HierarchicalDataBind(this DropDownList ddl, HierarchicalList lista, bool useValorpath = false, FormatacaoDeArvore formato = FormatacaoDeArvore.PermitirNosComFilhos)
        {
            _scanTrees(ddl, _getRoots(lista), useValorpath, formato, 0, true);
        }

        /// <summary>
        /// percorre uma lista hierárquica em usa profundidade para adicionar os itend em um ListBox
        /// </summary>
        /// <param name="ddl">ListBox - ListBox onde serão adicionados os itens hierárquicos estilizados</param>
        /// <param name="lista">HierarchicalList - lisa hierárquica a ser exibida em um combo</param>
        /// <param name="useValorpath">bool - define se deve ser criado um hint/tooltip com o caminho completo do item</param>
        /// <param name="formato">define se é permitido ou não nodes com filhos, e se eles são selecionáveis ou não</param>
        public static void HierarchicalDataBind(this ListBox ddl, HierarchicalList lista, bool useValorpath = false, FormatacaoDeArvore formato = FormatacaoDeArvore.PermitirNosComFilhos)
        {
            _scanTrees(ddl, _getRoots(lista), useValorpath, formato, 0, true);
        }

        #endregion


        #region métodos estáticos públicos de extensão de redirects padrão


        /// <summary>
        /// acessa CHAVE_URL_PRE_LOGIN indiretamente
        /// </summary>
        /// <returns>string - retorna a constante CHAVE_URL_PRE_LOGIN</returns>
        public static string GetChaveUrlPreLogin()
        {
            return CHAVE_URL_PRE_LOGIN;
        }


        /// <summary>
        /// fecha a sessão
        /// </summary>
        private static void FecharSessao()
        {
            try
            {
                HttpContext.Current.Session.Clear();
                HttpContext.Current.Session.Abandon();
                HttpContext.Current.Response.Cookies.Clear();
                HttpContext.Current.Request.Cookies.Clear();
            }
            catch
            {
            }
        }


        /// <summary>
        /// redireciona para a página de login armazenando antes na sessão, em CHAVE_URL_PRE_LOGIN, a url onde o usuário queria entrar
        /// </summary>
        /// <param name="response">HttpResponse</param>
        /// <param name="url">string - url para a tela de login</param>
        public static void RedirecionarTelaLogin(this HttpResponse response, string url = "~/Login.aspx")
        {
            try
            {
                System.Web.HttpContext.Current.Session.Add(WebExtensions.GetChaveUrlPreLogin(), System.Web.HttpContext.Current.Request.RawUrl);
            }
            catch
            {
            }

            try
            {
                response.Redirect(url, false);
            }
            catch
            {
            }
        }

        /// <summary>
        /// redireciona para a página armazenada em CHAVE_URL_PRE_LOGIN ou para a home após o login
        /// </summary>
        /// <param name="response">HttpResponse</param>
        public static void RedirecionarPosLogin(this HttpResponse response)
        {
            var url = System.Web.HttpContext.Current.Session[WebExtensions.GetChaveUrlPreLogin()];
            if ((url != null) && (!string.IsNullOrWhiteSpace(url.ToString())))
            {
                if (!url.ToString().ToLower().Contains("/login.aspx"))
                {
                    response.Redirect(url.ToString(), false);
                }
                else
                {
                    response.Redirect("~/", false);
                }
            }
            else
            {
                response.Redirect("~/", false);
            }
            
        }


        #endregion


        #region métodos estáticos públicos de extensão  de mensagens ao usuário

        /// <summary>
        /// emite uma mensagem de sucesso
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        public static void MensagemSucesso(this System.Web.UI.Page pagina, string msg)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemSucesso", "<script type=\"text/javascript\">MensagemSucesso(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\")</script>");
        }

        /// <summary>
        /// emite uma mensagem de sucesso em um controle específico
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="local">string - id do local onde a mensagem será exibida</param>
        public static void MensagemSucesso(this System.Web.UI.Page pagina, string msg, string local)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemSucesso" + local, "<script type=\"text/javascript\">MensagemSucesso(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\", \"" + local + "\")</script>");
        }


        /// <summary>
        /// emite uma mensagem de erro
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        public static void MensagemErro(this System.Web.UI.Page pagina, string msg)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemErro", "<script type=\"text/javascript\">MensagemErro(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\")</script>");
        }


        /// <summary>
        /// emite uma mensagem de erro em um controle específico
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="local">string - id do local onde a mensagem será exibida</param>
        public static void MensagemErro(this System.Web.UI.Page pagina, string msg, string local)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemErro" + local, "<script type=\"text/javascript\">MensagemErro(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\", \"" + local + "\")</script>");
        }


        /// <summary>
        /// emite uma mensagem de alerta
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        public static void MensagemAlerta(this System.Web.UI.Page pagina, string msg)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemAlerta", "<script type=\"text/javascript\">MensagemAlerta(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\")</script>");
        }


        /// <summary>
        /// emite uma mensagem de alerta em um controle específico
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="local">string - id do local onde a mensagem será exibida</param>
        public static void MensagemAlerta(this System.Web.UI.Page pagina, string msg, string local)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemAlerta" + local, "<script type=\"text/javascript\">MensagemAlerta(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\", \"" + local + "\")</script>");
        }


        /// <summary>
        /// emite uma mensagem de info
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        public static void MensagemInfo(this System.Web.UI.Page pagina, string msg)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemInfo", "<script type=\"text/javascript\">MensagemInfo(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\")</script>");
        }


        /// <summary>
        /// emite uma mensagem de info em um controle específico
        /// </summary>
        /// <param name="pagina">Page - a página onde a mensagem será exibida</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="local">string - id do local onde a mensagem será exibida</param>
        public static void MensagemInfo(this System.Web.UI.Page pagina, string msg, string local)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemInfo" + local, "<script type=\"text/javascript\">MensagemInfo(\"" + msg.Replace("\"", "\\\"").Replace("'", "\\'").Replace("\r\n", "\\r\\n") + "\", \"" + local + "\")</script>");
        }




        /// <summary>
        /// Mostra a janela modal com o seletor modalSelector
        /// </summary>
        /// <param name="modalSelector">string - seletor da janela a ser mostrada</param>
        public static void ShowModal(this System.Web.UI.Page pagina, string modalSelector)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), modalSelector, "<script>$('" + modalSelector + "').modal( {keyboard: true, backdrop: 'static'}, 'show');</script>");
        }

        #endregion


        #region métodos estáticos públicos de extensão de mensagens ao usuário temporizadas

        /// <summary>
        /// mostra uma mensagem de sucesso em verde por um tempo determinado
        /// </summary>
        /// <param name="pagina">Page - a página onde será feita a mensagem</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="url">string - a url para onde será redirecionado</param>
        /// <param name="milissegundos">int - a quantidade de milissegundos (só funciona múltiplos de 1000, são segundos na verdade)</param>
        /// <param name="local">string - id do local/label/controle onde a mensagem aparecerá</param>
        public static void MensagemSucessoTemporizada(this System.Web.UI.Page pagina, string msg, string url, int milissegundos, string local = "")
        {
            msg += string.Format("<strong><span id='ctTmp'>Você será <a href='{0}'>redirecionado</a> em {1} segundos</span></strong>", url, milissegundos/1000);
            if (!string.IsNullOrWhiteSpace(local))
            {
                MensagemSucesso(pagina, msg, local);
            }
            else
            {
                MensagemSucesso(pagina, msg);
            }
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemSucessoTemporizada"+local, "<script type=\"text/javascript\">window.setTimeout(function(){ window.location.href = \"" + url + "\"; }, " + milissegundos.ToString() + ");</script>");
        }

        /// <summary>
        /// mostra uma mensagem de erro em vermelho por um tempo determinado
        /// </summary>
        /// <param name="pagina">Page - a página onde será feita a mensagem</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="url">string - a url para onde será redirecionado</param>
        /// <param name="milissegundos">int - a quantidade de milissegundos (só funciona múltiplos de 1000, são segundos na verdade)</param>
        /// <param name="local">string - id do local/label/controle onde a mensagem aparecerá</param>
        public static void MensagemErroTemporizada(this System.Web.UI.Page pagina, string msg, string url, int milissegundos, string local = "")
        {
            msg += string.Format("<strong><span id='ctTmp'>Você será <a href='{0}'>redirecionado</a> em {1} segundos</span></strong>", url, milissegundos / 1000);
            if (!string.IsNullOrWhiteSpace(local))
            {
                MensagemErro(pagina, msg, local);
            }
            else
            {
                MensagemErro(pagina, msg);
            }
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemErroTemporizada"+local, "<script type=\"text/javascript\">window.setTimeout(function(){ window.location.href = \"" + url + "\"; }, " + milissegundos.ToString() + ");</script>");
        }
        
        /// <summary>
        /// mostra uma mensagem de alerta em amarelo por um tempo determinado
        /// </summary>
        /// <param name="pagina">Page - a página onde será feita a mensagem</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="url">string - a url para onde será redirecionado</param>
        /// <param name="milissegundos">int - a quantidade de milissegundos (só funciona múltiplos de 1000, são segundos na verdade)</param>
        /// <param name="local">string - id do local/label/controle onde a mensagem aparecerá</param>
        public static void MensagemAlertaTemporizada(this System.Web.UI.Page pagina, string msg, string url, int milissegundos, string local = "")
        {
            msg += string.Format("<strong><span id='ctTmp'> Você será <a href='{0}'>redirecionado</a> em {1} segundos</span></strong>", url, milissegundos / 1000);
            if (!string.IsNullOrWhiteSpace(local))
            {
                MensagemAlerta(pagina, msg, local);
            }
            else
            {
                MensagemAlerta(pagina, msg);
            }
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemAlertaTemporizada"+local, "<script type=\"text/javascript\">window.setTimeout(function(){ window.location.href = \"" + url + "\"; }, " + milissegundos.ToString() + ");</script>");
        }

        /// <summary>
        /// mostra uma mensagem de informação em azul por um tempo determinado
        /// </summary>
        /// <param name="pagina">Page - a página onde será feita a mensagem</param>
        /// <param name="msg">string - a mensagem a ser exibida</param>
        /// <param name="url">string - a url para onde será redirecionado</param>
        /// <param name="milissegundos">int - a quantidade de milissegundos (só funciona múltiplos de 1000, são segundos na verdade)</param>
        /// <param name="local">string - id do local/label/controle onde a mensagem aparecerá</param>
        public static void MensagemInfoTemporizada(this System.Web.UI.Page pagina, string msg, string url, int milissegundos, string local = "")
        {
            msg += string.Format("<strong><span id='ctTmp'>Você será <a href='{0}'>redirecionado</a> em {1} segundos</span></strong>", url, milissegundos / 1000);
            if (!string.IsNullOrWhiteSpace(local))
            {
                MensagemInfo(pagina, msg, local);
            }
            else
            {
                MensagemInfo(pagina, msg);
            }
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "MensagemInfoTemporizada"+local, "<script type=\"text/javascript\">window.setTimeout(function(){ window.location.href = \"" + url + "\"; }, " + milissegundos.ToString() + ");</script>");
        }

        #endregion


        #region métodos estáticos públicos de extensão de UX

        /// <summary>
        /// método de extensão de página que gera um script para rolar a página até o elemento html cujo id seja igual ao parâmetro destino
        /// </summary>
        /// <param name="pagina">Page - a página onde será executado o método</param>
        /// <param name="destino">string - o destino para onde o browser tem que rolar</param>
        public static void ScrollTo(this System.Web.UI.Page pagina, string destino)
        {
            pagina.ClientScript.RegisterStartupScript(pagina.GetType(), "ScrollTo", string.Format("<script>location.hash='{0}';</script>", destino));
        }

        #endregion


        #region métodos estáticos públicos de extensão  para includes de CSS e outros

        /// <summary>
        /// inclui um arquivo CSS no header da página
        /// </summary>
        /// <param name="page"></param>
        /// <param name="path"></param>
        public static void AddCss(this Page page, string path)
        {
            Literal cssFile = new Literal() { Text = @"<link href=""" + path + @""" type=""text/css"" rel=""stylesheet"" />" };
            page.Header.Controls.Add(cssFile);
        }


        /// <summary>
        /// inclui um arquivo js no header da página
        /// </summary>
        /// <param name="page"></param>
        /// <param name="path"></param>
        public static void AddJs(this Page page, string path)
        {
            Literal jsFile = new Literal() { Text = @"<script src=""" + path + @""" type=""text/javascript"" ></script>" };
            page.Header.Controls.Add(jsFile);
        }

        #endregion





        #region métodos estáticos privados

        /// <summary>
        /// obtém as raízes de uma HierarchicalList
        /// </summary>
        /// <param name="lista">HierarchicalList - lista hierárquica a se obterem as raizes</param>
        /// <returns>HierarchicalList - lista apenas com as raízes</returns>
        private static HierarchicalList _getRoots(HierarchicalList lista)
        {
            return lista.GetRoot();
        }

        /// <summary>
        /// método privado recursivo que constroi e estiliza os itens de um DropDownList ou ListBox hierárquico
        /// </summary>
        /// <param name="ddl">DropDownList ou ListBox a ser preenchido</param>
        /// <param name="lista">HierarchicalList a ter seus itens publicados</param>
        /// <param name="useValorpath">bool - define se usará um tooltip com o caminho completo ou não</param>
        /// <param name="formato">FormatacaoDeArvore - define se permite ou não seleção de itens com nodes filhos</param>
        /// <param name="nivel">int - nivel corrente na hierarquia</param>
        /// <param name="primeiroVazio">bool - define se o primeiro item é vazio ou não. É passado true somente na primeira iteração recursiva.</param>
        private static void _scanTrees(this DropDownList ddl, HierarchicalList lista, bool useValorpath, FormatacaoDeArvore formato, int nivel = 0, bool primeiroVazio = true)
        {
            if (primeiroVazio && (nivel == 0))
            {
                var item = new ListItem("", "");

                ddl.Items.Add(item);
            }

            foreach (var c in lista)
            {

                string[] parts = c.ValorPath.Split('/').Skip(1).ToArray();
                string caminho = String.Join("/", parts);

                var item = new ListItem((useValorpath && !string.IsNullOrWhiteSpace(caminho)) ? caminho : c.Valor, c.Id.ToString("0"));
                var path = c.ValorPath;
                item.Attributes.Add("title", path);
                item.Attributes.Add("data-toggle", "tooltip");

                //deve repetir essa verificação antes da chamada recursiva e antes de adicionar o item
                if (c.HasChildren)
                {
                    switch (formato)
                    {
                        case FormatacaoDeArvore.SugerirApenasFolhas:
                            item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0") + " disabled");
                            break;
                        case FormatacaoDeArvore.PermitirApenasFolhas:
                            item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0") + " disabled");
                            item.Attributes["disabled"] = "disabled";
                            break;
                        default:
                            item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0"));
                            break;
                    }
                }
                else
                {
                    item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0"));
                }

                if (!c.Ativo)
                {
                    item.Attributes["disabled"] = "disabled";
                }


                ddl.Items.Add(item);
                if (c.HasChildren)
                {
                    _scanTrees(ddl, (HierarchicalList)c.GetChildren(), useValorpath, formato, nivel + 1, false);
                }
            }

        }

        /// <summary>
        /// método privado recursivo que constroi e estiliza os itens de um DropDownList ou ListBox hierárquico
        /// </summary>
        /// <param name="ddl">DropDownList ou ListBox a ser preenchido</param>
        /// <param name="lista">HierarchicalList a ter seus itens publicados</param>
        /// <param name="useValorpath">bool - define se usará um tooltip com o caminho completo ou não</param>
        /// <param name="formato">FormatacaoDeArvore - define se permite ou não seleção de itens com nodes filhos</param>
        /// <param name="nivel">int - nivel corrente na hierarquia</param>
        /// <param name="primeiroVazio">bool - define se o primeiro item é vazio ou não. É passado true somente na primeira iteração recursiva.</param>
        private static void _scanTrees(this ListBox ddl, HierarchicalList lista, bool useValorpath, FormatacaoDeArvore formato, int nivel = 0, bool primeiroVazio = true)
        {
            if (primeiroVazio && (nivel == 0))
            {
                var item = new ListItem("", "");

                ddl.Items.Add(item);
            }

            foreach (var c in lista)
            {

                string[] parts = c.ValorPath.Split('/').Skip(1).ToArray();
                string caminho = String.Join("/", parts);

                var item = new ListItem((useValorpath && !string.IsNullOrWhiteSpace(caminho)) ? caminho : c.Valor, c.Id.ToString("0"));
                var path = c.ValorPath;
                item.Attributes.Add("title", path);
                item.Attributes.Add("data-toggle", "tooltip");

                //deve repetir essa verificação antes da chamada recursiva e antes de adicionar o item
                if (c.HasChildren)
                {
                    switch (formato)
                    {
                        case FormatacaoDeArvore.SugerirApenasFolhas:
                            item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0") + " disabled");
                            break;
                        case FormatacaoDeArvore.PermitirApenasFolhas:
                            item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0") + " disabled");
                            item.Attributes["disabled"] = "disabled";
                            break;
                        default:
                            item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0"));
                            break;
                    }

                }
                else
                {
                    item.Attributes.Add("class", "OptionNivel" + nivel.ToString("0"));
                }

                if (!c.Ativo)
                {
                    item.Attributes["disabled"] = "disabled";
                }

                ddl.Items.Add(item);
                if (c.HasChildren)
                {
                    _scanTrees(ddl, (HierarchicalList)c.GetChildren(), useValorpath, formato, nivel + 1, false);
                }
            }

        }


        #endregion
    }
}
