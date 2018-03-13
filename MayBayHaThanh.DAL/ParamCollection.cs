using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayBayHaThanh.DAL
{
    public class ParamCollection : System.Collections.CollectionBase
    {
        public ParamStruct Items(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                return null;
            }
            else
            {
                return (ParamStruct)List[index];
            }
        }

        public ParamStruct Items(string name)
        {
            if (List.Count == 0)
            {
                return null;
            }
            else
            {
                for (Int32 index = 0; index <= List.Count - 1; index++)
                {
                    if (((ParamStruct)List[index]).ParamName == name)
                    {
                        return (ParamStruct)List[index];
                    }
                }
            }
            return null;
        }

        public ParamStruct this[int index]
        {
            get { return (ParamStruct)List[index]; }
            set { List[index] = value; }
        }

        public Int32 Add(ParamStruct value)
        {
            return (List.Add(value));
        }
    }
}
