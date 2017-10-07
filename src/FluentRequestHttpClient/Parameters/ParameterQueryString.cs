using System;
using System.Collections.Generic;
using System.Text;

namespace FluentRequestHttpClient.Parameters
{
    public sealed class ParameterQueryString
    {
        #region Properties
        /// <summary>
        /// Name parameter
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// Value Parameter
        /// </summary>
        public object Value
        {
            get;
            private set;
        }

        #endregion

        #region Constructors
        internal ParameterQueryString()
        {
            this.Name = null;
            this.Value = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        internal ParameterQueryString(string name, object value)
            : this()
        {
            this.Name = name;
            this.Value = value;
        } 
        #endregion

        #region Factor
        public static class Factor
        {
            public static ParameterQueryString Create(string name, object value)
            {
                return new ParameterQueryString(name, value);
            }
        }
        #endregion
    }
}
