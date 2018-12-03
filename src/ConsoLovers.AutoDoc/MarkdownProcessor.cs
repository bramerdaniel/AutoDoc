// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarkdownProcessor.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using System.Text;

   using ConsoLovers.AutoDoc.DocuElements;

   public class MarkdownProcessor : IDocumentationProcessor
   {
      #region Constants and Fields

      private readonly string destinationDirectory;

      #endregion

      #region Constructors and Destructors

      public MarkdownProcessor(string destinationDirectory)
      {
         this.destinationDirectory = destinationDirectory;
      }

      #endregion

      #region IDocumentationProcessor Members

      public void Process(ICollection<IClassDocumentation> classDocumentations)
      {
         StringBuilder builder = new StringBuilder();
         builder.AppendLine("# Bam");
         builder.AppendLine();

         foreach (var classDocumentation in classDocumentations)
         {
            builder.AppendLine($"## {classDocumentation.UserFriendlyName}");
            builder.AppendLine($"[{classDocumentation.Type.FullName}]: #{classDocumentation.UserFriendlyName}");
            if (classDocumentation.UserFriendlyName != classDocumentation.Type.Name)
               builder.AppendLine($"[{classDocumentation.Type.Name}]: #{classDocumentation.UserFriendlyName}");
            builder.AppendLine();

            var description = GetMarkDown(classDocumentation.Summary);
            if (!string.IsNullOrEmpty(description))
               builder.AppendLine($"Description: {description}");

            builder.AppendLine();
            BuildMethodTable(builder, classDocumentation);
            builder.AppendLine();
            // BuildPropertyTable(builder, classDocumentation);
            builder.AppendLine();
         }

         WriteFile(builder);
      }

      #endregion

      #region Methods

      private static void BuildMethodTable(StringBuilder builder, IClassDocumentation classDocumentation)
      {
         if (classDocumentation.Methods.Count == 0)
            return;

         builder.AppendLine("### Methods");
         builder.AppendLine(" Name | Description ");
         builder.AppendLine(" ---| --- ");
         foreach (var method in classDocumentation.Methods)
         {
            var simpleSig = $"{method.MethodName}{MethodSignatureString(method)}";
            var fullSig = $"{method.UserFriendlyReturnTypeName} {method.MethodName}{MethodSignatureString(method)}".Replace(" ", "-");
            builder.AppendLine($" [{simpleSig}](#{fullSig}) | {GetMarkDown(method.Summary)}");
         }

         builder.AppendLine();
         foreach (var method in classDocumentation.Methods)
         {
            var fullSig = $"{method.UserFriendlyReturnTypeName} {method.MethodName}{MethodSignatureString(method)}";
            builder.AppendLine("---");
            builder.AppendLine($"#### {fullSig}");
         }
      }

      private static string GetReturnTypeMarkup(IMethodDocumentation method)
      {
         return $"[{method.UserFriendlyReturnTypeName}](#{method.UserFriendlyReturnTypeName})";
      }

      private static string MethodSignatureString(IMethodDocumentation method)
      {
         var signatureString = method.SignatureString.Replace("<", "\\<").Replace(">", "\\>").Replace(",", ", ");
         if (string.IsNullOrEmpty(signatureString))
            return "()";
         return signatureString;
      }

      private static void BuildPropertyTable(StringBuilder builder, IClassDocumentation classDocumentation)
      {
         builder.AppendLine("### Properties");
         builder.AppendLine("Type | Name | Description ");
         builder.AppendLine("--- | ---| --- ");
         foreach (var property in classDocumentation.Properties)
         {
            builder.AppendLine($" `{property.UserFriendlyTypeName}` | {property.PropertyName} | {GetMarkDown(property.Summary)}");
         }
      }

      private static string GetMarkDown(XDoc xDoc)
      {
         if (xDoc.IsEmpty)
            return string.Empty;

         StringBuilder builder = new StringBuilder();
         foreach (var element in xDoc)
         {
            if (element is XDocTextElement textElement)
            {
               builder.Append(textElement.AsString);
            }
            else if (element is SeeElement seeElement)
            {
               var refType = seeElement.Ref;
               if (refType.Length > 1 && refType[1] == ':')
                  refType = refType.Substring(2);

               var type = Type.GetType(seeElement.FullTypeName, false);
               if (type == null)
               {
                  var name = refType.Substring(refType.LastIndexOf(".") + 1);
                  builder.Append($"[{name}][#{refType}]");
               }
               else
               {
                  builder.Append($"[{TypeNameHelper.GetUserFriendlyName(type)}](#{TypeNameHelper.GetUserFriendlyName(type)})");
               }


            }
            else if (element is TypeParamRefElement typeParamRef)
            {
               builder.Append($"`{typeParamRef.TypeName}`");
            }
            else if (element is XDocXElement xDocumentation)
            {
               builder.Append(xDocumentation.AsString);
            }
            else
            {
               throw new NotImplementedException();
            }
         }

         return builder.ToString();
      }

      private void WriteFile(StringBuilder builder)
      {
         if (!Directory.Exists(destinationDirectory))
            Directory.CreateDirectory(destinationDirectory);

         var path = Path.Combine(destinationDirectory, "api.md");
         File.WriteAllText(path, builder.ToString());
      }

      #endregion
   }
}