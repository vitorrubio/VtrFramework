using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VtrFramework.Extensions
{
    //Extensão de strings para as operações mais comuns
    public static class VtrStringExtensions
    {




        /// <summary>
        /// Atenção: Use escape '\' nos seus likes
        /// Escapa os caracteres inválidos que servem para comandos no like.
        /// Substitui os argumentos de busca [,],_,%,^ por respectivamente  \[,\],\_,\%,\^
        /// Elimina aspas simples para evitar sql injection
        /// </summary>
        /// <param name="str">string a ser escapada</param>
        /// <returns>string limpa</returns>
        public static string SqlEscape(this string str)
        {
            return str.Replace("[", "\\[")
                .Replace("]", "\\]")
                .Replace("%", "\\%")
                .Replace("^", "\\^")
                .Replace("_", "\\_")
                .Replace("'", "''");
        }


        /// <summary>
        /// Método matches igual do Java, direto na string usando Regex.IsMatch
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="padrao"></param>
        /// <returns></returns>
        public static bool matches(this string valor, string padrao)
        {
            return Matches(valor, padrao);
        }

        /// <summary>
        /// Método matches igual do Java, mas em maiúsculo, respeitando as convenções geralmente usadas em C# direto na string usando Regex.IsMatch
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="padrao"></param>
        /// <returns></returns>
        public static bool Matches(this string valor, string padrao)
        {
            return Regex.IsMatch(valor, padrao, RegexOptions.Singleline);

            //exemplo do que você pode fazer se não quiser ser obrigado a colocar os lmitadores de inicio e fim da string ou de tamanho
            /*
            var matches = Regex.Matches(valor, padrao, RegexOptions.Singleline);
            return ((matches.Count == 1) &&
                    (matches[0].Success) &&
                    (matches[0].Value == valor)); 
             */
        }


        /// <summary>
        /// Remove os acentos diacríticos de uma string normalizando-a
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ReplaceDiacritics(this string source)
        {
            string sourceInFormD = source.Normalize(NormalizationForm.FormD);

            var output = new StringBuilder();
            foreach (char c in sourceInFormD)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    output.Append(c);
            }

            return (output.ToString().Normalize(NormalizationForm.FormC));
        }


        /// <summary>
        /// Limpa uma string para obter apenas caracteres ascii, conforme 
        /// http://stackoverflow.com/questions/497782/how-to-convert-a-string-from-utf8-to-ascii-single-byte-in-c
        /// http://msdn.microsoft.com/en-us/library/89856k4b.aspx
        /// tabela de encodings http://msdn.microsoft.com/en-us/library/system.text.encoding.aspx
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToUsAscii(this string source)
        {
            Encoding encoder = Encoding.GetEncoding("us-ascii", new EncoderReplacementFallback(string.Empty), new DecoderReplacementFallback(string.Empty));
            byte[] bAsciiString = encoder.GetBytes(source);
            string cleanString = encoder.GetString(bAsciiString);
            return cleanString;
        }


        /// <summary>
        /// Retira os caracteres de controle de uma string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string RemoveCtrlChars(this string source)
        {

            if (source == null) return null;

            StringBuilder newString = new StringBuilder();
            char ch;

            for (int i = 0; i < source.Length; i++)
            {

                ch = source[i];

                if (!char.IsControl(ch))
                {
                    newString.Append(ch);
                }
            }
            return newString.ToString();

        }

        /// <summary>
        /// obtém apenas os caracteres imprimíveis da string
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string OnlyPrintables(this string source)
        {
            return Regex.Replace(source, @"[^a-zA-Z0-9-_\.\s]", string.Empty);
        }

        /// <summary>
        /// Normaliza a string para uma string padrão ascii e retira todos os caracteres especiais para que possa ser armazenada em bancos de dados
        /// </summary>
        /// <param name="source">a string fonte (this ou a propria string)</param>
        /// <param name="toupper">true se desejar converter para maiúsculas, false caso contrário</param>
        /// <param name="removebreaks">true se desejar remover quebras de linha, pois o regex \s pode deixar passar, false caso contrário</param>
        /// <param name="removebreaks">true se desejar remover tabs, pois o regex \s pode deixar passar, false caso contrário</param>
        /// <param name="clsap">true se desejar remover aspas, apostrofes, parênteses e outros caracteres suspeitos de serem usados em ataques SQL Injection, false caso contrário</param>
        /// <returns>string normalizada para ser gravada em bancos de dados</returns>
        public static string ToDatabase(this string source, bool toupper = true, bool removebreaks = true, bool removetabs = true)
        {
            if ((source == null) || (source == string.Empty)) return "";

            //remove-se os diacríticos e os espaços em branco
            string tmp = source
                .Trim()
                .ReplaceDiacritics() //primeiro troca os diacríticos, assim pode-se substituir caracteres acentuados por caracteres sem acentuação. 
                .OnlyPrintables(); //depois coloca apenas os imprimiveis

            //pode-se opcionalmente converter tudo para maiusculas
            if (toupper)
            {
                tmp = tmp.ToUpper();
            }

            //pode-se opcionalmente remover as quebras de linha
            if (removebreaks)
            {
                tmp = tmp.Replace("\r\n", "").Replace('\r', '\0').Replace('\n', '\0');
            }

            //pode-se opcionalmente remover os tabs
            if (removetabs)
            {
                tmp = tmp.Replace("\t", "");
            }

            return tmp;
        }

        /// <summary>
        /// Verifica se uma string é uma data válida segundo um formato
        /// </summary>
        /// <param name="Expression">a string a ser validada</param>
        /// <returns></returns>
        public static bool IsDate(this string Expression, string Format)
        {
            if (Expression != null)
            {
                if (Expression is string)
                {
                    try
                    {
                        DateTime dt;
                        return DateTime.TryParseExact(Expression, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// retorna se uma string é uma data válida no formato brasileiro dd/MM/yyyy
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsDate(this string Expression)
        {
            return Expression.IsDate("dd/MM/yyyy");
        }
    }
}
