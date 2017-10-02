using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.IO;
using System.Text;
using Loader.Scanners;
using Loader.Traversals;
using Loader.Services.Factories;
using Loader.Types;
using Loader.Components;
using Loader.Searchers;

namespace LoaderTest
{
    [TestClass]
    public class TransactSqlNodeBuildFactoryTest
    {
        #region Consts
        private const string DATABASE_NAME = "NORTHWND";
        private const string TABLE = "Products";
        private const string COLUMN = "ProductID";
        private const string PRIMARY_KEY = "PK_Products";
        private const string FOREIGN_KEY = "FK_Products_Suppliers";
        private const string DEFAULT_CONSTRAINT = "DF_Products_UnitPrice";
        private const string CHECKED_CONSTRAINT = "CK_Products_UnitPrice";
        private const string INDEX = "CategoryID";
        #endregion

        #region Data
        private Node _dbNode, _tableNode, _viewNode,
                     _procedureNode, _columnNode,
                     _primaryKeyNode, _foreignKeyNode,
                     _defaultConstraintNode, _checkedConstraintNode,
                     _indexNode;

        private readonly BaseSqlNodeBuildFactory _buildFactory;
        #endregion

        #region Init

        public TransactSqlNodeBuildFactoryTest()
        {
            _buildFactory = new TransactSqlNodeBuildFactory();
            InitializeDbObjectsForTest();
        }

        private void InitializeDbObjectsForTest()
        {
            byte[] inContent = Encoding.UTF8.GetBytes(Resources.db);
            using (var stream = new MemoryStream(inContent))
            {
                var node = new DefaultXmlScanner(stream).Scan();
                var searcher = new NodeSearcher(new DepthFirstNodeTraverser());
                var targetNode = searcher.SearchTargetNode(node, DATABASE_NAME);

                _dbNode = targetNode;

                // header nodes
                var tableNodes = node.Children.Find(t => t.Name == DbSchemaConstants.Tables).Children;
                var viewNodes = node.Children.Find(t => t.Name == DbSchemaConstants.Views).Children;
                var procedureNodes = node.Children.Find(t => t.Name == DbSchemaConstants.Procedures).Children;

                //common nodes
                _tableNode = tableNodes.Find(t => t.Attributes[SqlQueryConstants.Name] == TABLE);

                _columnNode = _tableNode.Children.Find(c => c.Name == DbSchemaConstants.Columns)
                    .Children.Find(c => c.Attributes[SqlQueryConstants.Name] == COLUMN);

                _primaryKeyNode = _tableNode.Children.Find(k => k.Name == DbSchemaConstants.Keys)
                    .Children.Find(k => k.Attributes[SqlQueryConstants.Name] == PRIMARY_KEY);

                _foreignKeyNode = _tableNode.Children.Find(k => k.Name == DbSchemaConstants.Keys)
                    .Children.Find(k => k.Attributes[SqlQueryConstants.Name] == FOREIGN_KEY);

                _defaultConstraintNode = _tableNode.Children.Find(k => k.Name == DbSchemaConstants.Constraints)
                    .Children.Find(k => k.Attributes[SqlQueryConstants.Name] == DEFAULT_CONSTRAINT);

                _checkedConstraintNode = _tableNode.Children.Find(k => k.Name == DbSchemaConstants.Constraints)
                    .Children.Find(k => k.Attributes[SqlQueryConstants.Name] == CHECKED_CONSTRAINT);

                _indexNode = _tableNode.Children.Find(k => k.Name == DbSchemaConstants.Indexes)
                    .Children.Find(k => k.Attributes[SqlQueryConstants.Name] == INDEX);

            }
        }

        #endregion

        #region Tests
        [TestMethod]
        public void TransactSqlBuildDatabase()
        {
            const string db = "\r\nCREATE DATABASE NORTHWND;\r\n" +
                              "GO\r\n" +
                              "USE NORTHWND;\r\n";

            var dbObj = _buildFactory.BuildDatabase(_dbNode);
            var dbScript = RemoveCaptionFromBuildedScript(dbObj);

            Assert.AreEqual(db, dbScript);
        }

        [TestMethod]
        public void TransactSqlBuildTable() {

        }

        [TestMethod]
        public void TransactSqlBuildColumnInsideTable() {
            const string column = "[ProductID] int NOT NULL IDENTITY(1,1)";
            var columnScript = _buildFactory.BuildColumn(_columnNode, withParent: true);
            Assert.AreEqual(column, columnScript);
        }

        [TestMethod]
        public void TransactSqlBuildColumnOutsideTable()
        {
            const string column = "\r\nALTER TABLE [dbo].[Products] ADD [ProductID] int NOT NULL IDENTITY(1,1)\r\n";
            var columnObj = _buildFactory.BuildColumn(_columnNode, withParent: false);
            var columnScript = RemoveCaptionFromBuildedScript(columnObj);
            Assert.AreEqual(column, columnScript);
        }


        [TestMethod]
        public void TransactSqlBuildIndex() {
            const string index = "\r\nCREATE  INDEX [CategoryID] ON [dbo].[Products] ([CategoryID]);\r\nGO\r\n";
            var indexObj = _buildFactory.BuildIndex(_indexNode);
            var indexScript = RemoveCaptionFromBuildedScript(indexObj);
            Assert.AreEqual(index, indexScript);
        }

        [TestMethod]
        protected void TransactSqlBuildPrimaryKey() {
            const string key = "\r\nALTER TABLE [dbo].[Products] ADD CONSTRAINT PK_Products PRIMARY KEY(ProductID) CLUSTERED\r\nGO\r\n";
            var keyObj = _buildFactory.BuildKey(_primaryKeyNode);
            var keyScript = RemoveCaptionFromBuildedScript(keyObj);
            Assert.AreEqual(key, keyScript);
        }

        [TestMethod]
        protected void TransactSqlBuildForeignKey() {
            const string key = "\r\nALTER TABLE [dbo].[Products] ADD CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY ([SupplierID]) REFERENCES [Suppliers]([SupplierID]) ON DELETE NO_ACTION ON UPDATE NO_ACTION\r\nGO\r\n";
            var keyObj = _buildFactory.BuildKey(_foreignKeyNode);
            var keyScript = RemoveCaptionFromBuildedScript(keyObj);
            Assert.AreEqual(key, keyScript);
        }

        [TestMethod]
        protected void TransactSqlBuildDefaultConstraint() {
            var constraint = "\r\nALTER TABLE [dbo].[Products] ALTER COLUMN [UnitPrice] SET DEFAULT (0);\r\nGO\r\n";
            var constraintObj = _buildFactory.BuildConstraint(_defaultConstraintNode);
            var constraintScript = RemoveCaptionFromBuildedScript(constraintObj);
            Assert.AreEqual(constraint, constraintScript);
        }

        [TestMethod]
        protected void TransactSqlBuildCheckedConstraint() {
            var constraint = "\r\nALTER TABLE [dbo].[Products] ADD CONSTRAINT UnitPrice CHECK ([UnitPrice] >= 0);\r\nGO\r\n";
            var constraintObj = _buildFactory.BuildConstraint(_checkedConstraintNode);
            var constraintScript = RemoveCaptionFromBuildedScript(constraintObj);
            Assert.AreEqual(constraint, constraintScript);
        }

        #endregion

        #region Helpers

        private string RemoveCaptionFromBuildedScript(string source)
        {
            var symbol = '/';
            int first = source.IndexOf(symbol);
            int last = source.LastIndexOf(symbol);
            var pattern = source.Remove(first, first + last + 1);

            return pattern;
        }

        #endregion
    }
}
