using Godot;
using System;
using Telraam_sim;

public class StreamButton : CheckButton
{
	// Called when the node enters the scene tree for the first time.
	// [Export()] public NodePath RecordIconPath;
	// private TextureRect recordIcon;

	public override void _Ready()
	{
		// recordIcon = GetNode<TextureRect>(RecordIconPath);
		// recordIcon.Visible = false;
	}

	public override void _Pressed()
	{
		base._Pressed();
		if (!LiveStreamer.GetInstance().Streaming)
		{
			LiveStreamer.GetInstance().Start();
			// recordIcon.Visible = true;
		}
		else
		{
			LiveStreamer.GetInstance().Stop();
			// recordIcon.Visible = false;
		}
	}
}
