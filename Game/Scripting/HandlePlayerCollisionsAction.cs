using System;
using System.Collections.Generic;
using Casting;
using Services;

namespace Scripting 
{
    public class HandlePlayerCollisionsAction : Scripting.Action 
    {
        public HandlePlayerCollisionsAction()
        {
            
        }
        

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            Actor player = scene.GetFirstActor("player");
            List<Casting.Actor> enemies = scene.GetAllActors("enemies");

            //function to end the game, probably give its own file.
            void end(){
            player.Tint(Color.White());
            foreach (Actor enemy in enemies){
                enemy.Tint(Color.White());
            }
            }
            
            foreach (Actor enemy in enemies){
               if(player.Overlaps(enemy))
               {
                end();             
                    //Code to end game!
               }
            }
        }
    }
}