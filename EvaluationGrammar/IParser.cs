using EvaluationGrammar.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationGrammar
{
    public interface IParser
    {
        BaseAST Parse(string code);
    }
}
