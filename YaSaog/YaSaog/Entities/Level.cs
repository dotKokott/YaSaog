using System.Xml;
using System.Collections.Generic;

namespace YaSaog.Entities {

    public class Level : BaseEntity {
        
        public XmlDocument Document { get; private set; }        

        public Level(XmlDocument document) {
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