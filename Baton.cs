using System;
using Godot;

namespace Telraam_sim
{
    public class Baton : PathFollow2D
    {
        [Export()] public float Speed = 1000f;

        // amount of seconds in between transmissions
        [Export()] public float interval = 0.1f;
        [Export()] public float Duration = 0.1f;

        private float counter = 0f;
        private Area2D area2D;
        private Label label;
        public String Name;
        public int batonId { get; set; }

        // Called when the node enters the scene tree for the first time.
        public override void _Ready()
        {
            area2D = (Area2D) FindNode("Area2D");
        }

        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            Offset += Speed * delta;
            counter += delta;
            if (counter >= interval + Duration)
            {
                counter = 0;
                area2D.Monitorable = false;
            }

            if (!(counter >= interval)) return;
            area2D.Monitorable = true;
        }

        public void OnSpeedChange(float value)
        {
            Speed = value;
        }

        public void SetLabel(string text)
        {
            if (label == null)
            {
                label = GetNode<Label>("Label");
            }

            label.Text = text;
        }

    }
}
