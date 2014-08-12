using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Dashboard.Controllers
{
    public static class ToExpandoExtension
    {
        public static dynamic ToExpando(this object AnonymousObject)
        {
            IDictionary<string, Object> expando = new ExpandoObject();
            foreach (var property in AnonymousObject.GetType().GetProperties())
            {
                expando[property.Name] = property.GetValue(AnonymousObject);
            }
            return expando;
        }

    }
}