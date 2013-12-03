using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationGrammar.AST
{
    public abstract class BaseWhileExpression : BaseAST
    {
        private BaseBooleanExpression condition;
        private BaseStatementList block;

        protected void SetValues(BaseBooleanExpression condition, BaseStatementList block)
        {
            this.condition = condition;
            this.block = block;
        }

        public override EvaluationResult Evaluate(Environment env)
        {
            while ((bool)condition.Evaluate(env).Result) {
                block.Evaluate(env);
            }
            return null;
        }
    }
}
