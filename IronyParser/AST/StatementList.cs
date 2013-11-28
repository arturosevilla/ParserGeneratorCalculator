using System;
using System.Collections.Generic;
using System.Linq;
using Irony.Parsing;
using Irony.Ast;
using EvaluationGrammar.AST;

namespace IronyParser.AST {
    public class StatementList : BaseStatementList, IAstNodeInit {
        public void Init(AstContext context, ParseTreeNode parseNode)
        {
            var statements = new List<BaseAST>();
            foreach (var child in parseNode.GetMappedChildNodes()) {
                if (child.AstNode == null) {
                    continue;
                }

                statements.Add(child.AstNode as BaseAST);
            }
            SetStatements(statements);
        }
    }
}