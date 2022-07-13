using System;
using System.Collections.Generic;
using Casting;
using Scripting;
using Services;

namespace Scripting 
{
    public class HandleWeaponCollisionsAction : Scripting.Action 
    {
        public HandleWeaponCollisionsAction()
        {
            
        }
        

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            List<Actor> bullets = scene.GetAllActors("bullets");
            List<Actor> enemies = scene.GetAllActors("enemies");
            foreach(Actor bullet in bullets)
            {
                foreach(Actor enemy in enemies)
                {
                    if(enemy.Overlaps(bullet))
                    {
                        scene.RemoveActor("enemies", enemy);
                    }
                }
            }

        }
            
    }
}
