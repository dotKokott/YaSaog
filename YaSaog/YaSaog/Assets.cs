using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace YaSaog {
    public static class Assets {

        public static SpriteFont SmallDebugFont { get; set; }

        public static Texture2D BubbleBlue { get; set; }
        public static Texture2D HairDryer { get; set; }

        public static XmlDocument TestLevel { get; set; }

        public static void LoadContent(ContentManager content) {
            SmallDebugFont = content.Load<SpriteFont>("SmallDebugFont");

            BubbleBlue = content.Load<Texture2D>("Images/bubble_blue");
            HairDryer = content.Load<Texture2D>("Images/hair_dryer");

            TestLevel = new XmlDocument();
            TestLevel.Load("Levels/TestLevel.oel");
        }
    }
}
