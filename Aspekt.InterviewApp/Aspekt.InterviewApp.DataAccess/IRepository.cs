using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspekt.InterviewApp.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        int Create(T entity);
        void Delete(int id);
        void Update(T entity);
    }
}
