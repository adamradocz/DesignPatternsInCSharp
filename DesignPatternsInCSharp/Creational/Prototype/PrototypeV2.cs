using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Creational.Prototype
{

    public class Address
    {
        public string State { get; set; }

        public string City { get; set; }
    }

    public class AuthorForShallowCopy : ICloneable
    {
        public string Name { get; set; }
        public string TwitterAccount { get; set; }
        public string Website { get; set; }
        public Address HomeAddress { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class AddressICloneable : ICloneable
    {
        public string State { get; set; }
        public string City { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class AuthorForDeepCopy : ICloneable
    {
        public string Name { get; set; }
        public string TwitterAccount { get; set; }
        public string Website { get; set; }
        public AddressICloneable HomeAddress { get; set; }
        public object Clone()
        {
            AuthorForDeepCopy objPriCopy = (AuthorForDeepCopy)this.MemberwiseClone();
            objPriCopy.HomeAddress = (AddressICloneable)this.HomeAddress.Clone();
            return objPriCopy;
        }
    }
}
