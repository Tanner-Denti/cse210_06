using System;
using Casting;
using Services;


namespace Scripting
{
    public class SpawnEnemyAction : Scripting.Action
    {
        private Random random;
        private bool spawnTimerActive;
        private bool enemySpawn;
        private DateTime lastSpawn;
        private float spawnInterval;

        public SpawnEnemyAction(IServiceFactory serviceFactory)
        {
            this.spawnTimerActive = false;
            this.enemySpawn = false;
            this.lastSpawn = new DateTime();
            this.spawnInterval = spawnInterval * 1000;
            this.random = new Random();
        }


        private Enemy CreateEnemy(int x, int y)
        {
            Enemy enemy = new Enemy();
            enemy.SizeTo(30,30);
            enemy.MoveTo(x, y);
            enemy.Tint(Color.Red());
            return enemy;    
        }


        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            if (!this.spawnTimerActive)
            {
                this.spawnTimerActive = true;
                this.lastSpawn = DateTime.Now;
            }

            if ((DateTime.Now - this.lastSpawn).TotalMilliseconds >= this.spawnInterval)
            {
                int x;
                int y;
                int edge = this.random.Next(1, 5);
                if (edge == 1) //top edge
                {
                    x = this.random.Next(1, 1251);
                    y = 0;
                }
                else if (edge == 2) //right edge
                {
                    x = 1250;
                    y = this.random.Next(1, 931);
                }
                else if (edge == 3) //bottom edge
                {
                    x = this.random.Next(1, 1251);
                    y = 930;
                }
                else //left edge
                {
                    x = 0;
                    y = this.random.Next(1, 931);
                }
                Enemy enemy = this.CreateEnemy(x, y);

                scene.AddActor("enemies", enemy);

                this.lastSpawn = DateTime.Now;


            }
        }
    }
}
