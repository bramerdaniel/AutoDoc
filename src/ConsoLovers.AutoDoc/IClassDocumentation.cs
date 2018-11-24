// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClassDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System.Collections.Generic;
   using System.Reflection;

   /// <summary>The documentation of a complete class</summary>
   /// <seealso cref="ConsoLovers.AutoDoc.ITypeDocumentation"/>
   public interface IClassDocumentation : ITypeDocumentation
   {
      #region Public Properties

      /// <summary>Gets the assembly the class is defined in.</summary>
      Assembly Assembly { get; }

      /// <summary>Gets all available <see cref="IMethodDocumentation"/>s for this class.</summary>
      IReadOnlyCollection<IMethodDocumentation> Methods { get; }

      /// <summary>Gets all available <see cref="IPropertyDocumentation"/>s for this class.</summary>
      IReadOnlyCollection<IPropertyDocumentation> Properties { get; }

      #endregion
   }
}