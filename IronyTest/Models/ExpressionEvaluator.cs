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

                var relop = new NonTerminal("RELOP");
                relop.Rule = ToTerm("==") | "!=" | ">" | "<" | ">=" | "<=";
 
                // non terminals
                var Expr = new NonTerminal("Expr");
                var Declaration = new NonTerminal("DeclExpr", typeof(DeclarationStatement));
                var Initialization = new NonTerminal("Initialization", typeof(InitializationStatement));
                var Block = new NonTerminal("Block", typeof(StatementList));
                var BinExpr = new NonTerminal("BinExpr", typeof(BinaryExpression));
                var ParExpr = new NonTerminal("ParExpr");
                var IfExpr = new NonTerminal("IfExpression");
                var IfExprWithElse = new NonTerminal("IfExpressionWithElse", typeof(IfStatement));
                var IfExprWOElse = new NonTerminal("IfExpressionWithoutElse", typeof(IfStatement));
                var Assignment = new NonTerminal("Assignment", typeof(AssignmentExpression));
                var Statement = new NonTerminal("Statement");
                var Instruction = new NonTerminal("Instruction");
                var BoolExpr = new NonTerminal("BooleanExpression", typeof(BooleanExpression));
                var GeneralStatement = new NonTerminal("GeneralStatement");

                // Grammar definition
                Expr.Rule = BinExpr | number | ParExpr | identifier;
                Declaration.Rule = "int" + identifier;
                Initialization.Rule = "int" + identifier + "=" + Expr;
                ParExpr.Rule = "(" + Expr + ")";
                BinExpr.Rule = Expr + binop + Expr;
                BoolExpr.Rule = Expr + relop + Expr;
                Assignment.Rule = identifier + "=" + Expr;
                IfExpr.Rule = IfExprWithElse | IfExprWOElse;
                IfExprWithElse.Rule = ToTerm("if") + "(" + BoolExpr + ")" + "{" + Block + "}" +
                                      "else" + "{" + Block + "}";
                IfExprWOElse.Rule = ToTerm("if") + "(" + BoolExpr + ")" + "{" + Block + "}";
                Statement.Rule = Assignment | Declaration | Initialization | IfExpr;
                Instruction.Rule = Statement + ";";
                GeneralStatement.Rule = Instruction | IfExpr;
                Block.Rule = MakeStarRule(Block, GeneralStatement);

                RegisterOperators(1, "+", "-");
                RegisterOperators(2, "*", "/", "%");
                MarkPunctuation("(", ")", ";", "{", "}");
                RegisterBracePair("(", ")");
                RegisterBracePair("{", "}");

                MarkTransient(binop, relop, ParExpr, IfExpr, Instruction, Statement, Expr, GeneralStatement);
                MarkReservedWords("int", "if", "else");

                Root = Block;
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