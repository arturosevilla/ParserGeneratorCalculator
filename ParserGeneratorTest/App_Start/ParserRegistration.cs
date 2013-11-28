using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParserGeneratorTest.Models;
using System.Web.Compilation;
using System.Reflection;
using EvaluationGrammar;

namespace ParserGeneratorTest
{
    public class ParserRegistration
    {
        public static void RegisterParsers()
        {
            var repository = new AvailableParserRepository();
            var assemblies = GetAssemblies();
            var parserType = typeof(IParser);
            var parsers = from assembly in assemblies
                          from type in assembly.GetTypes()
                          where parserType.IsAssignableFrom(type) && type != parserType
                          select Activator.CreateInstance(type) as IParser;
            foreach (var parser in parsers) {
                repository.RegisterParser(parser);
            }
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            return BuildManager.GetReferencedAssemblies().Cast<Assembly>();
        }
    }
}