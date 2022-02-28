using Godot;
using System;
using Telraam_sim;

public class BeaconControl : VBoxContainer
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public Beacon Beacon { get; private set; }
    [Export()] public NodePath BeaconSliderPath;
    [Export()] public NodePath BeaconLabelPath;
    [Export()] public NodePath ExtraLabelPath;

    private HSlider beaconSlider;
    private Label beaconLabel;
    private Label beaconExtra;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        beaconSlider = GetNode<HSlider>(BeaconSliderPath);
        beaconLabel = GetNode<Label>(BeaconLabelPath);
        beaconExtra = GetNode<Label>(ExtraLabelPath);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    public void Link(Beacon beacon)
    {
        this.Beacon = beacon;
        beaconSlider.Connect("value_changed", Beacon, "_OnPositionChange");
        beaconLabel.Text = $"Beacon{beacon.BeaconId}";
        beaconExtra.Text = $"Reliability: {beacon.reliability}";
    }

    public void _OnDelete()
    {
        Beacon.QueueFree();
        this.QueueFree();
    }
}
