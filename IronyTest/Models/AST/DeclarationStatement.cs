using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.Models.AST
{
    public class DeclarationStatement : BaseAST
    {
        private string variable;

        public override EvaluationResult Evaluate(Environment env)
        {
            env.DefineVariable(variable);
            return null;
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            variable = parseNode.ChildNodes[1].FindTokenAndGetText();
        }
    }
}