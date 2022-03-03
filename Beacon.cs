using Godot;
using System;

namespace Telraam_sim
{
    public class Beacon : PathFollow2D
    {
        private Area2D area2D;
        private float time;

        [Export()] public VBoxContainer LogPanel;

        private Random rand = new Random();

        // The chance that the beacon receives the transmission of a passing baton
        [Export()] public double reliability;

        [Export()]
        public int BeaconId
        {
            get { return beaconId; }
            set
            {
                beaconId = value;
                label.Text = value.ToString();
            }
        }

        [Export()] public NodePath LabelPath;
        private Label label;
        private int beaconId;

        public override void _Ready()
        {
            area2D = (Area2D) FindNode("Area2D");
            label = GetNode<Label>(LabelPath);

            reliability = rand.NextDouble();
            UnitOffset = (float) rand.NextDouble();
        }


        // Called every frame. 'delta' is the elapsed time since the previous frame.
        public override void _Process(float delta)
        {
            time += delta;
            var areas = area2D.GetOverlappingAreas();
            if (areas.Count <= 0) return;
            foreach (Area2D area in areas)
            {
                var batonId = area.GetOwner<Baton>().batonId;
                var detection = new Detection(batonId, BeaconId, (int) (time * 1000));

                // Log to the logpane on the screen
                _AddLogToPanel("Detection");

                if (JsonLogger.GetInstance().Recording)
                {
                    // Log to file
                    JsonLogger.GetInstance().LogDetection(detection);
                    _AddLogToPanel("Log to json file");
                }

                if (LiveStreamer.GetInstance().Streaming)
                {
                    // Log to tcp socket of telraam
                    var message = $"{beaconId},{(int) (time * 1000)},{batonId},IGNORE\n";
                    LiveStreamer.GetInstance().SendString(message);
                    _AddLogToPanel("Send to tcp stream");
                }
            }
        }

        public void _OnPositionChange(float val)
        {
            UnitOffset = val;
        }

        private void _AddLogToPanel(string text)
        {
            Label l = new Label();
            // TODO Add date: [2022-02-28 21:04:12] 
            l.Text = text;
            LogPanel.AddChild(l);
            // Add to the top
            LogPanel.MoveChild(l, 0);
        }
    }
}