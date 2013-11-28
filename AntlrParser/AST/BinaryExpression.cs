using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST
{
    public class BinaryExpression : BaseBinaryExpression
    {
        public BinaryExpression(string operator_, BaseAST left, BaseAST right)
        {
            SetValues(
                operator_,
                left as Expression,
                right as Expression
            );
        }
    }
}