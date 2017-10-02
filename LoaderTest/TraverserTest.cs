using System;
using System.IO;
using System.Text;
using Loader.Scanners;
using Loader.Traversals;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoaderTest
{
    [TestClass]
    public class TraverserTest
    {
        [TestMethod]
        public void PositiveBreadthFirstSearch()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var traverser = new BreadthFirstNodeTraverser();

                var searchNode = traverser.Traverse(node, n => n.Name == "book");
                Assert.IsTrue(searchNode != null);
                Assert.AreEqual(6, searchNode.Children.Count);
                Assert.AreEqual(1, searchNode.Attributes.Count);
            }
        }

        [TestMethod]
        public void NegativeBreadthFirstSearch()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var traverser = new BreadthFirstNodeTraverser();

                var searchNode = traverser.Traverse(node, n => n.Name == "unknown");
                Assert.IsTrue(searchNode == null);
            }
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidBreadthFirstSearch()
        {
            var breadthTraverser = new BreadthFirstNodeTraverser();
            breadthTraverser.Traverse(null, null);
        }

        [TestMethod]
        public void PositiveDepthFirstSearch()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var traverser = new DepthFirstNodeTraverser();

                var searchNode = traverser.Traverse(node, n => n.Name == "book");
                Assert.IsTrue(searchNode != null);
                Assert.AreEqual(6, searchNode.Children.Count);
                Assert.AreEqual(1, searchNode.Attributes.Count);
            }
        }

        [TestMethod]
        public void NegativeDepthFirstSearch()
        {
            byte[] content = Encoding.UTF8.GetBytes(Resources.in0);
            using (var stream = new MemoryStream(content))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var traverser = new DepthFirstNodeTraverser();

                var searchNode = traverser.Traverse(node, n => n.Name == "unknown");
                Assert.IsTrue(searchNode == null);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InvalidDepthFirstSearch()
        {
            var breadthTraverser = new DepthFirstNodeTraverser();
            breadthTraverser.Traverse(null, null);
        }
    }
}