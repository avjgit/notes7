using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_extensions
{
    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', ',', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
