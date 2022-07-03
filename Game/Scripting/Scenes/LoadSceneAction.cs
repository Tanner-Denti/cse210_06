using System;
using cse210_06.Game.Casting;
using cse210_06.Game.Scripting;
using cse210_06.Game.Services;

namespace cse210_06.Game.Scripting.Scenes
{
    public class LoadSceneAction : cse210_06.Game.Scripting.Action
    {
        private IKeyboardService _keyboardService;
        private SceneLoader _gameSceneLoader;
        
        public LoadSceneAction(IServiceFactory serviceFactory)
        {
            _keyboardService = serviceFactory.GetKeyboardService();
            _gameSceneLoader = new GameSceneLoader(serviceFactory);
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if (_keyboardService.IsKeyPressed(KeyboardKey.Enter))
                {
                    _gameSceneLoader.Load(scene);
                }
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't load scene.", exception);
            }
        }
    }
}