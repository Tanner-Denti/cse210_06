using System;
using System.Collections.Generic;
using cse210_06.Game.Casting;
using cse210_06.Game.Casting.Zelda;
using cse210_06.Game.Scripting;
using cse210_06.Game.Services;


namespace cse210_06.Game.Scripting.Scenes
{
    public class GameSceneLoader : SceneLoader
    {

        private ActorFactory _actorFactory;

        public GameSceneLoader(IServiceFactory serviceFactory) : base(serviceFactory) 
        {
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            _actorFactory = new ActorFactory(settingsService);
        }

        public override void Load(Scene scene)
        {
            scene.Clear();
            LoadBackground(scene);
            LoadActors(scene);
            LoadActions(scene);
        }

        private void LoadActions(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            
            //The commented out methods are from breaker, they are game specific, swap them for zelda scripts
            // SteerActorsAction steerActorsAction = new SteerActorsAction(serviceFactory);
            // MoveActorsAction moveActorsAction = new MoveActorsAction(serviceFactory);
            // CollideActorsAction collideActorsAction = new CollideActorsAction(serviceFactory);
            LoadSceneAction loadSceneAction = new LoadSceneAction(serviceFactory);
            DrawActorsAction drawActorsAction = new DrawActorsAction(serviceFactory);

            // scene.AddAction(Phase.Input, steerActorsAction);
            // scene.AddAction(Phase.Update, moveActorsAction);
            // scene.AddAction(Phase.Update, collideActorsAction);
            scene.AddAction(Phase.Update, loadSceneAction);
            scene.AddAction(Phase.Output, drawActorsAction);
        }

        private void LoadActors(Scene scene)
        {
            //initialize actors and add them to the scene
        }

        private void LoadBackground(Scene scene)
        {
            IServiceFactory serviceFactory = GetServiceFactory();
            ISettingsService settingsService = serviceFactory.GetSettingsService();
            IVideoService videoService = serviceFactory.GetVideoService();
            videoService.SetBackground(Color.Black());
        }

    }
}

