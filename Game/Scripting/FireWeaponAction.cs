using System;
using System.Collections.Generic;
using System.Numerics;
using Casting;
using Services;


namespace Scripting
{
    public class FireWeaponAction : Scripting.Action
    {
        private IMouseService _mouseService;
        private Vector2 target;
        private Vector2 playerPos;
        float vx;
        float vy;

        public FireWeaponAction(IServiceFactory serviceFactory)
        {
            this._mouseService = serviceFactory.GetMouseService();
        }

        private Bullet CreateBullet(Vector2 playerPos)
        {
            Bullet bullet = new Bullet();
            bullet.SizeTo(10,10);
            bullet.MoveTo(playerPos);
            bullet.Tint(Color.Green());
            return bullet;
        }

        public override void Execute(Scene scene, float deltaTime, IActionCallback callback)
        {
            if(_mouseService.IsButtonPressed(MouseButton.Left))
            {
                Actor player = scene.GetFirstActor("player");
                Vector2 target = _mouseService.GetCoordinates();
                Vector2 playerPos = player.GetCenter();
                Bullet bullet = this.CreateBullet(playerPos);
                scene.AddActor("bullets", bullet);
                vx = (target.X - playerPos.X)/35;
                vy = (target.Y - playerPos.Y)/35;


                Console.WriteLine(vx);
                Console.WriteLine(vy);
                
                bullet.Steer(vx,vy);
            }    
            



        }

    }
}