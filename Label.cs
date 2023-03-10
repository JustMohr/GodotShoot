using Godot;
using System;

public class Label : Godot.Label
{

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        Globals g = (Globals)GetNode("/root/Gm");
        this.Text = g.scorePL.ToString()+"      "+g.scorePR.ToString();
    }
}
