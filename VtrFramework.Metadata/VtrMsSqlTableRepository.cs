using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using VtrFramework.Infra;

namespace VtrFramework.MetaData
{
    /// <summary>
    /// obtém do banco de dados do aplicativo listas de tabelas e campos
    /// </summary>
    public class VtrMsSqlTableRepository
    {




        public virtual List<VtrTable> GetAll(IVtrConnectionStringProvider prov, bool isAuditLogTable = false)
        {
            List<VtrTable> resultado = new List<VtrTable>();
            VtrSystemDatabase db = new VtrSystemDatabase(prov);
            string comando = string.Format(@"

                SELECT 
	                db_name() databaseName,
	                s.name schemaName,
	                t.name tableName
                FROM 
	                sys.Tables t 
	                INNER JOIN sys.schemas s ON s.schema_id = t.schema_id
                where
                    t.name <> 'sysdiagrams'
                    and {0} t.name like '{1}%' ", isAuditLogTable ? "" : " not ", VtrTable.LOG_TABLE_PREFIX);
            var dados = db.Query( comando ); 


            foreach (DataRow d in dados)
            {
                VtrTable tmp = new VtrTable();
                tmp.DatabaseName = d["databaseName"].ToString();
                tmp.Schema = d["schemaName"].ToString();
                tmp.Nome = d["tableName"].ToString();
                tmp.Campos.AddRange(this.GetByTable(prov, tmp.Nome));
                resultado.Add(tmp);
            }

            return resultado;
        }

        public virtual List<VtrField> GetByTable(IVtrConnectionStringProvider prov, string tableName)
        {
            List<VtrField> resultado = new List<VtrField>();
            VtrSystemDatabase db = new VtrSystemDatabase(prov);
            var dados = db.Query(@"
SELECT 
    db_name() databaseName,
	sys.schemas.name schemaName,
	sys.tables.name tableName,
	sys.columns.name COLUMN_NAME,
	sys.types.name DATA_TYPE,
	sys.columns.is_nullable IS_NULLABLE,
	sys.columns.max_length MAX_LENGTH,
	sys.columns.precision,
	sys.columns.scale,
	sys.extended_properties.value DESCRICAO,
	KCU1.CONSTRAINT_NAME AS 'NomeConstraint',
	KCU1.TABLE_NAME AS 'NomeTabela',
	KCU2.TABLE_NAME AS 'TabelaReferencia',
	KCU2.COLUMN_NAME AS 'CampoReferencia'
FROM 
	sys.schemas
	INNER JOIN sys.tables ON sys.schemas.schema_id = sys.tables.schema_id
	INNER JOIN sys.columns 	ON sys.tables.object_id = sys.columns.object_id
	inner join sys.types on sys.types.system_type_id = sys.columns.system_type_id and sys.types.user_type_id = sys.columns.user_type_id
	left JOIN sys.extended_properties 	ON sys.tables.object_id = sys.extended_properties.major_id
		AND sys.columns.column_id = sys.extended_properties.minor_id
		AND sys.extended_properties.name = 'MS_Description'
	left join 
	(	
		INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS RC
		inner JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU1 ON 
			KCU1.CONSTRAINT_CATALOG = RC.CONSTRAINT_CATALOG 
			AND KCU1.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA
			AND KCU1.CONSTRAINT_NAME = RC.CONSTRAINT_NAME

		inner JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KCU2 ON 
			KCU2.CONSTRAINT_CATALOG = RC.UNIQUE_CONSTRAINT_CATALOG 
			AND KCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA
			AND KCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME
			AND KCU2.ORDINAL_POSITION = KCU1.ORDINAL_POSITION
	) on kcu1.COLUMN_NAME = sys.columns.name and KCU1.TABLE_NAME = sys.tables.name
			

where
    sys.tables.name <> 'sysdiagrams' and
	sys.tables.name =  @tableName", new VtrParameter("@tableName", tableName));
            foreach (DataRow d in dados)
            {
                VtrField tmp = new VtrField();
                tmp.Nome = d["COLUMN_NAME"].ToString();
                tmp.Tipo = d["DATA_TYPE"].ToString();
                tmp.Nulavel = Convert.ToBoolean( d["IS_NULLABLE"] ?? false);
                tmp.Tamanho = VtrConvert.ToInteger( d["MAX_LENGTH"]);
                tmp.Precisao = VtrConvert.ToInteger(d["precision"]);
                tmp.Escala = VtrConvert.ToInteger(d["scale"]);
                tmp.Descricao = d["DESCRICAO"].ToString();

                if (!d["NomeConstraint"].IsNull())
                {
                    tmp.IsForeignKey = true;
                    tmp.InformacaoChaveEstrangeira = new VtrForeignKey
                    {
                        NomeConstraint = d["NomeConstraint"].ToString(),
                        NomeTabela = d["NomeTabela"].ToString(),
                        TabelaReferencia = d["TabelaReferencia"].ToString(),
                        CampoReferencia = d["CampoReferencia"].ToString()
                    };
                }
                else
                {
                    tmp.IsForeignKey = false;
                    tmp.InformacaoChaveEstrangeira = null;
                }

                resultado.Add(tmp);
            }

            return resultado;
        }


    }
}
