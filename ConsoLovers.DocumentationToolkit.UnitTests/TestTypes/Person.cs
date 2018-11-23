// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit.UnitTests.TestTypes
{
   /// <summary>Person summary</summary>
   public class Person
   {
      #region Public Properties

      /// <summary>Gets or sets the id.</summary>
      public int Id { get; set; }

      /// <summary>Gets or sets the name.</summary>
      public string Name { get; set; }

      public void Delete(){}
      #endregion
   }
}