using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrammarEnvironment = EvaluationGrammar.Environment;
using EvaluationGrammar.Errors;


namespace IronyTest.Models
{
    class ExpressionEvaluator
    {
        private string expression;
        private GrammarEnvironment env;

        public ExpressionEvaluator(string expression)
        {
            this.expression = expression;
            env = new GrammarEnvironment();
            env.DefineVariable("result");

        }

        public int? Evaluate()
        {
            var ast = new IronyParser.Parser().Parse(expression);
            
            ast.Evaluate(env);
            try {
                return env.GetValue("result");
            } catch (UninitializedVariableUseException) {
                return null;
            }
        }
    }
}