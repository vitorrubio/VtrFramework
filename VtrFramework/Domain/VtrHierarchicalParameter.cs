﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace VtrFramework.Domain
{
    /// <summary>
    /// Classe base para parametros hierarquicos. 
    /// Implementa IHeararchiData e mantém uma coleção interna HierarchicalList para fazer as consultas recursivas na memória.
    /// O contructor dessa classe é internal porque ela não deve de maneira alguma ser instanciada pelo programador. Ela deve ser manipulada através de sua coleção
    /// Classe concebida principalmente para popular TreeViews e DropDowns
    /// </summary>
    public class VtrHierarchicalParameter : IHierarchyData
    {
        #region campos privados

        private VtrHierarchicalList _listaHierarquica;

        private int _id;
        private int? _idPai;
        private string _valor;
        private bool _ativo = true;

        private string _separador = "/";

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
        public virtual VtrHierarchicalParameter Pai
        {
            get
            {
                return GetParent() as VtrHierarchicalParameter;
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
        internal VtrHierarchicalParameter(VtrHierarchicalList lista, int id, int? pai, string valor, bool ativo = true)
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
            return ((this.Pai == null) ? "" : (this.Pai.GetValorPath() + _separador)) + this.Valor;
        }

        private string GetIdPath()
        {
            return ((this.Pai == null) ? "" : (this.Pai.GetIdPath() + _separador)) + this.Id.ToString();
        }

        #endregion



        #region métodos internos
        /// <summary>
        /// Substitui a lista interna pela  HierarchicalList referência para todos os HierarchicalParameter
        /// </summary>
        /// <param name="lista"></param>
        internal void SetLista(VtrHierarchicalList lista)
        {
            if (lista == null)
                throw new ArgumentNullException("Lista", "A lista não pode ser nula");

            this._listaHierarquica = lista;
            this._separador = lista.Separador;
        }

        #endregion



        #region metodos sobrecarregados padrão object

        /// <summary>
        /// Se for convertido para string traz o valor
        /// </summary>
        /// <returns>string - a propriedade Valor</returns>
        public override string ToString()
        {
            return this.ValorPath;
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

            if (object.ReferenceEquals(this, obj))
                return true;

            if (!(obj is VtrHierarchicalParameter))
                return false;


            if ((obj is VtrHierarchicalParameter) && 
                string.IsNullOrEmpty(this._valor) && 
                string.IsNullOrEmpty((obj as VtrHierarchicalParameter)._valor)&&
                this._id == 0 &&
                (obj as VtrHierarchicalParameter).Id ==0)
                return true;

            if (obj is VtrHierarchicalParameter)
                return this._valor.Equals((obj as VtrHierarchicalParameter).Valor) && (this._id.Equals((obj as VtrHierarchicalParameter)._id));

            return  false;
        }


        public virtual bool Equals(VtrHierarchicalParameter obj)
        {

            if (obj == null)
                return false;

            if (object.ReferenceEquals(this, obj))
                return true;


            if (string.IsNullOrEmpty(this._valor) &&
                string.IsNullOrEmpty(obj._valor) &&
                this._id == 0 &&
                obj.Id == 0)
                return true;


            return this._valor.Equals(obj.Valor) && (this._id.Equals(obj._id));

        }

        /// <summary>
        /// Obtém o hashcode do valor
        /// Todo: aqui uma melhoria seria, talvez, pegar o  hashcode do Id
        /// </summary>
        /// <returns>int - o hashcode do valor</returns>
        public override int GetHashCode()
        {
            return this._id.GetHashCode();
        }


        #endregion



        #region IHierarchyData Members

        /// <summary>
        /// obtém todos os filhos desse parâmetro
        /// através de um enumerator convertido para um HierarchicalList
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public IHierarchicalEnumerable GetChildren()
        {

            var tmp = from c in this._listaHierarquica
                      where c.IdPai == this.Id
                      select c;

            return new VtrHierarchicalList(tmp);
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
                return (this.GetChildren() as VtrHierarchicalList).Count > 0;
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
        /// Verifica se dois HierarchicalParameter são iguais 
        /// </summary>
        /// <param name="x">HierarchicalParameter</param>
        /// <param name="y">HierarchicalParameter</param>
        /// <returns>bool - true se for igual, false caso contrário</returns>
        public static bool operator ==(VtrHierarchicalParameter x, VtrHierarchicalParameter y)
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
        /// Verifica se dois HierarchicalParameter são diferentes
        /// </summary>
        /// <param name="x">HierarchicalParameter</param>
        /// <param name="y">HierarchicalParameter</param>
        /// <returns>bool - true se for diferente, false caso contrário</returns>        
        public static bool operator !=(VtrHierarchicalParameter x, VtrHierarchicalParameter y)
        {
            return !(x == y);
        }


        #endregion


    }



}
