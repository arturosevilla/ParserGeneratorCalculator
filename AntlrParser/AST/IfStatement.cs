using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EvaluationGrammar.AST;

namespace AntlrParser.AST {
    public class IfStatement : BaseIfStatement
    {
        public IfStatement(BaseAST condition, BaseAST onTrue, BaseAST onFalse)
        {
            SetValues(
                condition as BooleanExpression,
                onTrue,
                onFalse
            );
        }

        public IfStatement(BaseAST condition, BaseAST onTrue)
            : this(condition, onTrue, null)
        {
        }
    }
}