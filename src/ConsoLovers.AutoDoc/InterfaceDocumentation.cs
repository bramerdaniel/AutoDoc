// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterfaceDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;

   public class InterfaceDocumentation : ComplexTypeDocumentation, IInterfaceDocumentation
   {
      #region Constructors and Destructors

      public InterfaceDocumentation(IDocumentationSource documentationSource, Type type)
         : base(documentationSource, type)
      {
         if (!type.IsInterface)
            throw new ArgumentException("The given type is not an interface", nameof(type));
      }

      #endregion
   }
}