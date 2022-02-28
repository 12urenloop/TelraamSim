using Godot;
using System;

namespace Telraam_sim
{
	public class BatonControl: HBoxContainer
	{
		[Export()] public NodePath LabelPath;

		[Export()] public NodePath SliderPath;
		private Label label;
		private HSlider slider;
		private Baton baton;

		public override void _Ready()
		{
			label = GetNode<Label>(LabelPath);
			slider = GetNode<HSlider>(SliderPath);
		}

		public void Link(Baton baton)
		{
			this.baton = baton;
			label.Text = baton.Name;
			slider.Value = baton.Speed;
			slider.Connect("value_changed", baton, "OnSpeedChange");
		}

		public void _OnDelete()
		{
			baton.QueueFree();
			this.QueueFree();
		}
	}
}
