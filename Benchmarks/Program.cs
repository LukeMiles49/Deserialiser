using System;

using BenchmarkDotNet.Running;

namespace Benchmarks
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			BenchmarkRunner.Run<Benchmarks>();
			Console.ReadLine();
		}
	}
}
