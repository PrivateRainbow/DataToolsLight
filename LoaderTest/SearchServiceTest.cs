using System;
using System.IO;
using Loader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ConsoleClient;

namespace LoaderTest
{
    [TestClass]
    public class SearchServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NotValidInFile()
        {
            /*var config = new NodeSearchConfig {InputSource = null};
            var service = new SearchDataFileClient(config);*/
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotExist()
        {
            /*var config = new NodeSearchConfig();
            config.InputSource = "test.abc";
            var service = new SearchDataFileClient(config);*/
        }
    }
}