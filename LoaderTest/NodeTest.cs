using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loader;
using Loader.Components;

namespace LoaderTest
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddingSublings()
        {
            var root = new Node("Root");
            var child0 = new Node("Child0");
            var child1 = new Node("Child1");

            root.Add(child0);
            root.Add(child1);
            child0.Add(child1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddOneMoreParent()
        {
            var root0 = new Node("Root0");
            var root1 = new Node("Root1");
            var child0 = new Node("Child0");

            root0.Add(child0);
            root1.Add(child0);
        }

        [TestMethod]
        public void AddingNodes()
        {
            var root = new Node("Root");
            var child0 = new Node("ch0");
            var child1 = new Node("ch1");

            root.Add(child0);
            root.Add(child1);
            Assert.AreEqual(2, root.Children.Count);

            child0.Add(new Node("ch01"));
            child0.Add(new Node("ch02"));
            Assert.AreSame(root, child0.Parent);
            Assert.AreEqual(2, child0.Children.Count);
        }

        [TestMethod]
        public void RemovingNodes()
        {
            var root = new Node("Root");
            var child0 = new Node("ch0");
            var child1 = new Node("ch1");

            root.Add(child0);
            root.Add(child1);
            Assert.AreEqual(2, root.Children.Count);

            root.Remove(child1);
            Assert.AreEqual(1, root.Children.Count);
        }
    }
}
