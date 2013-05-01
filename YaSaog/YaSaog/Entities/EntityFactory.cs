using System.Xml;
namespace YaSaog.Entities {

    public static class EntityFactory {

        public static BaseEntity CreateFromElement(XmlElement element) {
            var x = int.Parse(element.Attributes["x"].Value);
            var y = int.Parse(element.Attributes["y"].Value);

            switch (element.Name) {
                case "Bubble":
                    var bubble = new Bubble(x, y);

                    return bubble;
                case "SolidSpike":
                    var spike = new SolidSpike(x, y);

                    return spike;
            }

            return null;
        }
    }
}
