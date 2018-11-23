// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationEngine.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;

   public class DocumentationEngine
   {
      #region Public Properties

      public ITypeSelector TypeSelector { get; set; }

      public IDocumentationProcessor Processor{ get; set; }

      #endregion

      #region Public Methods and Operators

      public void GenerateDocumentation(string destinationDirectory)
      {
         var documentationSource = new XmlDocumentationSource();

         foreach (var type in TypeSelector.SelectTypes())
         {
            var classDocumentation = new ClassDocumentation(documentationSource, type);
            Processor.Process(classDocumentation);
         }
      }

      public IElementDocumentation GetDocumentation(Type type)
      {
         if (type.IsEnum)
            return new EnumDocumentation(null, type);
         if (type.IsInterface)
            return new InterfaceDocumentation(null, type);

         return new ClassDocumentation(null, type);
      }

      #endregion
   }
}