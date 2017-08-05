using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_CRUD.Helpers {
    interface IQueryable<T> {
        object GetById(int id);
        void DeleteById(int id);
        void Update(object obj);
    }
}
