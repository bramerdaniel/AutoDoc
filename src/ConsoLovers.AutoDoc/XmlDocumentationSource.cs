﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlDocumentationSource.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;
   using System.Reflection;

   public class XmlDocumentationSource : IDocumentationSource
   {
      #region Constructors and Destructors

      public XmlDocumentationSource()
         : this(TypeDocumentationCache.Instance)
      {
      }

      public XmlDocumentationSource(IXDocumentCache cache)
      {
         Cache = cache ?? throw new ArgumentNullException(nameof(cache));
      }

      #endregion

      #region IDocumentationSource Members

      public IEnumerable<ParameterXDoc> GetParam(MethodInfo memberInfo)
      {
         if (memberInfo == null)
            throw new ArgumentNullException(nameof(memberInfo));

         var element = Cache.GetMemberElement(memberInfo);
         if (element == null)
            yield break;

         foreach (var paramElement in element.Descendants("param"))
            yield return new  ParameterXDoc(paramElement);
      }

      public XDoc GetReturns(MemberInfo memberInfo)
      {
         if (memberInfo == null)
            throw new ArgumentNullException(nameof(memberInfo));

         var element = Cache.GetMemberElement(memberInfo);
         return new XDoc(element?.Element("returns"));
      }

      public XDoc GetSummary(MemberInfo memberInfo)
      {
         if (memberInfo == null)
            throw new ArgumentNullException(nameof(memberInfo));

         var element = Cache.GetMemberElement(memberInfo);
         return new XDoc(element?.Element("summary"));
      }

      #endregion

      #region Properties

      protected IXDocumentCache Cache { get; }

      #endregion
   }
}