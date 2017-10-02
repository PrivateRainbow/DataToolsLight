using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Loader;
using Loader.Scanners;
using Loader.Serializers;
using Loader.Traversals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loader.Searchers;

namespace LoaderTest
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void DefaultXmlSerialization()
        {
            string filename;
            byte[] inContent = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(inContent))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var searcher = new NodeSearcher(new DepthFirstNodeTraverser());

                var targetNode = "book";
                var attributes = new Dictionary<string, string>()
                {
                    ["id"] = "bk102"
                };

                var searchNode = searcher.SearchTargetNode(node, targetNode, attributes);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                filename = Path.Combine(path, "out.xml");

                using (var writer = File.CreateText(filename))
                {
                    new DefaultXmlNodeSerializer(writer).Serialize(searchNode);
                }
            }

            using (var stream = File.OpenRead(filename))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                Assert.IsTrue(node != null);
                Assert.AreEqual("book", node.Name);
                Assert.AreEqual(6, node.Children.Count);
                Assert.AreEqual(2, node.Attributes.Count);
                Assert.AreEqual("Hello", node.Attributes["additionAttr"]);
            }
        }

    }
}