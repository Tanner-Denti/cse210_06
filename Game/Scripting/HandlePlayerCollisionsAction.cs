using System;
using System.Collections.Generic;
using Casting;
using Services;

namespace Scripting 
{
    public class HandlePlayerCollisionsAction : Scripting.Action 
    {
        private bool isGameOver = false;
        public HandlePlayerCollisionsAction()
        {
            
        }
        

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            CheckPlayerCollision(scene);
        }

        private void CheckPlayerCollision(Scene scene)
        {
            Actor player = scene.GetFirstActor("player");
            List<Actor> enemies = scene.GetAllActors("enemies");
            
            foreach (Actor enemy in enemies)
            {
               if(player.Overlaps(enemy))
               {
                player.Tint(Color.White());
                isGameOver = true;
               }
               if(isGameOver)
               {
                enemy.Tint(Color.White());
               }
            }
        }
    }
}