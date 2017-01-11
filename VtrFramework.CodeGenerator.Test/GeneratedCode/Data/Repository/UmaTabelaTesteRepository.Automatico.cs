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
	public partial class UmaTabelaTesteRepository:IVtrRepository<UmaTabelaTeste>
	{
		#region campos privados

		private IVtrSystemDatabase _db = VtrContext.GetDB();



		#endregion

		#region metodos publicos

		public virtual UmaTabelaTeste GetById(int id)
		{
			UmaTabelaTeste result = null;
			string sql = "select * from UmaTabelaTeste (nolock)  where Id = @Id "; 
			var dados = _db.Query<UmaTabelaTeste>(sql, new VtrParameter("@Id", id));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result = dados.FirstOrDefault();
			}
			return result;
		}


		public virtual List<UmaTabelaTeste> GetAll()
		{
			List<UmaTabelaTeste> result = new List<UmaTabelaTeste>();
			string sql = "select * from UmaTabelaTeste (nolock)   "; 
			var dados = _db.Query<UmaTabelaTeste>(sql);
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( dados);
			}
			return result;
		}


		public virtual List<UmaTabelaTeste> GetByNome(string aNome)
		{
			List<UmaTabelaTeste> result = new List<UmaTabelaTeste>();
			string sql = "select * from UmaTabelaTeste (nolock)  where Nome like '%' + @Nome + '%' "; 
			var dados = _db.Query<UmaTabelaTeste>(sql, new VtrParameter("@Nome", aNome));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( dados);
			}
			return result;
		}


		public virtual List<UmaTabelaTeste> GetByObservacao(string aObservacao)
		{
			List<UmaTabelaTeste> result = new List<UmaTabelaTeste>();
			string sql = "select * from UmaTabelaTeste (nolock)  where Observacao like '%' + @Observacao + '%' "; 
			var dados = _db.Query<UmaTabelaTeste>(sql, new VtrParameter("@Observacao", aObservacao));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( dados);
			}
			return result;
		}


		public virtual List<UmaTabelaTeste> GetByDataRevisao(DateTime dtIni, DateTime dtFin)
		{
			List<UmaTabelaTeste> result = new List<UmaTabelaTeste>();
			string sql = "select * from UmaTabelaTeste (nolock)  where DataRevisao between @DtIni and @DtFin "; 
			var dados = _db.Query<UmaTabelaTeste>(sql, new VtrParameter("@DtIni", dtIni), new VtrParameter("@DtFin", dtFin));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( dados);
			}
			return result;
		}


		public virtual List<UmaTabelaTeste> GetByDataEvento(DateTime dtIni, DateTime dtFin)
		{
			List<UmaTabelaTeste> result = new List<UmaTabelaTeste>();
			string sql = "select * from UmaTabelaTeste (nolock)  where DataEvento between @DtIni and @DtFin "; 
			var dados = _db.Query<UmaTabelaTeste>(sql, new VtrParameter("@DtIni", dtIni), new VtrParameter("@DtFin", dtFin));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( dados);
			}
			return result;
		}


		public virtual List<UmaTabelaTeste> GetByDataUltimaAlteracao(DateTime dtIni, DateTime dtFin)
		{
			List<UmaTabelaTeste> result = new List<UmaTabelaTeste>();
			string sql = "select * from UmaTabelaTeste (nolock)  where DataUltimaAlteracao between @DtIni and @DtFin "; 
			var dados = _db.Query<UmaTabelaTeste>(sql, new VtrParameter("@DtIni", dtIni), new VtrParameter("@DtFin", dtFin));
			if((dados!=null)&&(dados.Count() > 0))
			{
				result.AddRange( dados);
			}
			return result;
		}


		public virtual void Delete(UmaTabelaTeste registro)
		{
			if(registro == null)
				return;
			registro = this.GetById(registro.Id);
			//salvamos antes de deletar para ter o log de auditoria (gerado por triggers) de quem excluiu
			this.Save(registro);
			VtrContext.Log("Excluiu ", registro);
			_db.Query("delete from UmaTabelaTeste where Id = @Id", new VtrParameter("@Id", registro.Id));
		}


		public virtual void Save(UmaTabelaTeste registro)
		{
			if(registro == null)
				throw new Exception("O objeto UmaTabelaTeste a ser salvo não pode ser nulo.");

			try
			{
				registro.LoginUsuarioUltimaAlteracao = VtrContext.GetCurrentLogin().ToUpper();
				registro.DataUltimaAlteracao = DateTime.Now;
			}
			catch
			{
			}

			string comandoInsert = @"insert into UmaTabelaTeste (Nome, Valor, ValorFloat, ValorDecimal, ValorNumerico, ValorReal, ValorDouble, ValorInt, ValorTinyInt, ValorBigInt, ValorGuid, Observacao, Arquivo, DataRevisao, DataEvento, LoginUsuarioUltimaAlteracao, DataUltimaAlteracao) values (@Nome, @Valor, @ValorFloat, @ValorDecimal, @ValorNumerico, @ValorReal, @ValorDouble, @ValorInt, @ValorTinyInt, @ValorBigInt, @ValorGuid, @Observacao, @Arquivo, @DataRevisao, @DataEvento, @LoginUsuarioUltimaAlteracao, @DataUltimaAlteracao); select scope_identity()  Id ";
			string comandoUpdate = @"update UmaTabelaTeste set Nome = @Nome, Valor = @Valor, ValorFloat = @ValorFloat, ValorDecimal = @ValorDecimal, ValorNumerico = @ValorNumerico, ValorReal = @ValorReal, ValorDouble = @ValorDouble, ValorInt = @ValorInt, ValorTinyInt = @ValorTinyInt, ValorBigInt = @ValorBigInt, ValorGuid = @ValorGuid, Observacao = @Observacao, Arquivo = @Arquivo, DataRevisao = @DataRevisao, DataEvento = @DataEvento, LoginUsuarioUltimaAlteracao = @LoginUsuarioUltimaAlteracao, DataUltimaAlteracao = @DataUltimaAlteracao where Id = @Id ";
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



		#endregion

	}

}