using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VtrFramework.MetaData
{
    /// <summary>
    /// representa uma tabela de uma banco de dados
    /// </summary>
    public class VtrTable
    {
        public const string LOG_TABLE_PREFIX = "__VTRLOG__";

        #region constructors
        /// <summary>
        /// construtor padrão
        /// </summary>
        public VtrTable()
        {
            _campos = new List<VtrField>();
        }

        #endregion




        #region private fields

        /// <summary>
        /// lista interna de campos
        /// </summary>
        private List<VtrField> _campos;

        #endregion




        #region public properties

        /// <summary>
        /// prefixo a ser colocado nas classes
        /// </summary>
        public virtual string Prefixo { get; set; }

        /// <summary>
        /// sufixo a ser colocado nas classes
        /// </summary>
        public virtual string Sufixo { get; set; }


        /// <summary>
        /// nome do banco de dados
        /// </summary>
        public virtual string DatabaseName { get; set; }


        /// <summary>
        /// nome do schema ao qual pertence a tabela
        /// </summary>
        public virtual string Schema { get; set; }



        /// <summary>
        /// nome da tabela
        /// </summary>
        public virtual string Nome { get; set; }


        




        /// <summary>
        /// lsita de campos
        /// </summary>
        public virtual List<VtrField> Campos { get { return _campos; } }

        #endregion


        #region metodos sobrecarregados padrão object


        /// <summary>
        /// Verifica se dois VtrTable são iguais através de um campo que os identifique, para poder fazer ordenações e distinct
        /// </summary>
        /// <param name="obj">objeto a ser comparado</param>
        /// <returns>bool - True se forem iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (!(obj is VtrTable))
                return false;

            return this.ToString().Equals((obj as VtrTable).ToString());
        }

        /// <summary>
        /// Verifica se dois VtrTable são iguais através de um campo que os identifique, para poder fazer ordenações e distinct
        /// igual o objeto acima, mas tipado, por performance
        /// </summary>
        /// <param name="ent">Entity a ser comparada</param>
        /// <returns>bool - True se forem iguais</returns>
        public virtual bool Equals(VtrTable ent)
        {
            if (ent == null)
                return false;

            if (object.ReferenceEquals(this, ent))
                return true;

            return this.ToString().Equals(ent.ToString());
        }


        /// <summary>
        /// pega o hashcode da ToString, que deve ser única por banco/schema/tabela
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }


        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}", this.DatabaseName, this.Schema, this.Nome).ToLower(); 
        }


        #endregion


        #region operator overloading

        /// <summary>
        /// usa o método Equals para verificar se dois objetos são iguais e sobrecarregar a ação do operador de igualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
        public static bool operator ==(VtrTable x, VtrTable y)
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
        public static bool operator !=(VtrTable x, VtrTable y)
        {
            return !(x == y);
        }

        #endregion
    }
}
