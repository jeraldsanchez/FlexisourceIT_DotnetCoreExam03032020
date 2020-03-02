using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using opg_201910_interview.Controllers;
using opg_201910_interview.Models;
using opg_201910_interview.Services;
using opg_201910_interview_UnitTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace opg_201910_interview_UnitTest
{
    [TestClass]
    public abstract class BaseUnitTest
    {
        public ServiceProvider ContainerService;

        [TestInitialize]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddLogging();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<DataProcessController>();
            services.AddTransient<IDataProcessRepository, DataProcessRepository>();
            services.AddTransient<IDataProcessService, MockDataProcessService>();

            services.AddTransient(provider => Options.Create(new List<ClientSettings>
            {
                new ClientSettings()
                {
                    ClientId = "1001",
                    FileDirectoryPath = "UploadFiles/ClientA",
                    Delimiter = "-",
                    FileName = "shovel,waghor,blaze,discus",
                    ExtensionFile = "xml"
                },
                new ClientSettings()
                {
                    ClientId = "2001",
                    FileDirectoryPath = "UploadFiles/ClientB",
                    Delimiter = "_",
                    FileName = "orca,widget,eclair,talon",
                    ExtensionFile = "xml"
                }
            }));

            ContainerService = services.BuildServiceProvider();
        }

        [TestCleanup]
        public void Cleanup()
        {

        }
    }
}
