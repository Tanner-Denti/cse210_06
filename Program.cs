using cse210_06.Game.Casting;
using cse210_06.Game.Directing;
using cse210_06.Game.Scripting;
using cse210_06.Game.Scripting.Scenes;
using cse210_06.Game.Services;


namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IServiceFactory serviceFactory = new RaylibServiceFactory();
            Scene scene = new Scene();

            SceneLoader menuSceneLoader = new MenuSceneLoader(serviceFactory);
            menuSceneLoader.Load(scene);

            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}