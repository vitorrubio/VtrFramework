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



    }
}
