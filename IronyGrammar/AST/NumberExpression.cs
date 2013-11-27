using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
using EvaluationGrammar.AST;

namespace IronyParser.AST {
    public class NumberExpression : BaseNumberExpression, IAstNodeInit {

        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            SetValue(int.Parse(parseNode.Token.ValueString));
        }
    }
}