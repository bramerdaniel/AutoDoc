// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XDocTextElement.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc.DocuElements
{
   using System.Diagnostics;

   /// <summary><see cref="XDocElement"/> representing a raw text</summary>
   /// <seealso cref="ConsoLovers.AutoDoc.DocuElements.XDocElement"/>
   [DebuggerDisplay("{" + nameof(AsString) + "}")]
   public class XDocTextElement : XDocElement
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="XDocTextElement"/> class.</summary>
      /// <param name="text">The text.</param>
      public XDocTextElement(string text)
      {
         AsString = text;
      }

      #endregion

      #region Public Properties

      /// <summary>Gets or sets the raw text.</summary>
      public override string AsString { get; }

      #endregion
   }
}