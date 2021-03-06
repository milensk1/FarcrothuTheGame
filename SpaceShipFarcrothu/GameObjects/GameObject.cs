﻿namespace SpaceShipFartrothu.GameObjects
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Interfaces;
    using System;

    public abstract class GameObject : ICollidable, IGameObject
    {
        protected Texture2D texture;
        protected Rectangle boundingBox;
        protected Vector2 position;
        protected bool isVisible;
        protected int speed;

        protected GameObject(Vector2 position)
        {
            this.Position = position;
            this.IsVisible = true;
        }

        public Texture2D Texture { get; protected set; }

        public Rectangle BoundingBox { get; protected set; }

        public Vector2 Position { get;  set; }

        public bool IsVisible { get; protected set; }

        public int Speed { get; set; }

        public int Damage { get; protected set; }

        public virtual int Health { get; set; }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void ReactOnColission(IGameObject target = null);
    }
}
