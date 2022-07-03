using System;
using cse210_06.Game.Casting;
using cse210_06.Game.Scripting;
using cse210_06.Game.Services;


namespace cse210_06.Game.Scripting.Scenes
{
    public class PlayMusicAction : cse210_06.Game.Scripting.Action
    {
        private IAudioService _audioService;
        private string _musicFile;

        public PlayMusicAction(IServiceFactory serviceFactory)
        {
            _audioService = serviceFactory.GetAudioService();
            _musicFile = serviceFactory.GetSettingsService().GetString("menuMusic");
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            try
            {
                if (!_audioService.IsPlayingMusic(_musicFile))
                {
                    _audioService.PlayMusic(_musicFile);
                }
                _audioService.UpdateMusic(_musicFile);
            }
            catch (Exception exception)
            {
                callback.OnError("Couldn't play music.", exception);
            }
        }
    }
}