using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Irony.Parsing;
using Irony.Ast;
using IronyParser.AST;


namespace IronyParser
{
    [Language("ExpressionDemo", "1.0", "Language to test Irony in MVC")]
    internal class ExpressionGrammar : Grammar
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
            var WhileExpression = new NonTerminal("WhileExpression", typeof(WhileExpression));

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
            WhileExpression.Rule = ToTerm("while") + "(" + BoolExpr + ")" + "{" + Block + "}";
            GeneralStatement.Rule = Instruction | IfExpr | WhileExpression;
            Block.Rule = MakeStarRule(Block, GeneralStatement);

            RegisterOperators(1, "+", "-");
            RegisterOperators(2, "*", "/", "%");
            MarkPunctuation("(", ")", ";", "{", "}");
            RegisterBracePair("(", ")");
            RegisterBracePair("{", "}");

            MarkTransient(binop, relop, ParExpr, IfExpr, Instruction, Statement, Expr, GeneralStatement);
            MarkReservedWords("int", "if", "else", "while");

            Root = Block;
            LanguageFlags = LanguageFlags.CreateAst | LanguageFlags.NewLineBeforeEOF;

        }
    }
}
