using BenchmarkDotNet.Attributes;

using Deserialiser;

namespace Benchmarks
{
	[Deserialisable]
	public class Chat
	{
		[Order(0)]
		public int PlayerId { get; set; }

		[Order(1)]
		public string Message { get; set; }
	}

	public class Benchmarks
	{
		private readonly object[] _goodArgs = new object[] { 10, "hello world" };

		private Chat _chat;

		[GlobalSetup]
		public void Setup()
		{
			_chat = new Chat
			{
				Message = "hello world",
				PlayerId = 10
			};

			// dry run, ensure caching in decorator is fine
			BasicDeserialize();

			for (var i = 0; i < 2; i++)
			{
				BasicDeserialize();
			}
		}

		[Benchmark(Description = "Simple TryDeserialize", Baseline = true)]
		public Chat BasicDeserialize()
			=> Deserialiser<Chat>.Deserialise(_goodArgs);
	}
}