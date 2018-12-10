// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationBuilder.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;
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
         IList<ITypeDocumentation> documentations = new List<ITypeDocumentation>();

         foreach (var type in TypeSelector.SelectTypes())
         {
            if (type.IsInterface)
            {
               documentations.Add(new InterfaceDocumentation(documentationSource, type));
            }
            else if(type.IsClass)
            {
               documentations.Add(new ClassDocumentation(documentationSource, type));
            }
            else if (type.IsEnum)
            {
               documentations.Add(new EnumDocumentation(documentationSource, type));
            }
            else
            {
               documentations.Add(new StructDocumentation(documentationSource, type));
            }
            
         }

         // var documentations = TypeSelector.SelectTypes().Select(x => new ClassDocumentation(documentationSource, x)).ToArray();

         Processor.Process(documentations);
      }

      #endregion
   }
}