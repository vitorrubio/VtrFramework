using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VtrFramework.MetaData
{
    /// <summary>
    /// informações sobre a chave estrangeira
    /// </summary>
    public class VtrForeignKey
    {
        public virtual string NomeTabela { get; set; }

        public virtual string TabelaReferencia { get; set; }

        public virtual string CampoReferencia { get; set; }

        public virtual string NomeConstraint { get; set; }
    }
}
