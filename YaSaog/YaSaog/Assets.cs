using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Entities;

namespace YaSaog {
    public static class Assets {

        public static SpriteFont SmallDebug { get; set; }
        public static SpriteFont UI { get; set; }
        public static SpriteFont MenuDefault { get; set; }
        public static SpriteFont MenuSelected { get; set; }

        public static Texture2D BubbleBlue { get; set; }
        public static Texture2D HairDryer { get; set; }

        public static List<Level> Levels { get; set; }        

        public static void LoadContent(ContentManager content) {
            SmallDebug = content.Load<SpriteFont>("SmallDebugFont");
            UI = content.Load<SpriteFont>("UIFont");
            MenuDefault = content.Load<SpriteFont>("MenuDefaultFont");
            MenuSelected = content.Load<SpriteFont>("MenuSelectedFont");

            BubbleBlue = content.Load<Texture2D>("Images/bubble_blue");
            HairDryer = content.Load<Texture2D>("Images/hair_dryer");

            Levels = new List<Level>();
            foreach (var file in Directory.GetFiles("Levels", "*.oel").OrderBy(f => f)) {
                var level = new XmlDocument();
                level.Load(file);

                Levels.Add(new Level(Path.GetFileName(file), level));
            }
        }
    }
}
