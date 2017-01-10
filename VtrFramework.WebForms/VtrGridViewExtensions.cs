using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace VtrFramework.WebForms.Extensions
{
    /// <summary>
    /// Extensões para facilitar o uso da gridview
    /// </summary>
    public static class VtrGridViewExtensions
    {
        /// <summary>
        /// o método registrar configura o GridView com AccessibleHeader e TableHeader para ser gerado o html referente ao thead.
        /// Ele também faz o bind do evento prerender com um literal numérico indicando o número de colunas que não são botões. 
        /// Tudo isso deve ser usado no load da página e serve para substituir o código e constantes que se usava antes em Render() da página
        /// Para funcionar tudo isso a página deve ter EnableEventValidation=false
        /// </summary>
        /// <param name="ogv"></param>
        /// <param name="numeroColunasSemBotoes"></param>
        public static void Registrar(this GridView ogv, int numeroColunasSemBotoes)
        {
            ogv.PreRender += (sndr, evArgs) =>
            {
                if (ogv.Rows.Count > 0)
                {
                    ogv.UseAccessibleHeader = true;
                    ogv.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                foreach (GridViewRow Row in ogv.Rows)
                {

                    //conforme dica de http://www.aspsnippets.com/Articles/Select-GridView-row-without-using-Select-Button-in-ASPNet.aspx
                    if (Row.RowType == DataControlRowType.DataRow)
                    {
                        try
                        {
                            //É obrigatório o uso de EnableEventValidation=false na página. 
                            ogv.Page.ClientScript.RegisterForEventValidation(ogv.UniqueID, "Select$" + Row.RowIndex);

                            //contorno para não deixar a linha inteira clicável no ie e evitar o comando duplo
                            int i = 0;
                            foreach (TableCell c in Row.Cells)
                            {
                                //são 6 colunas de dados (sem botões). 
                                //Nelas haverá o click da linha. Nas outras apenas o click do botão. 
                                //Isso é necessário porque o IE performa dois cliques na linha quando se clica no botão
                                if (i < numeroColunasSemBotoes)
                                {

                                    c.Attributes["onclick"] = ogv.Page.ClientScript.GetPostBackClientHyperlink((ogv as GridView), "Select$" + Row.RowIndex);
                                    c.ToolTip = "Click para selecionar esta linha.";
                                    i++;
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            throw new InvalidOperationException("É obrigatório o uso de EnableEventValidation=false na página. " + err.Message, err);
                        }
                    }
                }
            };
        }


        /// <summary>
        /// Seleciona a linha cujo id corresponde ao argumento
        /// Deve ser usado em botões ou comandos que não são o select, não alteram SelectedIndexChanged mas deveriam mudar a linha selecionada
        /// </summary>
        /// <param name="argument">Id do objeto a ser selecionado</param>
        public static void SelecionarLinhaPorId(this GridView ogv, object argument)
        {
            int id = 0;


            if ((ogv.DataKeys != null) && (argument != null) && (int.TryParse(argument.ToString(), out id)))
            {
                for (int i = 0; i < ogv.DataKeys.Count; i++)
                {
                    int idSelecionado = 0;
                    if ((ogv.DataKeys.Count > 0) && (ogv.DataKeys[i] != null) && (ogv.DataKeys[i].Value != null) && (int.TryParse(ogv.DataKeys[i].Value.ToString(), out idSelecionado)) && (id == idSelecionado))
                    {
                        ogv.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}
