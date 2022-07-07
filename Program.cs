using Casting;
using Directing;
using Scripting;
using Services;


namespace Game
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <remarks>
    /// The purpose of this program is to demonstrate how Actors, Actions, Services and a Director 
    /// work together to move an actor on the screen.
    /// </remarks>
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Instantiate a service factory for other objects to use.
            IServiceFactory serviceFactory = new RaylibServiceFactory();

            // Instantiate the actors that are used in this example.
            
            Actor actor = new Actor();
            actor.SizeTo(20, 20);
            actor.MoveTo(640, 480);
            actor.Tint(Color.Blue());

            Actor screen = new Actor();
            screen.SizeTo(1280, 960);
            screen.MoveTo(0, 0);

            // Instantiate the actions that use the actors.
            SteerActorAction steerActorAction = new SteerActorAction(serviceFactory);
            MoveActorAction moveActorAction = new MoveActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("actors", actor);
            scene.AddActor("screen", screen);
            scene.AddAction(Phase.Input, steerActorAction);
            scene.AddAction(Phase.Update, moveActorAction);
            scene.AddAction(Phase.Output, drawActorAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
