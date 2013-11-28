using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;
using Irony.Ast;
using EvaluationGrammar.AST;


namespace IronyParser.AST
{
    public class AssignmentExpression : BaseAssignmentExpression, IAstNodeInit
    {
        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            SetValues(
                parseNode.ChildNodes[0].AstNode as IdentifierExpression,
                parseNode.ChildNodes[2].AstNode as Expression
            );
        }
    }
}