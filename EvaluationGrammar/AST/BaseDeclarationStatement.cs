using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace EvaluationGrammar.AST
{
    public abstract class BaseDeclarationStatement : BaseAST
    {
        private string variable;

        protected void SetValue(string variableName)
        {
            variable = variableName;
        }

        public override EvaluationResult Evaluate(Environment env)
        {
            env.DefineVariable(variable);
            return null;
        }

    }
}