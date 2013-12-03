tree grammar ASTGenerator;

options {
	tokenVocab=EvaluationGrammar;
	ASTLabelType=CommonTree;
}

@header {
	using EvaluationGrammar.AST;
	using AntlrParser.AST;
}

@namespace { AntlrParser }

public getAST returns [BaseAST e]
	: exp { e = $exp.e; }
	;

exp returns [BaseAST e]
	: ^(Add left=exp right=exp) { e = new BinaryExpression("+", $left.e, $right.e); }
	| ^(Sub left=exp right=exp) { e = new BinaryExpression("-", $left.e, $right.e); }
	| ^(Mul left=exp right=exp) { e = new BinaryExpression("*", $left.e, $right.e); }
	| ^(Div left=exp right=exp) { e = new BinaryExpression("/", $left.e, $right.e); }
	| ^(Mod left=exp right=exp) { e = new BinaryExpression("\%", $left.e, $right.e); }

	| ^(IF condition=exp onTrue=exp) { e = new IfStatement($condition.e, $onTrue.e); }
	| ^(IFELSE condition=exp onTrue=exp onFalse=exp) { e = new IfStatement($condition.e, $onTrue.e, $onFalse.e); }
	| ^(Assign identifier=exp expression=exp) { e = new AssignmentExpression($identifier.e, $expression.e); }
	| ^(op=Relop left=exp right=exp) { e = new BooleanExpression($op.text, $left.e, $right.e); }
	| ^(NUMBER n=Number) { e = new NumberExpression($n.text); }
	| ^(IDENTIFIER id=Id) { e = new IdentifierExpression($id.text); }
	| ^(DECLARATION id=Id) { e = new DeclarationStatement($id.text); }
	| ^(INITIALIZATION ini=exp val=exp) { e = new InitializationStatement($ini.e, $val.e); }
	| ^(WHILE condition=exp code=exp) { e = new WhileExpression($condition.e, $code.e); }
	| values=blockStatements { e = new BlockStatement($values.sts); }
	;

blockStatements returns [List<BaseAST> sts]
	@init {
		sts = new List<BaseAST>();
	}
	: ^(BLOCK (st=exp {$sts.Add($st.e);})*)
	;
