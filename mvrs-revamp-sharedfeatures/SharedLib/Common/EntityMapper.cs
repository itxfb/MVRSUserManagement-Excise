using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Common
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MatchParentAttribute : Attribute
    {
        public readonly string ParentPropertyName;
        public MatchParentAttribute(string parentPropertyName)
        {
            ParentPropertyName = parentPropertyName;
        }
    }

    public class EntityMapper<TParent, TChild> where TParent : class
                                            where TChild : class
    {
        public static void CopyByPropertyName(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name)
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }

        public static void CopyByPropertyNameAndType(TParent parent, TChild child)
        {
            var parentProperties = parent.GetType().GetProperties();
            var childProperties = child.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && 
                        (parentProperty.PropertyType == childProperty.PropertyType || Nullable.GetUnderlyingType(parentProperty.PropertyType) == childProperty.PropertyType))
                    {
                        childProperty.SetValue(child, parentProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }

        public static void CopyByMatchParentAttribute(TParent parent, TChild child)
        {
            var childProperties = child.GetType().GetProperties();
            foreach (var childProperty in childProperties)
            {
                var attributesForProperty = childProperty.GetCustomAttributes(typeof(MatchParentAttribute), true);
                var isOfTypeMatchParentAttribute = false;

                MatchParentAttribute currentAttribute = null;

                foreach (var attribute in attributesForProperty)
                {
                    if (attribute.GetType() == typeof(MatchParentAttribute))
                    {
                        isOfTypeMatchParentAttribute = true;
                        currentAttribute = (MatchParentAttribute)attribute;
                        break;
                    }
                }

                if (isOfTypeMatchParentAttribute)
                {
                    var parentProperties = parent.GetType().GetProperties();
                    object parentPropertyValue = null;
                    foreach (var parentProperty in parentProperties)
                    {
                        if (parentProperty.Name == currentAttribute.ParentPropertyName)
                        {
                            if (parentProperty.PropertyType == childProperty.PropertyType)
                            {
                                parentPropertyValue = parentProperty.GetValue(parent);
                            }
                        }
                    }
                    childProperty.SetValue(child, parentPropertyValue);
                }
            }
        }
    }
}
