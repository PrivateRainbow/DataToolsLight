using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Loader;
using Loader.Scanners;
using Loader.Traversals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loader.Searchers;

namespace LoaderTest
{
    [TestClass]
    public class NodeSearcherTest
    {
        [TestMethod]
        public void PotitiveSearchByName()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var searcher = new NodeSearcher(new DepthFirstNodeTraverser());
                var searchNode = searcher.SearchTargetNode(node, "book");
                
                Assert.IsTrue(searchNode != null);
                Assert.AreEqual(6, searchNode.Children.Count);
                Assert.AreEqual(1, searchNode.Attributes.Count);
                Assert.AreEqual("bk101", searchNode.Attributes["id"]);
            }
        }
        [TestMethod]
        public void PotitiveSearchByAttributes()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var searcher = new NodeSearcher(new DepthFirstNodeTraverser());

                var attributes = new Dictionary<string, string>()
                {
                    ["id"] = "bk102"
                };

                var searchNode = searcher.SearchTargetNode(node, targetAttributes:attributes);

                Assert.IsTrue(searchNode != null);
                Assert.AreEqual(6, searchNode.Children.Count);
                Assert.AreEqual(2, searchNode.Attributes.Count);
                Assert.AreEqual("bk102", searchNode.Attributes["id"]);
            }
        }

        [TestMethod]
        public void PotitiveSearchByNameAndAttributes()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var searcher = new NodeSearcher(new DepthFirstNodeTraverser());

                var targetNode = "book";
                var attributes = new Dictionary<string, string>()
                {
                    ["id"] = "bk102"
                };

                var searchNode = searcher.SearchTargetNode(node, targetNode, attributes);

                Assert.IsTrue(searchNode != null);
                Assert.AreEqual(6, searchNode.Children.Count);
                Assert.AreEqual(2, searchNode.Attributes.Count);
                Assert.AreEqual("bk102", searchNode.Attributes["id"]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidSearch()
        {
            var searcher = new NodeSearcher(new DepthFirstNodeTraverser());
            var searchNode = searcher.SearchTargetNode(null);
        }
    }
}