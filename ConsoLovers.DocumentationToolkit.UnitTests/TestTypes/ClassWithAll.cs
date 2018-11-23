namespace ConsoLovers.DocumentationToolkit.UnitTests
{
   using System;

   public class ClassWithAll
   {
      /// <summary>The field</summary>
      public bool Field;

      /// <summary>Gets or sets the string property.</summary>
      public string StringProperty { get; set; }

      /// <summary>Gets the value.</summary>
      /// <param name="hint">The hint.</param>
      /// <returns>The result</returns>
      public int GetValue(int hint) => hint;

      /// <summary>Occurs when failed.</summary>
      public event EventHandler Failed;
   }
}