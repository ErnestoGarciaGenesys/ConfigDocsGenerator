using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Util
{
    class ToString
    {
        public static string Collection<E>(ICollection<E> collection, string separator)
        {
            StringBuilder result = new StringBuilder();

            int i = 0;
            foreach (E element in collection)
            {
                if (i != 0)
                    result.Append(separator);

                result.Append(element.ToString());

                i++;
            }

            return result.ToString();
        }
    }
}
