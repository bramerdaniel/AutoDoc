namespace ConsoLovers.DocumentationToolkit.UnitTests
{
   using ConsoLovers.DocumentationToolkit.UnitTests.Setups;
   using ConsoLovers.DocumentationToolkit.UnitTests.TestTypes;

   using FluentAssertions;

   using Microsoft.VisualStudio.TestTools.UnitTesting;

   [TestClass]
   public class XmlDocumentationSourceTest
   {
      [TestMethod]
      public void EnsureSummaryOfANormalPropertyIsReturnedCorrectly()
      {
         var propertyInfo = typeof(ClassWithAll).GetProperty(nameof(ClassWithAll.StringProperty));

         var target = Setup.XmlDocumentationSource().Done();

         var summary = target.GetSummary(propertyInfo);

         summary.GetRawText().Should().Be("Gets or sets the string property.");
      }

      [TestMethod]
      public void EnsureSummaryOfAPropertyWithSeeReferenceIsReturnedCorrectly()
      {
         var propertyInfo = typeof(ClassWithSee).GetProperty(nameof(ClassWithSee.Reference));

         var target = Setup.XmlDocumentationSource().Done();

         var summary = target.GetSummary(propertyInfo);
         
         summary.Count.Should().Be(2);
         summary.GetRawText().Should().Be("Gets or sets the <see cref=\"T:ConsoLovers.DocumentationToolkit.UnitTests.ClassWithAll\" />");
      }

      [TestMethod]
      public void EnsureSummaryOfANormalFieldIsReturnedCorrectly()
      {
         var propertyInfo = typeof(ClassWithAll).GetField(nameof(ClassWithAll.Field));

         var target = Setup.XmlDocumentationSource().Done();

         var summary = target.GetSummary(propertyInfo);

         summary.GetRawText().Should().Be("The field");
      }

      [TestMethod]
      public void EnsureSummaryOfANormalMethodIsReturnedCorrectly()
      {
         var propertyInfo = typeof(ClassWithAll).GetMethod(nameof(ClassWithAll.GetValue));

         var target = Setup.XmlDocumentationSource().Done();

         var summary = target.GetSummary(propertyInfo);

         summary.GetRawText().Should().Be("Gets the value.");
      }

      [TestMethod]
      public void EnsureSummaryOfAMethodWithSeeElementsIsReturnedCorrectly()
      {
         var propertyInfo = typeof(ClassWithSee).GetMethod(nameof(ClassWithSee.GetValue));

         var target = Setup.XmlDocumentationSource().Done();

         var summary = target.GetSummary(propertyInfo);
         summary.Count.Should().Be(3);

         summary.GetRawText().Should().Be("Gets the <see cref=\"T:ConsoLovers.DocumentationToolkit.UnitTests.ClassWithAll\" /> by the id.");
      }

      [TestMethod]
      public void EnsureReturnsElementOfAMethodWithSeeElementsIsReturnedCorrectly()
      {
         var propertyInfo = typeof(ClassWithSee).GetMethod(nameof(ClassWithSee.GetValue));

         var target = Setup.XmlDocumentationSource().Done();

         var summary = target.GetReturns(propertyInfo);
         summary.Count.Should().Be(3);

         summary.GetRawText().Should().Be("The result <see cref=\"T:ConsoLovers.DocumentationToolkit.UnitTests.ClassWithAll\" /> when found.");
      }

      [TestMethod]
      public void EnsureSummaryOfANormalEventIsReturnedCorrectly()
      {
         var propertyInfo = typeof(ClassWithAll).GetEvent(nameof(ClassWithAll.Failed));

         var target = Setup.XmlDocumentationSource().Done();

         target.GetReturns(propertyInfo).Should().BeEmpty();

         var summary = target.GetSummary(propertyInfo);
         summary.GetRawText().Should().Be("Occurs when failed.");
      }
   }
}