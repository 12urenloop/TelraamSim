using Godot;
using System;
using Telraam_sim;

public class BeaconSlider : HSlider
{
    private Beacon beacon;

    public override void _Ready()
    {
        beacon = GetOwner<BeaconControl>().Beacon;
    }
}