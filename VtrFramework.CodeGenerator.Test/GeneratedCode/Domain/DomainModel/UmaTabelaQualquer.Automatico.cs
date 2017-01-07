using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using VtrFramework.Domain;

namespace VtrTemplate.Domain.DomainModel
{
	// USAR  CTRL+K+D para identar o código 
	/// <summary>
	/// tabela UmaTabelaQualquer
	/// <summary>
	public partial class UmaTabelaQualquer : VtrEntity
	{
		#region propriedades publicas 

		/// <summary>
		/// campo Nome : nvarchar
		/// </summary>
		public virtual string Nome {get; set;}

		/// <summary>
		/// campo Valor : float
		/// </summary>
		public virtual double? Valor {get; set;}

		/// <summary>
		/// campo ValorFloat : float
		/// </summary>
		public virtual double? ValorFloat {get; set;}

		/// <summary>
		/// campo ValorDecimal : decimal
		/// </summary>
		public virtual double? ValorDecimal {get; set;}

		/// <summary>
		/// campo ValorNumerico : numeric
		/// </summary>
		public virtual double? ValorNumerico {get; set;}

		/// <summary>
		/// campo ValorReal : real
		/// </summary>
		public virtual double? ValorReal {get; set;}

		/// <summary>
		/// campo ValorDouble : float
		/// </summary>
		public virtual double? ValorDouble {get; set;}

		/// <summary>
		/// campo ValorInt : int
		/// </summary>
		public virtual int? ValorInt {get; set;}

		/// <summary>
		/// campo ValorTinyInt : tinyint
		/// </summary>
		public virtual int? ValorTinyInt {get; set;}

		/// <summary>
		/// campo ValorBigInt : bigint
		/// </summary>
		public virtual Int64? ValorBigInt {get; set;}

		/// <summary>
		/// campo ValorGuid : uniqueidentifier
		/// </summary>
		public virtual Guid? ValorGuid {get; set;}

		/// <summary>
		/// campo Observacao : nvarchar
		/// </summary>
		public virtual string Observacao {get; set;}

		/// <summary>
		/// campo Arquivo : varbinary
		/// </summary>
		public virtual Byte[] Arquivo {get; set;} = new byte[0];

		/// <summary>
		/// campo DataRevisao : datetime
		/// </summary>
		public virtual DateTime? DataRevisao {get; set;}

		/// <summary>
		/// campo DataEvento : datetime2
		/// </summary>
		public virtual DateTime? DataEvento {get; set;}

		/// <summary>
		/// campo LoginUsuarioUltimaAlteracao : varchar
		/// </summary>
		public virtual string LoginUsuarioUltimaAlteracao {get; set;}

		/// <summary>
		/// campo DataUltimaAlteracao : datetime
		/// </summary>
		public virtual DateTime DataUltimaAlteracao {get; set;}

		#endregion 

	}

}