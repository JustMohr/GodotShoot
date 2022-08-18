using Godot;
using System;

public class arrow_PL : Area2D
{

    public Boolean movementcontroll = true;
    public Boolean movementarrow = false;


    public override void _Ready()
    {
        this.Visible = false; //set invisible on start
        Vector2 startpos = new Vector2(50,100);
        this.Position = startpos;
    }

    public override void _Process(float delta)
    {
        keyInput();
        if(movementarrow==true){
            MoveLocalX(30);
        }
        if(Position.x > 1124){
            arrowreturnL();
        }
        Globals globals = (Globals)GetNode("/root/Gm");
        if(globals.resetposL==true){
            globals.resetposL = false;
            arrowreturnL();
            GD.Print(globals.resetposL);
        }

    }

    public void keyInput()
    {     
        if(Input.IsActionJustPressed("PL_shot")){
            this.Visible = true;
            movementarrow = true;
        }

        if(movementcontroll == true){

            if(Input.IsActionPressed("PL_down"))
            {
                if(Position.y<525){
                this.MoveLocalY(3);
            }
            }
            if(Input.IsActionPressed("PL_high"))
            {
                if(Position.y>75){
                this.MoveLocalY(-3);
                }
            }
        }

    }

    public void _arrow_exit_PL(KinematicBody PL){
        if(PL.Name == "player_left")
        {
            movementcontroll=false;
            GD.Print("arrow left Exit");
        }
    }

    public void _arrow_enter_PL(StaticBody SB)
    {
        //arrow hit obstacle
        if((SB.Name !=  "player_right")&&(SB.Name != "player_left")){
            GD.Print("wall enter"); 
            arrowreturnL();

        //arrow hit other player    
        }else if(SB.Name =="player_right"){
            GD.Print("left win");
            Globals globals = (Globals)GetNode("/root/Gm");
            globals.scorePL++;
            System.Threading.Thread.Sleep(2000);

            //return arrow of other player
            //Globals globals = (Globals)GetNode("/root/Gm");
            globals.resetposR = true;

            //return own arrow
            arrowreturnL();

        //arrow returns
        }else if(SB.Name == "player_left"){
            GD.Print("arrow return");
        }
    }

    public void arrowreturnL(){

        movementarrow= false;   
        movementcontroll=true;
        this.Visible = false; //after return set invisibile

        Globals g = (Globals)GetNode("/root/Gm");

        Vector2 resetpos = new Vector2(50, g.posYPL);
        this.Position = resetpos;

    }
    
}
