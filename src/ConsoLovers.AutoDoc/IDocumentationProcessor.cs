namespace ConsoLovers.AutoDoc
{
   using System.Collections.Generic;

   public interface IDocumentationProcessor
   {
      void Process(ICollection<IClassDocumentation> classDocumentations);
   }
}