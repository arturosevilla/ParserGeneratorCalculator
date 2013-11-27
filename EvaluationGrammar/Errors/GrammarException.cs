using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluationGrammar.Errors
{
    public class GrammarException : Exception
    {
    }

    public class UndefinedVariableException : GrammarException
    {
        private string variable;

        public UndefinedVariableException(string variable)
        {
            this.variable = variable;
        }

        public override string Message
        {
            get
            {
                return "Undefined variable: " + variable;
            }
        }
    }

    public class VariableRedefinitionException : GrammarException
    {
        private string variable;

        public VariableRedefinitionException(string variable)
        {
            this.variable = variable;
        }

        public override string Message
        {
            get
            {
                return "Redefinition of variable" + variable;
            }
        }

    }

    public class UninitializedVariableUseException : GrammarException
    {
        private string variable;

        public UninitializedVariableUseException(string variable)
        {
            this.variable = variable;
        }

        public override string Message
        {
            get
            {
                return "Variable not yet initialized: " + variable;
            }
        }
    }
}