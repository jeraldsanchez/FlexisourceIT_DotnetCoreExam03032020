using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using opg_201910_interview.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace opg_201910_interview_UnitTest.Service
{
    [TestClass]
    public class UnitTest_00001_DataProcessRepository : BaseUnitTest
    {
        [TestMethod]
        public async Task UnitTest_00001_DataProcessRepository_Positive()
        {
            // Arrange
            IDataProcessRepository service = ContainerService.GetService<IDataProcessRepository>();

            // Act
            var value = service.GetClientSettings("2001");

            // Assert
            Assert.IsNotNull(value);
        }
    }
}
