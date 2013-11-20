using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.Models.AST
{
    public class BinaryExpression : Expression
    {
        private string Operator;
        private Expression Left;
        private Expression Right;
        private delegate int BooleanOperator(int a, int b);


        private int Sum(int a, int b)
        {
            return a + b;
        }

        private int Multiply(int a, int b)
        {
            return a * b;
        }

        private int Difference(int a, int b)
        {
            return a - b;
        }

        private int Divide(int a, int b)
        {
            return a / b;
        }

        private int Modulo(int a, int b)
        {
            return a % b;
        }

        private BooleanOperator GetOperator()
        {
            switch (Operator)
            {
                case "+":
                    return Sum;
                case "-":
                    return Difference;
                case "*":
                    return Multiply;
                case "/":
                    return Divide;
                case "%":
                    return Modulo;
                default:
                    throw new InvalidOperationException("Unknown operator: " + Operator);
            }
        }

        public override EvaluationResult Evaluate(Environment env)
        {
            var leftEval = Left.Evaluate(env);
            var rightEval = Right.Evaluate(env);
            
            return new EvaluationResult {
                Result = GetOperator()((int)leftEval.Result, (int)rightEval.Result)
            };
        }


        public override void Init(AstContext context, ParseTreeNode parseNode)
        {
            Operator = parseNode.ChildNodes[1].FindTokenAndGetText();
            Left = parseNode.ChildNodes[0].AstNode as Expression;
            Right = parseNode.ChildNodes[2].AstNode as Expression;
        }
    }
}