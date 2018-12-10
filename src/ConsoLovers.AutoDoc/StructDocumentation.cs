// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;

   public class StructDocumentation : TypeDocumentation
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="StructDocumentation"/> class.</summary>
      /// <param name="documentationSource">The documentation source.</param>
      /// <param name="type">The enum type.</param>
      public StructDocumentation(IDocumentationSource documentationSource, Type type)
         : base(documentationSource, type)
      {
         if (type.IsClass)
            throw new ArgumentException("The given type is not a struct", nameof(type));
      }

      #endregion
   }
}