using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using VtrFramework.Extensions;

namespace VtrFramework.Domain
{

    /// <summary>
    /// uma classe com um enum com todas as unidades da federação e um conjunto de métodos para popular listas e combos com esses enums
    /// está em português porque é muito característica do Brasil
    /// </summary>
    public  class VtrUnidadeFederacao
    {
        #region public properties
        /// <summary>
        /// id do elemento, correspondente a ordem dele no enum
        /// </summary>
        public int Id {get; set;}
        /// <summary>
        /// sigla da unidade
        /// </summary>
        public string Sigla {get; set;}
        /// <summary>
        /// nome da unidade
        /// </summary>
        public string Nome {get; set;}
        #endregion


        #region public static methods

        /// <summary>
        /// Obtém uma lista dos elementos do Enum em si
        /// </summary>
        /// <returns>list of UnidadeFederacaoSigla</returns>
        public static List<UnidadeFederacaoSigla> GetUnidadeFederacaoSiglaList()
        {
            var values = Enum.GetValues(typeof(UnidadeFederacaoSigla)).Cast<UnidadeFederacaoSigla>();
            return values.ToList<UnidadeFederacaoSigla>();
        }

        /// <summary>
        /// obtém uma lista de elementos UnidadeFederacao, que é representado através de uma classe, tem id numérico e o nome completo
        /// </summary>
        /// <returns></returns>
        public static List<VtrUnidadeFederacao> GetUnidadeFederacaoList()
        {
            return (from v in VtrUnidadeFederacao.GetUnidadeFederacaoSiglaList()
             select new VtrUnidadeFederacao
             {
                 Id = (int) v,
                 Sigla = v.ToString(),
                 Nome = v.ToText()
             }).ToList<VtrUnidadeFederacao>();
        }

        /// <summary>
        /// [WebForms]preenche um combo webforms com as unidades da federação
        /// permite que se crie combos onde a descrição é o estado e o value é a UF,
        /// ou a descrição é a UF e o value é um id numérico
        /// </summary>
        /// <param name="ddl">o combo</param>
        /// <param name="text">o que vai ser o text d combo</param>
        /// <param name="value">o que vai ser o value do combo</param>
        /// <param name="primeiroVazio">indica se o primeiro item deve vir vazio</param>
        /// <param name="placeholderPrimeiroVazio">indica o placeholder do primeiro item</param>
        /// <param name="valorPrimeiroVazio">o valor do primeiro item, caso permita vazio, pode ser 0, String.Empty ou null</param>
        public static void PopulaCombo(DropDownList ddl, string text = "Nome", string value = "Sigla", bool primeiroVazio = true, string placeholderPrimeiroVazio = "Escolha um Estado", string valorPrimeiroVazio = "")
        {


            ddl.DataTextField = text;
            ddl.DataValueField = value;
            ddl.DataSource = VtrUnidadeFederacao.GetUnidadeFederacaoList();
            ddl.DataBind();

            if (primeiroVazio)
            {
                ddl.Items.Insert(0, new ListItem(placeholderPrimeiroVazio, valorPrimeiroVazio));
            }
        }

        /// <summary>
        /// [WebForms]preenche um combo webforms com as unidades da federação
        /// permite que se crie combos onde a descrição é o estado e o value é a UF,
        /// ou a descrição é a UF e o value é um id numérico
        /// </summary>
        /// <param name="ddl">o combo</param>
        /// <param name="map">uma expressão lambda que papeia um UnidadeFederacao para um  ListItem</param>
        /// <param name="primeiroVazio">indica se o primeiro item deve vir vazio</param>
        /// <param name="placeholderPrimeiroVazio">indica o placeholder do primeiro item</param>
        /// <param name="valorPrimeiroVazio">o valor do primeiro item, caso permita vazio, pode ser 0, String.Empty ou null</param>
        public static void PopulaCombo(DropDownList ddl, Func<VtrUnidadeFederacao, ListItem> map, bool primeiroVazio = true, string placeholderPrimeiroVazio = "Escolha um Estado", string valorPrimeiroVazio = "")
        {
            if (primeiroVazio)
            {
                ddl.Items.Add(new ListItem(placeholderPrimeiroVazio, valorPrimeiroVazio));
            }

            foreach (var v in VtrUnidadeFederacao.GetUnidadeFederacaoList())
            {
                ddl.Items.Add(map(v));
            }

        }

        #endregion

        #region enum UnidadeFederacaoSigla

        /// <summary>
        /// enum com as UF's de fato
        /// </summary>
        public enum UnidadeFederacaoSigla
        {
            [Text("Acre")]
            AC,
            [Text("Alagoas")]
            AL,
            [Text("Amapá")]
            AP,
            [Text("Amazonas")]
            AM,
            [Text("Bahia")]
            BA,
            [Text("Ceará")]
            CE,
            [Text("Distrito Federal")]
            DF,
            [Text("Espirito Santo")]
            ES,
            [Text("Goiás")]
            GO,
            [Text("Maranhão")]
            MA,
            [Text("Mato Grosso")]
            MT,
            [Text("Mato Grosso do Sul")]
            MS,
            [Text("Minas Gerais")]
            MG,
            [Text("Pará")]
            PA,
            [Text("Paraiba")]
            PB,
            [Text("Paraná")]
            PR,
            [Text("Pernambuco")]
            PE,
            [Text("Piauí")]
            PI,
            [Text("Rio de Janeiro")]
            RJ,
            [Text("Rio Grande do Norte")]
            RN,
            [Text("Rio Grande do Sul")]
            RS,
            [Text("Rondônia")]
            RO,
            [Text("Roraima")]
            RR,
            [Text("Santa Catarina")]
            SC,
            [Text("São Paulo")]
            SP,
            [Text("Sergipe")]
            SE,
            [Text("Tocantis")]
            TO
        }

        #endregion


    }
}
