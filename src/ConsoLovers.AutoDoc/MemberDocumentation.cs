// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Reflection;

   /// <summary>The documentation of a class member like methods, properties, fields</summary>
   /// <seealso cref="ConsoLovers.AutoDoc.IElementDocumentation"/>
   public class MemberDocumentation : IElementDocumentation
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="MemberDocumentation"/> class.</summary>
      /// <param name="documentationSource">The documentation source.</param>
      /// <param name="memberInfo">The member information.</param>
      /// <exception cref="ArgumentNullException">documentationSource or memberInfo</exception>
      protected MemberDocumentation(IDocumentationSource documentationSource, MemberInfo memberInfo)
      {
         DocumentationSource = documentationSource ?? throw new ArgumentNullException(nameof(documentationSource));
         MemberInfo = memberInfo ?? throw new ArgumentNullException(nameof(memberInfo));
      }

      #endregion

      #region IElementDocumentation Members

      /// <summary>Gets the summary of the documentation.</summary>
      public XDoc Summary => DocumentationSource.GetSummary(MemberInfo);

      #endregion

      #region Properties

      /// <summary>Gets the documentation source for this element.</summary>
      protected IDocumentationSource DocumentationSource { get; }

      /// <summary>Gets the member information.</summary>
      protected MemberInfo MemberInfo { get; }

      #endregion
   }
}