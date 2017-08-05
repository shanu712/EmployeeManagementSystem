using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADO_CRUD.Helpers {
    public static class Extensions {
        public static List<T> Slice<T>(this List<T> list, int start, int finish) {
            var result = new List<T>();
            for (int i = start; i < finish; i++) {
                result.Add(list[i]);
            }
            return result;
        }
    }
}