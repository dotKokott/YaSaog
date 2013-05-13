using System.Xml;

namespace YaSaog.Entities {

    public class Level : BaseEntity {

        public string File { get; private set; }
        public XmlDocument Document { get; private set; }        

        public Level(string file, XmlDocument document) {
            File = file;
            Document = document;
        }

        public override void Init() {
            foreach (XmlElement element in Document.SelectNodes("level/Entities")[0].ChildNodes) {
                Scene.AddEntity(EntityFactory.CreateFromElement(element));           
            }   
        }        

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
        }

        public override void Delete() {            
        }
    }
}