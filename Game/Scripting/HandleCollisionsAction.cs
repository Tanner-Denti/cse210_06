using System;
using System.Collections.Generic;
using Casting;
using Services;

namespace Scripting 
{
    public class HandleCollisionsAction : Scripting.Action 
    {
        public HandleCollisionsAction()
        {
            
        }


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            Actor player = scene.GetFirstActor("player");
            List<Casting.Actor> enemies = scene.GetAllActors("enemies");
            foreach (Actor enemy in enemies){
               if(player.Overlaps(enemy))
               {
                player.Tint(Color.White());                   
                    //Code to end game!
               }
            }
        }
    }
}