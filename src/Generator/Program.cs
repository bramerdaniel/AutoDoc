// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Generator
{
   using System;

   using ConsoLovers.AutoDoc;

   /// <summary>Entry point</summary>
   class Program
   {
      #region Public Methods and Operators

      /// <summary>Funcy method with arguments.</summary>
      /// <param name="args">The arguments.</param>
      public void Funcy(string[] args)
      {
      }

      #endregion

      #region Methods

      /// <summary>Mains the specified arguments.</summary>
      /// <param name="args">The arguments.</param>
      static void Main(string[] args)
      {
         var builder = Documentation.Setup()
            .ForAssembly(typeof(Program).Assembly)
            .ForAssembly(typeof(IMethodDocumentation).Assembly)
            .WithMarkdownOutput("D:\\_md")
            .GetBuilder();

         builder.Build();
         Console.WriteLine("Done");
      }

      #endregion
   }
}