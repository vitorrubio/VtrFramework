using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VtrFramework.Domain
{

    /// <summary>
    /// Exemplo de classe base para todos os Entity Models ou Domain Models
    /// Neste framework, voltado para aplicações Data Driven, os Domain Models são também Data Models.
    /// São classes POCO rasas e com pouca inteligência.
    /// 
    ///         /// Uma Entity é um objeto que é um objeto com identidade própria e que é persistido no 
    /// banco de dados. 
    /// Eles são do tipo ReferenceType (do ponto de vista do .net framework) e do tipo
    /// EntityType (do ponto de vista da aplicação), ou seja, representam uma entidade da vida real.
    /// 
    /// Ele deve ter uma identidade, geralemnte uma propriedade que o identifica 
    /// (no nosso caso a propriedade é o Id, do tipo int). 
    /// Sua identidade, seu "EU" é definido por esta propriedade, e ela é usada
    /// para definir a igualdade entre dois objetos Entity. 
    /// 
    /// Mesmo que todo o Estado (variáveis, campos e propriedades) de um bojeto mudem,
    /// se sua Identidade não mudar, então ele não é um objeto diferente, mas sim um objeto que
    /// sofreu algum tipo de atualização.
    /// 
    /// Todos os Entity Data Models devem ter um Id, no nosso caso do tipo int.
    /// 
    /// Esse Id pode ser imutável (definido apenas no constructor e recriado 
    /// por um factory method quando vem de um repositório) ou não. 
    /// Fazer com o Id Imutável seria o mais correto, mas isso dificultaria um pouco a 
    /// criação / manutenção dos repositórios e a herança da classe Entity
    /// </summary>
    public class VtrEntity
    {

        #region propriedades públicas


        /// <summary>
        ///O Id da tabela.
        /// </summary>
        public virtual int Id { get; set; }


        #endregion


        #region metodos sobrecarregados padrão object


        /// <summary>
        /// Verifica se dois objetos são iguais através de um campo que os identifique, para poder fazer ordenações e distinct
        /// </summary>
        /// <param name="obj">objeto a ser comparado</param>
        /// <returns>bool - True se forem iguais</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (!(obj is VtrEntity))
                return false;

            return this.Id.Equals((obj as VtrEntity).Id);
        }

        /// <summary>
        /// Verifica se dois objetos são iguais através de um campo que os identifique, para poder fazer ordenações e distinct
        /// igual o objeto acima, mas tipado, por performance
        /// </summary>
        /// <param name="ent">Entity a ser comparada</param>
        /// <returns>bool - True se forem iguais</returns>
        public virtual bool Equals(VtrEntity ent)
        {
            if (ent == null)
                return false;

            if (object.ReferenceEquals(this, ent))
                return true;

            return this.Id.Equals(ent.Id);
        }


        /// <summary>
        /// Chama o hashcode da propriedade usada como Id para comparações
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }


        #endregion


        #region operator overloading

        /// <summary>
        /// usa o método Equals para verificar se dois objetos são iguais e sobrecarregar a ação do operador de igualdade
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>bool</returns>
        public static bool operator ==(VtrEntity x, VtrEntity y)
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
        public static bool operator !=(VtrEntity x, VtrEntity y)
        {
            return !(x == y);
        }

        #endregion
    }
}