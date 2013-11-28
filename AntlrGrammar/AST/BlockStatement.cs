using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvaluationGrammar;
using EvaluationGrammar.AST;

namespace AntlrParser.AST
{
    public class BlockStatement : BaseAST
    {
        private List<BaseAST> statements;

        public BlockStatement(List<BaseAST> statements)
        {
            this.statements = statements;
        }

        public override EvaluationResult Evaluate(Environment env)
        {
            foreach (var statement in statements) {
                statement.Evaluate(env);
            }
            return null;
        }
    }
}
