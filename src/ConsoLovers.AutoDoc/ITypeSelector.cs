// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITypeSelector.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;

   public interface ITypeSelector
   {
      /// <summary>Selects the types a documentation should be created for.</summary>
      /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="Type"/>s</returns>
      IEnumerable<Type> SelectTypes();
   }
}