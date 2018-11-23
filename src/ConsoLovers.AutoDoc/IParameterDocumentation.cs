// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IParameterDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Reflection;

   /// <summary>The documentation of a method parameter</summary>
   /// <seealso cref="IElementDocumentation"/>
   public interface IParameterDocumentation
   {
      #region Public Properties

      /// <summary>Gets the parameter information.</summary>
      ParameterInfo ParameterInfo { get; }

      /// <summary>Gets the type of the parameter.</summary>
      Type Type { get; }

      #endregion
   }
}