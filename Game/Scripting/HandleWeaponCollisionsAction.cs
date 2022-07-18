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
            DoWeaponCollision(scene);
        }

        private void DoWeaponCollision(Scene scene)
        {
            List<Actor> bullets = scene.GetAllActors<Actor>("bullets");
            List<Actor> enemies = scene.GetAllActors<Actor>("enemies");
            foreach(Actor enemy in enemies)
            {
                foreach(Actor bullet in bullets)
                {
                    if(enemy.Overlaps(bullet))
                    {   
                        enemy.MoveTo(1000,1000);
                        enemy.Disable();
                        bullet.MoveTo(1200,1200);
                        bullet.Disable();
                        //scene.RemoveActor("enemies", enemy);
                    }           
                }
            }
        }         
    }
}
