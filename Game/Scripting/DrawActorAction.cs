using System;
using System.Collections.Generic;
using Casting;
using Services;


namespace Scripting
{
    /// <summary>
    /// Draws the actors on the screen.
    /// </summary>
    public class DrawActorAction : Scripting.Action
    {
        private IVideoService _videoService;

        public DrawActorAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                // get the actors from the cast
                // Label label = (Label) scene.GetFirstActor("labels");
       
                Actor player = scene.GetFirstActor("player");
                List<Casting.Actor> enemies = scene.GetAllActors("enemies");
                
                // draw the actors on the screen using the video service
                _videoService.ClearBuffer();
                // _videoService.Draw(label);
                _videoService.Draw(player);
                _videoService.Draw(enemies);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }
    }
}