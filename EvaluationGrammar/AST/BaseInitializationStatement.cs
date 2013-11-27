using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationGrammar.AST
{
    public abstract class BaseInitializationStatement : BaseAST
    {
        private BaseIdentifierExpression identifier;
        private Expression initialization;

        protected void SetValues(BaseIdentifierExpression identifier, Expression initialization)
        {
            this.identifier = identifier;
            this.initialization = initialization;
        }

        public override EvaluationResult Evaluate(Environment env)
        {
            int value = (int)initialization.Evaluate(env).Result;
            var symbol = identifier.GetIdentifierSymbol();
            env.DefineVariable(symbol);
            env.AssignValue(symbol, value);
            return null;
        }

    }
}