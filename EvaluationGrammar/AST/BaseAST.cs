using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar;

namespace EvaluationGrammar.AST
{
    public abstract class BaseAST
    {
        public abstract EvaluationResult Evaluate(Environment env);
    }
}