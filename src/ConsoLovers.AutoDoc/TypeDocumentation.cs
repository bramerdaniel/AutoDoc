// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDocumentation.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Reflection;

   /// <summary>Base class for type documentations</summary>
   /// <seealso cref="MemberDocumentation"/>
   /// <seealso cref="ConsoLovers.AutoDoc.ITypeDocumentation"/>
   public class TypeDocumentation : MemberDocumentation, ITypeDocumentation
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="TypeDocumentation"/> class.</summary>
      /// <param name="documentationSource">The documentation source.</param>
      /// <param name="type">The type.</param>
      protected TypeDocumentation(IDocumentationSource documentationSource, Type type)
         : base(documentationSource, type)
      {
         if (type == null)
            throw new ArgumentNullException(nameof(type));

         UserFriendlyName = TypeNameHelper.GetUserFriendlyName(type);
      }

      #endregion

      #region ITypeDocumentation Members

      /// <summary>Gets a user friendly name. Relevant for generics</summary>
      public string UserFriendlyName { get; }

      /// <summary>Gets the type the documentation is for.</summary>
      public Type Type => (Type)MemberInfo;

      #endregion

      #region Public Properties

      /// <summary>Gets the assembly the type was defined in.</summary>
      public Assembly Assembly => Type.Assembly;

      #endregion

      #region Methods

      private string GetUserFrienflyName(Type type)
      {
         return type.Name;
      }

      #endregion
   }
}