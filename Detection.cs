using System;

namespace Telraam_sim
{
	public class Detection
	{
		public Detection(int batonId, int beaconId, int timeStamp)
		{
			this.batonId = batonId;
			this.beaconId = beaconId;
			this.timeStamp = timeStamp;
		}

		public int batonId { get; set; }
		public int beaconId { get; set; }
		public int timeStamp { get; set; }
	}
}
