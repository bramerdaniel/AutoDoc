namespace ConsoLovers.AutoDoc.UnitTests
{
   using ConsoLovers.AutoDoc;

   using FluentAssertions;

   using Microsoft.VisualStudio.TestTools.UnitTesting;

   /// <summary>
   /// 
   /// </summary>
   [TestClass]
   public class MethodDocumentationTest
   {
      class NestedClass
      {
         /// <summary>Raw text 1.</summary>
         /// <param name="param">The parameter.</param>
         public void MethodWithOneParameter(int param)
         {
         }

         /// <summary>Raw text 3.</summary>
         /// <param name="intParameter">The int parameter.</param>
         /// <param name="stringParameter">The string parameter.</param>
         /// <param name="booleanParameter">if set to <c>true</c> [boolean parameter].</param>
         public void MethodWithThreeParameter(int intParameter, string stringParameter, bool booleanParameter)
         {
         }
      }

      /// <summary>Raw text.</summary>
      /// <returns>nothing</returns>
      [TestMethod]
      public void EnsureRawTextAsSummaryWorksCorrectly()
      {
         var methodInfo = typeof(MethodDocumentationTest).GetMethod(nameof(EnsureRawTextAsSummaryWorksCorrectly));
         var methodDocumentation = new MethodDocumentation(methodInfo, new XmlDocumentationSource());

         methodDocumentation.Summary.GetRawText().Should().Be("Raw text.");
         methodDocumentation.Type.Should().Be(typeof(void));
         methodDocumentation.Returns.GetRawText().Should().Be("nothing");
      }

      [TestMethod]
      public void EnsureRawTextAsSummaryWorksCorrectly1()
      {
         var methodInfo = typeof(NestedClass).GetMethod(nameof(NestedClass.MethodWithOneParameter));
         var methodDocumentation = new MethodDocumentation(methodInfo, new XmlDocumentationSource());

         methodDocumentation.Summary.GetRawText().Should().Be("Raw text 1.");
      }

      [TestMethod]
      public void EnsureRawTextAsSummaryWorksCorrectly3()
      {
         var methodInfo = typeof(NestedClass).GetMethod(nameof(NestedClass.MethodWithThreeParameter));
         var methodDocumentation = new MethodDocumentation(methodInfo, new XmlDocumentationSource());

         methodDocumentation.Summary.GetRawText().Should().Be("Raw text 3.");
      }
   }
}
