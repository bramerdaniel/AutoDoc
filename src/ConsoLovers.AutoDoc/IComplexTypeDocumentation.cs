// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IComplexTypeDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System.Collections.Generic;

   /// <summary>Base interface for types that define methods and properties</summary>
   /// <seealso cref="ConsoLovers.AutoDoc.ITypeDocumentation"/>
   public interface IComplexTypeDocumentation : ITypeDocumentation
   {
      #region Public Properties

      /// <summary>Gets the identifier.</summary>
      string Id { get; }

      /// <summary>Gets all available <see cref="IMethodDocumentation"/>s for this class.</summary>
      IReadOnlyCollection<IMethodDocumentation> Methods { get; }

      /// <summary>Gets all available <see cref="IPropertyDocumentation"/>s for this class.</summary>
      IReadOnlyCollection<IPropertyDocumentation> Properties { get; }

      #endregion
   }
}