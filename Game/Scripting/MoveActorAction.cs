using System;
using Casting;
using Services;


namespace Scripting
{
    /// <summary>
    /// Moves the actors and wraps them around the screen boundaries. Note, this is different from
    /// steering them which only changes their direction. The call to actor.Move() is what updates
    /// their position on the screen.
    /// </summary>
    public class MoveActorAction : Scripting.Action
    {
        private IKeyboardService _keyboardService;

        public MoveActorAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the scene
                Actor actor = scene.GetFirstActor("actors");
                Actor screen = scene.GetFirstActor("screen");
                
                // move the actor and wrap it around the screen boundaries
                actor.Move();
                actor.ClampTo(screen);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't move actor.", exception);
            }
        }
    }
}