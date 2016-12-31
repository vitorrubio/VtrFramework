using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace VtrFramework.Domain
{
    public class HierarchicalList : List<HierarchicalParameter>, IHierarchicalEnumerable
    {
        /// <summary>
        /// cria uma HierarquicalList baseada numa lista já existente (padrão)
        /// </summary>
        /// <param name="collection"></param>
        public HierarchicalList(IEnumerable<HierarchicalParameter> collection)
            : base(collection)
        {

        }

        /// <summary>
        /// cria uma HierarquicalList (padrão)
        /// </summary>
        public HierarchicalList()
            : base()
        {

        }

        //cria uma HierarquicalList e seta a capacidade (padrão)
        public HierarchicalList(int capacity)
            : base(capacity)
        {

        }

        /// <summary>
        /// botém um item como IHierarchyData
        /// </summary>
        /// <param name="enumeratedItem">objeto da lista</param>
        /// <returns>IHierarchyData</returns>
        public IHierarchyData GetHierarchyData(object enumeratedItem)
        {
            return enumeratedItem as IHierarchyData;
        }


        /// <summary>
        /// adiciona um item (padrão)
        /// </summary>
        /// <param name="item">O item a ser adicionado, do tipo HierarchicalParameter</param>
        public new void Add(HierarchicalParameter item)
        {
            base.Add(item);
            item.SetLista(this);
        }

        /// <summary>
        /// Adiciona uma coleção à lista de itens
        /// </summary>
        /// <param name="collection"></param>
        public new void AddRange(IEnumerable<HierarchicalParameter> collection)
        {
            foreach (var item in collection)
            {
                this.Add(item);
                item.SetLista(this);
            }
        }

        /// <summary>
        /// Cria um novo parametro e adiciona baseado nos valores
        /// </summary>
        /// <param name="id">id od parametro</param>
        /// <param name="pai">id do pai, pode ser nulo, se for nulo é uma raiz</param>
        /// <param name="valor">valor/descrição do parametro</param>
        /// <param name="ativo">bool - se é ativo ou não</param>
        /// <returns>retorna o proprio HierarchicalParameter para encadear chamadas</returns>
        public virtual HierarchicalParameter Add(int id, int? pai, string valor, bool ativo = true)
        {
            HierarchicalParameter p = new HierarchicalParameter(this, id, pai, valor, ativo);
            this.Add(p);
            return p;
        }


        /// <summary>
        /// Retorna uma lista inicial só com as raízes de cada arvore
        /// </summary>
        /// <returns>IEnumerable com todos os pais</returns>
        public HierarchicalList GetRoot()
        {
            return new HierarchicalList( this.Where(x => x.IdPai == 0 || x.IdPai == null));
        }

    }

}
