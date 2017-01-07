using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.MetaData;

namespace VtrFramework.Metadata
{
    public class VtrMsSqlField : VtrField, IVtrFieldTypeInfo
    {


        #region constructors

        /// <summary>
        /// aqui temos uma volação de encapsulamento: se uma classe filha tem uma propriedade imutável, classes descententes não podem alterá-la
        /// </summary>
        /// <param name="table"></param>
        public VtrMsSqlField(VtrTable table):base(table)
        {
        }

        #endregion

        #region public virtual methods

        /// <summary>
        /// reconstitui o tipo SQL com precisão e escala se for numerico/decimal ou com tamanho se for char, varchar, nchar, nvarchar
        /// </summary>
        /// <returns></returns>
        public virtual string GetSqlType()
        {
            if ((this.Tipo.StartsWith("varchar")) || (this.Tipo.StartsWith("nvarchar")) || (this.Tipo.StartsWith("char")) || (this.Tipo.StartsWith("nchar")))
            {
                return string.Format("{0}({1})", this.Tipo, (this.Tamanho > 0) ? this.Tamanho.ToString() : "max");
            }
            else if ((this.Tipo.ToLower().StartsWith("numeric")) || (this.Tipo.ToLower().StartsWith("decimal")))
            {
                return string.Format("{0}({1},{2})", this.Tipo, this.Precisao, this.Escala);
            }
            else
            {
                return this.Tipo;
            }

        }


        /// <summary>
        /// define se o tipo é suportado nas triggers de delete. 
        /// tipos text, ntext e image não saõ suportados
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSupportedInTrigger()
        {
            string tipo = this.GetSqlType().ToLower();
            return !((tipo == "text") || (tipo == "ntext") || (tipo == "image"));
        }


        /// <summary>
        /// define se um campo é de algum tipo inteiro
        /// </summary>
        /// <returns></returns>
        public virtual bool IsIntType()
        {
            return (this.Tipo.ToLower() == "integer") ||
                    (this.Tipo.ToLower() == "int") ||
                    (this.Tipo.ToLower() == "bigint") ||
                    (this.Tipo.ToLower() == "tinyint") ||
                    (this.Tipo.ToLower() == "smallint");
        }


        /// <summary>
        /// define se um campo é de algum tipo decimal/fracionário/ponto flutuante
        /// </summary>
        /// <returns></returns>
        public virtual bool IsFloatType()
        {
            return (this.Tipo.ToLower() == "extended") ||
                (this.Tipo.ToLower().StartsWith("double")) ||
                (this.Tipo.ToLower().StartsWith("double precision")) ||
                (this.Tipo.ToLower().StartsWith("float")) ||
                (this.Tipo.ToLower().StartsWith("real")) ||
                (this.Tipo.ToLower().StartsWith("numeric")) ||
                (this.Tipo.ToLower().StartsWith("decimal")) ||
                (this.Tipo.ToLower().StartsWith("money")) ||
                (this.Tipo.ToLower().StartsWith("smallmoney"));
        }


        /// <summary>
        /// define se um campo é de valores monetários
        /// </summary>
        /// <returns></returns>
        public virtual bool IsMoneyType()
        {
            //todo: verificar a aplicabilidade de todos os numeric(x,2) serem automaticamente dinheiro
            return (this.Tipo.ToLower().StartsWith("money")) ||
                (this.Tipo.ToLower().StartsWith("smallmoney"));
        }


        /// <summary>
        /// verifica se o campo é de algum tipo numérico
        /// </summary>
        /// <returns></returns>
        public virtual bool IsNumericType()
        {
            return this.IsIntType() || this.IsFloatType();
        }


        /// <summary>
        /// verifica se o campo é de um tipo date
        /// </summary>
        /// <returns></returns>
        public virtual bool IsDateType()
        {
            return ((this.Tipo.ToLower() == "datetime") || (this.Tipo.ToLower() == "datetime2") || (this.Tipo.ToLower() == "date"));
        }


        /// <summary>
        /// converte o tipo SQL para um tipo .Net
        /// </summary>
        /// <returns>string - representação do tipo .net em string</returns>
        public virtual string GetDotNetType()
        {
            if ((this.Tipo.StartsWith("varchar")) || (this.Tipo.StartsWith("nvarchar")) || (this.Tipo.StartsWith("text")) || (this.Tipo.StartsWith("ntext")))
            {
                return "string";
            }
            else if ((this.Tipo.ToLower() == "datetime") || (this.Tipo.ToLower() == "datetime2") || (this.Tipo.ToLower() == "date"))
            {
                return Nulavel ? "DateTime?" : "DateTime";
            }
            else if ((this.Tipo.ToLower() == "extended") ||
                (this.Tipo.ToLower().StartsWith("double")) ||
                (this.Tipo.ToLower().StartsWith("double precision")) ||
                (this.Tipo.ToLower().StartsWith("float")) ||
                (this.Tipo.ToLower().StartsWith("real")) ||
                (this.Tipo.ToLower().StartsWith("numeric")) ||
                (this.Tipo.ToLower().StartsWith("decimal")) ||
                (this.Tipo.ToLower().StartsWith("money")) ||
                (this.Tipo.ToLower().StartsWith("smallmoney")))
            {
                return Nulavel ? "double?" : "double";
            }
            else if (this.Tipo.ToLower() == "money")
            {
                return Nulavel ? "double?" : "double";
            }
            else if ((this.Tipo.ToLower() == "integer") ||
                    (this.Tipo.ToLower() == "int") ||
                    (this.Tipo.ToLower() == "tinyint") ||
                    (this.Tipo.ToLower() == "smallint"))
            {
                return Nulavel ? "int?" : "int";
            }
            else if (this.Tipo.ToLower() == "bigint")
            {
                return Nulavel ? "Int64?" : "Int64";
            }
            else if (this.Tipo.ToLower() == "bit")
            {
                return Nulavel ? "bool?" : "bool";
            }
            else if (this.Tipo.ToLower() == "uniqueidentifier")
            {
                return Nulavel ? "Guid?" : "Guid";
            }
            else if ((this.Tipo.ToLower().StartsWith("image")) || (this.Tipo.ToLower().StartsWith("varbinary")))
            {
                return "Byte[]";
            }

            return "object";
        }

        #endregion

    }
}
