using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluationGrammar;
using EvaluationGrammar.AST;
using IronyGrammarParser = Irony.Parsing.Parser;

namespace IronyParser
{
    public class Parser : IParser
    {
        private static ExpressionGrammar grammar = new ExpressionGrammar();
        private static IronyGrammarParser parser;
        static Parser()
        {
            parser = new IronyGrammarParser(grammar);
        }

        public string Name
        {
            get { return "Irony Parser"; }
        }

        public Guid Id
        {
            get { return new Guid("6CF1AB86-BFB4-4510-B5B4-D7FB68E7ECDF"); }
        }

        public BaseAST Parse(string code)
        {
            var tree = parser.Parse(code);
            if (tree.HasErrors()) {
                throw new InvalidOperationException(string.Join("\n", tree.ParserMessages));
            }
            var ast = tree.Root.AstNode as BaseAST;
            if (ast == null) {
                throw new InvalidOperationException("Unable to parse");
            }

            return ast;
        }
    }
}
