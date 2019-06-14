using Godot;
using System;

public class Player : Area2D
{
	[Signal]
	public delegate void Hit();

	[Export]
	public int Speed = 400; // Speed player moves in pixels/sec
	private Vector2 _screenSize; // Size of the game window
	
	public override void _Ready()
	{
		_screenSize = GetViewport().GetSize();	
	}
	
	public override void _Process(float delta)
	{
		var velocity = new Vector2(); //Player's movement vector
		//Detects directional input and assigns velocity accordingly
		if (Input.IsActionPressed("ui_right"))
		{
			velocity.x += 1;
		}
		
		if (Input.IsActionPressed("ui_left"))
		{
			velocity.x -= 1;
		}
		
		if (Input.IsActionPressed("ui_down"))
		{
			velocity.y += 1;
		}
		
		if (Input.IsActionPressed("ui_up"))
		{
			velocity.y -= 1;
		}
		var animatedSprite = GetNode <AnimatedSprite>("AnimatedSprite");
		
		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
			animatedSprite.Play();
		}
		else
		{
			animatedSprite.Stop();
		}
		//Changes position based on velocity
		Position += velocity * delta;
		Position = new Vector2(
			x: Mathf.Clamp(Position.x, 0, _screenSize.x),
			y: Mathf.Clamp(Position.y, 0, _screenSize.y)
		);
		//Chooses animations based on directional input
		if (velocity.x !=0)
		{
			animatedSprite.Animation = "right";
			animatedSprite.FlipH = velocity.x < 0;
			animatedSprite.FlipV = false;
		}
		else if (velocity.y !=0)
		{
			animatedSprite.Animation = "up";
			animatedSprite.FlipV = velocity.y > 0;
		}
	}
}
