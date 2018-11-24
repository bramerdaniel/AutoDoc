// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPropertyDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;

   /// <summary>The documentation of a property</summary>
   /// <seealso cref="IElementDocumentation"/>
   public interface IPropertyDocumentation : IElementDocumentation
   {
      #region Public Properties

      /// <summary>Gets the name of the property.</summary>
      string PropertyName { get; }

      /// <summary>Gets the type of the property.</summary>
      Type Type { get; }

      string UserFriendlyTypeName { get; }

      #endregion
   }
}