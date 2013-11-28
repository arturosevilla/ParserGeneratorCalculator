using EvaluationGrammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParserGeneratorTest.Models
{
    public class AvailableParserRepository
    {
        private static Dictionary<Guid, IParser> parsers = new Dictionary<Guid, IParser>();

        public void RegisterParser(IParser parser)
        {
            if (parsers.ContainsKey(parser.Id)) {
                return;
            }
            parsers[parser.Id] = parser;
        }

        public IEnumerable<IParser> GetAllParsers()
        {
            return parsers.Select(p => p.Value);
        }

        public IParser GetParser(Guid id)
        {
            if (!parsers.ContainsKey(id)) {
                return null;
            }
            return parsers[id];
        }

    }
}