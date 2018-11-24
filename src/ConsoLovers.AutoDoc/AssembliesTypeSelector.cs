namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;

   public class AssembliesTypeSelector : ITypeSelector

   {
      #region Constants and Fields

      private readonly Assembly[] assemblies;

      #endregion

      #region Constructors and Destructors

      public AssembliesTypeSelector(params Assembly[] assemblies)
      {
         this.assemblies = assemblies ?? throw new ArgumentNullException(nameof(assemblies));
      }

      #endregion

      #region ITypeSelector Members

      public IEnumerable<Type> SelectTypes()
      {
         foreach (var assembly in assemblies)
         {
            foreach (var type in GetTypes(assembly))
            {
               yield return type;
            }
         }

      }

      #endregion

      #region Methods

      private IEnumerable<Type> GetTypes(Assembly assembly)
      {
         try
         {
            return assembly.GetTypes();
         }
         catch (ReflectionTypeLoadException ex)
         {
            throw;
            return ex.Types.Where(t => t != null);
         }
         catch (Exception ex)
         {
            throw;
         }
      }

      #endregion
   }
}