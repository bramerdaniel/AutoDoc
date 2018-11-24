namespace ConsoLovers.AutoDoc.DocuElements
{
   using System;
   using System.Diagnostics;
   using System.Xml.Linq;

   [DebuggerDisplay("{Element.ToString()}")]
   public class TypeParamRefElement : XDocXElement
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="TypeParamRefElement"/> class.</summary>
      /// <param name="typeParamRef">The see element.</param>
      /// <exception cref="ArgumentException"></exception>
      public TypeParamRefElement(XElement typeParamRef)
         : base(typeParamRef)
      {
         if (Element.Name != "typeparamref")
            throw new ArgumentException($"The element {typeParamRef} is not a <typeparamref /> element.");

         TypeName = Element.Attribute("name")?.Value;
      }

      #endregion

      #region Public Properties

      /// <summary>Gets the reference type as string.</summary>
      public string TypeName { get; }

      #endregion
   }
}