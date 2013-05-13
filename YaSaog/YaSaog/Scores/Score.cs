using System.IO;

namespace YaSaog.Scores {

    public class Score {

        public string Level { get; private set; }
        public float Time { get; private set; }
        public int StarCount { get; private set; }

        public Score(string level, float time, int starCount) {
            Level = level;
            Time = time;
            StarCount = starCount;
        }

        public void Save() {
            if (!Directory.Exists("Scores")) Directory.CreateDirectory("Scores");

            using (var sw = new StreamWriter(Path.Combine("Scores", Level), false)) {
                sw.WriteLine(string.Concat(Time.ToString(), ";", StarCount.ToString()));
            }
        }

        public static Score LoadFromFile(string file) {
            Score score = default(Score);

            if (File.Exists(Path.Combine("Scores", file))) {
                using (var sr = new StreamReader(Path.Combine("Scores", file))) {
                    var data = sr.ReadLine().Split(';');
                    score = new Score(file, float.Parse(data[0]), int.Parse(data[1]));
                }
            }

            return score;
        }
    }
}
