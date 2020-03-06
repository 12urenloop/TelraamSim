using Godot;
using System;

public class PauseBaton : Button
{
    [Export()] public NodePath SliderPath;
    private HSlider slider;

    public override void _Ready()
    {
        slider = GetNode<HSlider>(SliderPath);
    }

    public override void _Pressed()
    {
        base._Pressed();
        slider.Value = 0;
    }

}