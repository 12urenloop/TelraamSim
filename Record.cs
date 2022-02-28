using Godot;
using System;
using Telraam_sim;

public class Record : Button
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	[Export()] public NodePath RecordIconPath;
	private Sprite recordIcon;

	public override void _Ready()
	{
		recordIcon = GetNode<Sprite>(RecordIconPath);
		recordIcon.Visible = false;
	}

	public override void _Pressed()
	{
		base._Pressed();
		if (!JsonLogger.GetInstance().Recording)
		{
			JsonLogger.GetInstance().Start();
			recordIcon.Visible = true;
		}
		else
		{
			JsonLogger.GetInstance().Stop();
			recordIcon.Visible = false;
		}
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
