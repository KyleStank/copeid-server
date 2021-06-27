using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopeID.API
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AutoIncludeAttribute : Attribute
    {
        public AutoIncludeAttribute()
        {
            Console.WriteLine("AutoIncludeAttribute created!");
        }
    }
}
