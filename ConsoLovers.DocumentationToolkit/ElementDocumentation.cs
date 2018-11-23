// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System;
   using System.Reflection;

   public class ElementDocumentation : IElementDocumentation
   {
      /// <summary>Gets the documentation source for this element.</summary>
      protected IDocumentationSource DocumentationSource { get; }

      protected MemberInfo MemberInfo { get; }

      /// <summary>Initializes a new instance of the <see cref="ElementDocumentation"/> class.</summary>
      /// <param name="documentationSource">The documentation source.</param>
      protected ElementDocumentation(IDocumentationSource documentationSource, MemberInfo memberInfo)
      {
         DocumentationSource = documentationSource ?? throw new ArgumentNullException(nameof(documentationSource));
         MemberInfo = memberInfo ?? throw new ArgumentNullException(nameof(memberInfo));
      }

      #region IElementDocumentation Members

      /// <summary>Gets the summary of the documentation.</summary>
      public XDoc Summary => DocumentationSource.GetSummary(MemberInfo);

      #endregion
   }
}