using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluationGrammar;
using EvaluationGrammar.AST;

namespace AntlrParser.AST
{
    public class BlockStatement : BaseStatementList
    {
        private List<BaseAST> statements;

        public BlockStatement(List<BaseAST> statements)
        {
            SetStatements(statements);   
        }
    }
}
