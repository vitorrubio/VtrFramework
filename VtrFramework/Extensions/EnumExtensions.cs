using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace VtrFramework.Extensions
{
    /// <summary>
    /// classe que permite usar um atributo texto em um item de enum, para ele ter uma descrição amigável
    /// </summary>
    public class TextAttribute : Attribute
    {
        public string Text;
        public TextAttribute(string text)
        {
            Text = text;
        }
    }

    /// <summary>
    /// Adiciona um método a mais em um  elemento do tipo enum para pegarmos seu texto amigável
    /// </summary>
    public static class EnumExtensions
    {

        /// <summary>
        /// Dado um enum, retorna seu correspondente string que pode ser: "" se ele for null, Seu decorator/atributo Text se houver, ToString caso contrário
        /// funciona também com o atributo Description e com o atributo EnumMember
        /// </summary>
        /// <param name="enumeration">O Enum a ser convertido</param>
        /// <returns>string - O texto do enum</returns>
        public static string ToText(this Enum enumeration)
        {

            if (enumeration == null)
            {
                return "";
            }

            MemberInfo[] memberInfo = enumeration.GetType().GetMember(enumeration.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                try
                {
                    object[] descrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                    if (descrs != null && descrs.Length > 0)
                    {
                        return ((DescriptionAttribute)descrs[0]).Description;
                    }


                    object[] enumbs = memberInfo[0].GetCustomAttributes(typeof(EnumMemberAttribute), false);

                    if (enumbs != null && enumbs.Length > 0)
                    {
                        return ((EnumMemberAttribute)enumbs[0]).Value;
                    }

                    object[] txts = memberInfo[0].GetCustomAttributes(typeof(TextAttribute), false);

                    if (txts != null && txts.Length > 0)
                    {
                        return ((TextAttribute)txts[0]).Text;
                    }
                }
                catch
                {
                    //catch mudinho porque o fallback é direto para o ToString
                }

            }

            return enumeration.ToString();

        }



    }
}
