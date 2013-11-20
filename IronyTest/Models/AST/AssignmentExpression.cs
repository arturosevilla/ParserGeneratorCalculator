using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using Irony.Ast;

namespace IronyTest.Models.AST
{
    public class AssignmentExpression : BaseAST
    {
        private IdentifierExpression variable;
        private Expression assignment;

        public override EvaluationResult Evaluate(Environment env)
        {
            variable.AssignValue(env, assignment.Evaluate(env));
            return null;
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            variable = parseNode.ChildNodes[0].AstNode as IdentifierExpression;
            assignment = parseNode.ChildNodes[2].AstNode as Expression;
        }
    }
}