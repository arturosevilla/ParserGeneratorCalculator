using EvaluationGrammar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluationGrammar.AST;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace AntlrParser
{
    public class Parser : IParser
    {
        public BaseAST Parse(string code)
        {
            var codeStream = new ANTLRStringStream(code);
            var lexer = new EvaluationGrammarLexer(codeStream);
            if (lexer.NumberOfSyntaxErrors > 0) {
                return null;
            }
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new EvaluationGrammarParser(tokenStream);
            var parseTree = (CommonTree)parser.program().Tree;
            if (parser.NumberOfSyntaxErrors > 0) {
                return null;
            }
            var nodes = new CommonTreeNodeStream(parseTree);
            var astGenerator = new ASTGenerator(nodes);
            return astGenerator.getAST();
        }

        public string Name
        {
            get { return "ANTLR Parser"; }
        }

        public Guid Id
        {
            get { return new Guid("BA497A10-BBDD-43BA-B4A1-64C516FBFB50"); }

        }
    }
}
