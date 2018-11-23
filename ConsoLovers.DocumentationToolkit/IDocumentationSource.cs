// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDocumentationSource.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System.Collections.Generic;
   using System.Reflection;

   public interface IDocumentationSource
   {
      #region Public Methods and Operators

      IEnumerable<XDoc> GetParam(MethodInfo methodInfo);

      XDoc GetReturns(MemberInfo memberInfo);

      XDoc GetSummary(MemberInfo methodInfo);

      #endregion
   }
}