using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Common
{
    public static class Extentions
    {
        public static DataTable ToDataTable<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x =>
                {
                    //var propType = x.GetType();

                    if (x.PropertyType.IsPrimitive)
                    {
                        return true;
                    }
                    else if (x.PropertyType == typeof(string))
                    {
                        return true;
                    }
                    else if (x.PropertyType == typeof(DateTime))
                    {
                        return true;
                    }
                    else
                    { 
                        var nullableUnderlyingType = Nullable.GetUnderlyingType(x.PropertyType);

                        if (nullableUnderlyingType is not null)
                        {
                            return nullableUnderlyingType.IsPrimitive || nullableUnderlyingType.IsValueType;
                        }
                    }

                    return false;
                })
                .OrderBy(x => x.Name)
                .ToArray();

            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }

            foreach (T item in iList)
            {
                var values = new object[Props.Length];

                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows

                    if (Props[i].PropertyType == typeof(DateTime))
                    {
                        var datetime = new DateTime();

                        if (DateTime.TryParse(Props[i].GetValue(item, null).ToString(), out datetime))
                        { 
                            //values[i] = datetime.ToString("u");
                            values[i] = datetime.ToString("yyyy-MM-dd hh:mm:ss");
                        }
                    }
                    else
                    { 
                        values[i] = Props[i].GetValue(item, null);
                    }
                }

                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public static DataTable ToDataTable_Old<T>(this List<T> iList)
        {
            DataTable dataTable = new DataTable();
            PropertyDescriptorCollection propertyDescriptorCollection =
                TypeDescriptor.GetProperties(typeof(T));
            for (int i = 0; i < propertyDescriptorCollection.Count; i++)
            {
                PropertyDescriptor propertyDescriptor = propertyDescriptorCollection[i];
                Type type = propertyDescriptor.PropertyType;

                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                    type = Nullable.GetUnderlyingType(type);


                dataTable.Columns.Add(propertyDescriptor.Name, type);
            }
            object[] values = new object[propertyDescriptorCollection.Count];
            foreach (T iListItem in iList)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = propertyDescriptorCollection[i].GetValue(iListItem);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        private static readonly IDictionary<Type, ICollection<PropertyInfo>> _Properties = new Dictionary<Type, ICollection<PropertyInfo>>();

        public static IEnumerable<T> ToEnumerable<T>(this DataTable table) where T : class, new()
        {
            try
            {
                var objType = typeof(T);
                ICollection<PropertyInfo> properties;

                lock (_Properties)
                {
                    if (!_Properties.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite).ToList();
                        _Properties.Add(objType, properties);
                    }
                }

                var list = new List<T>(table.Rows.Count);

                //foreach (var row in table.AsEnumerable().Skip(1))
                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        //try
                        //{
                        //    var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        //    var safeValue = row[prop.Name] == null ? null : Convert.ChangeType(row[prop.Name], propType);

                        //    prop.SetValue(obj, safeValue, null);
                        //}
                        //catch
                        //{
                        //    // ignored
                        //}

                        if (table.Columns.Contains(prop.Name) == false)
                            prop.SetValue(obj, null, null);
                        else
                            if (row[prop.Name] == DBNull.Value)
                            prop.SetValue(obj, null, null);
                        else
                            prop.SetValue(obj, row[prop.Name], null);
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>();
            }
        }
        
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                var objType = typeof(T);
                ICollection<PropertyInfo> properties;

                lock (_Properties)
                {
                    if (!_Properties.TryGetValue(objType, out properties))
                    {
                        properties = objType.GetProperties().Where(property => property.CanWrite).ToList();
                        _Properties.Add(objType, properties);
                    }
                }

                var list = new List<T>(table.Rows.Count);

                //foreach (var row in table.AsEnumerable().Skip(1))
                foreach (var row in table.AsEnumerable())
                {
                    var obj = new T();

                    foreach (var prop in properties)
                    {
                        //try
                        //{
                        //    var propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                        //    var safeValue = row[prop.Name] == null ? null : Convert.ChangeType(row[prop.Name], propType);

                        //    prop.SetValue(obj, safeValue, null);
                        //}
                        //catch
                        //{
                        //    // ignored
                        //}

                        if (table.Columns.Contains(prop.Name) == false)
                            prop.SetValue(obj, null, null);
                        else
                            if (row[prop.Name] == DBNull.Value)
                            prop.SetValue(obj, null, null);
                        else
                            prop.SetValue(obj, row[prop.Name], null);
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<T>().ToList();
            }
        }
        
    }
}
