using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
using EvaluationGrammar.AST;

namespace IronyParser.AST
{
    public class DeclarationStatement : BaseDeclarationStatement, IAstNodeInit
    {
        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            SetValue(parseNode.ChildNodes[1].FindTokenAndGetText());
        }
    }
}