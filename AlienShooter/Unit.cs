﻿using System.Drawing;
using System.Collections.Generic;

namespace AlienShooter
{
    class Unit
    {
        public int posX;
        public int posY;
        public int frameCount = 10;
        public int facing = 5; 
        public int speed = 3;
        public int mouseX;
        public int mouseY;

        int count;

        public bool KeyUp;
        public bool KeyLeft;
        public bool KeyDown;
        public bool KeyRight;

        public List<Bitmap> animChain = new List<Bitmap>();
        public UnitFrames frameSource = new UnitFrames(Resource1.zergl_full);

        public const int UP = 0;
        public const int UP_RIGHT = 2;
        public const int RIGHT = 4;
        public const int DOWN_RIGHT = 6;
        public const int DOWN = 8;
        public const int DOWN_LEFT = 16;
        public const int LEFT = 14;
        public const int UP_LEFT = 12;
        

        public Unit(int _posX, int _posY)
        {
            posX = _posX;
            posY = _posY;
            frameSource.DumpAllFrames();
            animChain = frameSource.GetAnim(facing);
        }

        public Unit(int _posX, int _posY, int _facing)
        {
            posX = _posX;
            posY = _posY;
            frameSource.DumpAllFrames();
            facing = _facing;
            animChain = frameSource.GetAnim(facing);
        }
        
        public Unit() 
        {
            // Это использовать нельзя иначе пиздец
        }

        public void GetFacing(Player plr)
        {
            int oldFacing = facing;

            if (plr.posX > posX && plr.posY > posY)
            {
                facing = DOWN_RIGHT;
            }

            else if (plr.posX < posX && plr.posY < posY)
            {
                facing = UP_LEFT;
            }

            else if (plr.posX > posX && plr.posY < posY)
            {
                facing = UP_RIGHT;
            }

            else if (plr.posX < posX && plr.posY > posY)
            {
                facing = DOWN_LEFT;
            }

            else if (plr.posX > posX)
            {
                facing = RIGHT;
            }

            else if (plr.posX < posX)
            {
                facing = LEFT;
            }

            else if (plr.posY > posY)
            {
                facing = DOWN;
            }

            else if (plr.posY < posY)
            {
                facing = UP;
            }

            if (facing != oldFacing)
            {
                animChain = frameSource.GetAnim(facing);
            }
        }

        public void Die()
        {
            
        }

        /// <summary>
        /// Movement and draw routines
        /// </summary>
        /// <param name="canvas">>GDI+ Graphics Object</param>

        public void draw(Graphics canvas)
        {
            switch (facing)
            {
                case UP:
                    posY -= speed;
                    break;
                case RIGHT:
                    posX += speed;
                    break;
                case DOWN:
                    posY += speed;
                    break;
                case UP_RIGHT:
                    posX += speed;
                    posY -= speed;
                    break;
                case DOWN_RIGHT:
                    posX += speed;
                    posY += speed;
                    break;
                case DOWN_LEFT:
                    posX -= speed;
                    posY += speed;
                    break;
                case UP_LEFT:
                    posX -= speed;
                    posY -= speed;
                    break;
                case LEFT:
                    posX -= speed;
                    break;
            }

            if (posX > 640 - 64) posX = 640 - 64;
            if (posY > 512 - 64) posY = 512 - 64;
            if (posX < 0) posX = 0;
            if (posY < 0) posY = 0;

            canvas.DrawImage(animChain[count], posX, posY);
            count++;
            if (count > frameCount) count = 0;
        }
    }
}
