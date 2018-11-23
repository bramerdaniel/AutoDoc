// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XDoc.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System.Collections.Generic;
   using System.Text;
   using System.Xml.Linq;

   public class XDoc : List<XDocElement>
   {
      #region Public Properties

      public static XDoc Empty { get; } = new XDoc();

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
               summary.Add(new SeeElement(child));
            }
            else
            {
               summary.Add(new TextElement(node.ToString()));
            }
         }

         return summary;
      }

      public string GetRawText()
      {
         StringBuilder builder = new StringBuilder();
         foreach (var element in this)
            builder.Append(element.RawText);

         return builder.ToString();
      }

      #endregion
   }
}