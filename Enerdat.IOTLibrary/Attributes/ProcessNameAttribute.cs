using System;

namespace Enerdat.IOTLibrary.Attributes
{
    /// <summary>
    /// Process name attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ProcessNameAttribute : Attribute
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Process name.</param>
        /// <param name="parametersType">Process parameters type.</param>
        public ProcessNameAttribute(string name, Type parametersType)
        {
            Name = name;
            ParametersType = parametersType;
        }

        /// <summary>
        /// Process name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Process parameters type.
        /// </summary>
        public Type ParametersType { get; set; }
    }
}