﻿namespace SpaceShipFartrothu.Handlers
{
    using GameObjects;
    using GameObjects.Items;
    using System.Collections.Generic;
    using System.Linq;

    public static class CollisionHandler
    {
        //check players for gameobjects collisions
        public static void CheckForCollision(List<GameObject> targets)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                GameObject currentTarget = targets[i];

                foreach (var player in Player.Players)
                {
                    if (player.BoundingBox.Intersects(currentTarget.BoundingBox))
                    {
                        if (currentTarget is EnemyEntity)
                        {
                            player.Score += (currentTarget as EnemyEntity).ScorePoints;

                            player.ReactOnColission(currentTarget);
                            currentTarget.ReactOnColission();
                        }
                        else if (currentTarget is Item)
                        {
                            if (currentTarget.IsVisible)
                            {
                                currentTarget.ReactOnColission(player);
                            }
                        }
                    }
                }
            }
        }



        //check if player bullets collides with gameobjects
        public static void CheckPlayerBulletsCollisions(List<GameObject> targets)
        {
            foreach (var player in Player.Players)
            {
                var playerBullets = Bullet.Bullets.Where(b => b.ShooterId == player.Id).ToList();

                for (int i = 0; i < targets.Count; i++)
                {
                    GameObject currentTarget = targets[i];

                    foreach (var playerBullet in playerBullets)
                    {
                        if (currentTarget.BoundingBox.Intersects(playerBullet.BoundingBox))
                        {
                            //player.ReactOnColission(currentTarget);
                            //TODO: increase player points
                            player.Score += (currentTarget as EnemyEntity).ScorePoints;

                            playerBullet.ReactOnColission();
                            currentTarget.ReactOnColission();
                        }
                    }
                }
            }

        }

        //check enemies bullets for collision with palyer
        public static void CheckEnemiesBulletsCollisions()
        {
            var enemiesBullets = Bullet.Bullets.Where(b => b.ShooterId == 0).ToList();

            foreach (Player player in Player.Players)
            {
                for (int i = 0; i < enemiesBullets.Count; i++)
                {
                    var currentBullet = enemiesBullets[i];

                    if (player.BoundingBox.Intersects(currentBullet.BoundingBox))
                    {
                        player.ReactOnColission(currentBullet);
                        currentBullet.ReactOnColission();
                    }
                }
            }
        }

        //check boss bullets for collision with players
        public static void CheckBossBulletsCollisions()
        {
            var bossBullets = Bullet.Bullets.Where(b => b.ShooterId == 3).ToList();

            foreach (Player player in Player.Players)
            {
                for (int i = 0; i < bossBullets.Count; i++)
                {
                    var currentBullet = bossBullets[i];

                    if (player.BoundingBox.Intersects(currentBullet.BoundingBox))
                    {
                        player.ReactOnColission(currentBullet);
                        currentBullet.ReactOnColission();
                    }
                }
            }
        }
    }
}


