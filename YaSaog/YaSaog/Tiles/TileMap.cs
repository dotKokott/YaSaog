namespace YaSaog.Tiles {

    public class TileMap {

        public int Width { get; set; }
        public int Height { get; set; }

        public int TileSize { get; set; }

        public TileMap(int width, int height, int tileSize) {
            Width = width;
            Height = height;
            TileSize = tileSize;
        }



    }
}
