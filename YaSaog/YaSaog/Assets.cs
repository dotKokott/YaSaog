using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace YaSaog {
    public static class Assets {

        public static Texture2D BubbleBlue { get; set; }

        public static void LoadContent(ContentManager content) {
            BubbleBlue = content.Load<Texture2D>("Images/bubble_blue");
        }
    }
}
