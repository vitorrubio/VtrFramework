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
	/// tabela UmaTabelaFilha
	/// <summary>
	public partial class UmaTabelaFilha : VtrEntity
	{
		#region propriedades publicas 

		/// <summary>
		/// campo IdUmaTabelaQualquer : int
		/// </summary>
		public virtual int? IdUmaTabelaQualquer {get; set;}

		/// <summary>
		/// campo Nome : varchar
		/// </summary>
		public virtual string Nome {get; set;}

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