using UnityEngine;
using System.Collections;
using System;

public static class Lambda {

	public static Func<A, Func<B, R>> Curry<A, B, R>(this Func<A, B, R> f)
	{
		return a => b => f(a, b);
	}
	
	public class Variable : Exception {
		public string Name { get; set; }
	}
	public class Constant : Exception {
		public int Value { get; set; }
	}
	public class Adicionar : Exception {
		public Exception Esquerda { get; set; }
		public Exception Direita { get; set; }
	}
	public class Multiplicar : Exception {
		public Exception Esquerda { get; set; }
		public Exception Direita { get; set; }
	}
	
	public static string Formatar(Exception e) {
		try { throw e; }
		catch (Constant n) { return n.Value.ToString(); }
		catch (Variable v) { return v.Name; }
		catch (Adicionar a) { return "({Formatar(a.Esquerda)} + {Formatar(a.Direita)})"; }
		catch (Multiplicar a) { return "({Formatar(a.Esquerda)} * {Formatar(a.Direita)})"; }
	}
	
	static void Main(string[] args)
	{
		Func<int,int,int> Adiciona = (x,y) => x+y;
		Func<int,Func<int,int>> curryInt = Curry(Adiciona);
		Func<int,int> decrementaUm = curryInt(-1);
		
		var auxInt = Curry(Adiciona);
		int resultInt = auxInt(3)(-1);
		Console.WriteLine(resultInt);
		Console.WriteLine(decrementaUm(2));
		Console.WriteLine(Adiciona(1,3));
		Console.WriteLine(curryInt(2)(2));
		
		
		Func<string,string,string> concatena = (x,y) => x+y;
		Func<string,Func<string,string>> curryString = Curry(concatena);
		Func<string,string> concatenaComTrabalho = curryString("Trabalho ");
		
		var auxString = Curry(concatena);
		string resultString = auxString("Cristiano Lunardi ")("Gustavo Santana");
		
		Console.WriteLine("{0}", resultString);
		Console.WriteLine(concatenaComTrabalho("MLP"));
		Console.WriteLine(curryString("af ")("bg"));
		
		
		var expr = new Multiplicar {
			Esquerda = new Variable {
				Name = "batalha naval tem matrizes"
			},
			Direita = new Multiplicar {
				Esquerda = new Constant { Value = 5 },
				Direita = new Constant { Value = 5 }
			}
		};
		
		Console.WriteLine(Formatar(expr)); //"batalha naval tem matrizes * ( 5 * 5 )"
		
	}
}