namespace ConsoLovers.AutoDoc
{
   using System;
   using System.Reflection;

   public class PropertyDocumentation : MemberDocumentation, IPropertyDocumentation
   {
      #region Constructors and Destructors

      /// <summary>Initializes a new instance of the <see cref="PropertyDocumentation"/> class.</summary>
      /// <param name="propertyInfo">The property information.</param>
      /// <param name="documentationSource">The documentation source.</param>
      /// <exception cref="System.ArgumentNullException">propertyInfo</exception>
      public PropertyDocumentation(PropertyInfo propertyInfo, IDocumentationSource documentationSource)
         : base(documentationSource, propertyInfo)
      {
         PropertyInfo = propertyInfo ?? throw new ArgumentNullException(nameof(propertyInfo));
         UserFriendlyTypeName = TypeNameHelper.GetUserFriendlyName(propertyInfo.PropertyType);
      }

      #endregion

      #region IPropertyDocumentation Members

      /// <summary>Gets the type of the property.</summary>
      public Type Type => PropertyInfo.PropertyType;

      public string UserFriendlyTypeName { get; }

      public string PropertyName => PropertyInfo.Name;

      #endregion

      #region Public Properties

      /// <summary>Gets the <see cref="MemberInfo"/> for this documentation.</summary>
      public PropertyInfo PropertyInfo { get; }

      #endregion
   }
}