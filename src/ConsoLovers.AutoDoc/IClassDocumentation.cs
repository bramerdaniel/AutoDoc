namespace ConsoLovers.AutoDoc
{
   using System.Collections.Generic;

   public interface IClassDocumentation : IElementDocumentation
   {
      /// <summary>Gets all available <see cref="IMethodDocumentation"/>s for this class.</summary>
      IReadOnlyCollection<IMethodDocumentation> Methods { get; }

      IReadOnlyCollection<IPropertyDocumentation> Properties { get; }
   }
}