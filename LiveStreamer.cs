using System;
using System.Collections.Generic;
using Godot;
using Newtonsoft.Json;

namespace Telraam_sim
{
	public class LiveStreamer
	{
		private static LiveStreamer myInstance;

		public bool Streaming { get; set; }

		private LiveStreamer()
		{
		}

		public static LiveStreamer GetInstance()
		{
			return myInstance ?? (myInstance = new LiveStreamer());
		}

		public void Start()
		{
			Streaming = true;
		}

		public void Stop()
		{
			Streaming = false;
		}
	}
}
