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

      public static XDoc Empty { get; } = new XDoc(null);

      public bool IsEmpty => Count == 0;

      public XDoc(XElement element)
      {
         if(element==null)
            return;

         foreach (var node in element.Nodes())
         {
            if (node is XElement child)
            {
              Add(GetElement(child));
            }
            else
            {
               Add(new XDocTextElement(node.ToString()));
            }
         }
         
      }

      #endregion

      #region Public Methods and Operators

      public string GetRawText()
      {
         StringBuilder builder = new StringBuilder();
         foreach (var element in this)
            builder.Append(element.AsString);

         return builder.ToString();
      }

      #endregion

      #region Methods

      protected static XDocElement GetElement(XElement element)
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

   public class ParameterXDoc : XDoc
   {
      public string Name { get;}

      public ParameterXDoc(XElement element)
         : base(element)
      {
         if (element != null)
            Name = element.Attribute("name")?.Value;
      }
   }
}