using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST
{
    public class IdentifierExpression : BaseIdentifierExpression
    {
        public IdentifierExpression(string symbol)
        {
            SetValue(symbol);
        }
    }
}