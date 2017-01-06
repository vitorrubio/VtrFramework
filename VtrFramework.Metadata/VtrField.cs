using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace VtrFramework.MetaData
{
    public class VtrField
    {
        /// <summary>
        /// nome do campo tal qual nos metadados da tabela
        /// </summary>
        public virtual string Nome { get; set; }

        /// <summary>
        /// tipo SQL do campo
        /// </summary>
        public virtual string Tipo { get; set; }

        /// <summary>
        /// True se o campo for nulável, false caso contrário
        /// </summary>
        public virtual bool Nulavel { get; set; }

        /// <summary>
        /// obtém a descrição do campo na documentação do SQL
        /// </summary>
        public virtual string Descricao { get; set; }

        /// <summary>
        /// obtém o tamanho de campos varchar/nvarchar 
        /// </summary>
        public virtual int Tamanho { get; set; }

        /// <summary>
        /// tamanho de um campo numérico
        /// </summary>
        public virtual int Precisao { get; set; }

        /// <summary>
        /// número de casas depois da vírgula de um campo numérico
        /// </summary>
        public virtual int Escala { get; set; }


        /// <summary>
        /// diz se um campo é foreign key ou não
        /// </summary>
        public virtual bool IsForeignKey { get; set; }


        /// <summary>
        /// porta as informações da foreign key, se houver
        /// </summary>
        public virtual VtrForeignKey InformacaoChaveEstrangeira { get; set; }

        /// <summary>
        /// converte um tipo sql para um tipo SqlDbType para ser usado no Ado.Net
        /// todo: atualizar com a lista completa de fields
        /// </summary>
        /// <param name="tipoSql"></param>
        /// <param name="tipoSqlDbType"></param>
        /// <returns></returns>
        public static SqlDbType SqlTypeSqlDbType(string tipoSql, SqlDbType tipoSqlDbType)
        {
            return SqlDbType.NVarChar;
        }

        /// <summary>
        /// converte um tipo .net para um tipo SqlDbType
        /// todo: colocar a lista completa de tipos
        /// </summary>
        /// <param name="tipoDotNet"></param>
        /// <param name="tipoSqlDbType"></param>
        /// <returns></returns>
        public static SqlDbType DotNetTypeToSqlDbType(Type tipoDotNet, SqlDbType tipoSqlDbType)
        {
            return SqlDbType.NVarChar;
        }

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
            return !((tipo == "text") || (tipo == "ntext") ||  (tipo == "image"));
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
                return  Nulavel?  "double?" : "double";
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
                return Nulavel?  "int?":"int";
            }
            else if (this.Tipo.ToLower() == "bigint")
            {
                return Nulavel ? "Int64?" : "Int64";
            }
            else if (this.Tipo.ToLower() == "bit")
            {
                return Nulavel? "bool?": "bool";
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
    }
}
