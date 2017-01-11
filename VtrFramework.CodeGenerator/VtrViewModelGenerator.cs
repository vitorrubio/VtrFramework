using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VtrFramework.MetaData;

namespace VtrFramework.CodeGenerator
{
    /// <summary>
    /// 
    /// </summary>
    public class VtrViewModelGenerator : IVtrGenerator, IVtrViewModelGenerator
    {


        #region campos privados

        private VtrTable _tabela; 

        #endregion



        #region propriedaes públicas

        /// <summary>
        /// objeto tabela que este exportador carrega
        /// </summary>
        public virtual VtrTable Tabela { get { return _tabela; } set { _tabela = value; } }

        /// <summary>
        /// namespace base da aplicação
        /// </summary>
        public virtual string NameSpaceBase { get; set; }

        /// <summary>
        /// caminho base do source da aplicação
        /// </summary>
        public virtual string CaminhoBase { get; set; }

        #endregion



        #region constructors

        /// <summary>
        /// Inicializa a classe passando a tabela, o namespace e o path
        /// </summary>
        /// <param name="tab">Tabela que está sendo usada para gerar o arquivo</param>
        /// <param name="ns">NameSpace padrão da aplicação</param>
        /// <param name="p">Path onde serão salvos os arquivos</param>
        public VtrViewModelGenerator(VtrTable table, string baseNamespace, string basePath)
        {
            if (table == null)
                throw new ArgumentNullException("A tabela não pode ser nula!");

            if (string.IsNullOrWhiteSpace(baseNamespace))
                throw new ArgumentNullException("O namespace base não pode ser nulo!");

            if (string.IsNullOrWhiteSpace(basePath))
                throw new ArgumentNullException("O caminho base não pode ser nulo!");


            if (table != null)
            {
                _tabela = table;
            }


            this.NameSpaceBase = baseNamespace;
            this.CaminhoBase = basePath;
        }

        #endregion


        #region métodos públicos

        /// <summary>
        /// compõe o namespace baseado em um namespace base mais uma constante
        /// </summary>
        /// <returns></returns>
        public virtual string GetNameSpace()
        {
            string esteNamespace = "ViewModel";
            if (!string.IsNullOrWhiteSpace(this.NameSpaceBase))
            {
                return (this.NameSpaceBase + "." + esteNamespace).Replace("..", ".");
            }
            else
            {
                return esteNamespace;
            }
        }

        /// <summary>
        /// compõe o caminho baseado no caminho base  mais uma constante
        /// </summary>
        /// <returns></returns>
        public virtual string GetCaminho()
        {
            string dir = Path.GetDirectoryName((this.CaminhoBase + "\\Model\\").Replace("\\\\", "\\"));
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return (dir + "\\" + this.Tabela.Nome + ".Automatico.cs");
        }


        /// <summary>
        /// gera a casca da classe e encaixa o miolo dentro
        /// </summary>
        /// <returns>String - uma classe completa</returns>
        public virtual string Gerar()
        {
            string conteudo = string.Format(@"using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VtrFramework.Domain;

namespace {0}
{{
{1}
}}", this.GetNameSpace(), this.GerarAutoProperties());

            return conteudo;

        }




        /// <summary>
        /// dado um exportador (já com uma tabela embutida), cria um arquivo e gera seu conteúdo
        /// </summary>
        /// <param name="exp"></param>
        public virtual void Exportar()
        {
            using (StreamWriter sw = new StreamWriter(this.GetCaminho()))
            {
                sw.Write(this.Gerar());
                sw.Close();
            }
        }


        #endregion




        #region métodos privados

        /// <summary>
        /// Gera as strings das properties como o miolo das classes
        /// </summary>
        /// <returns></returns>
        private string GerarAutoProperties()
        {


            StringBuilder sb = new StringBuilder();
            sb.Append("\t// USAR  CTRL+K+D para identar o código \r\n");

            sb.Append(string.Format("\t/// <summary>\r\n"));
            sb.Append(string.Format("\t/// tabela {0}\r\n", this.Tabela.Nome));
            sb.Append(string.Format("\t/// <summary>\r\n"));
            sb.Append(string.Format("\tpublic partial class {0} \r\n", this.Tabela.Nome));            
            sb.Append("\t{\r\n");

            sb.Append(string.Format("\t\t#region propriedades publicas \r\n\r\n"));
            foreach (var c in this.Tabela.Campos.Where(x => x.Nome.ToUpper() != "ID"))
            {
                
                sb.Append(string.Format("\t\t/// <summary>\r\n"));
                sb.Append(string.Format("\t\t/// campo {0} : {1}\r\n", c.Nome, c.Tipo));
                if (!string.IsNullOrWhiteSpace(c.Descricao))
                {
                    sb.Append(string.Format("\t\t/// {0}\r\n", c.Descricao));
                }
                sb.Append(string.Format("\t\t/// </summary>\r\n"));

                if (c is IVtrFieldTypeInfo)
                {
                    if (c.Tipo.ToLower() != "varbinary")
                    {
                        sb.Append(string.Format("\t\tpublic virtual {0} {1} {{get; set;}}\r\n\r\n", (c as IVtrFieldTypeInfo).GetDotNetType(), c.Nome));
                    }
                    else
                    {
                        sb.Append(string.Format("\t\tpublic virtual {0} {1} {{get; set;}} = new byte[0];\r\n\r\n", (c as IVtrFieldTypeInfo).GetDotNetType(), c.Nome));
                    }
                }
                else
                {
                    //todo: e se estiver errado aqui?
                }
            }
            sb.Append(string.Format("\t\t#endregion \r\n\r\n"));
            sb.Append("\t}\r\n");

            return sb.ToString();

        }

        #endregion


    }
}
