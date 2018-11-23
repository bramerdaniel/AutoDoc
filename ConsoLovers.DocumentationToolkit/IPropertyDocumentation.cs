// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System;

   /// <summary>The documentation of a property</summary>
   /// <seealso cref="ConsoLovers.DocumentationToolkit.IElementDocumentation"/>
   public interface IPropertyDocumentation : IElementDocumentation
   {
      #region Public Properties

      /// <summary>Gets the type of the property.</summary>
      Type Type { get; }

      #endregion
   }
}