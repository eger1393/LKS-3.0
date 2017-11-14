using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS_3._0
{
    [System.AttributeUsage(AttributeTargets.All)] //, Inherited = false, AllowMultiple = true)
    class RusNameAttribute : Attribute
    {
        readonly string RussianTittle;

        public RusNameAttribute(string RusName)
        {
            this.RussianTittle = RusName;
        }

        public string Get_RussianTittle
        {
            get { return RussianTittle; }
        }
    }
}
