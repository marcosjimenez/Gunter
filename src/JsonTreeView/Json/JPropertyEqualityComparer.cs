﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ZTn.Json.JsonTreeView.Json
{
    /// <summary>
    /// Defines methods to support the comparison of <see cref="JProperty"/> objects for equality.
    /// </summary>
    sealed class JPropertyEqualityComparer : IEqualityComparer<JProperty>
    {
        /// <inheritdoc />
        public bool Equals(JProperty x, JProperty y)
        {
            return x.Name == y.Name;
        }

        /// <inheritdoc />
        public int GetHashCode(JProperty obj)
        {
            if (obj == null)
            {
                return 0;
            }
            return obj.Name.GetHashCode();
        }
    }
}
