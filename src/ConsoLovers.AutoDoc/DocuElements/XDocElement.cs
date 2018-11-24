// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XDocElement.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc.DocuElements
{
   /// <summary>Representing one element in an a documentation</summary>
   public abstract class XDocElement
   {
      #region Public Properties

      /// <summary>Gets the element as raw text.</summary>
      public abstract string AsString { get; }

      #endregion
   }
}