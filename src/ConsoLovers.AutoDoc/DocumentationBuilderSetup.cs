// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DocumentationBuilderSetup.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System.Collections.Generic;
   using System.Diagnostics;
   using System.Reflection;

   public class DocumentationBuilderSetup
   {
      private List<Assembly> assemblies = new List<Assembly>();

      private MarkdownProcessor processor;

      #region Public Methods and Operators

      public DocumentationBuilder GetBuilder()
      {
         return new DocumentationBuilder
         {
            Processor = processor,
            TypeSelector = new AssembliesTypeSelector(assemblies.ToArray())
         };
      }

      #endregion

      public DocumentationBuilderSetup ForAssembly(Assembly assembly)
      {
         assemblies.Add(assembly);
         return this;
      }

      public DocumentationBuilderSetup WithMarkdownOutput(string destinationDirectory)
      {
         processor = new MarkdownProcessor(destinationDirectory);
         return this;
      }
   }
}