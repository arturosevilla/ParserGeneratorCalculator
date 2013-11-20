using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.Models.AST
{
    public class InitializationStatement : BaseAST
    {
        private string variable;
        private Expression initialization;

        public override EvaluationResult Evaluate(Environment env)
        {
            int value = (int)initialization.Evaluate(env).Result;
            env.DefineVariable(variable);
            env.AssignValue(variable, value);
            return null;
        }

        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            variable = parseNode.ChildNodes[1].FindTokenAndGetText();
            initialization = parseNode.ChildNodes[3].AstNode as Expression;
        }
    }
}