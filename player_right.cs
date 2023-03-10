using Godot;
using System;

public class player_right : KinematicBody2D
{
    public override void _Ready()
    {
        Vector2 startpos = new Vector2(974,100);
        this.Position = startpos;
    }

    public override void _Process(float delta)
    {
        key_input();
        Globals g = (Globals)GetNode("/root/Gm");
        g.posYPR = this.Position.y;
        //GD.Print(g.posYPR);
    }

    public void key_input()
    {
        if(Input.IsActionPressed("PR_down"))
        {        
            if(Position.y<525){
                this.MoveLocalY(3);
                GD.Print("R"+this.Position);
            }
        }

        if(Input.IsActionPressed("PR_high"))
        {
            if(Position.y>75){
                this.MoveLocalY(-3);
                GD.Print("R"+this.Position);
            }
        }
    }
}
