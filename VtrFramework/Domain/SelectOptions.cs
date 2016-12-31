using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VtrFramework.Domain
{
    /// <summary>
    /// DTO genérico para popular qualquer combo do tipo select2 com itens do tipo chave/valor
    /// </summary>
    [Serializable]
    public class SelectOptions
    {
        #region propriedades públicas

        /// <summary>
        /// código ou valor do option
        /// </summary>
        public virtual string id { get; set; }

        /// <summary>
        /// string/texto/nome/descrição do option
        /// </summary>
        public virtual string text { get; set; }

        /// <summary>
        /// identifica se o item é desabilitado ou não
        /// </summary>
        public virtual bool disable { get; set; }

        #endregion
    }
}
