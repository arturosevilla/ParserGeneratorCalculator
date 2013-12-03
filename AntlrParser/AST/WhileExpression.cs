using EvaluationGrammar.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrParser.AST
{
    public class WhileExpression : BaseWhileExpression
    {
        public WhileExpression(BaseAST condition, BaseAST block)
        {
            SetValues(condition as BooleanExpression, block as BlockStatement);
        }
    }
}
