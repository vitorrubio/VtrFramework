using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtrFramework.Infra
{
    /// <summary>
    /// classes que implementarem essa interface podem obter uma connectionstring de maneiras diferentes, do web.config, de um arquivo de resources, de um arquivo txt ou de outro banco de dados
    /// connectionstrings não devem ser passadas para quem as use, mas sim IConnectionStringProvider
    /// </summary>
    public interface IVtrConnectionStringProvider
    {
        string GetConnectionString();
    }
}
