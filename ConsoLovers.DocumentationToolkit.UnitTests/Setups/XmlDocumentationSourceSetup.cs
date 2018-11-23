﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDocumentationSourceSetup.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit.UnitTests.Setups
{
   internal class XmlDocumentationSourceSetup : SetupBase<XmlDocumentationSource>
   {
      #region Methods

      protected override XmlDocumentationSource CreateInstance()
      {
         return new XmlDocumentationSource();
      }

      #endregion
   }
}