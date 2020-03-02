using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opg_201910_interview.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace opg_201910_interview_UnitTest
{
    [TestClass]
    public class UnitTest_00001_DataProcessController : BaseUnitTest
    {
        [TestMethod]
        public void UnitTest_00001_DataProcessController_InstanceTest()
        {
            var controller = ActivatorUtilities.CreateInstance<DataProcessController>(ContainerService);

            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(DataProcessController));
        }

        [TestMethod]
        public async Task UnitTest_00001_DataProcessController_GetAllCustomer_Positive()
        {
            //Arrange
            var controller = ActivatorUtilities.CreateInstance<DataProcessController>(ContainerService);

            //Act
            var result = await controller.GetAllCustomer("1001");

            //Assert
            AcceptedResult result2 = result as AcceptedResult;
            Assert.AreEqual(202, result2.StatusCode);
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(DataProcessController));
        }

        [TestMethod]
        public async Task UnitTest_00001_DataProcessController_GetAllCustomer_Negative()
        {
            //Arrange
            var controller = ActivatorUtilities.CreateInstance<DataProcessController>(ContainerService);

            //Act
            var result = await controller.GetAllCustomer("3001");

            //Assert
            NotFoundResult result2 = result as NotFoundResult;
            Assert.AreEqual(404, result2.StatusCode);
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(DataProcessController));
        }
    }
}
