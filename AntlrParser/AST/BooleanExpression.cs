using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST {
    public class BooleanExpression : BaseBooleanExpression
    {
        public BooleanExpression(string relop, BaseAST left, BaseAST right)
        {
            SetValues(
                left as Expression,
                right as Expression,
                relop
            );
        }
    }
}