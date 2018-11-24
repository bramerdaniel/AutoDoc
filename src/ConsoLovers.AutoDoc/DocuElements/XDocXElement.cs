// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XDocXElement.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc.DocuElements
{
   using System;
   using System.Diagnostics;
   using System.Xml.Linq;

   /// <summary><see cref="XDocElement"/> representing an <see cref="XElement"/></summary>
   /// <seealso cref="ConsoLovers.AutoDoc.DocuElements.XDocElement"/>
   [DebuggerDisplay("{Element.ToString()}")]
   public class XDocXElement : XDocElement
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="XDocXElement"/> class.</summary>
      /// <param name="element">The element.</param>
      /// <exception cref="ArgumentNullException">element</exception>
      public XDocXElement(XElement element)
      {
         Element = element ?? throw new ArgumentNullException(nameof(element));
      }

      #endregion

      #region Public Properties

      /// <summary>Gets or sets the element as raw text.</summary>
      public override string AsString => Element.ToString();

      #endregion

      #region Properties

      /// <summary>Gets the <see cref="XElement"/>.</summary>
      protected XElement Element { get; }

      #endregion
   }
}