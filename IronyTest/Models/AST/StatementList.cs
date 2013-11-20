using System;
using System.Collections.Generic;
using System.Linq;
using Irony.Parsing;
using Irony.Ast;

namespace IronyTest.Models.AST {
    public class StatementList : BaseAST {
        private List<BaseAST> children = new List<BaseAST>();

        public override EvaluationResult Evaluate(Environment env)
        {
            foreach (var child in children) {
                child.Evaluate(env);
            }
            return null;
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            foreach (var child in parseNode.GetMappedChildNodes()) {
                if (child.AstNode == null) {
                    continue;
                }

                children.Add(child.AstNode as BaseAST);
            }
        }
    }
}