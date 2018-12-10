// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;

   public class EnumDocumentation : TypeDocumentation
   {
      #region Constructors and Destructors

      public EnumDocumentation(IDocumentationSource documentationSource, Type type)
         : base(documentationSource, type)
      {
         if (!type.IsEnum)
            throw new ArgumentException("The given type is not an enum", nameof(type));
      }

      #endregion
   }
}