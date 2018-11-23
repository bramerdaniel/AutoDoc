// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockSetupBase.cs" company="KUKA Roboter GmbH">
//   Copyright (c) KUKA Roboter GmbH 2006 - 2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ConsoLovers.DocumentationToolkit.UnitTests.Setups
{
   using System;
   using System.Collections.Generic;
   using System.Linq.Expressions;

   using Moq;

   /// <summary>Base class for mocks</summary>
   /// <typeparam name="T"></typeparam>
   internal abstract class MockSetupBase<T>
      where T : class
   {
      #region Constants and Fields

      private readonly List<MockBehaviour> behaviours = new List<MockBehaviour>();

      private readonly Dictionary<string, MockBehaviour> fields = new Dictionary<string, MockBehaviour>();

      #endregion

      #region Methods

      internal T Done()
      {
         Mock<T> mockInstance = CreateMock();
         CreateSetups(mockInstance);
         SetupMock(mockInstance);
         return DoneOverride(mockInstance);
      }

      protected virtual Mock<T> CreateMock()
      {
         return new Mock<T>();
      }

      protected virtual T DoneOverride(Mock<T> mockInstance)
      {
         return mockInstance.Object;
      }

      protected FT GetValue<FT>(string name)
      {
         var setupData = fields[name];
         return (FT)setupData.Value;
      }

      protected FT GetValue<FT>(string name, FT defaultValue)
      {
         MockBehaviour setupData;
         if (fields.TryGetValue(name, out setupData))
         {
            return (FT)setupData.Value;
         }

         return defaultValue;
      }

      protected void SetupBehaviour(Action<Mock<T>> mockSetup)
      {
         if (mockSetup == null)
            throw new ArgumentNullException(nameof(mockSetup));

         var setupData = new MockBehaviour { SetupMethodWithoutParameter = mock => mockSetup(mock) };
         behaviours.Add(setupData);
      }

      protected void SetupBehaviour<FT>(FT value, Action<Mock<T>, FT> mockSetup)
      {
         if (mockSetup == null)
            throw new ArgumentNullException(nameof(mockSetup));

         var setupData = new MockBehaviour { Value = value, SetupMethodWithParameter = (mock, objectValue) => { mockSetup(mock, (FT)objectValue); } };
         behaviours.Add(setupData);
      }

      protected virtual void SetupMock(Mock<T> mockInstance)
      {
      }

      protected void SetupThrowBehaviour<ET>(Expression<Action<T>> functionThatThrows)
         where ET : Exception, new()
      {
         SetupBehaviour(cs => cs.Setup(functionThatThrows).Throws<ET>());
      }

      protected void SetValue<FT>(string name, FT value)
      {
         if (fields.ContainsKey(name))
            throw new InvalidOperationException($"The field {name} was allready set");

         var data = new MockBehaviour { Value = value };
         fields.Add(name, data);
      }

      protected bool TryGet<FT>(string name, out FT value)
      {
         MockBehaviour setupData;
         if (fields.TryGetValue(name, out setupData))
         {
            value = (FT)setupData.Value;
            return true;
         }

         value = default(FT);
         return false;
      }

      private void CreateSetups(Mock<T> mockInstance)
      {
         foreach (var mockBehaviour in behaviours)
         {
            if (mockBehaviour.SetupMethodWithoutParameter != null)
               mockBehaviour.SetupMethodWithoutParameter.Invoke(mockInstance);
            if (mockBehaviour.SetupMethodWithParameter != null)
               mockBehaviour.SetupMethodWithParameter.Invoke(mockInstance, mockBehaviour.Value);
         }
      }

      #endregion

      private class MockBehaviour
      {
         #region Public Properties

         public Action<Mock<T>> SetupMethodWithoutParameter { get; set; }

         public Action<Mock<T>, object> SetupMethodWithParameter { get; set; }

         public object Value { get; set; }

         #endregion
      }
   }
}