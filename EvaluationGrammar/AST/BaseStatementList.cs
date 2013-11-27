using System;
using System.Collections.Generic;
using System.Linq;

namespace EvaluationGrammar.AST {
    public abstract class BaseStatementList : BaseAST {
        private List<BaseAST> children;

        public override EvaluationResult Evaluate(Environment env)
        {
            foreach (var child in children) {
                child.Evaluate(env);
            }
            return null;
        }

        protected void SetStatements(List<BaseAST> statements)
        {
            children = statements;
        }

   }
}