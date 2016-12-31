using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace VtrFramework.Domain
{
    /// <summary>
    /// Classe base para parametros hierarquicos. 
    /// Implementa IHeararchiData e mantém uma coleção interna HierarquicalList para fazer as consultas recursivas na memória.
    /// O contructor dessa classe é internal porque ela não deve de maneira alguma ser instanciada pelo programador. Ela deve ser manipulada através de sua coleção
    /// Classe concebida principalmente para popular TreeViews e DropDowns
    /// </summary>
    public class HierarchicalParameter : IHierarchyData
    {
        #region campos privados

        private HierarchicalList _listaHierarquica;

        private int _id;
        private int? _idPai;
        private string _valor;
        private bool _ativo = true;

        #endregion



        #region propriedades públicas

        /// <summary>
        /// Int - O id do objeto
        /// </summary>
        public virtual int Id { get {return _id;} }
        
        /// <summary>
        /// O id do pai, pode ser null se for um objeto raiz
        /// </summary>
        public virtual int? IdPai { get {return _idPai;} }

        /// <summary>
        /// Um valor do tipo string arbitrário. Será o texto do dropdown.
        /// </summary>
        public virtual string Valor { get {return _valor;} }

        /// <summary>
        /// Caminho completo das strings desde a raiz separados por / 
        /// </summary>
        public virtual string ValorPath { get { return GetValorPath(); } }

        /// <summary>
        /// Caminho completo dos id`s desde a raiz separados por /
        /// </summary>
        public virtual string IdPath { get { return GetIdPath(); } }

        /// <summary>
        /// indica se está habilitado ou não. Estar ele inativo não significa nada, tudo dependerá da camada de apresentação, pode ser usado para setar o enabled/disabled
        /// </summary>
        public virtual bool Ativo { get { return _ativo; } set { _ativo = value; } }

        /// <summary>
        /// retorna o pai baseado no getparent
        /// </summary>
        public virtual HierarchicalParameter Pai
        {
            get
            {
                return GetParent() as HierarchicalParameter;
            }
        }

        #endregion



        #region construtores

        /// <summary>
        /// Construtor utilizado apenas pela coleção que manipula os objetos
        /// </summary>
        /// <param name="lista">A lista dos objetos</param>
        /// <param name="id">o id deste objeto</param>
        /// <param name="pai">o id do pai, se houver</param>
        /// <param name="valor">o valor / nome / descrição</param>
        /// <param name="ativo">bool - Ativo ou Inativo</param>
        internal HierarchicalParameter(HierarchicalList lista, int id, int? pai, string valor, bool ativo = true)
        {


            this._id = id;
            this._idPai = pai;
            this._valor = valor;
            this._ativo = ativo;
            this.SetLista(lista);
        }

        #endregion



        #region métodos privados


        private string GetValorPath()
        {
            return ((this.Pai == null) ? "" : (this.Pai.GetValorPath() + "/")) + this.Valor;
        }

        private string GetIdPath()
        {
            return ((this.Pai == null) ? "" : (this.Pai.GetIdPath() + "/")) + this.Id.ToString();
        }

        #endregion



        #region métodos internos
        /// <summary>
        /// Substitui a lista interna pela  HierarquicalList referência para todos os HierarchicalParameter
        /// </summary>
        /// <param name="lista"></param>
        internal void SetLista(HierarchicalList lista)
        {
            if (lista == null)
                throw new ArgumentNullException("Lista", "A lista não pode ser nula");

            this._listaHierarquica = lista;
        }

        #endregion



        #region metodos sobrecarregados padrão object

        /// <summary>
        /// Se for convertido para string traz o valor
        /// </summary>
        /// <returns>string - a propriedade Valor</returns>
        public override string ToString()
        {
            return _valor;
        }

        /// <summary>
        /// Se o Id de dois HierarchicalParameter forem iguais, então consideramos que seja o mesmo objeto 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            //if (!(obj is HierarchicalParameter))
            //    return false;

            if (object.ReferenceEquals(this, obj))
                return true;

            if (string.IsNullOrEmpty(this._valor) && string.IsNullOrEmpty((obj as HierarchicalParameter)._valor))
                return true;

            return  (this._id.Equals((obj as HierarchicalParameter)._id));
        }

        /// <summary>
        /// Obtém o hashcode do valor
        /// Todo: aqui uma melhoria seria, talvez, pegar o  hashcode do Id
        /// </summary>
        /// <returns>int - o hashcode do valor</returns>
        public override int GetHashCode()
        {
            return this._valor.GetHashCode();
        }


        #endregion



        #region IHierarchyData Members

        /// <summary>
        /// obtém todos os filhos desse parâmetro
        /// através de um enumerator convertido para um HierarquicalList
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IHierarchicalEnumerable GetChildren()
        {

            var tmp = from c in this._listaHierarquica
                      where c.IdPai == this.Id
                      select c;

            return new HierarchicalList(tmp);
        }






        /// <summary>
        /// Obtém da lista interna o objeto que represente o pai deste
        /// </summary>
        /// <returns></returns>
        public IHierarchyData GetParent()
        {
            if ((this.IdPai == null) || (this.IdPai.Value == 0))
                return null;

            var tmp = (from p in this._listaHierarquica
                       where p.Id == this.IdPai
                       select p).FirstOrDefault();

            return tmp;
        }

        /// <summary>
        /// Verifica se o item atual tem filhos
        /// </summary>
        public bool HasChildren
        {
            get
            {
                return (this.GetChildren() as HierarchicalList).Count > 0;
            }
        }

        /// <summary>
        /// Obtém o proprio objeto como nó de árvore hierárquica
        /// </summary>
        public object Item
        {
            get { return this; }
        }

        /// <summary>
        /// Obtém o caminho relativo, que é apenas o id
        /// </summary>
        public string Path
        {
            get
            {
                return this.Id.ToString();
            }
        }

        /// <summary>
        /// obtém o tipo como string
        /// </summary>
        public string Type
        {
            get { return this.GetType().ToString(); }
        }

        #endregion



        #region operator overloading http://msdn.microsoft.com/en-us/library/ms173147(v=vs.80).aspx

        /// <summary>
        /// Retorna o Id se for atribuido a um int
        /// </summary>
        /// <param name="p">HierarchicalParameter - o parâmetro do lado direito da atribuição</param>
        /// <returns>int - o Id</returns>
        public static implicit operator Int32(HierarchicalParameter p)
        {
            return p.Id;
        }

        /// <summary>
        /// Retorna o valor se for atribuido a um string
        /// </summary>
        /// <param name="p">HierarchicalParameter - o parâmetro do lado direito da atribuição</param>
        /// <returns>string - o valor</returns>
        public static implicit operator string(HierarchicalParameter p)
        {
            return p.Valor;
        }








        /// <summary>
        /// Verifica se dois HierarchicalParameter são iguais 
        /// </summary>
        /// <param name="x">HierarchicalParameter</param>
        /// <param name="y">HierarchicalParameter</param>
        /// <returns>bool - true se for igual, false caso contrário</returns>
        public static bool operator ==(HierarchicalParameter x, HierarchicalParameter y)
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


        //public static bool operator ==(int x, HierarchicalParameter y)
        //{
        //    if (((object)x == null) && ((object)y == null))
        //    {
        //        return true;
        //    }

        //    if (((object)x == null) || ((object)y == null))
        //    {
        //        return false;
        //    }

        //    return x.Equals(y);
        //}


        //public static bool operator ==(HierarchicalParameter x, int y)
        //{
        //    if (((object)x == null) && ((object)y == null))
        //    {
        //        return true;
        //    }

        //    if (((object)x == null) || ((object)y == null))
        //    {
        //        return false;
        //    }

        //    return x.Equals(y);
        //}

        /// <summary>
        /// Verifica se dois HierarchicalParameter são diferentes
        /// </summary>
        /// <param name="x">HierarchicalParameter</param>
        /// <param name="y">HierarchicalParameter</param>
        /// <returns>bool - true se for diferente, false caso contrário</returns>        
        public static bool operator !=(HierarchicalParameter x, HierarchicalParameter y)
        {
            return !(x == y);
        }

        //public static bool operator !=(int x, HierarchicalParameter y)
        //{
        //    return !(x == y);
        //}

        //public static bool operator !=(HierarchicalParameter x, int y)
        //{
        //    return !(x == y);
        //}
        #endregion
    }



}
