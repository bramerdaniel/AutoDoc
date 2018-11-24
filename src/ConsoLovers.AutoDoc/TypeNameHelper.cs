namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;
   using System.Linq;

   public class TypeNameHelper
   {
      private static Dictionary<Type, string> aliases = new Dictionary<Type, string>();

      static TypeNameHelper()
      {
         aliases[typeof(byte)] = "byte";
         aliases[typeof(sbyte)] = "sbyte";
         aliases[typeof(short)] = "short";
         aliases[typeof(ushort)] = "ushort";
         aliases[typeof(int)] = "int";
         aliases[typeof(uint)] = "uint";
         aliases[typeof(long)] = "long";
         aliases[typeof(ulong)] = "ulong";
         aliases[typeof(char)] = "char";
         aliases[typeof(float)] = "float";
         aliases[typeof(double)] = "double";
         aliases[typeof(decimal)] = "decimal";
         aliases[typeof(bool)] = "bool";
         aliases[typeof(object)] = "object";
         aliases[typeof(string)] = "string";
      }

      public static string GetUserFriendlyName(Type type)
      {
         if (aliases.TryGetValue(type, out var alias))
            return alias;

         if (type.IsGenericType)
         {
            var types = type.GetGenericArguments();
            string arguments = string.Join(",", types.Select(x => x.Name));
            return type.Name.Replace($"`{types.Length}", $@"<{arguments}>");
         }

         return type.Name;
      }
   }
}