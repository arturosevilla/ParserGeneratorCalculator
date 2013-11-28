using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrammarEnvironment = EvaluationGrammar.Environment;
using EvaluationGrammar.Errors;
using EvaluationGrammar;


namespace ParserGeneratorTest.Models
{
    class ExpressionEvaluator
    {
        private string expression;
        private GrammarEnvironment env;
        private Guid parserId;

        public ExpressionEvaluator(string expression, Guid parserId)
        {
            this.expression = expression;
            this.parserId = parserId;
            env = new GrammarEnvironment();
            env.DefineVariable("result");
        }

        private IParser GetParser(Guid id)
        {
            var repo = new AvailableParserRepository();
            return repo.GetParser(id);
        }

        public int? Evaluate()
        {
            var ast = GetParser(parserId).Parse(expression);
            
            ast.Evaluate(env);
            try {
                return env.GetValue("result");
            } catch (UninitializedVariableUseException) {
                return null;
            }
        }
    }
}