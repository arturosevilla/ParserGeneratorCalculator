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
