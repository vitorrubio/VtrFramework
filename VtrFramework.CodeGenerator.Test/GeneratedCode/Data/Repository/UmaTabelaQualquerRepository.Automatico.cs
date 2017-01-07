using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VtrTemplate.Domain.DomainModel;
using System.Data;
using VtrFramework;
using VtrFramework.Infra;
using VtrFramework.Domain;
using VtrFramework.Data;

namespace VtrTemplate.Data.Repository
{
	//USAR  CTRL+K+D para identar o código 
	public partial class UmaTabelaQualquerRepository:IRepository<UmaTabelaQualquer>
	{
		#region campos privados

		private IVtrSystemDatabase _db = VtrContext.GetDB();



		#endregion

		#region metodos publicos

		public virtual UmaTabelaQualquer GetById(int id)
		{
			UmaTabelaQualquer result = null;
			string sql = "select * from UmaTabelaQualquer (nolock)  where Id = @Id "; 
			var dados = _db.Query(sql, new VtrParameter("@Id", id));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result = DataRowsToEntity(dados).FirstOrDefault();
			}
			return result;
		}


		public virtual List<UmaTabelaQualquer> GetAll()
		{
			List<UmaTabelaQualquer> result = new List<UmaTabelaQualquer>();
			string sql = "select * from UmaTabelaQualquer (nolock)   "; 
			var dados = _db.Query(sql);
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaQualquer> GetByNome(string aNome)
		{
			List<UmaTabelaQualquer> result = new List<UmaTabelaQualquer>();
			string sql = "select * from UmaTabelaQualquer (nolock)  where Nome like '%' + @Nome + '%' "; 
			var dados = _db.Query(sql, new VtrParameter("@Nome", aNome));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaQualquer> GetByObservacao(string aObservacao)
		{
			List<UmaTabelaQualquer> result = new List<UmaTabelaQualquer>();
			string sql = "select * from UmaTabelaQualquer (nolock)  where Observacao like '%' + @Observacao + '%' "; 
			var dados = _db.Query(sql, new VtrParameter("@Observacao", aObservacao));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaQualquer> GetByDataRevisao(DateTime dtIni, DateTime dtFin)
		{
			List<UmaTabelaQualquer> result = new List<UmaTabelaQualquer>();
			string sql = "select * from UmaTabelaQualquer (nolock)  where DataRevisao between @DtIni and @DtFin "; 
			var dados = _db.Query(sql, new VtrParameter("@DtIni", dtIni), new VtrParameter("@DtFin", dtFin));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaQualquer> GetByDataEvento(DateTime dtIni, DateTime dtFin)
		{
			List<UmaTabelaQualquer> result = new List<UmaTabelaQualquer>();
			string sql = "select * from UmaTabelaQualquer (nolock)  where DataEvento between @DtIni and @DtFin "; 
			var dados = _db.Query(sql, new VtrParameter("@DtIni", dtIni), new VtrParameter("@DtFin", dtFin));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaQualquer> GetByDataUltimaAlteracao(DateTime dtIni, DateTime dtFin)
		{
			List<UmaTabelaQualquer> result = new List<UmaTabelaQualquer>();
			string sql = "select * from UmaTabelaQualquer (nolock)  where DataUltimaAlteracao between @DtIni and @DtFin "; 
			var dados = _db.Query(sql, new VtrParameter("@DtIni", dtIni), new VtrParameter("@DtFin", dtFin));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual void Delete(UmaTabelaQualquer registro)
		{
			if(registro == null)
				return;
			registro = this.GetById(registro.Id);
			this.Save(registro);
			VtrContext.Log("Excluiu ", registro);
			_db.Query("delete from UmaTabelaQualquer where Id = @Id", new VtrParameter("@Id", registro.Id));
		}


		public virtual void Save(UmaTabelaQualquer registro)
		{
			if(registro == null)
				throw new Exception("O objeto UmaTabelaQualquer a ser salvo não pode ser nulo.");

			try
			{
				registro.LoginUsuarioUltimaAlteracao = VtrContext.GetCurrentLogin().ToUpper();
				registro.DataUltimaAlteracao = DateTime.Now;
			}
			catch
			{
			}

			string comandoInsert = @"insert into UmaTabelaQualquer (Nome, Valor, ValorFloat, ValorDecimal, ValorNumerico, ValorReal, ValorDouble, ValorInt, ValorTinyInt, ValorBigInt, ValorGuid, Observacao, Arquivo, DataRevisao, DataEvento, LoginUsuarioUltimaAlteracao, DataUltimaAlteracao) values (@Nome, @Valor, @ValorFloat, @ValorDecimal, @ValorNumerico, @ValorReal, @ValorDouble, @ValorInt, @ValorTinyInt, @ValorBigInt, @ValorGuid, @Observacao, @Arquivo, @DataRevisao, @DataEvento, @LoginUsuarioUltimaAlteracao, @DataUltimaAlteracao); select scope_identity()  Id ";
			string comandoUpdate = @"update UmaTabelaQualquer set Nome = @Nome, Valor = @Valor, ValorFloat = @ValorFloat, ValorDecimal = @ValorDecimal, ValorNumerico = @ValorNumerico, ValorReal = @ValorReal, ValorDouble = @ValorDouble, ValorInt = @ValorInt, ValorTinyInt = @ValorTinyInt, ValorBigInt = @ValorBigInt, ValorGuid = @ValorGuid, Observacao = @Observacao, Arquivo = @Arquivo, DataRevisao = @DataRevisao, DataEvento = @DataEvento, LoginUsuarioUltimaAlteracao = @LoginUsuarioUltimaAlteracao, DataUltimaAlteracao = @DataUltimaAlteracao where Id = @Id ";
			List<VtrParameter> VtrParameters = new List<VtrParameter>();
			VtrParameters.Add(new VtrParameter("@Nome", registro.Nome));
			VtrParameters.Add(new VtrParameter("@Valor", registro.Valor));
			VtrParameters.Add(new VtrParameter("@ValorFloat", registro.ValorFloat));
			VtrParameters.Add(new VtrParameter("@ValorDecimal", registro.ValorDecimal));
			VtrParameters.Add(new VtrParameter("@ValorNumerico", registro.ValorNumerico));
			VtrParameters.Add(new VtrParameter("@ValorReal", registro.ValorReal));
			VtrParameters.Add(new VtrParameter("@ValorDouble", registro.ValorDouble));
			VtrParameters.Add(new VtrParameter("@ValorInt", registro.ValorInt));
			VtrParameters.Add(new VtrParameter("@ValorTinyInt", registro.ValorTinyInt));
			VtrParameters.Add(new VtrParameter("@ValorBigInt", registro.ValorBigInt));
			VtrParameters.Add(new VtrParameter("@ValorGuid", registro.ValorGuid));
			VtrParameters.Add(new VtrParameter("@Observacao", registro.Observacao));
			VtrParameters.Add(new VtrParameter("@Arquivo", registro.Arquivo));
			VtrParameters.Add(new VtrParameter("@DataRevisao", registro.DataRevisao));
			VtrParameters.Add(new VtrParameter("@DataEvento", registro.DataEvento));
			VtrParameters.Add(new VtrParameter("@LoginUsuarioUltimaAlteracao", registro.LoginUsuarioUltimaAlteracao));
			VtrParameters.Add(new VtrParameter("@DataUltimaAlteracao", registro.DataUltimaAlteracao));
			if (registro.Id == 0)
			{
				VtrContext.Log("Inseriu ", registro);
				var retorno = _db.Query(comandoInsert, VtrParameters.ToArray());
				registro.Id = Convert.ToInt32(retorno[0]["Id"]);
			}
			else
			{
				VtrContext.Log("Alterou ", registro);
				VtrParameters.Add(new VtrParameter("@Id", registro.Id));
				_db.Query(comandoUpdate, VtrParameters.ToArray());
			}
		}




		#endregion

		#region metodos privados

		private List<UmaTabelaQualquer> DataRowsToEntity(IEnumerable<DataRow> dados)
		{
			var consulta = from d in dados 
			select new UmaTabelaQualquer() 
				{
					Id = VtrConvert.ToInteger(d["Id"]), 
					Nome = d["Nome"].ToString(), 
					Valor = VtrConvert.ToNullableDouble(d["Valor"]), 
					ValorFloat = VtrConvert.ToNullableDouble(d["ValorFloat"]), 
					ValorDecimal = VtrConvert.ToNullableDouble(d["ValorDecimal"]), 
					ValorNumerico = VtrConvert.ToNullableDouble(d["ValorNumerico"]), 
					ValorReal = VtrConvert.ToNullableDouble(d["ValorReal"]), 
					ValorDouble = VtrConvert.ToNullableDouble(d["ValorDouble"]), 
					ValorInt = VtrConvert.ToNullableInteger(d["ValorInt"]), 
					ValorTinyInt = VtrConvert.ToNullableInteger(d["ValorTinyInt"]), 
					ValorBigInt = VtrConvert.ToNullableInt64(d["ValorBigInt"]), 
					ValorGuid = d["ValorGuid"].IsNull()? new Nullable<Guid>(  ) : (Guid) d["ValorGuid"], 
					Observacao = d["Observacao"].ToString(), 
					Arquivo = (Byte[]) d["Arquivo"], 
					DataRevisao = VtrConvert.ToNullableDateTime(d["DataRevisao"]), 
					DataEvento = VtrConvert.ToNullableDateTime(d["DataEvento"]), 
					LoginUsuarioUltimaAlteracao = d["LoginUsuarioUltimaAlteracao"].ToString(), 
					DataUltimaAlteracao = VtrConvert.ToDateTime(d["DataUltimaAlteracao"]) 
				};
			return consulta.ToList();
		}


		#endregion

	}

}