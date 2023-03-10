using Godot;
using System;

public class arrow_PR : Area2D
{
    public Boolean movementcontroll = true;
    public Boolean movementarrow = false;

    public override void _Ready()
    {
        this.Visible = false; //set invisible on start
        Vector2 startpos = new Vector2(974,100);
        this.Position = startpos;
    }

    public override void _Process(float delta)
    {
        keyInput();
        if(movementarrow==true){
            MoveLocalX(-30);
        }
         if(Position.x < -100){
             arrowreturnR();
        }
        Globals globals = (Globals)GetNode("/root/Gm");
        if(globals.resetposR==true){
            globals.resetposR = false;
            arrowreturnR();
            GD.Print(globals.resetposR);
        } 

    }

    public void keyInput()
    {     
        if(Input.IsActionJustPressed("PR_shot")){
            this.Visible = true;
            movementarrow = true;
        }

        if(movementcontroll == true){

            if(Input.IsActionPressed("PR_down"))
            {
                if(Position.y<525){
                this.MoveLocalY(3);
            }
            }
            if(Input.IsActionPressed("PR_high"))
            {
                if(Position.y>75){
                    this.MoveLocalY(-3);
                }
            }
        }

    }

    public void _arrow_exit_PR(KinematicBody PR){
        if(PR.Name == "player_right")
        {
            movementcontroll=false;
            GD.Print("arrow right Exit");
        }
    }

    public void _arrow_enter_PR(StaticBody SB)
    {
        //arrow hit obstacle
        if((SB.Name !=  "player_left")&&(SB.Name != "player_right")){ 
            GD.Print("wall enter");
            arrowreturnR();
   
        //arrow hit other player
        }else if(SB.Name== "player_left"){
            GD.Print("right win");
            Globals globals = (Globals)GetNode("/root/Gm");
            globals.scorePR++;
            System.Threading.Thread.Sleep(2000);

            //return arrow of other player
            //Globals globals = (Globals)GetNode("/root/Gm");
            globals.resetposL = true;

            //return own arrow
            arrowreturnR();

        //arrow returns
        }else if(SB.Name== "player_right"){
            GD.Print("arrow return");
        }
    }

    public void arrowreturnR(){
        movementarrow= false; 
        movementcontroll=true;
        this.Visible = false; //after return set invisible

        Globals g = (Globals)GetNode("/root/Gm");
            
        Vector2 resetpos = new Vector2(974, g.posYPR);
        this.Position = resetpos;
    } 

}
