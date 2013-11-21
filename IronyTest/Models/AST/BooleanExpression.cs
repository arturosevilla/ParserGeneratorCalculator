using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.Models.AST {
    public class BooleanExpression : BaseAST {
        private Expression Left, Right;
        private string RELOP;

        public override EvaluationResult Evaluate(Environment env)
        {
            int left = (int)Left.Evaluate(env).Result;
            int right = (int)Right.Evaluate(env).Result;
            bool result;
            switch (RELOP) {
                case "==":
                    result = left == right;
                    break;
                case "!=":
                    result = left != right;
                    break;
                case ">":
                    result = left > right;
                    break;
                case "<":
                    result = left < right;
                    break;
                case ">=":
                    result = left >= right;
                    break;
                case "<=":
                    result = left <= right;
                    break;
                default:
                    throw new InvalidOperationException("Unknown operator: " + RELOP);
            }
            return new EvaluationResult {
                Result = result
            };
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Left = parseNode.ChildNodes[0].AstNode as Expression;
            Right = parseNode.ChildNodes[2].AstNode as Expression;
            RELOP = parseNode.ChildNodes[1].FindTokenAndGetText();
        }
    }
}