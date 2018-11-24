// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Reflection;

   /// <summary>Gets the documentation for a type</summary>
   /// <seealso cref="MemberDocumentation"/>
   public class ClassDocumentation : TypeDocumentation, IClassDocumentation
   {
      #region Constants and Fields

      private IReadOnlyCollection<IMethodDocumentation> methods;

      private IReadOnlyCollection<IPropertyDocumentation> properties;

      #endregion

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

      #region IClassDocumentation Members

      /// <summary>Gets the assembly the class is defined in.</summary>

      /// <summary>Gets all available <see cref="IMethodDocumentation"/>s for this class.</summary>
      public IReadOnlyCollection<IMethodDocumentation> Methods => methods ?? (methods = CreateMethods().ToArray());

      /// <summary>Gets all available <see cref="IPropertyDocumentation"/>s for this class.</summary>
      public IReadOnlyCollection<IPropertyDocumentation> Properties => properties ?? (properties = CreateProperties().ToArray());

      #endregion

      #region Methods

      private IEnumerable<MethodDocumentation> CreateMethods()
      {
         return GetMethods().Select(mi => new MethodDocumentation(mi, DocumentationSource));
      }

      private IEnumerable<PropertyDocumentation> CreateProperties()
      {
         return GetProperties().Select(mi => new PropertyDocumentation(mi, DocumentationSource));
      }

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

      private MethodInfo[] GetMethods()
      {
         return Type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any() && !x.IsPrivate)
            .ToArray();
      }

      PropertyInfo[] GetProperties()
      {
         return Type.GetProperties(
               BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.SetProperty)
            .Where(x => !x.IsSpecialName && !x.GetCustomAttributes<ObsoleteAttribute>().Any())
            .Where(
               y =>
               {
                  var getMethod = y.GetGetMethod(true);
                  var setMethod = y.GetSetMethod(true);
                  if (getMethod != null && setMethod != null)
                     return !(getMethod.IsPrivate && setMethod.IsPrivate);

                  if (getMethod != null)
                     return !getMethod.IsPrivate;

                  if (setMethod != null)
                     return !setMethod.IsPrivate;

                  return false;
               }).ToArray();
      }

      #endregion
   }
}