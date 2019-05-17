using System;
using System.Collections.Generic;
using System.Text;

namespace CfgDoc.Input.Db
{
    class Key
    {
        string[] values;

        public Key(params string[] values)
        {
            this.values = values;
        }

        public override bool Equals(object obj)
        {
            if (obj is Key)
            {
                Key index = obj as Key;

                if (this.values.Length == index.values.Length)
                {
                    for (int i = 0; i < this.values.Length; i++)
                        if (this.values[i] != index.values[i])
                            return false;

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int sum = 0;

            foreach (string s in values)
                sum ^= s.GetHashCode();

            return sum;
        }

        public override string ToString()
        {
            return "Index(" + Util.ToString.Collection(values, ", ") + ")";
        }
    }
}
