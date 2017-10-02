using System;
using System.IO;

using Loader.Factories;
using Loader.Parsers;
using Loader.Types;
using Loader.Searchers;
using Loader.Components;
using Loader.Services.Types;
using System.Collections.Generic;

namespace DbClient
{
    internal sealed class SearchDataDbClient
    {
        #region Data

        private Node _node;
        private NodeSearchConfig _nodeSearchConfig;

        #endregion

        #region Init

        public SearchDataDbClient(NodeSearchContext searchContext)
        {
            if (searchContext == null)
                throw new ArgumentException($"{searchContext}");

            //var config = GetParsedSearchConfig(searchContext);

            var test = new NodeSearchConfig()
            {
                InputSource = @"Data Source=.\SQLEXPRESS;Initial Catalog=NORTHWND;Integrated Security=true;",
                OutputFile = "db.xml",
                TraverseStrategy = "depth",
            };

            InitializeSearchConfig(test);
        }
        private NodeSearchConfig GetParsedSearchConfig(NodeSearchContext searchContext)
        {
            var parser = new ConsoleArgsParser(searchContext.InputConsoleArgs, searchContext.KeyTokenCollection);
            if (!parser.TryParse())
                throw new ArgumentException($"{nameof(searchContext)} are not in valid state!");

            return parser.GetSearchConfig();
        }
       
        private void InitializeSearchConfig(NodeSearchConfig config)
        {
            if (config == null)
                throw new ArgumentException($"{nameof(config)}");

            if (string.IsNullOrEmpty(config.InputSource))
                throw new ArgumentException($"{nameof(config.InputSource)} must be initialized before using.");

            if (config.HasOutputFile())
            {
                if (!config.OutputFile.EndsWith(".xml"))
                {
                    var dot = config.OutputFile.IndexOf('.');
                    var name = config.OutputFile.Substring(0, dot) + ".xml";
                    Console.WriteLine(name);
                }
            }

            _nodeSearchConfig = new NodeSearchConfig()
            {
                InputSource = config.InputSource,
                OutputFile = config.OutputFile,
                TraverseStrategy = config.TraverseStrategy,
                TargetNode = config.TargetNode,
                Targets = config.Targets
            };
        }

        #endregion

        #region API

        public void Search()
        {
            Logger.Log.Info($"{nameof(SearchDataDbClient.Search)} ran!");

            try
            {                
                InitializeNode();
                if (!HasSearchTargets())
                {
                    Logger.Log.Info($"{nameof(SearchDataDbClient.HasSearchTargets)} no search targets!");
                    SerializeNodeToConsole();
                }
                else
                {
                    if (FindNode())
                    {
                        if (!HasOutputFile())
                            SerializeNodeToConsole();
                        else
                            SerializeNodeToFile();

                        WriteScriptToFile();
                    }
                    else
                        Logger.Log.Info($"{nameof(SearchDataDbClient.Search)} Node with such criterions was not founded!");
                }
                Logger.Log.Info($"{nameof(SearchDataDbClient.Search)} finished!");
            }
            catch (Exception ex)
            {
                Logger.Log.Error($"{nameof(SearchDataDbClient.Search)}", ex);
                throw;
            }
        }

        private void InitializeNode()
        {
            try
            {
                Logger.Log.Info($"{nameof(SearchDataDbClient.InitializeNode)} started!");

                var builder = DbNodeBuilderFactory.Make(DbNodeBuilderType.Bulk, _nodeSearchConfig.InputSource);
                var local = builder.MakeNode(new BuildContext(new Node(DbSchemaConstants.Databases), _nodeSearchConfig.InputSource));


                _node = new Node(DbSchemaConstants.Server);
                _node.AttachAttribute(new KeyValuePair<string, string>("connectionString", _nodeSearchConfig.InputSource));
                var databasesNode = new Node(DbSchemaConstants.Databases);

                _node.Add(databasesNode);
                databasesNode.Add(local[0]);              

                Logger.Log.Info($"{nameof(SearchDataDbClient.InitializeNode)} has got node from Db!");
            }
            catch(Exception ex)
            {
                Logger.Log.Error($"{nameof(SearchDataDbClient.Search)}", ex);
                throw;
            }
        }
        private void SerializeNodeToConsole()
        {
            try
            {
                Logger.Log.Info($"{nameof(SearchDataDbClient.SerializeNodeToConsole)} started to serialize node to Console.Out");

                var serializer = SerializerFactory.MakeSerializer(SourceSchemaType.Database, Console.Out);
                serializer.Serialize(_node);

                Logger.Log.Info($"{nameof(SearchDataDbClient.SerializeNodeToConsole)} finished serialization node to Console.Out");
            }
            catch (Exception ex)
            {
                Logger.Log.Error($"{nameof(SearchDataDbClient.Search)}", ex);
                throw;
            }
        }
        private void SerializeNodeToFile()
        {
            try
            {
                Logger.Log.Info($"{nameof(SearchDataDbClient.SerializeNodeToFile)} started to serialize node to output file ({_nodeSearchConfig.OutputFile})!");

                using (var writer = File.CreateText(_nodeSearchConfig.OutputFile))
                {
                    var serializer = SerializerFactory.MakeSerializer(SourceSchemaType.Database, writer);
                    serializer.Serialize(_node);
                }

                Logger.Log.Info($"{nameof(SearchDataDbClient.SerializeNodeToFile)} finished to serialize node to output file ({_nodeSearchConfig.OutputFile})!");
            }
            catch (Exception ex)
            {
                Logger.Log.Error($"{nameof(SearchDataDbClient.Search)}", ex);
                throw;
            }
        }

        private bool FindNode()
        {
            try
            {
                Logger.Log.Info($"{nameof(SearchDataDbClient.FindNode)} started to find node!");

                if (!Enum.TryParse(_nodeSearchConfig.TraverseStrategy, true, out TraversalStrategy traverseKey))
                    throw new ArgumentException($"{nameof(TraversalStrategy)} is not valid!");

                var nodeSearcher = new NodeSearcher(TraversalFactory.Make(traverseKey));
                var filteredNode = nodeSearcher.SearchTargetNode(_node, _nodeSearchConfig.TargetNode, _nodeSearchConfig.Targets);

                if (filteredNode != null)
                    _node = filteredNode;

                Logger.Log.Info($"{nameof(SearchDataDbClient.FindNode)} {(_node != null ? " Found" : "Not Found")}");
                return _node != null;
            }
            catch (Exception ex)
            {
                Logger.Log.Error($"{nameof(SearchDataDbClient.Search)}", ex);
                throw;
            }
        }
        private void WriteScriptToFile()
        {
            try
            {
                Logger.Log.Info($"{nameof(SearchDataDbClient.WriteScriptToFile)} started to write sql for node!");

                /*var script = _dbSchemaService.MakeSqlScript(_node);
                File.WriteAllText("script.txt", script);*/

                Logger.Log.Info($"{nameof(SearchDataDbClient.WriteScriptToFile)} finished to write sql for node!");
            }
            catch (Exception ex)
            {
                Logger.Log.Error($"{nameof(SearchDataDbClient.Search)}", ex);
                throw;
            }
        }
        #endregion

        #region Helpers

        private bool HasSearchTargets() => !string.IsNullOrEmpty(_nodeSearchConfig.TargetNode) || _nodeSearchConfig.Targets != null;
        private bool HasOutputFile() => !string.IsNullOrEmpty(_nodeSearchConfig.OutputFile);

        #endregion
    }
}
