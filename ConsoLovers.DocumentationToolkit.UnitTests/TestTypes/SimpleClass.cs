// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleClass.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit.UnitTests.TestTypes
{
   public class SimpleClass
   {
      #region Public Methods and Operators

      /// <summary>Gets the name of the person with the given id.</summary>
      /// <param name="id">The identifier.</param>
      /// <returns>The name of the person</returns>
      public Person GetPerson(int id)
      {
         return new Person { Id = id };
      }

      #endregion
   }
}