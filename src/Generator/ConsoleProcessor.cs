// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleProcessor.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Generator
{
   using System;
   using System.Collections.Generic;

   using ConsoLovers.AutoDoc;

   internal class ConsoleProcessor : IDocumentationProcessor
   {
      #region IDocumentationProcessor Members

      public void Process(IClassDocumentation classDocumentation)
      {
         Console.WriteLine(classDocumentation.Summary.GetRawText());
         foreach (var methodDocumentation in classDocumentation.Methods)
         {
            Console.WriteLine($"/// {methodDocumentation.Summary.GetRawText()}");
            foreach (var parameter in methodDocumentation.Parameters)
            {
               Console.WriteLine($"/// {parameter.GetRawText()}");
            }

            Console.WriteLine($"{methodDocumentation.Type} {methodDocumentation.MethodName} ()");
         }

         Console.WriteLine("--------------------------------------------------------------------------");
      }

      #endregion

      public void Process(ICollection<IClassDocumentation> classDocumentations)
      {
         throw new NotImplementedException();
      }

      public void Process(ICollection<ITypeDocumentation> classDocumentations)
      {
         throw new NotImplementedException();
      }
   }
}