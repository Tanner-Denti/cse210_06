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
            float playerPositionX = player.GetCenterX();
            float playerPositionY = player.GetCenterY();

            foreach(Actor enemy in enemies)
            {
                float enemyPositionX = enemy.GetCenterX();
                float enemyPositionY = enemy.GetCenterY();
                int vx = 0;
                int vy = 0;
                
                if(playerPositionX - enemyPositionX < 0)
                {
                    vx = -2;
                }
                else
                {
                    vx = 2;
                }
                if(playerPositionY - enemyPositionY < 0)
                {
                    vy = -2;
                }
                else
                {
                    vy = 2;
                }
              
                enemy.Steer(vx,vy);
                enemy.Move();
            }

        }



    }


}