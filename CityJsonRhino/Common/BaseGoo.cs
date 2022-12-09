using System;
using CityJsonRhino.Attributes;
using GH_IO.Serialization;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;
using Newtonsoft.Json;

namespace CityJsonRhino.Common
{
    /// <summary>
    /// Sane defaults for goo wrapped objects
    /// - Allows the usage of 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseGoo<T> : GH_Goo<T> where T : new()
    {
        private string _typeName;
        private string _typeDescription;

        /// <summary>
        /// Force a duplicate method
        /// </summary>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        public abstract IGH_Goo Duplicate(T oldValue);

        public override object ScriptVariable()
        {
            return Value;
        }

        /// <summary>
        /// Make duplicate method explicitly only applicable to the value
        /// </summary>
        /// <returns></returns>
        public override IGH_Goo Duplicate()
        {
            return Duplicate(Value);
        }

        /// <summary>
        /// Set default value of IGH_Goo to an empty class
        /// </summary>
        public override T Value { get; set; } = new T();

        /// <summary>
        /// Copy name and description from GhParam attributes on the class
        /// </summary>
        public void CopyAttributes()
        {
            // only set once.
            if (_typeName != null) return;
            var attribute = (GhParam) Attribute.GetCustomAttribute(typeof(T), typeof(GhParam));

            _typeDescription = attribute?.Description ?? "";
            _typeName = attribute?.Name ?? "";
        }

        /// <summary>
        /// Override if needed
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value.ToString();
        }

        /// <summary>
        /// Override if needed.
        /// </summary>
        public override bool IsValid => true;

        /// <summary>
        /// Get the type from GhParam attributes of the wrapped class
        /// </summary>
        public override string TypeName
        {
            get
            {
                if (_typeName == null)
                {
                    CopyAttributes();
                }

                return _typeName ?? $"Class {nameof(T)}";
            }
        }

        /// <summary>
        /// Basic casts: from it's to type and back
        /// </summary>
        /// <typeparam name="TQ"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public override bool CastTo<TQ>(ref TQ target)
        {
            if (typeof(TQ).IsAssignableFrom(typeof(T)))
            {
                target = (TQ) (object) Value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Basic casts: from it's wrapper type and back
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public override bool CastFrom(object source)
        {
            if (source == null)
            {
                return false;
            }

            if (source is T sourceObj)
            {
                // Pretty shitty way to copy T.
                // but it should work pretty well.
                var copy = (GH_Goo<T>)Duplicate(sourceObj);
                Value = copy.Value;
                return true;
            }

            return base.CastFrom(source);
        }


        public override string TypeDescription
        {
            get
            {
                if (_typeDescription == null)
                {
                    CopyAttributes();
                }

                return _typeName ?? $"No description of class {nameof(T)} found";
            }
        }

        public override bool Write(GH_IWriter writer)
        {
            writer.SetString("json", JsonConvert.SerializeObject(Value));
            return true;
        }
        public override bool Read(GH_IReader reader)
        {
            var jsonText = reader.GetString("json");
            if (jsonText == null)
            {
                return false;
            }
            Value = JsonConvert.DeserializeObject<T>(jsonText);
            return true;
        }
    }
}
