using System;
using System.Collections.Generic;
using System.Numerics;

/*
	2018-11-02	Created.	apress.com/us/book/9781484213339
*/
namespace InformationInTransit.ProcessCode
{
	// This delegate can point to any method,
	// taking two integers and returning an integer.
	public delegate BigInteger BinaryOperation
	(
		BigInteger firstOperand,
		BigInteger secondOperand
	);
	
	// This class contains methods BinaryOp will
	// point to.
	public class SimpleMath
	{
		public static BigInteger Add
		(
			BigInteger firstOperand,
			BigInteger secondOperand
		)
		{ return firstOperand + secondOperand; }

		public static BigInteger Divide
		(
			BigInteger firstOperand,
			BigInteger secondOperand
		)
		{ return firstOperand / secondOperand; }

		public static BigInteger Modulo
		(
			BigInteger firstOperand,
			BigInteger secondOperand
		)
		{ return firstOperand % secondOperand; }
		
		public static BigInteger Multiply
		(
			BigInteger firstOperand,
			BigInteger secondOperand
		)
		{ return firstOperand * secondOperand; }

		public static BigInteger Power
		(
			BigInteger firstOperand,
			BigInteger secondOperand
		)
		{ return BigInteger.Pow(firstOperand, (int)secondOperand); }

		public static BigInteger Subtract
		(
			BigInteger firstOperand,
			BigInteger secondOperand
		)
		{ return firstOperand - secondOperand; }
	}
	
	public static partial class BigIntegerDelegateOperation
	{
		public static BigInteger Operation
		(
			string firstOperand,
			string secondOperand,
			char operation
		)
		{
			BigInteger bigIntegerFirstOperand = BigInteger.Parse(firstOperand);
			BigInteger bigIntegerSecondOperand = BigInteger.Parse(secondOperand);
			
			// Create a BinaryOperation delegate object that
			// "points to" SimpleMath.Add().
			BinaryOperation binaryOperation = null;
			
			switch (operation)
			{
				case '+':
					binaryOperation = new BinaryOperation(SimpleMath.Add);
					break;
				case '-':
					binaryOperation = new BinaryOperation(SimpleMath.Subtract);
					break;
				case '*':
					binaryOperation = new BinaryOperation(SimpleMath.Multiply);
					break;
				case '/':
					binaryOperation = new BinaryOperation(SimpleMath.Divide);
					break;
				case '%':
					binaryOperation = new BinaryOperation(SimpleMath.Divide);
					break;
				case '^':
					binaryOperation = new BinaryOperation(SimpleMath.Power);
					break;
			}

			// Invoke operation method indirectly using delegate object.
			BigInteger result = binaryOperation
			(
				bigIntegerFirstOperand,
				bigIntegerSecondOperand
			);
			
			return result;
		}
	}	
}	
