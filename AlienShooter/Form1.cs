﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlienShooter
{
    public partial class Form1 : Form
    {
        Level lv1;

        private List<Unit> enemies = new List<Unit>(25); 
       
        private int mouseX;
        private int mouseY;

        Random rnd1 = new Random();

        Player plr1 = new Player(250,250,2);
        
        public Form1()
        {
            InitializeComponent();
            lv1 = new Level(Width, Height);
            
            for (int i = 0; i < 25; i++)
            {
                enemies.Add(new Unit(rnd1.Next(600), rnd1.Next(500), rnd1.Next(16)));
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics canvas = e.Graphics;
            lv1.Draw(canvas);
            plr1.Draw(canvas);
            foreach (Unit unit in enemies)
            {
                unit.GetFacing(plr1);
                unit.mouseX = mouseX;
                unit.mouseY = mouseY;
                if (unit.posX == plr1.posX && unit.posY == plr1.posY)
                {
                    unit.dead = true;
                }
                unit.Draw(canvas);                  
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            plr1.ProcessKeys(true, e.KeyData);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            plr1.ProcessKeys(false, e.KeyData);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }
    }
}
