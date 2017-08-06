using ADO_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Text;
using System.Data;
using System.Reflection;

namespace ADO_CRUD {
    public static class Extensions {

        static T[] Slice<T>(this T[] data, int start, int finish) {
            var result = new T[finish - start];
            int counter = 0;
            for (int i = start; i < finish; i++) {
                result[counter++] = data[i];
            }
            return result;
        }
    }
}