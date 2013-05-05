using System;
using System.Linq;
using System.Reflection;
using System.Xml;
using YaSaog.Utils;

namespace YaSaog.Entities {

    public static class EntityFactory {

        public static BaseEntity CreateFromElement(XmlElement element) {
            var typeName = "YaSaog.Entities." + element.Name;
            var type = ReflectionHelper.GetTypeByName(typeName);

            if (type == null) return null;

            BaseEntity ent = type.CreateInstance<BaseEntity>();

            foreach (XmlAttribute attr in element.Attributes) {
                var name = attr.Name.First().ToString().ToUpper() + String.Join("", attr.Name.Skip(1));

                type.SetProperty(ent, name, attr.Value);
            }

            return ent;
        }
    }
}
