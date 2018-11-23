namespace ConsoLovers.DocumentationToolkit
{
   using System;
   using System.Reflection;

   public class PropertyDocumentation : ElementDocumentation, IPropertyDocumentation
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
      }

      #endregion

      #region IPropertyDocumentation Members

      /// <summary>Gets the type of the property.</summary>
      public Type Type => PropertyInfo.PropertyType;

      #endregion

      #region Public Properties

      /// <summary>Gets the <see cref="MemberInfo"/> for this documentation.</summary>
      public PropertyInfo PropertyInfo { get; }

      #endregion
   }
}