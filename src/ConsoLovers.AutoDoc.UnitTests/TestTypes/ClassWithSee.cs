// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassWithSee.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc.UnitTests.TestTypes 
{
   /// <summary>class using see in documentation</summary>
   public class ClassWithSee
   {
      #region Public Properties

      /// <summary>Gets or sets the <see cref="ClassWithAll"/></summary>
      public ClassWithAll Reference { get; set; }

      #endregion

      #region Public Methods and Operators

      /// <summary>Gets the <see cref="ClassWithAll"/> by the id.</summary>
      /// <param name="id">The id of the <see cref="ClassWithAll"/>.</param>
      /// <returns>The result <see cref="ClassWithAll"/> when found.</returns>
      public ClassWithAll GetValue(int id) => null;

      #endregion
   }
}