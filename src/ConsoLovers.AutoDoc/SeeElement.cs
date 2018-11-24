// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeeElement.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Diagnostics;
   using System.Xml.Linq;

   using ConsoLovers.AutoDoc.DocuElements;

   [DebuggerDisplay("{Element.ToString()}")]
   public class SeeElement : XDocXElement
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="SeeElement"/> class.</summary>
      /// <param name="seeElement">The see element.</param>
      /// <exception cref="ArgumentException"></exception>
      public SeeElement(XElement seeElement)
         : base(seeElement)
      {
         if (Element.Name != "see")
            throw new ArgumentException($"The element {seeElement} is not a <see /> element.");

         Ref = Element.Attribute("cref")?.Value;
      }

      #endregion

      #region Public Properties

      /// <summary>Gets the string that  reference.</summary>
      public string Ref { get; }

      public string FullTypeName
      {
         get
         {
            var refType = Ref;
            if (Ref.Length > 1 && Ref[1] == ':')
               refType = Ref.Substring(2);

            return $"{refType}, {Element.Document?.Root?.Element("assembly")?.Element("name")?.Value}";
         }
      }

      #endregion
   }
}