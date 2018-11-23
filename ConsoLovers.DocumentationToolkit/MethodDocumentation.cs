// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MethodDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;

   public class MethodDocumentation : ElementDocumentation, IMethodDocumentation
   {
      #region Constants and Fields

      private IReadOnlyCollection<XDoc> parameters;

      #endregion

      #region Constructors and Destructors

      public MethodDocumentation(MethodInfo method, IDocumentationSource documentationSource)
         : base(documentationSource, method)
      {
         MethodInfo = method ?? throw new ArgumentNullException(nameof(method));
      }

      #endregion

      #region IMethodDocumentation Members

      /// <summary>Gets the type of the return.</summary>
      /// <value>The type of the return.</value>
      public Type Type => MethodInfo.ReturnType;

      /// <summary>Gets the name of the method.</summary>
      public string MethodName => MethodInfo.Name;

      /// <summary>Gets the returns element.</summary>
      public XDoc Returns => DocumentationSource.GetReturns(MethodInfo);

      #endregion

      #region Public Properties

      /// <summary>Gets the <see cref="MemberInfo"/> for this documentation.</summary>
      public MethodInfo MethodInfo { get; }

      public IReadOnlyCollection<XDoc> Parameters => parameters ?? (parameters = CreateParameters().ToArray());

      #endregion

      #region Methods

      private IEnumerable<XDoc> CreateParameters()
      {
         return DocumentationSource.GetParam(MethodInfo);
      }

      #endregion
   }
}