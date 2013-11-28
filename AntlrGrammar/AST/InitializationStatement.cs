using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST
{
    public class InitializationStatement : BaseInitializationStatement
    {
        public InitializationStatement(BaseAST identifier, BaseAST expression)
        {
            SetValues(
                identifier as IdentifierExpression,
                expression as Expression
            );
        }
    }
}