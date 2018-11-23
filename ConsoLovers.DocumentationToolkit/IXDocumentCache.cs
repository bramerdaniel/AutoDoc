// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXDocumentCache.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit
{
   using System.Reflection;
   using System.Xml.Linq;

   public interface IXDocumentCache
   {
      #region Public Methods and Operators

      XElement GetMemberElement(MemberInfo methodInfo);

      #endregion
   }
}