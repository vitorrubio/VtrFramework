using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    /// <summary>
    /// representa um parâmetro de um conjunto de parâmetros SQL para uma stored procedure ou query
    /// </summary>
    public class Parametro
    {
        #region membros privados

        /// <summary>
        /// armazena o valor do parâmetos
        /// </summary>
        private object _valor;

        #endregion


        #region propriedades públicas

        /// <summary>
        /// nome do parâmetro, geralmente precedido de @
        /// </summary>
        public virtual string Nome { get; set; }

        /// <summary>
        /// valor do parâmetro, automaticamente conversível de null para DBNull
        /// </summary>
        public virtual object Valor
        {
            get
            {
                //se o valor for null devolve DBNull
                return _valor ?? DBNull.Value;
            }
            set
            {
                //se value for null armazena DBNull
                _valor = value ?? DBNull.Value;
            }
        }


        #endregion


        #region constructors

        /// <summary>
        /// constructor default, inicializa o tipo como nvarchar e o valor como dbnull se for null
        /// </summary>
        /// <param name="nomeParametro"></param>
        /// <param name="valorParametro"></param>
        public Parametro(string nomeParametro, object valorParametro)
        {
            Nome = nomeParametro;
            Valor = valorParametro ?? DBNull.Value;
        }

        #endregion
    }
}
