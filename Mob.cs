using Godot;
using System;

public class Mob : RigidBody2D
{
	[Signal]
	public delegate void screen_exited();
	
    [Export]
    public int MinSpeed = 150; // Minimum speed range.

    [Export]
    public int MaxSpeed = 250; // Maximum speed range.

    private String[] _mobTypes = {"walk", "swim", "fly"};

	static private Random _random = new Random();
	
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
   {
        GetNode<AnimatedSprite>("AnimatedSprite").Animation = _mobTypes[_random.Next(0, _mobTypes.Length)];
    }

	private void _on_Visibility_screen_exited()
	{
	    QueueFree();
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//\  public override void _Process(float delta)
//  {
//      
//  }
}
