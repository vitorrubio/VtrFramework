using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace VtrFramework.MetaData
{
    /// <summary>
    /// representa um campo de uma tabela de um banco de dados
    /// um campo de uma cllection de campos de um VtrTable
    /// </summary>
    public class VtrField
    {


        #region private fields

        /// <summary>
        /// manfém uma referência para a tabela desse campo.
        /// É necessário para se consultar igualdade, pois dois campos com o mesmo nome só são iguais se forem da mesma tabela
        /// </summary>
        private readonly VtrTable _table;

        #endregion


        #region constructors

        /// <summary>
        /// não tem constructor padrão. O constructor deve receber a tabela e a mesma deve ser imutável
        /// </summary>
        /// <param name="table"></param>
        public VtrField(VtrTable table)
        {
            if (table == null)
                throw new Exception("A tabela do campo não pode ser nula!");

            this._table = table;
        }

        #endregion





        #region public properties

        /// <summary>
        /// a propriedade somente leitura e imutável da Tabela
        /// </summary>
        public virtual  VtrTable Table { get { return this._table; } }

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


        #endregion




        #region metodos sobrecarregados padrão object


        /// <summary>
        /// se dois VtrField tem a mesma string, então são iguais
        /// </summary>
        /// <param name="obj">objeto a ser comparado</param>
        /// <returns>bool - True se forem iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (!(obj is VtrField))
                return false;

            return this.ToString().Equals((obj as VtrField).ToString());
        }

        /// <summary>
        /// se dois VtrField tem a mesma string, então são iguais
        /// </summary>
        /// <param name="ent">Entity a ser comparada</param>
        /// <returns>bool - True se forem iguais</returns>
        public virtual bool Equals(VtrField ent)
        {
            if (ent == null)
                return false;

            if (object.ReferenceEquals(this, ent))
                return true;

            return this.ToString().Equals(ent.ToString());
        }


        /// <summary>
        /// pega o hash do ToString que deve ser único. 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        /// <summary>
        /// é a fusão da ToString da tabela com o nome do campo. Deve ser única por campo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}.{1}", this.Table.ToString(), this.Nome).ToLower();
        }


        #endregion


        #region operator overloading

        /// <summary>
        /// usa o método Equals para verificar se dois objetos são iguais e sobrecarregar a ação do operador de igualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
        public static bool operator ==(VtrField x, VtrField y)
        {
            if (((object)x == null) && ((object)y == null))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y);
        }

        /// <summary>
        /// usa o método Equals para verificar se dois objetos são iguais e sobrecarregar a ação do operador de desigualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(VtrField x, VtrField y)
        {
            return !(x == y);
        }

        #endregion

    }
}
