using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using Irony.Ast;
using IronyTest.Models.AST;
using IronyTest.Models.Errors;


namespace IronyTest.Models
{

    class ExpressionEvaluator
    {
        [Language("ExpressionDemo", "1.0", "Language to test Irony in MVC")]
        private class ExpressionGrammar : Grammar
        {
            public ExpressionGrammar()
            {
                var number = new NumberLiteral("number", NumberOptions.IntOnly);
                number.AstConfig.NodeType = typeof(NumberExpression);

                var identifier = new IdentifierTerminal("identifier");
                identifier.AstConfig.NodeType = typeof(IdentifierExpression);

                var binop = new NonTerminal("binop");
                binop.Rule = ToTerm("+") | "*" | "/" | "%" | "-";
 
                // non terminals
                var Expr = new NonTerminal("Expr");
                var Declaration = new NonTerminal("DeclExpr", typeof(DeclarationStatement));
                var Initialization = new NonTerminal("Initialization", typeof(InitializationStatement));
                var Program = new NonTerminal("Program", typeof(StatementList));
                var BinExpr = new NonTerminal("BinExpr", typeof(BinaryExpression));
                var ParExpr = new NonTerminal("ParExpr");
                var Assignment = new NonTerminal("Assignment", typeof(AssignmentExpression));
                var Statement = new NonTerminal("Statement");
                var Instruction = new NonTerminal("Instruction");

                // Grammar definition
                Expr.Rule = BinExpr | number | ParExpr | identifier;
                Declaration.Rule = "int" + identifier;
                Initialization.Rule = "int" + identifier + "=" + Expr;
                ParExpr.Rule = "(" + Expr + ")";
                BinExpr.Rule = Expr + binop + Expr;
                Assignment.Rule = identifier + "=" + Expr;
                Statement.Rule = Assignment | Declaration | Initialization;
                Instruction.Rule = Statement + ";";
                Program.Rule = MakeStarRule(Program, Instruction);

                RegisterOperators(1, "+", "-");
                RegisterOperators(2, "*", "/", "%");
                MarkPunctuation("(", ")", ";");
                RegisterBracePair("(", ")");

                MarkTransient(binop, ParExpr, Instruction, Statement, Expr);
                MarkReservedWords("int");

                Root = Program;
                LanguageFlags = LanguageFlags.CreateAst | LanguageFlags.NewLineBeforeEOF;

            }
        }

        private static ExpressionGrammar grammar = new ExpressionGrammar();
        private string expression;
        private Environment env;

        public ExpressionEvaluator(string expression)
        {
            this.expression = expression;
            env = new Environment();
            env.DefineVariable("result");

        }

        public int? Evaluate()
        {
            Parser p = new Parser(grammar);
            var tree = p.Parse(expression);
            if (tree.HasErrors()) {
                throw new InvalidOperationException(string.Join("\n", tree.ParserMessages));
            }
            var ast = tree.Root.AstNode as BaseAST;
            if (ast == null)
            {
                throw new InvalidOperationException("Unable to parse");
            }
            
            ast.Evaluate(env);
            try {
                return env.GetValue("result");
            } catch (UninitializedVariableUseException) {
                return null;
            }
        }
    }
}