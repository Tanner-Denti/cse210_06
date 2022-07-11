using System;
using Casting;
using Services;


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

            for(enemy in enemies)
            {

            }

        }



    }


}