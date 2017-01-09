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
    public class VtrRepositoryGenerator : IVtrGenerator
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
        public VtrRepositoryGenerator(VtrTable table, string baseNamespace, string basePath)
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
            string esteNamespace = "Data.Repository";
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
            string dir = Path.GetDirectoryName((this.CaminhoBase + "\\Data\\Repository\\").Replace("\\\\", "\\"));
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return (dir + "\\" + this.Tabela.Nome + "Repository.Automatico.cs");
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
using System.Web;
using {0};
using System.Data;
using VtrFramework;
using VtrFramework.Infra;
using VtrFramework.Domain;
using VtrFramework.Data;

namespace {1}
{{
{2}
}}", this.GetDomainNameSpace(), this.GetNameSpace(), this.GerarRepositorio());

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




        #region métodos protegidos

        /// <summary>
        /// obtém o namespace de domínio para inclusão no source do repositório
        /// </summary>
        /// <returns></returns>
        protected virtual string GetDomainNameSpace()
        {
            string esteNamespace = "Domain.DomainModel";
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
        /// gera a string  para este repositório
        /// </summary>
        /// <returns></returns>
        protected virtual string GetSelectSql()
        {
            return string.Format("select * from {0} (nolock) ", this.Tabela.Nome);
        }

        /// <summary>
        /// gera a string de insert para este repositório
        /// </summary>
        /// <returns></returns>
        protected virtual string GetInsertSql()
        {
            StringBuilder comando = new StringBuilder();
            StringBuilder listaCampos = new StringBuilder();
            StringBuilder listaVtrParameters = new StringBuilder();

            var campos = this.Tabela.Campos.Where(x => x.Nome.ToUpper() != "ID");

            foreach (var c in campos)
            {
                bool isLast = (c.Equals(campos.Last()));
                listaCampos.Append(c.Nome + (isLast ? "" : ", "));
                listaVtrParameters.Append("@" + c.Nome + (isLast ? "" : ", "));
            }

            comando.Append(string.Format("insert into {0} ({1}) values ({2}); select scope_identity()  Id ", this.Tabela.Nome, listaCampos.ToString(), listaVtrParameters.ToString()));

            return comando.ToString();
        }

        /// <summary>
        /// gera a string de update padrão
        /// </summary>
        /// <returns></returns>
        protected virtual string GetUpdateSql()
        {
            StringBuilder comando = new StringBuilder();
            StringBuilder listaCampos = new StringBuilder();

            var campos = this.Tabela.Campos.Where(x => x.Nome.ToUpper() != "ID");

            foreach (var c in campos)
            {
                bool isLast = (c.Equals(campos.Last()));
                listaCampos.Append(c.Nome + " = " + "@" + c.Nome + (isLast ? "" : ", "));
            }

            comando.Append(string.Format("update {0} set {1} where Id = @Id ", this.Tabela.Nome, listaCampos.ToString()));

            return comando.ToString();
        }


        protected virtual string GetDeleteSql()
        {
            return string.Format("delete from {0} where Id = @Id", this.Tabela.Nome);
        }

        #endregion



        #region métodos privados

        /// <summary>
        /// Gera as strings das properties como o miolo das classes padrão CODE
        /// </summary>
        /// <returns></returns>
        public virtual string GerarRepositorio()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("\t//USAR  CTRL+K+D para identar o código \r\n");
            sb.Append(string.Format("\tpublic partial class {0}Repository:IRepository<{0}>\r\n", this.Tabela.Nome));
            sb.Append("\t{\r\n");

            BuldPrivateFields(sb);
            BuildPublicMethods(sb);
            BuildPrivateMethods(sb);

            sb.Append("\t}\r\n");

            return sb.ToString();
        }


        private void BuldPrivateFields(StringBuilder sb)
        {
            sb.Append("\t\t#region campos privados\r\n\r\n");

            sb.Append("\t\tprivate IVtrSystemDatabase _db = VtrContext.GetDB();\r\n\r\n");

            sb.Append("\r\n\r\n");
            sb.Append("\t\t#endregion\r\n\r\n");
        }


        private void BuildPublicMethods(StringBuilder sb)
        {
            sb.Append("\t\t#region metodos publicos\r\n\r\n");

            BuildGetById(sb);
            BuildGetAll(sb);
            BuildGetByPropertiesSpecialMethods(sb);
            BuildDelete(sb);
            BuildSave(sb);

            sb.Append("\r\n\r\n");
            sb.Append("\t\t#endregion\r\n\r\n");
        }



        private void BuildPrivateMethods(StringBuilder sb)
        {
            sb.Append("\t\t#region metodos privados\r\n\r\n");

            BuildDataRowsToEntity(sb);

            sb.Append("\r\n\r\n");
            sb.Append("\t\t#endregion\r\n\r\n");
        }



        private void BuildDataRowsToEntity(StringBuilder sb)
        {

            #region DataRowsToEntity
            sb.Append(string.Format("\t\tprivate List<{0}> DataRowsToEntity(IEnumerable<DataRow> dados)\r\n", this.Tabela.Nome));
            sb.Append("\t\t{\r\n");
            sb.Append("\t\t\tvar consulta = from d in dados \r\n");

            sb.Append(string.Format("\t\t\tselect new {0}() \r\n", this.Tabela.Nome));
            sb.Append("\t\t\t\t{\r\n");

            int i = 0;
            foreach (var f in this.Tabela.Campos)
            {
                var c = (f as IVtrFieldTypeInfo);
                i++;
                string virgula = (i == this.Tabela.Campos.Count) ? "" : ",";
                if (c.GetDotNetType() == "int")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToInteger(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "int?")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToNullableInteger(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }

                else if (c.GetDotNetType() == "Int64")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToInt64(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "Int64?")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToNullableInt64(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }

                else if (c.GetDotNetType() == "DateTime")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToDateTime(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "DateTime?")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToNullableDateTime(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "double")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToDouble(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "double?")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToNullableDouble(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }

                else if (c.GetDotNetType() == "decimal")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToDouble(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "decimal?")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = VtrConvert.ToNullableDouble(d[\"{0}\"]){1} \r\n", f.Nome, virgula));
                }

                else if (c.GetDotNetType() == "bool")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = (VtrConvert.ToBool(d[\"{0}\"])){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "bool?")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = ((VtrConvert.ToNullableBool(d[\"{0}\"]) == null) ? new Nullable<bool>(  ): (VtrConvert.ToNullableBool(d[\"{0}\"]))){1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "Guid")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = (Guid) d[\"{0}\"]{1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "Guid?")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = d[\"{0}\"].IsNull()? new Nullable<Guid>(  ) : (Guid) d[\"{0}\"]{1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "Byte[]")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = (Byte[]) d[\"{0}\"]{1} \r\n", f.Nome, virgula));
                }
                else if (c.GetDotNetType() == "string")
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = d[\"{0}\"].ToString(){1} \r\n", f.Nome, virgula));
                }
                else
                {
                    sb.Append(string.Format("\t\t\t\t\t{0} = d[\"{0}\"].ToString(){1} \r\n", f.Nome, virgula));
                }

            }

            sb.Append("\t\t\t\t};\r\n");

            sb.Append("\t\t\treturn consulta.ToList();\r\n");

            sb.Append("\t\t}\r\n");
            #endregion

        }



        private void BuildGetById(StringBuilder sb)
        {
            sb.Append(string.Format("\t\tpublic virtual {0} GetById(int id)\r\n", this.Tabela.Nome));
            sb.Append("\t\t{\r\n");
            sb.Append(string.Format("\t\t\t{0} result = null;\r\n", this.Tabela.Nome));
            sb.Append(string.Format("\t\t\tstring sql = \"{0} where Id = @Id \"; \r\n", this.GetSelectSql()));
            sb.Append("\t\t\tvar dados = _db.Query(sql, new VtrParameter(\"@Id\", id));\r\n");
            sb.Append("\t\t\tif((dados!=null)&&(dados.Count() > 0))\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tresult = DataRowsToEntity(dados).FirstOrDefault();\r\n");
            sb.Append("\t\t\t}\r\n");

            sb.Append("\t\t\treturn result;\r\n");
            sb.Append("\t\t}\r\n\r\n\r\n");
        }



        private void BuildGetAll(StringBuilder sb)
        {
            sb.Append(string.Format("\t\tpublic virtual List<{0}> GetAll()\r\n", this.Tabela.Nome));
            sb.Append("\t\t{\r\n");
            sb.Append(string.Format("\t\t\tList<{0}> result = new List<{0}>();\r\n", this.Tabela.Nome));
            sb.Append(string.Format("\t\t\tstring sql = \"{0}  \"; \r\n", this.GetSelectSql()));
            sb.Append("\t\t\tvar dados = _db.Query(sql);\r\n");
            sb.Append("\t\t\tif((dados!=null)&&(dados.Count() > 0))\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tresult.AddRange( DataRowsToEntity(dados));\r\n");
            sb.Append("\t\t\t}\r\n");

            sb.Append("\t\t\treturn result;\r\n");
            sb.Append("\t\t}\r\n\r\n\r\n");
        }

        private void BuildGetByPropertiesSpecialMethods(StringBuilder sb)
        {

            foreach (var c in this.Tabela.Campos)
            {
                if (
                    (c.Nome.ToLower() == "nome") ||
                    (c.Nome.ToLower() == "descricao") ||
                    (c.Nome.ToLower() == "observacao") ||
                    (c.Nome.ToLower() == "obs")
                   )
                {
                    BuildGetByPropertyLike(sb, c.Nome);
                }
                else if ((c.Tipo.ToLower() == "datetime") || (c.Tipo.ToLower() == "datetime2") || (c.Tipo.ToLower() == "date"))
                {
                    BuildGetBetweenDates(sb, c.Nome);
                }
                else if (c.IsForeignKey)
                {
                    BuildGetByForeignKey(sb, c.Nome);
                }
            }
        }


        private void BuildGetByForeignKey(StringBuilder sb, string PropertyName)
        {
            sb.Append(string.Format("\t\tpublic virtual List<{0}> GetBy{1}(int a{1})\r\n", this.Tabela.Nome, PropertyName));
            sb.Append("\t\t{\r\n");
            sb.Append(string.Format("\t\t\tList<{0}> result = new List<{0}>();\r\n", this.Tabela.Nome));
            sb.Append(string.Format("\t\t\tstring sql = \"{0} where {1} =  @{1} \"; \r\n", this.GetSelectSql(), PropertyName));
            sb.Append(string.Format("\t\t\tvar dados = _db.Query(sql, new VtrParameter(\"@{0}\", a{0}));\r\n", PropertyName));
            sb.Append("\t\t\tif((dados!=null)&&(dados.Count() > 0))\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tresult.AddRange( DataRowsToEntity(dados));\r\n");
            sb.Append("\t\t\t}\r\n");

            sb.Append("\t\t\treturn result;\r\n");
            sb.Append("\t\t}\r\n\r\n\r\n");
        }

        private void BuildGetByPropertyLike(StringBuilder sb, string PropertyName)
        {
            sb.Append(string.Format("\t\tpublic virtual List<{0}> GetBy{1}(string a{1})\r\n", this.Tabela.Nome, PropertyName));
            sb.Append("\t\t{\r\n");
            sb.Append(string.Format("\t\t\tList<{0}> result = new List<{0}>();\r\n", this.Tabela.Nome));
            sb.Append(string.Format("\t\t\tstring sql = \"{0} where {1} like '%' + @{1} + '%' \"; \r\n", this.GetSelectSql(), PropertyName));
            sb.Append(string.Format("\t\t\tvar dados = _db.Query(sql, new VtrParameter(\"@{0}\", a{0}));\r\n", PropertyName));
            sb.Append("\t\t\tif((dados!=null)&&(dados.Count() > 0))\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tresult.AddRange( DataRowsToEntity(dados));\r\n");
            sb.Append("\t\t\t}\r\n");

            sb.Append("\t\t\treturn result;\r\n");
            sb.Append("\t\t}\r\n\r\n\r\n");
        }


        private void BuildGetBetweenDates(StringBuilder sb, string PropertyName)
        {
            sb.Append(string.Format("\t\tpublic virtual List<{0}> GetBy{1}(DateTime dtIni, DateTime dtFin)\r\n", this.Tabela.Nome, PropertyName));
            sb.Append("\t\t{\r\n");
            sb.Append(string.Format("\t\t\tList<{0}> result = new List<{0}>();\r\n", this.Tabela.Nome));
            sb.Append(string.Format("\t\t\tstring sql = \"{0} where {1} between @DtIni and @DtFin \"; \r\n", this.GetSelectSql(), PropertyName));
            sb.Append(string.Format("\t\t\tvar dados = _db.Query(sql, new VtrParameter(\"@DtIni\", dtIni), new VtrParameter(\"@DtFin\", dtFin));\r\n"));
            sb.Append("\t\t\tif((dados!=null)&&(dados.Count() > 0))\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tresult.AddRange( DataRowsToEntity(dados));\r\n");
            sb.Append("\t\t\t}\r\n");

            sb.Append("\t\t\treturn result;\r\n");
            sb.Append("\t\t}\r\n\r\n\r\n");
        }


        private void BuildDelete(StringBuilder sb)
        {
            sb.Append(string.Format("\t\tpublic virtual void Delete({0} registro)\r\n", this.Tabela.Nome));
            sb.Append("\t\t{\r\n");
            sb.Append("\t\t\tif(registro == null)\r\n\t\t\t\treturn;\r\n");

            sb.Append(string.Format("\t\t\tregistro = this.GetById(registro.Id);\r\n"));
            //salvamos antes de deletar para ter o log de auditoria (gerado por triggers) de quem excluiu
            sb.Append(string.Format("\t\t\t//salvamos antes de deletar para ter o log de auditoria (gerado por triggers) de quem excluiu\r\n"));
            sb.Append(string.Format("\t\t\tthis.Save(registro);\r\n"));
            sb.Append(string.Format("\t\t\tVtrContext.Log(\"Excluiu \", registro);\r\n"));
            sb.Append(string.Format("\t\t\t_db.Query(\"{0}\", new VtrParameter(\"@Id\", registro.Id));\r\n", this.GetDeleteSql()));

            sb.Append("\t\t}\r\n\r\n\r\n");
        }


        private void BuildSave(StringBuilder sb)
        {
            sb.Append(string.Format("\t\tpublic virtual void Save({0} registro)\r\n", this.Tabela.Nome));
            sb.Append("\t\t{\r\n");
            sb.Append(string.Format("\t\t\tif(registro == null)\r\n\t\t\t\tthrow new Exception(\"O objeto {0} a ser salvo não pode ser nulo.\");\r\n\r\n", this.Tabela.Nome));

            sb.Append("\t\t\ttry\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tregistro.LoginUsuarioUltimaAlteracao = VtrContext.GetCurrentLogin().ToUpper();\r\n");
            sb.Append("\t\t\t\tregistro.DataUltimaAlteracao = DateTime.Now;\r\n");
            sb.Append("\t\t\t}\r\n");
            sb.Append("\t\t\tcatch\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t}\r\n\r\n");


            sb.Append(string.Format("\t\t\tstring comandoInsert = @\"{0}\";\r\n", this.GetInsertSql()));
            sb.Append(string.Format("\t\t\tstring comandoUpdate = @\"{0}\";\r\n", this.GetUpdateSql()));

            sb.Append("\t\t\tList<VtrParameter> VtrParameters = new List<VtrParameter>();\r\n");

            foreach (VtrField c in this.Tabela.Campos.Where(x => x.Nome.ToUpper() != "ID"))
            {
                sb.Append(string.Format("\t\t\tVtrParameters.Add(new VtrParameter(\"@{0}\", registro.{0}));\r\n", c.Nome));
            }

            sb.Append("\t\t\tif (registro.Id == 0)\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tVtrContext.Log(\"Inseriu \", registro);\r\n");
            sb.Append("\t\t\t\tvar retorno = _db.Query(comandoInsert, VtrParameters.ToArray());\r\n");
            sb.Append("\t\t\t\tregistro.Id = Convert.ToInt32(retorno[0][\"Id\"]);\r\n");
            sb.Append("\t\t\t}\r\n");
            sb.Append("\t\t\telse\r\n");
            sb.Append("\t\t\t{\r\n");
            sb.Append("\t\t\t\tVtrContext.Log(\"Alterou \", registro);\r\n");
            sb.Append("\t\t\t\tVtrParameters.Add(new VtrParameter(\"@Id\", registro.Id));\r\n");
            sb.Append("\t\t\t\t_db.Query(comandoUpdate, VtrParameters.ToArray());\r\n");
            sb.Append("\t\t\t}\r\n");

            sb.Append("\t\t}\r\n\r\n\r\n");
        }




        #endregion


    }
}
