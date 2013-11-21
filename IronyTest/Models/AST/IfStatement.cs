using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.Models.AST {
    public class IfStatement : BaseAST {
        private BooleanExpression Condition;
        private BaseAST OnTrue;
        private BaseAST OnFalse;

        public override EvaluationResult Evaluate(Environment env)
        {
            bool resultCondition = (bool)Condition.Evaluate(env).Result;
            if (resultCondition) {
                OnTrue.Evaluate(env);
            } else if (OnFalse != null) {
                OnFalse.Evaluate(env);
            }
            return null;
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            // if ( b ) { t } else { f }
            Condition = parseNode.ChildNodes[1].AstNode as BooleanExpression;
            OnTrue = parseNode.ChildNodes[2].AstNode as BaseAST;
            if (parseNode.ChildNodes.Count > 3) {
                OnFalse = parseNode.ChildNodes[4].AstNode as BaseAST;
            } else {
                OnFalse = null;
            }
        }
    }
}