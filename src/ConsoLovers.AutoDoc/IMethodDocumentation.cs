// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMethodDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;
   using System.Reflection;

   public interface IMethodDocumentation : IElementDocumentation
   {
      #region Public Properties

      /// <summary>Gets the returns element.</summary>
      XDoc Returns { get; }

      /// <summary>Gets the return type of the method.</summary>
      Type Type { get; }

      /// <summary>Gets the name of the method.</summary>
      string MethodName { get; }

      IReadOnlyCollection<XDoc> Parameters { get; }

      string SignatureString { get; }

      string UserFriendlyReturnTypeName { get; }

      #endregion
   }
}