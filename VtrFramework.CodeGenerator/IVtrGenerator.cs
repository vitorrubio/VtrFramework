using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VtrFramework.MetaData;

namespace VtrFramework.CodeGenerator
{
    /// <summary>
    /// Interface comum para todos os exportadores
    /// </summary>
    public interface IVtrGenerator
    {


        /// <summary>
        /// tabela embutida no exportador pelo constructor
        /// </summary>
        VtrTable Tabela { get; set; }

        /// <summary>
        /// namespace base que será concatenado ao namespace do que for exportado
        /// </summary>
        string NameSpaceBase { get; set; }

        /// <summary>
        /// caminho base que onde será salvo toda a estrutura do projeto
        /// </summary>
        string CaminhoBase { get; set; }

        /// <summary>
        /// obtém o namespace completo
        /// </summary>
        /// <returns></returns>
        string GetNameSpace();

        /// <summary>
        /// obtém o caminho completo
        /// </summary>
        /// <returns></returns>
        string GetCaminho();

        /// <summary>
        /// gera a string com o conteúdo
        /// </summary>
        /// <returns></returns>
        string Gerar();

        /// <summary>
        /// salva a string do conteúdo como arquivo
        /// </summary>
        void Exportar();


    }
}
