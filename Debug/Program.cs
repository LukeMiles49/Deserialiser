using System;

using Deserialiser;

namespace Debug
{
	[Deserialisable]
	public class Test
	{
		[Order(1)]
		public string test1 { get; set; }

		[Order(2)]
		public int test2 { get; set; }

		[Order(3)]
		public string test3 { get; set; }

		[Order(4)]
		public string test4 { get; set; }
	}

	public class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 50000000; i++)
				Deserialiser<Test>.Deserialise(new object[] { "hi", 12, "test", "" });
		}
	}
}
