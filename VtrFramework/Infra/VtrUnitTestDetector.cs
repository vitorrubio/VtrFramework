using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VtrFramework.Infra
{
    /// <summary>
    /// testa se estamos executando o código em unit test ou não
    /// </summary>
    public static class VtrUnitTestDetector
    {



        #region privados estáticos

        /// <summary>
        /// faz o cache da resposta em lazy load
        /// </summary>
        private static bool? _isInTest = null;

        #endregion


        #region public static methods

        /// <summary>
        /// retorna true se for identificada a ausencia de httpcontext e um framework de testes
        /// </summary>
        /// <returns></returns>
        public static bool IsInTest()
        {
            //se tem http context nunca é considerado em teste
            if (System.Web.HttpContext.Current != null)
            {
                return false;
            }

            //lazy load do is in test para evitar usar reflection
            if (_isInTest == null)
            {
                string msUnit = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
                string nUnit = "nunit.framework";

                bool existsMsUnit = AppDomain.CurrentDomain.GetAssemblies()
                    .Any(a => a.FullName.StartsWith(msUnit, StringComparison.InvariantCultureIgnoreCase));

                bool existsNUnit = AppDomain.CurrentDomain.GetAssemblies()
                    .Any(a => a.FullName.StartsWith(nUnit, StringComparison.InvariantCultureIgnoreCase));

                VtrUnitTestDetector._isInTest = ((existsMsUnit || existsNUnit) && (System.Web.HttpContext.Current == null) );
            }

            return VtrUnitTestDetector._isInTest.Value;
        }

        #endregion
    }
}
