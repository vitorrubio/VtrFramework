using System;
using System.Collections.Generic;
using VtrFramework.Extensions;

namespace VtrFramework
{
    /// <summary>
    /// Ferramentas para trabalhar com Enuns
    /// </summary>
    public class VtrEnumTools
    {
        /// <summary>
        /// publica os itens de um enum em um ListItemCollection
        /// </summary>
        /// <typeparam name="TEnum">O tipo do enum a ser publicado</typeparam>
        /// <param name="lst">System.Web.UI.WebControls.ListItemCollection da ListBox ou DropDownList que vai ser preenchida</param>
        /// <param name="primeiroVazio">true se o primeiro item for o vazio/default, false caso contrário</param>
        /// <param name="textoPrimeiroVazio">texto do primeiro item, que não deve fazer parte do enum</param>
        /// <param name="valorPrimeiroVazio">valor do primeiro item, que pode ser String.Empty, 0 ou null dependendo da regra</param>
        public static void PublicaEnum<TEnum>(System.Web.UI.WebControls.ListItemCollection lst, bool primeiroVazio = true, string textoPrimeiroVazio = "Escolha uma opção", string valorPrimeiroVazio = "") where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum precisa ser do tipo ENUM");
            }

            lst.Clear();
            if (primeiroVazio)
            {
                lst.Insert(0, new System.Web.UI.WebControls.ListItem(textoPrimeiroVazio, valorPrimeiroVazio));
            }

            var valores = Enum.GetValues(typeof(TEnum));

            foreach(var v in valores)
            {
                string text = ((Enum)v).ToText();
                string value = ((int)v).ToString();
                lst.Add(new System.Web.UI.WebControls.ListItem(text, value));
            }
        }

        /// <summary>
        /// publica os itens de um enum em um DropDownList
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="drop">o DropDown/ComboList a ser preenchido</param>
        /// <param name="primeiroVazio">true se o primeiro item for o vazio/default, false caso contrário</param>
        /// <param name="textoPrimeiroVazio">texto do primeiro item, que não deve fazer parte do enum</param>
        /// <param name="valorPrimeiroVazio">valor do primeiro item, que pode ser String.Empty, 0 ou null dependendo da regra</param>
        public static void PublicaEnum<TEnum>(System.Web.UI.WebControls.DropDownList drop, bool primeiroVazio = true, string textoPrimeiroVazio = "Escolha uma opção", string valorPrimeiroVazio = "") where TEnum : struct, IConvertible
        {
            PublicaEnum<TEnum>(drop.Items, primeiroVazio, textoPrimeiroVazio, valorPrimeiroVazio);
        }

        /// <summary>
        /// publica os itens de um enum em um RadioButtonList
        /// </summary>
        /// <typeparam name="TEnum">O tipo do enum a ser publicado</typeparam>
        /// <param name="rbl">o RadioButtonList a ser publicado</param>
        public static void PublicaEnum<TEnum>(System.Web.UI.WebControls.RadioButtonList rbl) where TEnum : struct, IConvertible
        {
            PublicaEnum<TEnum>(rbl.Items, false);
        }

        /// <summary>
        /// publica os itens de um enum em um ListBox
        /// </summary>
        /// <typeparam name="TEnum">O tipo do enum a ser publicado</typeparam>
        /// <param name="lbx">o ListBox a ser publicado</param>
        public static void PublicaEnum<TEnum>(System.Web.UI.WebControls.ListBox lbx) where TEnum : struct, IConvertible
        {
            PublicaEnum<TEnum>(lbx.Items, false);
        }

    }
}
