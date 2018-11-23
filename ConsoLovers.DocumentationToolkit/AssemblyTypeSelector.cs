// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyTypeSelector.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;

   public class AssemblyTypeSelector : ITypeSelector

   {
      #region Constants and Fields

      private readonly Assembly assembly;

      #endregion

      #region Constructors and Destructors

      public AssemblyTypeSelector(Assembly assembly)
      {
         this.assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
      }

      #endregion

      #region ITypeSelector Members

      public IEnumerable<Type> SelectTypes()
      {
         return GetTypes();
      }

      #endregion

      #region Methods

      private IEnumerable<Type> GetTypes()
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