using System;
using Casting;
using Services;
using System.Collections.Generic;
using System.Numerics;

namespace Scripting
{
    public class MoveEnemyAction : Scripting.Action
    {
        public MoveEnemyAction()
        {

        }


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            Actor player = scene.GetFirstActor("player");
            List<Casting.Actor> enemies = scene.GetAllActors("enemies");
            Vector2 playerPosition = player.GetCenter();

            foreach(Actor enemy in enemies)
            {
                Vector2 enemyPosition = enemy.GetCenter();
                
                
                int vx = 3;
                int vy = 3;
                

                //calculate x and y
                enemy.Steer(vx,vy);
                enemy.Move();
            }

        }



    }


}