using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST {
    public class NumberExpression : BaseNumberExpression
    {
        public NumberExpression(string value)
        {
            SetValue(int.Parse(value));
        }
    }
}