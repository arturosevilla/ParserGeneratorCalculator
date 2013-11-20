using Irony.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Parsing;

namespace IronyTest.Models.AST
{
    public abstract class BaseAST : IAstNodeInit
    {
        public abstract EvaluationResult Evaluate(Environment env);
        public abstract void Init(AstContext context, ParseTreeNode parseNode);
    }
}