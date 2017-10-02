using Loader.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoaderTest
{
    [TestClass]
    public class ArgsParserTest
    {
        [TestMethod]
        public void ValidArgs()
        {
            /*var source = "-in input.xml -str depth -attr key1=value1 key2=value2 -out out.xml";
            var client = new ConsoleClient.Program();
            
            var result = new ConsoleArgsParser(source).TryParse();
            Assert.IsTrue(result);*/
        }

        [TestMethod]
        public void KeyRepetition()
        {
            /*var source = "-in -str depth -attr key1=value1 key2=value2 -out out.xml";
            var result = new ConsoleArgsParser(source).TryParse();
            Assert.IsTrue(!result);*/
        }

        [TestMethod]
        public void IncorrectOrderOfValues()
        {
            /*var source = "-in input.xml -str depth deadth -attr key1=value1 key2=value2 -out out.xml";
            var result = new ConsoleArgsParser(source).TryParse();
            Assert.IsTrue(!result);*/
        }
    }
}