using Microsoft.Xna.Framework.Media;
namespace YaSaog.Utils.ActionLists.Actions {

    class FadeInSong : IAction {
                
        public bool IsBlocking { get; set; }
        public bool IsComplete { get; set; }

        public Song Song { get; set; }
        public bool Repeat { get; set; }
        public float MaxVolume { get; set; }

        public FadeInSong(Song song, bool repeat, float maxVolume) {
            Song = song;
            Repeat = repeat;
            MaxVolume = maxVolume;
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime) {
            MediaPlayer.IsRepeating = Repeat;

            if (MediaPlayer.Queue.ActiveSong == null) {
                MediaPlayer.Volume = 0;
                MediaPlayer.Play(Song);
            }                

            if (MediaPlayer.Queue.ActiveSong != Song) {
                if (MediaPlayer.Volume > 0) {
                    MediaPlayer.Volume -= 0.01f;
                } else {
                    MediaPlayer.Play(Song);
                }
            } else {
                if (MediaPlayer.Volume < MaxVolume) {
                    MediaPlayer.Volume += 0.01f;
                } else {
                    IsComplete = true;
                }
            }
        }
    }
}
