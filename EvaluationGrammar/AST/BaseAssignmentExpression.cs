using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar;


namespace EvaluationGrammar.AST
{
    public abstract class BaseAssignmentExpression : BaseAST
    {
        private BaseIdentifierExpression identifier;
        private Expression assignment;

        protected void SetValues(BaseIdentifierExpression identifier, Expression assignment)
        {
            this.identifier = identifier;
            this.assignment = assignment;
        }

        public override EvaluationResult Evaluate(Environment env)
        {
            identifier.AssignValue(env, assignment.Evaluate(env));
            return null;
        }

    }
}