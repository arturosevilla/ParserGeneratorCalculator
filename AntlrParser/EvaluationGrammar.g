grammar EvaluationGrammar;

options {
	output=AST;
	TokenLabelType=CommonToken;
	language=CSharp3;
}

tokens {
	IDENTIFIER;
	NUMBER;
	DECLARATION;
	INITIALIZATION;
	IF;
	WHILE;
	IFELSE;
	BLOCK;
} 

@parser::namespace { AntlrParser }
@lexer::namespace  { AntlrParser }

@header {
	using EvaluationGrammar.AST;
}

public program
	: block EOF
	;

block
	: generalStatement* -> ^(BLOCK generalStatement*)
	;

generalStatement
	: instruction | ifExpression | whileExpression
	;

instruction
	: statement ';'!
	;

statement
	: initialization | declaration | assignment
	;

ifExpression
	: 'if' '(' booleanExpression ')' '{' s1=block '}'
	( 'else' '{' s2=block '}' -> ^(IFELSE booleanExpression $s1 $s2)
	  |                       -> ^(IF booleanExpression $s1)
	)
	;

whileExpression
	: 'while' '(' booleanExpression ')' '{' s1=block '}' -> ^(WHILE booleanExpression $s1)
	;

assignment
	:  identifier Assign^ expression
	;

booleanExpression
	: expression Relop^ expression
	;

expression
	: addition
	;

addition
	: product ((Add | Sub)^ product)*
	;

product
	: atom ((Mul | Div | Mod)^ atom)*
	;

atom
	: Number -> ^(NUMBER Number)
	| identifier
	| '(' expression ')' -> expression
	;

identifier
	: Id -> ^(IDENTIFIER Id)
	;

initialization
	: 'int' identifier '=' expression -> ^(INITIALIZATION identifier expression)
	;

declaration
	: 'int' Id -> ^(DECLARATION Id)
	;


Add    : '+';
Sub    : '-';
Mul    : '*';
Div    : '/';
Mod    : '%';
Number : '0'..'9'+;
Space  : (' ' | '\t' | '\n')+ { $channel = Hidden;};
Id     : ('a'..'z' | 'A'..'Z' | '_')('a'..'z' | 'A'..'Z' | '_' | '0'..'9')*;
Relop  : '==' | '!=' | '>' | '<' | '>=' | '<=';
Assign : '=';
