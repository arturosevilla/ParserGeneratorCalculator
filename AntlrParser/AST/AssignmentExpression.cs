using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST
{
    public class AssignmentExpression : BaseAssignmentExpression
    {
        public AssignmentExpression(BaseAST identifier, BaseAST expression)
        {
            SetValues(identifier as IdentifierExpression, expression as Expression);
        }
    }
}