using System;
using System.Collections.Generic;
using Godot;
using Newtonsoft.Json;

namespace Telraam_sim
{
	public class JsonLogger
	{
		private static JsonLogger myInstance;
		private File logFile;
		private List<Detection> detections;
		private int counter = 0;
		private Dictionary<int, int> laps;
		public bool Recording { get; set; }

		private JsonLogger()
		{
			detections = new List<Detection>();
			laps = new Dictionary<int, int>();
		}

		public static JsonLogger GetInstance()
		{
			return myInstance ?? (myInstance = new JsonLogger());
		}

		public void Start()
		{
			Recording = true;
			counter++;
		}

		public void Stop()
		{
			Recording = false;
			logFile = new File();
			var fn = $"res://logfile_{DateTime.Now.ToString("yy_MM_dd:hh_mm_ss")}.log.json";
			GD.Print(fn);
			logFile.Open(fn, File.ModeFlags.WriteRead);
			logFile.StoreString(JsonConvert.SerializeObject(detections));
			logFile.Close();
			detections.Clear();


			var lapLogFile = new File();
			fn = $"res://laps_logfile_{DateTime.Now.ToString("yy_MM_dd:hh_mm_ss")}.log.json";
			GD.Print(fn);
			lapLogFile.Open(fn, File.ModeFlags.WriteRead);
			lapLogFile.StoreString(JsonConvert.SerializeObject(laps));
			lapLogFile.Close();
			laps.Clear();
		}

		public void LogDetection(Detection detection)
		{
			detections.Add(detection);
		}

		public void LogLap(int batonId)
		{
			if (!laps.ContainsKey(batonId))
			{
				laps[batonId] = 1;
			}
			else
			{
				laps[batonId]++;
			}
		}
	}
}
