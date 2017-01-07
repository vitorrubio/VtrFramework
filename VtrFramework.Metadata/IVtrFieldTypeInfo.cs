using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Metadata
{
    /// <summary>
    /// interface a ser implementada por todos os descendentes de VtrField ou todos os wrappers de VtrField que 
    /// sejam inicializados com um VtrField. 
    /// Provê um conjunto de métodos comuns para obter informações e conversões de tipo baseados no tipo do VtrField corrente e em seu banco de dados
    /// </summary>
    public interface IVtrFieldTypeInfo
    {
        #region public virtual methods

        /// <summary>
        /// reconstitui o tipo SQL com precisão e escala se for numerico/decimal ou com tamanho se for char, varchar, nchar, nvarchar
        /// </summary>
        /// <returns></returns>
        string GetSqlType();


        /// <summary>
        /// define se o tipo é suportado nas triggers de delete. 
        /// tipos text, ntext e image não saõ suportados
        /// </summary>
        /// <returns></returns>
        bool IsSupportedInTrigger();

        /// <summary>
        /// define se um campo é de algum tipo inteiro
        /// </summary>
        /// <returns></returns>
        bool IsIntType();


        /// <summary>
        /// define se um campo é de algum tipo decimal/fracionário/ponto flutuante
        /// </summary>
        /// <returns></returns>
        bool IsFloatType();


        /// <summary>
        /// define se um campo é de valores monetários
        /// </summary>
        /// <returns></returns>
        bool IsMoneyType();


        /// <summary>
        /// verifica se o campo é de algum tipo numérico
        /// </summary>
        /// <returns></returns>
        bool IsNumericType();


        /// <summary>
        /// verifica se o campo é de um tipo date
        /// </summary>
        /// <returns></returns>
        bool IsDateType();


        /// <summary>
        /// converte o tipo SQL para um tipo .Net
        /// </summary>
        /// <returns>string - representação do tipo .net em string</returns>
        string GetDotNetType();

        #endregion
    }
}
