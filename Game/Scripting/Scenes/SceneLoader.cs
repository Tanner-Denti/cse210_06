using cse210_06.Game.Services;
using cse210_06.Game.Scripting;


namespace cse210_06.Game.Scripting
{
    public abstract class SceneLoader
    {
        private static IServiceFactory ServiceFactory;

        public SceneLoader(IServiceFactory serviceFactory)
        {
            ServiceFactory = serviceFactory;
        }

        public IServiceFactory GetServiceFactory()
        {
            return ServiceFactory;
        }

        public abstract void Load(Scene scene);

    }
}