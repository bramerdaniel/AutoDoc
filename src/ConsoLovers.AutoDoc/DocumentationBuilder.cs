// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationBuilder.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Linq;

   public class DocumentationBuilder
   {
      #region Public Properties

      public IDocumentationProcessor Processor { get; set; }

      public ITypeSelector TypeSelector { get; set; }

      #endregion

      #region Public Methods and Operators

      public void Build()
      {
         if (TypeSelector == null)
            throw new InvalidOperationException("No type selector defined");

         if (Processor == null)
            throw new InvalidOperationException("No processor defined");

         BuildInternal();
      }

      public void BuildInternal()
      {
         var documentationSource = new XmlDocumentationSource();
         var documentations = TypeSelector.SelectTypes().Select(x => new ClassDocumentation(documentationSource, x)).ToArray();

         Processor.Process(documentations);
      }

      #endregion
   }
}