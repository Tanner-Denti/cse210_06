using System;
using Casting;
using System.Collections.Generic;
using Services;


namespace Scripting
{
    /// <summary>
    /// Moves the actors and wraps them around the screen boundaries. Note, this is different from
    /// steering them which only changes their direction. The call to actor.Move() is what updates
    /// their position on the screen.
    /// </summary>
    public class MoveBulletAction: Scripting.Action
    {

        public MoveBulletAction()
        {
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the scene
                List<Actor> bullets = scene.GetAllActors("bullets");
                foreach(Actor bullet in bullets)
                {
                    bullet.Move();
                }
                
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move bullets.", exception);
            }
        }
    }
}