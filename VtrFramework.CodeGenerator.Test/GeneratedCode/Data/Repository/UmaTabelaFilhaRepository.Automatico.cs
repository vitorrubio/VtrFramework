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
	public partial class UmaTabelaFilhaRepository:IRepository<UmaTabelaFilha>
	{
		#region campos privados

		private IVtrSystemDatabase _db = VtrContext.GetDB();



		#endregion

		#region metodos publicos

		public virtual UmaTabelaFilha GetById(int id)
		{
			UmaTabelaFilha result = null;
			string sql = "select * from UmaTabelaFilha (nolock)  where Id = @Id "; 
			var dados = _db.Query(sql, new VtrParameter("@Id", id));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result = DataRowsToEntity(dados).FirstOrDefault();
			}
			return result;
		}


		public virtual List<UmaTabelaFilha> GetAll()
		{
			List<UmaTabelaFilha> result = new List<UmaTabelaFilha>();
			string sql = "select * from UmaTabelaFilha (nolock)   "; 
			var dados = _db.Query(sql);
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaFilha> GetByIdUmaTabelaQualquer(int aIdUmaTabelaQualquer)
		{
			List<UmaTabelaFilha> result = new List<UmaTabelaFilha>();
			string sql = "select * from UmaTabelaFilha (nolock)  where IdUmaTabelaQualquer =  @IdUmaTabelaQualquer "; 
			var dados = _db.Query(sql, new VtrParameter("@IdUmaTabelaQualquer", aIdUmaTabelaQualquer));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaFilha> GetByNome(string aNome)
		{
			List<UmaTabelaFilha> result = new List<UmaTabelaFilha>();
			string sql = "select * from UmaTabelaFilha (nolock)  where Nome like '%' + @Nome + '%' "; 
			var dados = _db.Query(sql, new VtrParameter("@Nome", aNome));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual List<UmaTabelaFilha> GetByDataUltimaAlteracao(DateTime dtIni, DateTime dtFin)
		{
			List<UmaTabelaFilha> result = new List<UmaTabelaFilha>();
			string sql = "select * from UmaTabelaFilha (nolock)  where DataUltimaAlteracao between @DtIni and @DtFin "; 
			var dados = _db.Query(sql, new VtrParameter("@DtIni", dtIni), new VtrParameter("@DtFin", dtFin));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( DataRowsToEntity(dados));
			}
			return result;
		}


		public virtual void Delete(UmaTabelaFilha registro)
		{
			if(registro == null)
				return;
			registro = this.GetById(registro.Id);
			this.Save(registro);
			VtrContext.Log("Excluiu ", registro);
			_db.Query("delete from UmaTabelaFilha where Id = @Id", new VtrParameter("@Id", registro.Id));
		}


		public virtual void Save(UmaTabelaFilha registro)
		{
			if(registro == null)
				throw new Exception("O objeto UmaTabelaFilha a ser salvo não pode ser nulo.");

			try
			{
				registro.LoginUsuarioUltimaAlteracao = VtrContext.GetCurrentLogin().ToUpper();
				registro.DataUltimaAlteracao = DateTime.Now;
			}
			catch
			{
			}

			string comandoInsert = @"insert into UmaTabelaFilha (IdUmaTabelaQualquer, Nome, LoginUsuarioUltimaAlteracao, DataUltimaAlteracao) values (@IdUmaTabelaQualquer, @Nome, @LoginUsuarioUltimaAlteracao, @DataUltimaAlteracao); select scope_identity()  Id ";
			string comandoUpdate = @"update UmaTabelaFilha set IdUmaTabelaQualquer = @IdUmaTabelaQualquer, Nome = @Nome, LoginUsuarioUltimaAlteracao = @LoginUsuarioUltimaAlteracao, DataUltimaAlteracao = @DataUltimaAlteracao where Id = @Id ";
			List<VtrParameter> VtrParameters = new List<VtrParameter>();
			VtrParameters.Add(new VtrParameter("@IdUmaTabelaQualquer", registro.IdUmaTabelaQualquer));
			VtrParameters.Add(new VtrParameter("@Nome", registro.Nome));
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

		private List<UmaTabelaFilha> DataRowsToEntity(IEnumerable<DataRow> dados)
		{
			var consulta = from d in dados 
			select new UmaTabelaFilha() 
				{
					Id = VtrConvert.ToInteger(d["Id"]), 
					IdUmaTabelaQualquer = VtrConvert.ToNullableInteger(d["IdUmaTabelaQualquer"]), 
					Nome = d["Nome"].ToString(), 
					LoginUsuarioUltimaAlteracao = d["LoginUsuarioUltimaAlteracao"].ToString(), 
					DataUltimaAlteracao = VtrConvert.ToDateTime(d["DataUltimaAlteracao"]) 
				};
			return consulta.ToList();
		}


		#endregion

	}

}