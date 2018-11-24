// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiGenericClass.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Generator.TestTypes
{
   /// <summary>
   /// Class with the two generic parameters <typeparamref name="T"/> and <typeparamref name="G"/>
   /// </summary>
   /// <typeparam name="T">The T type</typeparam>
   /// <typeparam name="G">The G type</typeparam>
   public class MultiGenericClass<T, G>
   {
      #region Public Properties

      /// <summary>Gets or sets the genetic member of type <typeparamref name="T"/>.</summary>
      public T Member { get; set; }

      #endregion

      #region Public Methods and Operators

      /// <summary>Gets the integer.</summary>
      /// <returns>A simple integer</returns>
      public int GetInteger()
      {
         return 0;
      }

      /// <summary>Gets the genetic member of type <typeparamref name="T"/>.</summary>
      /// <returns>The <typeparamref name="T"/></returns>
      public T GetMember()
      {
         return Member;
      }

      /// <summary>Gets the integer.</summary>
      /// <typeparam name="A">The A type.</typeparam>
      /// <typeparam name="B">The B type</typeparam>
      /// <returns>A simple integer by <typeparamref name="A"/></returns>
      public int OtherGeneric<A, B>()
      {
         return 0;
      }

      #endregion
   }
}