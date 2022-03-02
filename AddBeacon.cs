using Godot;
using System;
using Telraam_sim;

public class AddBeacon : Button
{
	[Export()] public NodePath SliderBoxPath;
	[Export()] public NodePath LogPanelPath;

	private VBoxContainer sliders;
	private PackedScene beaconControlScene;
	private PackedScene beaconScene;
	private int counter = 0;
	private Path2D beaconTrack;
	
	private VBoxContainer logPanel;

	public override void _Ready()
	{
		sliders = GetNode<VBoxContainer>(SliderBoxPath);
		beaconControlScene = GD.Load<PackedScene>("res://BeaconSlider.tscn");
		beaconScene = GD.Load<PackedScene>("res://Beacon.tscn");
		beaconTrack = GetNode<Path2D>("/root/Main/TrackView/BeaconTrack");
		
		logPanel = GetNode<VBoxContainer>(LogPanelPath);
	}

	public override void _Pressed()
	{
		base._Pressed();
		counter++;
		BeaconControl beaconControlInstance = (BeaconControl) beaconControlScene.Instance();
		Beacon beacon = (Beacon) beaconScene.Instance();

		sliders.AddChild(beaconControlInstance);
		beaconTrack.AddChild(beacon);
		beacon.BeaconId = counter;
		beacon.LogPanel = logPanel;
		beaconControlInstance.Link(beacon);
	}
}
