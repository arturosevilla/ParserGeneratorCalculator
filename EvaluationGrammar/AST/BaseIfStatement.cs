using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationGrammar.AST {
    public class BaseIfStatement : BaseAST {
        private BaseBooleanExpression Condition;
        private BaseAST OnTrue;
        private BaseAST OnFalse;

        protected void SetValues(BaseBooleanExpression condition, BaseAST onTrue, BaseAST onFalse)
        {
            Condition = condition;
            OnTrue = onTrue;
            OnFalse = onFalse;
        }

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
    }
}