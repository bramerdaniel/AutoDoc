﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericClass.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Generator.TestTypes
{
   /// <summary>A generic class</summary>
   /// <typeparam name="T">The generic type</typeparam>
   public class GenericClass<T>
   {
      #region Public Properties

      /// <summary>Gets or sets the genetic member of type <typeparamref name="T"/>.</summary>
      public T Member { get; set; }

      /// <summary>Gets the genetic member of type <typeparamref name="T"/>.</summary>
      public T GetMember()
      {
         return Member;
      }

      /// <summary>Gets the integer.</summary>
      /// <returns>A simple integer</returns>
      public int GetInteger()
      {
         return 0;
      }

      /// <summary>Gets the integer.</summary>
      /// <typeparam name="GT">The GT type.</typeparam>
      /// <returns>A simple integer by <typeparamref name="GT"/></returns>
      public int OtherGeneric<GT>()
      {
         return 0;
      }

      #endregion
   }
}