using Godot;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using Godot.Collections;

namespace Telraam_sim
{
	public class Beacon : PathFollow2D
	{
		private Area2D area2D;
		private float time = 0;
		private TcpClient tcpClient;

		[Export()]
		public int BeaconId
		{
			get { return beaconId; }
			set
			{
				beaconId = value;
				label.Text = value.ToString();
			}
		}

		[Export()] public NodePath LabelPath;
		private Label label;
		private int beaconId;

		public override void _Ready()
		{
			area2D = (Area2D) FindNode("Area2D");
			label = GetNode<Label>(LabelPath);
			// tcpClient = new TcpClient();
			// tcpClient.Connect("localhost", 4564);
		}


		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(float delta)
		{
			time += delta;
			var areas = area2D.GetOverlappingAreas();
			if (areas.Count <= 0) return;
			foreach (Area2D area in areas)
			{
				var batonId = area.GetOwner<Baton>().batonId;
				if (JsonLogger.GetInstance().Recording)
				{
					var detection = new Detection(batonId, BeaconId, (int) (time * 1000));
					JsonLogger.GetInstance().LogDetection(detection);
					var buf = $"{beaconId},{(int)(time*1000)},{batonId},IGNORE\n".ToUTF8();
					// tcpClient.GetStream().Write(buf, 0, buf.Length);
				}
			}
		}

		public void _OnPositionChange(float val)
		{
			UnitOffset = val;
		}
	}
}
