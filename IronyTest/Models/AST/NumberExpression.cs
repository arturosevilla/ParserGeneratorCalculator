using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.Models.AST {
    public class NumberExpression : Expression {
        private int value;

        public override EvaluationResult Evaluate(Environment env)
        {
            return new EvaluationResult {
                Result = value
            };
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            value = int.Parse(parseNode.Token.ValueString);
        }
    }
}