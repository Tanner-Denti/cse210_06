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
            // Label label = new Label();
            // label.Display("'w', 's', 'a', 'd' to move");
            // label.MoveTo(25, 25);
            
            Actor player = new Actor();
            player.SizeTo(20, 20);
            player.MoveTo(640, 480);
            player.Tint(Color.Blue());

            Actor screen = new Actor();
            screen.SizeTo(1280, 960);
            screen.MoveTo(0, 0);

            // Instantiate the actions that use the actors.
            MoveEnemyAction moveEnemyAction = new MoveEnemyAction();
            SpawnEnemyAction spawnEnemyAction = new SpawnEnemyAction(serviceFactory);
            SteerActorAction steerActorAction = new SteerActorAction(serviceFactory);
            MoveActorAction moveActorAction = new MoveActorAction(serviceFactory);
            DrawActorAction drawActorAction = new DrawActorAction(serviceFactory);

            // Instantiate a new scene, add the actors and actions.
            Scene scene = new Scene();
            scene.AddActor("player", player);
            // scene.AddActor("labels", label);
            scene.AddActor("screen", screen);
            scene.AddAction(Phase.Input, steerActorAction);
            scene.AddAction(Phase.Update, moveActorAction);
            scene.AddAction(Phase.Update, spawnEnemyAction);
            scene.AddAction(Phase.Update, moveEnemyAction);
            scene.AddAction(Phase.Output, drawActorAction);

            // Start the game.
            Director director = new Director(serviceFactory);
            director.Direct(scene);
        }
    }
}
