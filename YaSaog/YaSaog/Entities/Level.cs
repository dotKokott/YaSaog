using System.Xml;
using System.Collections.Generic;

namespace YaSaog.Entities {

    public class Level : BaseEntity {
        
        public XmlDocument File { get; private set; }        

        public Level(XmlDocument file) {
            File = file;
        }

        public override void Init() {
            foreach (XmlElement element in File.SelectNodes("level/Entities")[0].ChildNodes) {
                Screen.AddEntity(EntityFactory.CreateFromElement(element));           
            }   
        }        

        public override void Draw(ExtendedSpriteBatch spriteBatch) {
        }

        public override void Delete() {            
        }
    }
}