using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.Models.AST
{
    public class IdentifierExpression : Expression
    {
        private string variable;

        public override EvaluationResult Evaluate(Environment env)
        {
            return new EvaluationResult {
                Result = env.GetValue(variable)
            };
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            variable = parseNode.Token.ValueString;
        }

        public void AssignValue(Environment env, EvaluationResult evaluationResult)
        {
            env.AssignValue(variable, (int)evaluationResult.Result);
        }
    }
}