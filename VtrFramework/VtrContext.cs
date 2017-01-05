using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using VtrFramework.Infra;

namespace VtrFramework
{
    /// <summary>
    /// 
    /// xxx
    /// classe estática com um ponto de acesso para configurações e variáveis de contexto
    /// </summary>
    public static class VtrContext
    {

        #region métodos estáticos públicos


        /// <summary>
        /// verifica se uma aplicação está rodando em ambiente de teste ou está rodando com uma suite de testes unitários atachada
        /// </summary>
        /// <returns></returns>
        public static bool IsInTest()
        {
            return (VtrUnitTestDetector.IsInTest());
        }

        /// <summary>
        /// usa WinNT  para obter informações de uma conta de usuário
        /// </summary>
        /// <param name="dominio">string - dominio do usuario</param>
        /// <param name="login">string - login do usuario</param>
        /// <returns>string - o nome do usuário</returns>
        public static string GetCompleteUserName(string dominio, string login)
        {

            string resultado = "";

            try
            {
                DirectoryEntry entry = new DirectoryEntry("WinNT://" + dominio + "/" + login);

                if (null != entry)
                {
                    resultado = entry.Properties["fullname"].Value.ToString().ToUpper().Trim();
                }

            }
            catch
            {
            }

            return resultado;

        }



        #endregion

    }
}
