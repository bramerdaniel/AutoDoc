// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Reflection;

   public class ParameterDocumentation : IParameterDocumentation
   {
      #region Constants and Fields

      private readonly IDocumentationSource documentationSource;

      private readonly ParameterInfo parameterInfo;

      #endregion

      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="ParameterDocumentation"/> class.</summary>
      /// <param name="parameterInfo">The parameter information.</param>
      /// <param name="documentationSource">The documentation source.</param>
      /// <exception cref="System.ArgumentNullException">propertyInfo</exception>
      public ParameterDocumentation(ParameterInfo parameterInfo, IDocumentationSource documentationSource)
      {
         this.documentationSource = documentationSource ?? throw new ArgumentNullException(nameof(documentationSource));
         this.parameterInfo = parameterInfo ?? throw new ArgumentNullException(nameof(parameterInfo));
      }

      #endregion

      #region IParameterDocumentation Members

      /// <summary>Gets the type of the property.</summary>
      public Type Type => ParameterInfo.ParameterType;

      public ParameterInfo ParameterInfo => parameterInfo;

      #endregion
   }
}