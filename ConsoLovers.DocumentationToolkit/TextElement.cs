// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextElement.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System.Diagnostics;

   [DebuggerDisplay("{" + nameof(Text) + "}")]
   public class TextElement : XDocElement
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="TextElement"/> class.</summary>
      /// <param name="text">The text.</param>
      public TextElement(string text)
      {
         Text = text;
      }

      #endregion

      #region Public Properties

      /// <summary>Gets or sets the raw text.</summary>
      public override string RawText => Text;

      /// <summary>Gets the text.</summary>
      public string Text { get; }

      #endregion
   }
}