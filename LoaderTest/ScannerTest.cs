using System;
using System.IO;
using System.Text;
using Loader.Scanners;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoaderTest
{
    [TestClass]
    public class ScannerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NegativeScan()
        {
            var node = new DefaultXmlScanner(null).Scan();
        }

        [TestMethod]
        public void PositiveScan()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(null).Scan();
                Assert.IsTrue( node != null);
                Assert.AreEqual( 12, node.Children.Count);
            }
        }
    }
}