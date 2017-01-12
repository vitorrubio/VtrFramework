using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VtrFramework.Domain;
using VtrFramework.Infra;

namespace VtrFramework.MetaData
{
    /// <summary>
    /// gera um modelo com uma lista de Tabelas e campos a partir de uma classe
    /// faz um mapeamento entre classes -> tabelas e propriedades -> campos
    /// </summary>
    public class VtrModelToMsSqlExtrator : IVtrModelExtrator
    {
        private string _assembly;

        private string _namespace;

        private string _schemaname;

        private string _databasename;


        public VtrModelToMsSqlExtrator(string assemblyname, string namesp, string schemaname, string databasename)
        {
            this._assembly = assemblyname;
            this._namespace = namesp;
            this._schemaname = schemaname;
            this._databasename = databasename;
        }



        public List<VtrTable> GetTables()
        {
            List<VtrTable> result = new List<VtrTable>();

            var DLL = Assembly.LoadFile(this._assembly);
            var classes = (from t in DLL.GetExportedTypes()
                           where t.IsClass && t.Namespace == this._namespace && t.IsSubclassOf(typeof(VtrEntity))
                           select t).ToList();



            foreach (Type c in classes)
            {
                var props = c.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                VtrTable tb = new VtrTable();
                tb.Nome = c.Name;
                tb.Schema = this._schemaname;
                tb.DatabaseName = this._databasename;

                foreach (var p in props)
                {
                    VtrMsSqlField field = new VtrMsSqlField(tb);
                    field.Nome = p.Name;

                    if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        field.Nulavel = true;

                    if ((field.Nome.ToLower() == "obs") || (field.Nome.ToLower() == "observacao") || (field.Nome.ToLower() == "descricao"))
                    {
                        field.Tamanho = -1; //nvarchar(max)
                        field.Tipo = "nvarchar";
                    }
                    else
                    {
                        string tipo = VtrTypeServices.DotNetTypeToMsSqlType(p.PropertyType);

                        //se o tipo não foi identificado, mas o nome do campo for um tipo de referência da library, precedido ou não de Id ou o tipo for um tipo de referencia da library
                        if(classes.Select(x => "id"+x.Name.ToLower()).ToList().Contains(field.Nome.ToLower())||
                            classes.Select(x => x.Name.ToLower()).ToList().Contains(field.Nome.ToLower())||
                            classes.Select(x => x.Name.ToLower()).ToList().Contains(p.PropertyType.Name.ToLower()))
                        {

                            string tabreferencia = (from cc in classes
                                                    where
                                                         cc.Name.ToLower() == p.PropertyType.Name.ToLower() ||
                                                         cc.Name.ToLower() == field.Nome.ToLower() ||
                                                         field.Nome.ToLower() == "id" + cc.Name.ToLower()
                                                    select cc.Name).ToList<string>().FirstOrDefault();

                                                   

                            VtrForeignKey fk = new VtrForeignKey();
                            fk.NomeTabela = tb.Nome;
                            fk.TabelaReferencia = tabreferencia;
                            fk.NomeConstraint = "fk_" + fk.NomeTabela + "_" + fk.TabelaReferencia;
                            fk.CampoReferencia = "Id";


                            field.InformacaoChaveEstrangeira = fk;
                            field.IsForeignKey = true;
                            field.Tipo = "int";
                            field.Nome = "Id" + fk.TabelaReferencia;
                        }
                        else   if (!string.IsNullOrWhiteSpace(tipo))
                        {
                            field.Tipo = VtrTypeServices.DotNetTypeToMsSqlType(p.PropertyType);
                        }
                        else
                        {
                            field.Tipo= "varchar";
                        }
                    }

                    if((field.Tipo.ToLower() == "numeric") || (field.Tipo.ToLower() == "decimal"))
                    {
                        field.Tamanho = 12;
                        field.Precisao = 2;
                    }

                    if((field.Tipo.ToLower() == "varchar") || (field.Tipo.ToLower() == "nvarchar") || (field.Tipo.ToLower() == "char") || (field.Tipo.ToLower() == "nchar"))
                    {
                        field.Tamanho = 50;
                    }

                    if(field.Tipo.ToLower() == "varbinary")
                    {
                        field.Tamanho = -1;
                    }

                    tb.Campos.Add(field);
                }
                result.Add(tb);
            }

            return result;
        }
    }
}
