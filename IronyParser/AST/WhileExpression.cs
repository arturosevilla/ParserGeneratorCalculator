using EvaluationGrammar.AST;
using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronyParser.AST
{
    public class WhileExpression : BaseWhileExpression, IAstNodeInit
    {
    
        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            SetValues(
                parseNode.ChildNodes[1].AstNode as BooleanExpression,
                parseNode.ChildNodes[2].AstNode as StatementList
            );
        }
    }
}
