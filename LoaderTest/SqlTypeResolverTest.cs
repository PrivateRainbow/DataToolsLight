using Loader;

using Loader.Scanners;
using Loader.Traversals;
using Loader.Services.Helpers;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using Loader.Types;
using Loader.Components;
using Loader.Searchers;

namespace LoaderTest
{
    [TestClass]
    public class SqlTypeResolverTest
    {
        private const string TABLE_NAME = "Orders";

        private Node _characterNode, _commonNode;

        #region Init
        public SqlTypeResolverTest()
        {
            InitializeDbObjects();
        }

        private void InitializeDbObjects()
        {
            byte[] inContent = Encoding.UTF8.GetBytes(Resources.db);
            using (var stream = new MemoryStream(inContent))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var searcher = new NodeSearcher(new DepthFirstNodeTraverser());

                var attributes = new Dictionary<string, string>
                {
                    {"tableName", TABLE_NAME}
                };

                var targetNode = searcher.SearchTargetNode(node, targetAttributes: attributes);

                _characterNode = targetNode.Children.Find(c => c.Name == DbSchemaConstants.Columns)
                    .Children.Find(c => c.Attributes[SqlQueryConstants.Name] == "ShipAddress");

                _commonNode = targetNode.Children.Find(c => c.Name == DbSchemaConstants.Columns)
                    .Children.Find(c => c.Attributes[SqlQueryConstants.Name] == "ShipVia");
            }
        }

        #endregion

        #region Tests

        [TestMethod]
        public void FormatCharacterTypeTest()
        {
            const string pattern = "[ShipAddress] nvarchar(120)";
            var script = SqlNodeTypeResolver.ResolveColumnNodeType(_characterNode);

            Assert.AreEqual(pattern, script);
        }

        [TestMethod]
        public void FormatPrecisionTypeTest()
        {
            var node = new Node("column")
            {
                Attributes = new System.Collections.Generic.Dictionary<string, string>
                {
                    {"name", "ArtifName" },
                    {"type", "decimal"},
                    {"precision", "14"},
                    {"scale", "2"},
                    {"is_nullable", "False"},
                }
            };
            const string pattern = "[ArtifName] decimal(14,2) NOT NULL";
            var script = SqlNodeTypeResolver.ResolveColumnNodeType(node);
            Assert.AreEqual(pattern, script);
        }

        [TestMethod]
        public void FormatCommonTypeTest()
        {
            const string pattern = "[ShipVia] int";
            var script = SqlNodeTypeResolver.ResolveColumnNodeType(_commonNode);

            Assert.AreEqual(pattern, script);
        }

        #endregion

    }
}
