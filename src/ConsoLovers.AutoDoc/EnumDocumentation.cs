// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;

   public class EnumDocumentation : ElementDocumentation
   {
      #region Constructors and Destructors

      public EnumDocumentation(IDocumentationSource documentationSource, Type type)
         : base(documentationSource, type)
      {
      }

      #endregion
   }
}