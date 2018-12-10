// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Linq;
   using System.Reflection;

   /// <summary>Gets the documentation for a type</summary>
   /// <seealso cref="MemberDocumentation"/>
   public class ClassDocumentation : ComplexTypeDocumentation, IClassDocumentation
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="ClassDocumentation"/> class.</summary>
      /// <param name="documentationSource">The documentation source.</param>
      /// <param name="type">The type.</param>
      /// <exception cref="System.ArgumentNullException">type</exception>
      public ClassDocumentation(IDocumentationSource documentationSource, Type type)
         : base(documentationSource, type)
      {
         if (type == null)
            throw new ArgumentNullException(nameof(type));
      }

      #endregion

      #region Methods

      private EventInfo[] GetEvents()
      {
         return Type.GetEvents(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
            .ToArray();
      }

      private FieldInfo[] GetFields()
      {
         return Type.GetFields(
               BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.GetField | BindingFlags.SetField)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
            .ToArray();
      }

      #endregion
   }
}