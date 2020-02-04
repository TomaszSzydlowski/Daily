using Daily.Actions;
using Daily.Controller;
using Daily.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Daily.Tests
{
    [TestFixture]
    public class MainControllerTest
    {
        private ActionController mainController;

        [SetUp]
        public void Setup()
        {
            mainController = ActionController.GetInstance();
        }

        [Test]
        public void CreateAction_ReturnAddTaskAction()
        {
            var method = EActionMethod.ADD;
            Assert.IsInstanceOf<AddTask>(mainController.CreateAction(method));
        }

        [Test]
        public void CreateAction_ReturnFindTaskAction()
        {
            var method = EActionMethod.FIND;
            Assert.IsInstanceOf<FindTask>(mainController.CreateAction(method));
        }

        [Test]
        public void CreateAction_CheckAllEnumOptions_FindMissing()
        {
            var actionBases = new List<string>()
            {
                AddTask.GetInstance().GetType().ToString(),
                FindTask.GetInstance().GetType().ToString(),
            };

            string message = string.Empty;
            for (int i = 0; i < Enum.GetNames(typeof(EActionMethod)).Length; i++)
            {
                try
                {
                    var enumChecker = (EActionMethod)i;
                    message = $"Missing action {enumChecker.ToString()}";
                    var createActionTypeResult = mainController.CreateAction(enumChecker).GetType().ToString();

                    Assert.That(createActionTypeResult, Is.EqualTo(actionBases[i]));
                }
                catch (Exception)
                {
                    Assert.Fail(message);
                }
            }
        }
    }
}
