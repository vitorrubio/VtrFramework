using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VtrFramework.MetaData;
using VtrFramework.Infra;

namespace VtrFramework.CodeGenerator
{
    public class VtrCodeGenerationWork
    {
        #region propriedades privadas

        /// <summary>
        /// lista privada de factories
        /// </summary>
        private List<IVtrGeneratorFactory> _generatorFactories;


        private readonly IVtrSystemDatabase _db;

        #endregion

        #region propriedades públicas

        /// <summary>
        /// lista de fabricas de Exportadores
        /// </summary>
        public virtual List<IVtrGeneratorFactory> GeneratorFactories { get { return _generatorFactories; } }


        /// <summary>
        /// namespace base do aplicativo
        /// </summary>
        public virtual string NameSpaceBase {get; set;}

        /// <summary>
        /// caminho onde o src do aplicativo é salvo
        /// </summary>
        public virtual string CaminhoBase {get; set;}

        #endregion



        #region constructors

        /// <summary>
        /// construtor padrão valida e inicializa o projeto
        /// </summary>
        /// <param name="idApp">Id da aplicação no GPF</param>
        /// <param name="namesp">Namespace da aplicação</param>
        /// <param name="caminho">Caminho do source da aplicação</param>
        public VtrCodeGenerationWork(IVtrSystemDatabase db, string nameSpace, string path)
        {

            if (db == null)
            {
                throw new ArgumentNullException("IVtrSystemDatabase não pode ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(nameSpace))
            {
                throw new ArgumentNullException("namesp precisa ser preenchido com o NameSpace base da aplicação.");
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("caminho precisa ser preenchido com o Diretório base onde são gravados os arquivos da aplicação.");
            }

            this._db = db;
            this.NameSpaceBase = nameSpace;
            this.CaminhoBase = path;

            this._generatorFactories = new List<IVtrGeneratorFactory>();

        }

        #endregion

        #region métodos públicas

        /// <summary>
        /// obtém do repositório de metadados e tabelas do sistema a lista de tabelas completa e gera o projeto todo
        /// </summary>
        public virtual void ExportarProjeto()
        {
            IVtrTableRepository rep = VtrMetaDataFactory.GetTableRepository();
            var tabelas = rep.GetAll();
            ExportarProjeto(tabelas);

        }

        /// <summary>
        /// Exporta uma lista de tabelas do front-end que não são necessariamente todas as tabelas do aplicativo
        /// </summary>
        /// <param name="tabelas">Lista de tabelas a serem exportadas</param>
        public virtual void ExportarProjeto(List<VtrTable> tabelas)
        {
            foreach (var t in tabelas)
            {
                ExportaArquivosDaTabela(t);
            }
        }

        #endregion




        #region métodos protegidos


        /// <summary>
        /// cria a lista de exportadores da tabela T (para cada tabela) baseado na lista de factories (fixa)
        /// pode ser alterado facilmente para uma lista de exportadores com método SetTabela ou para uma lista de strings com a factory usando reflection
        /// pode ser sobrecarregado para usar uma lista de types
        /// </summary>
        /// <param name="t">Tabela - a tabela da coleção sendo varrida no momento</param>
        /// <returns>IEnumerable[IExportador] - Retorna a lista de exportadores para essa tabela</returns>
        protected virtual IEnumerable<IVtrGenerator> GetExportadores(VtrTable t)
        {
            foreach (var f in _generatorFactories)
            {
                var exportador = f.Create(t, this.NameSpaceBase, this.CaminhoBase);
                yield return exportador;
            }
        }

        #endregion



        #region métodos privados



        /// <summary>
        /// dada a lista de exportadores da tabela T, executa o método Exportar para cada exportador
        /// </summary>
        /// <param name="t"></param>
        private void ExportaArquivosDaTabela(VtrTable t)
        {
            foreach (var xp in this.GetExportadores(t))
            {
                xp.Exportar();
            }
        }



        #endregion

    }
}
