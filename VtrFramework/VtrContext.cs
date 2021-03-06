﻿using System;
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


        /// <summary>
        /// esse método que vai trazer o IVtrSystemDatabase correto dependendo das configurações do web.config
        /// </summary>
        /// <returns></returns>
        public static IVtrSystemDatabase GetDB()
        {
            return new VtrSystemDatabase(new VtrAppConfigConnectionStringProvider());
        }

        /// <summary>
        /// esse método traz um IVtrSystemDatabase conectado à connectionString do IVtrConnectionStringProvider que eu passar para ele
        /// É ideal para se conectar a um outro banco de dados onde a connectionString será imputada pelo usuário ou virá de um outro banco
        /// </summary>
        /// <param name="prov"></param>
        /// <returns></returns>
        public static IVtrSystemDatabase GetDB(IVtrConnectionStringProvider prov)
        {
            return new VtrSystemDatabase(prov);
        }

        public static void Log(string verb, object obj)
        {

        }


        public static string GetCurrentLogin()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        }

        #endregion

    }
}
