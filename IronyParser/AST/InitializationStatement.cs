using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
using EvaluationGrammar.AST;

namespace IronyParser.AST
{
    public class InitializationStatement : BaseInitializationStatement, IAstNodeInit
    {
        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            SetValues(
                parseNode.ChildNodes[1].AstNode as IdentifierExpression,
                parseNode.ChildNodes[3].AstNode as Expression
            );
        }
    }
}