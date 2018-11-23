// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Generator
{
   using System;

   using ConsoLovers.DocumentationToolkit;

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
         var engine = new DocumentationEngine();
         engine.TypeSelector = new AssemblyTypeSelector(typeof(Program).Assembly);
         engine.Processor = new ConsoleProcessor();
         engine.GenerateDocumentation("docs");

         Console.ReadLine();
      }

      #endregion
   }
}