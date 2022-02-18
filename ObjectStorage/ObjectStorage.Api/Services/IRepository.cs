using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Geolocation.ObjectStorage.Api.Services
{
    public interface IRepository<T>
    {
        T Get(string id);

        string Create(T obj);

        T Edit(T obj);

        string Delete(string id);

        IQueryable<T> GetAll();
    }
}
