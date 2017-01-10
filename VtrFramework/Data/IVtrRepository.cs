using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VtrFramework.Domain;

namespace VtrFramework.Data
{
    /// <summary>
    /// Interfce de repositório genérico
    /// </summary>
    public interface IVtrRepository<T> where T : VtrEntity
    {
        T GetById(int id);
        List<T> GetAll();
        void Save(T ent);
        void Delete(T ent); 
        
    }
}