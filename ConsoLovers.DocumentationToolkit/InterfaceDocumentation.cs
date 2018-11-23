// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterfaceDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System;

   public class InterfaceDocumentation : ElementDocumentation
   {
      #region Constructors and Destructors

      public InterfaceDocumentation(IDocumentationSource documentationSource, Type type)
         : base(documentationSource, type)
      {
      }

      #endregion
   }
}