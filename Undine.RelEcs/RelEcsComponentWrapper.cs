using System;
using System.Collections.Generic;
using System.Text;

namespace Undine.RelEcs
{
    public class RelEcsComponentWrapper<T>
        where T : struct
    {
        public T Value;
    }
}
