using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using YaSaog.Entities;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace YaSaog {
    public static class Assets {

        public static SpriteFont SmallDebug { get; set; }
        public static SpriteFont UI { get; set; }
        public static SpriteFont MenuDefault { get; set; }
        public static SpriteFont MenuSelected { get; set; }

        public static Texture2D Logo { get; set; }
        public static Texture2D IngameBackground { get; set; }
        public static Texture2D BubbleBlue { get; set; }
        public static Texture2D HairDryer { get; set; }
        public static Texture2D Cloud { get; set; }
        public static Texture2D Spikes { get; set; }
        public static Texture2D Star { get; set; }

        public static List<Level> Levels { get; set; }

        public static Song Ingame { get; set; }
        public static Song Menu { get; set; }

        public static SoundEffect MenuHover { get; set; }
        public static SoundEffect MenuClick { get; set; }

        public static SoundEffectInstance DryerOn { get; set; }
        public static SoundEffectInstance DryerOff { get; set; }
        public static SoundEffectInstance DryerDry { get; set; }

        public static SoundEffect StarCollect { get; set; }
        public static SoundEffect Finish { get; set; }
        public static SoundEffect BubblePop { get; set; }

        public static void LoadContent(ContentManager content) {
            SmallDebug = content.Load<SpriteFont>("SmallDebugFont");
            UI = content.Load<SpriteFont>("UIFont");
            MenuDefault = content.Load<SpriteFont>("MenuDefaultFont");
            MenuSelected = content.Load<SpriteFont>("MenuSelectedFont");

            Logo = content.Load<Texture2D>("Images/logo");
            IngameBackground = content.Load<Texture2D>("Images/ingame");
            BubbleBlue = content.Load<Texture2D>("Images/bubble_blue");
            HairDryer = content.Load<Texture2D>("Images/hair_dryer");
            Cloud = content.Load<Texture2D>("Images/cloud");
            Spikes = content.Load<Texture2D>("Images/spikes");
            Star = content.Load<Texture2D>("Images/star");

            Levels = new List<Level>();
            foreach (var file in Directory.GetFiles("Levels", "*.oel").OrderBy(f => f)) {
                var level = new XmlDocument();
                level.Load(file);

                Levels.Add(new Level(Path.GetFileName(file), level));
            }

            Ingame = content.Load<Song>("Music/Songs/ingame");
            Menu = content.Load<Song>("Music/Songs/menu");

            MenuHover = content.Load<SoundEffect>("Music/Effects/menu_hover");
            MenuClick = content.Load<SoundEffect>("Music/Effects/menu_click");

            DryerOn = content.Load<SoundEffect>("Music/Effects/dryer_on").CreateInstance();
            DryerOff = content.Load<SoundEffect>("Music/Effects/dryer_off").CreateInstance();
            DryerDry = content.Load<SoundEffect>("Music/Effects/dryer_dry").CreateInstance();

            StarCollect = content.Load<SoundEffect>("Music/Effects/star_collect");
            Finish = content.Load<SoundEffect>("Music/Effects/finish");
            BubblePop = content.Load<SoundEffect>("Music/Effects/bubble_pop");
        }
    }
}
