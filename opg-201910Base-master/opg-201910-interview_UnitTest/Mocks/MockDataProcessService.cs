using Microsoft.AspNetCore.Hosting;
using opg_201910_interview.Models;
using opg_201910_interview.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opg_201910_interview_UnitTest.Services
{
    public class MockDataProcessService : IDataProcessService
    {
        public MockDataProcessService()
        {
            
        }
        public async Task<HashSet<Tuple<string, string, string>>> GetAllFileName(ClientSettings clientSettings)
        {
            #region Declare Variables
            //Change depends on your user
            string tempPath = @"C:\Users\Dell\Desktop\FlexisourceIT_DotnetCoreExam\opg-201910Base-master\opg-201910-interview_UnitTest\bin\Debug\netcoreapp3.1";
            string contentRootPath = String.Empty;
            char ch = '.';
            string[] actualValue;
            string extension = String.Empty;
            string[] allowedFileName = null;
            HashSet<Tuple<string, string, string>> hashTuple = new HashSet<Tuple<string, string, string>>();
            #endregion

            #region Transform Data
            ch = Convert.ToChar(clientSettings.Delimiter);
            contentRootPath = @$"{tempPath}/{clientSettings.FileDirectoryPath}";
            extension = $"*.{clientSettings.ExtensionFile.ToString()}";
            allowedFileName = clientSettings.FileName.ToString().Split(',');
            #endregion

            DirectoryInfo d = new DirectoryInfo(contentRootPath);
            FileInfo[] Files = d.GetFiles(extension);
            foreach (FileInfo file in Files)
            {
                string fileName = file.Name;
                if (fileName.Contains(clientSettings.Delimiter))
                {
                    actualValue = fileName.Split(new char[] { ch }, 2);
                    if (allowedFileName.Contains(actualValue[0]))
                    {
                        hashTuple.Add(new Tuple<string, string, string>(fileName, actualValue[0], actualValue[1]));
                    }
                }
            }

            return hashTuple;
        }
    }
}
