using System;
using System.Collections.Generic;
using cse210_06.Game.Casting;
using cse210_06.Game.Scripting;
using cse210_06.Game.Services;


namespace cse210_06.Game.Scripting.Scenes
{
    public class DrawActorsAction : cse210_06.Game.Scripting.Action
    {
        private IVideoService _videoService;

        public DrawActorsAction(IServiceFactory serviceFactory)
        {
            _videoService = serviceFactory.GetVideoService();
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                List<Image> images = scene.GetAllActors<Image>("images");
                List<Label> labels = scene.GetAllActors<Label>("labels");  //scene.GetAllActors<Image>("labels"); if this line breaks, put this back in, it isn't accepting the type when it's an image though.
                
                _videoService.ClearBuffer();
                _videoService.Draw(images);
                _videoService.Draw(labels);
                _videoService.FlushBuffer();
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't draw actors.", exception);
            }
        }
    }
}