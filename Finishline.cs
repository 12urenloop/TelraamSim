using Godot;
using System;
using Telraam_sim;

public class Finishline : Area2D
{
	public override void _Ready()
	{
	}

	public void _OnAreaEntered(Area2D area)
	{
		var baton = area.GetOwner<Baton>();
		if (JsonLogger.GetInstance().Recording)
		{

			if (baton.Speed > 0)
			{
				JsonLogger.GetInstance().LogLap(baton.batonId);
			}
		}
	}
}
