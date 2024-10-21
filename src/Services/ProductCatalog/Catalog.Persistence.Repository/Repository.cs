
using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;
using Microsoft.Extensions.Logging;

namespace Catalog.Persistence.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProductDbContext _db;
        private ILogger<Repository<T>> _logger;
        protected readonly DbSet<T> EntitySet;

        public Repository(ProductDbContext db, ILogger<Repository<T>> logger)
        {
            _db = db;
            EntitySet = _db.Set<T>();
            _logger = logger;
        }

        

        public T? GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Repository => GetById<{typeof(T).Name}> => Busca por id");
                return EntitySet.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<T>? GetAll()
        {
            try
            {
                _logger.LogInformation($"Repository => GetAll<{typeof(T).Name}> => Busca todos");
                return EntitySet.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Insert(T entidad)
        {
            try
            {
                _logger.LogInformation($"Repository => Insert<{typeof(T).Name}> => Inserta");
                EntitySet.Add(entidad);

                _logger.LogInformation($"Repository => Insert<{typeof(T).Name}> => Guarda cambios");
                return _db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(T entidad)
        {
            try
            {
                _logger.LogInformation($"Repository => Update<{typeof(T).Name}> => Edita");
                _db.Entry(entidad).State = EntityState.Modified;

                _logger.LogInformation($"Repository => Update<{typeof(T).Name}> => Guarda cambios");
                return _db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Repository => Delete<{typeof(T).Name}> => Busca por id");
                var entidad = EntitySet.Find(id);

                if (entidad != null)
                {
                    _logger.LogInformation($"Repository => Delete<{typeof(T).Name}> => Elimina");
                    EntitySet.Remove(entidad);

                    _logger.LogInformation($"Repository => Delete<{typeof(T).Name}> => Guarda cambios");
                    return _db.SaveChanges() > 0;
                }
                else
                {
                    _logger.LogError($"Repository => Delete<{typeof(T).Name}> => No encontro el campo");
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
