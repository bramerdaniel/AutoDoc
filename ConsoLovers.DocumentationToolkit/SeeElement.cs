// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeeElement.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System;
   using System.Diagnostics;
   using System.Xml.Linq;

   
   [DebuggerDisplay("{Element.ToString()}")]
   public class SeeElement : XDocElement
   {
      #region Constructors and Destructors

      public SeeElement(XElement seeElement)
      {
         Element = seeElement ?? throw new ArgumentNullException(nameof(seeElement));
      }

      #endregion

      #region Public Properties

      public override string RawText => Element.ToString();

      #endregion

      #region Properties

      protected XElement Element { get; }

      #endregion
   }
}