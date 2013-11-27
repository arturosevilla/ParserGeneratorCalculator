﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;
using EvaluationGrammar.AST;

namespace IronyParser.AST {
    public class BooleanExpression : BaseBooleanExpression, IAstNodeInit {
        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            SetValues(
                parseNode.ChildNodes[0].AstNode as Expression,
                parseNode.ChildNodes[2].AstNode as Expression,
                parseNode.ChildNodes[1].FindTokenAndGetText()
            );
        }
    }
}