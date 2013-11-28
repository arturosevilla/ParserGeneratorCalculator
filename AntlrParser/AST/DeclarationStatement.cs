using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST
{
    public class DeclarationStatement : BaseDeclarationStatement
    {
        public DeclarationStatement(string symbol)
        {
            SetValue(symbol);
        }
    }
}