using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationGrammar.AST {
    public abstract class BaseNumberExpression : Expression {
        private int value;

        public override EvaluationResult Evaluate(Environment env)
        {
            return new EvaluationResult {
                Result = value
            };
        }

        protected void SetValue(int value)
        {
            this.value = value;
        }

    }
}