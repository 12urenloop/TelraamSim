using Godot;

namespace Telraam_sim
{
    public class AddBaton : Button
    {
        // Declare member variables here. Examples:
        // private int a = 2;
        // private string b = "text";
        [Export()] public NodePath SliderContainerPath;
        private int counter = 0;

        // Called when the node enters the scene tree for the first time.
        private Container sliders;
        private PackedScene baton;
        private PackedScene slider;
        private Path2D track;

        public override void _Ready()
        {
            sliders = GetNode<Container>(SliderContainerPath);
            GD.Print(sliders.ToString());
            baton = ResourceLoader.Load<PackedScene>("res://Baton.tscn");
            slider = ResourceLoader.Load<PackedScene>("res://BatonControl.tscn");
            track = GetNode<Path2D>("/root/Main/TrackView/Track");
        }

        public override void _Pressed()
        {
            base._Pressed();
            counter++;
            var batonInstance = (Baton) baton.Instance();
            var batonControlInstance = (BatonControl) slider.Instance();
            
            sliders.AddChild(batonControlInstance);
            track.AddChild(batonInstance);
            
            batonInstance.Name = $"Baton{counter}";
            batonInstance.SetLabel(counter.ToString());
            batonInstance.batonId = counter;


            GD.Print(batonControlInstance);
            batonControlInstance.Link(batonInstance);
        }

        //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
    }
}
