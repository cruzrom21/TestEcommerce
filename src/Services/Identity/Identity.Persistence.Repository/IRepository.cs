using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Persistence.Repository
{

    public interface IRepository<T>
	{
		T? GetById(int id);
		List<T>? GetAll();
		bool Insert(T entidad);
        bool Update(T entidad);
        bool Delete(int id);
	}
}
