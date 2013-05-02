using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Xml;
using System.Linq;

namespace YaSaog.Entities {

    public static class EntityFactory {

        private static Assembly assembly = Assembly.GetExecutingAssembly();

        public static BaseEntity CreateFromElement(XmlElement element) {
            var typeName = "YaSaog.Entities." + element.Name;
            var type = assembly.GetType(typeName, false);

            if (type == null) return null;

            BaseEntity ent = (BaseEntity)Activator.CreateInstance(type);

            foreach (XmlAttribute attr in element.Attributes) {
                var name = attr.Name.First().ToString().ToUpper() + String.Join("", attr.Name.Skip(1));

                PropertyInfo prop = type.GetProperty(name);
                if (prop != null) {                    
                    prop.SetValue(ent, Convert.ChangeType(attr.Value, prop.PropertyType), null);
                }
            }

            return ent;
        }
    }
}
