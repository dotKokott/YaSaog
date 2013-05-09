using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;

namespace YaSaog {
    public static class Assets {

        public static SpriteFont SmallDebug { get; set; }
        public static SpriteFont UI { get; set; }
        public static SpriteFont MenuDefault { get; set; }
        public static SpriteFont MenuSelected { get; set; }

        public static Texture2D BubbleBlue { get; set; }
        public static Texture2D HairDryer { get; set; }

        public static XmlDocument TestLevel { get; set; }

        public static void LoadContent(ContentManager content) {
            SmallDebug = content.Load<SpriteFont>("SmallDebugFont");
            UI = content.Load<SpriteFont>("UIFont");
            MenuDefault = content.Load<SpriteFont>("MenuDefaultFont");
            MenuSelected = content.Load<SpriteFont>("MenuSelectedFont");

            BubbleBlue = content.Load<Texture2D>("Images/bubble_blue");
            HairDryer = content.Load<Texture2D>("Images/hair_dryer");

            TestLevel = new XmlDocument();
            TestLevel.Load("Levels/TestLevel.oel");
        }
    }
}
