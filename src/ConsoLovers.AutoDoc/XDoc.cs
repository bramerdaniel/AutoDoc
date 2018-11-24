// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XDoc.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System.Collections.Generic;
   using System.Text;
   using System.Xml.Linq;

   using ConsoLovers.AutoDoc.DocuElements;

   public class XDoc : List<XDocElement>
   {
      #region Public Properties

      public static XDoc Empty { get; } = new XDoc();

      public bool IsEmpty => Count == 0;

      #endregion

      #region Public Methods and Operators

      public static XDoc FromXElement(XElement element)
      {
         if (element == null)
            return Empty;

         var summary = new XDoc();
         foreach (var node in element.Nodes())
         {
            if (node is XElement child)
            {
               summary.Add(GetElement(child));
            }
            else
            {
               summary.Add(new XDocTextElement(node.ToString()));
            }
         }

         return summary;
      }

      public string GetRawText()
      {
         StringBuilder builder = new StringBuilder();
         foreach (var element in this)
            builder.Append(element.AsString);

         return builder.ToString();
      }

      #endregion

      #region Methods

      private static XDocElement GetElement(XElement element)
      {
         if (element == null)
            return new XDocTextElement(string.Empty);

         switch (element.Name.LocalName.ToLowerInvariant())
         {
            case "see":
               return new SeeElement(element);
            case "typeparamref":
               return new TypeParamRefElement(element);

            default:
               return new XDocXElement(element);
         }
      }

      #endregion
   }
}