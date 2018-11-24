// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Reflection;

   /// <summary>Documentation of types like classes, interfaces, enums and structs</summary>
   /// <seealso cref="ConsoLovers.AutoDoc.IElementDocumentation"/>
   public interface ITypeDocumentation : IElementDocumentation
   {
      #region Public Properties

      /// <summary>Gets the assembly the type was defined in.</summary>
      Assembly Assembly { get; }

      /// <summary>Gets the type the documentation is for.</summary>
      Type Type { get; }

      /// <summary>Gets a user friendly name. Relevant for generics</summary>
      string UserFriendlyName { get; }

      #endregion
   }
}