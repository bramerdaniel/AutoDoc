// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDocumentationCache.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System.Collections.Generic;
   using System.IO;
   using System.Reflection;
   using System.Text;
   using System.Xml.Linq;

   public class TypeDocumentationCache : IXDocumentCache
   {
      #region Constants and Fields

      private static TypeDocumentationCache instance;

      private readonly Dictionary<Assembly, XDocument> documentCache = new Dictionary<Assembly, XDocument>();

      private readonly Dictionary<MemberInfo, XElement> memberCache = new Dictionary<MemberInfo, XElement>();

      #endregion

      #region Public Properties

      /// <summary>Gets the instance.</summary>
      public static TypeDocumentationCache Instance => instance ?? (instance = new TypeDocumentationCache());

      #endregion

      #region Methods

      private XElement FindElement(MemberInfo memberInfo)
      {
         if (memberCache.TryGetValue(memberInfo, out var element))
            return element;

         var memberName = GetMemberName(memberInfo);
         XDocument document = GetDocument(memberInfo);
         if (document == null)
            return null;

         foreach (var member in document.Descendants("member"))
         {
            var nameAttribute = member.Attribute("name");
            if (string.Equals(memberName, nameAttribute?.Value))
            {
               memberCache[memberInfo] = member;
               return member;
            }
         }

         memberCache[memberInfo] = null;
         return null;
      }

      private XDocument GetDocument(MemberInfo memberInfo)
      {
         var declaringType = memberInfo.DeclaringType;
         if (declaringType == null)
            return null;

         var assembly = declaringType.Assembly;

         if (!documentCache.ContainsKey(assembly))
         {
            var path = Path.ChangeExtension(assembly.Location, ".xml");
            documentCache[assembly] = File.Exists(path) ? XDocument.Load(path) : null;
         }

         return documentCache[assembly];
      }

      private string GetSignature(MethodInfo methodInfo)
      {
         var parameters = methodInfo.GetParameters();
         if (parameters.Length == 0)
            return string.Empty;

         StringBuilder builder = new StringBuilder();
         builder.Append("(");
         foreach (var parameter in parameters)
            builder.Append(parameter.ParameterType.FullName + ",");

         builder.Length -= 1;
         builder.Append(")");
         return builder.ToString();
      }

      private string GetMemberName(MemberInfo memberInfo)
      {
         var declaringType = memberInfo.DeclaringType;
         if (declaringType == null || declaringType.FullName == null)
            return null;

         if (memberInfo is MethodInfo methodInfo)
         {
            // foM:ConsoLovers.DocumentationToolkit.UnitTests.MethodDocumentationTest.EnsureRawTextAsSummaryWorksCorrectly
            // for nested M:ConsoLovers.DocumentationToolkit.UnitTests.MethodDocumentationTest.Nested.Method(System.Int32)
            return $"M:{declaringType.FullName.Replace("+", ".")}.{methodInfo.Name}{GetSignature(methodInfo)}";
         }

         if (memberInfo is PropertyInfo propertyInfo)
         {
            // P:ConsoLovers.DocumentationToolkit.UnitTests.ClassWithAll.StringProperty
            return $"P:{declaringType.FullName.Replace("+", ".")}.{propertyInfo.Name}";
         }

         if (memberInfo is FieldInfo fieldInfo)
         {
            // F:ConsoLovers.DocumentationToolkit.UnitTests.ClassWithAll.Field
            return $"F:{declaringType.FullName.Replace("+", ".")}.{fieldInfo.Name}";
         }
         
         if (memberInfo is EventInfo eventInfo)
         {
            // E:ConsoLovers.DocumentationToolkit.UnitTests.ClassWithAll.Failed
            return $"E:{declaringType.FullName.Replace("+", ".")}.{eventInfo.Name}";
         }

         return memberInfo.DeclaringType.Namespace + "()";
      }

      #endregion

      public XElement GetMemberElement(MemberInfo methodInfo)
      {
         return FindElement(methodInfo);
 

      }
   }
}