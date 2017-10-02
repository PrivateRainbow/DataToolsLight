using System;
using System.IO;
using Loader;

using Loader.Factories;
using Loader.Parsers;
using Loader.Types;
using Loader.Components;
using Loader.Searchers;

namespace ConsoleClient
{
    internal sealed class SearchDataFileClient
    {
        #region Data

        private Node _node;
        private readonly NodeSearchContext _nodeSearchContext;
        private NodeSearchConfig _nodeSearchConfig;

        #endregion

        #region Init
        public SearchDataFileClient(NodeSearchContext searchContext)
        {
            if(searchContext == null)
                throw new ArgumentException($"{searchContext}");

            var config = GetParsedSearchConfig(searchContext);
            InitializeSearchConfig(config);
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

            if (!File.Exists(config.InputSource))
                throw new FileNotFoundException($"{nameof(config.InputSource)} has not been found");

            var inFileExt = Path.GetExtension(config.InputSource);
            if (inFileExt != ".xml")
                throw new ArgumentException($" Such file {nameof(config.InputSource)} has invalid file extention! *.xml was expected");

            if (config.HasOutputFile())
            {
                if (!config.OutputFile.EndsWith(inFileExt))
                {
                    var dot = config.OutputFile.IndexOf('.');
                    var name = config.OutputFile.Substring(0, dot) + inFileExt;
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
            try
            {
                InitializeNode();
                if (HasSearchTargets())
                {
                    if (FindNode())
                    {
                        if (HasOutputFile())
                            SerializeNodeToFile();
                        else
                            SerializeNodeToConsole();
                    }
                }
                else
                    SerializeNodeToConsole();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void InitializeNode()
        {
            try
            {
                using (var stream = File.OpenRead(_nodeSearchConfig.InputSource))
                {
                    var scanner = ScannerFactory.Make(SourceSchemaType.File, stream);
                    _node = scanner.Scan();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
        private void SerializeNodeToConsole()
        {
            try
            {
                var serializer = SerializerFactory.MakeSerializer(SourceSchemaType.File, Console.Out);
                serializer.Serialize(_node);
            }
            catch (IOException ex) { throw ex; }
            catch (UnauthorizedAccessException ex) { throw ex; }
        }
        private void SerializeNodeToFile()
        {
            try
            {
                using (var writer = File.CreateText(_nodeSearchConfig.OutputFile))
                {
                    var serializer = SerializerFactory.MakeSerializer(SourceSchemaType.File, writer);
                    serializer.Serialize(_node);
                }
            }
            catch (IOException) { throw; }
            catch (UnauthorizedAccessException ) { throw; }
        }
        private bool FindNode()
        {
            try
            {
                if (!Enum.TryParse(_nodeSearchConfig.TraverseStrategy, true, out TraversalStrategy traverseKey))
                    throw new ArgumentException($"{nameof(TraversalStrategy)} is not valid!");

                var nodeSearcher = new NodeSearcher(TraversalFactory.Make(traverseKey));
                _node = nodeSearcher.SearchTargetNode(_node, _nodeSearchConfig.TargetNode, _nodeSearchConfig.Targets);
                return _node != null;
            }
            catch (Exception ex) { throw ex; }
        }

        #endregion

        #region Helpers

        private bool HasSearchTargets() => !string.IsNullOrEmpty(_nodeSearchConfig.TargetNode) || _nodeSearchConfig.Targets != null;
        private bool HasOutputFile() => !string.IsNullOrEmpty(_nodeSearchConfig.OutputFile);

        #endregion
    }
}
