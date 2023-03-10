using Godot;
using System;

public class player_left : KinematicBody2D
{
    public override void _Ready()
    {
        Vector2 startpos = new Vector2(50,100);
        this.Position = startpos;
    }

    public override void _Process(float delta)
    {
        key_input();
        Globals g = (Globals)GetNode("/root/Gm");
        g.posYPL = this.Position.y;
        //GD.Print(g.posYPL);
    }

    public void key_input()
    {
        if(Input.IsActionPressed("PL_down"))
        {        
            if(Position.y<525){
                this.MoveLocalY(3);
                GD.Print("L"+this.Position);
            }
        }

        if(Input.IsActionPressed("PL_high"))
        {
            if(Position.y>75){
                this.MoveLocalY(-3);
                GD.Print("L"+this.Position);
            }
        }
    }
}
