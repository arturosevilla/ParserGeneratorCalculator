using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
using EvaluationGrammar.AST;

namespace IronyParser.AST {
    public class IfStatement : BaseIfStatement, IAstNodeInit
    {
        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            // if ( b ) { t } else { f }
            BaseAST onFalse;
            if (parseNode.ChildNodes.Count > 3) {
                onFalse = parseNode.ChildNodes[4].AstNode as BaseAST;
            } else {
                onFalse = null;
            }
            SetValues(
                parseNode.ChildNodes[1].AstNode as BooleanExpression,
                parseNode.ChildNodes[2].AstNode as BaseAST,
                onFalse
            );
        }
    }
}