namespace DesignPatternsInCSharp.Creational.Prototype
{
    public class PersonShallowCopy : ICloneable
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public IdInfo IdInfo { get; set; }

        public object Clone()
        {
            return (PersonShallowCopy)this.MemberwiseClone();
        }
    }

    public class PersonDeepCopy : ICloneable
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public IdInfo IdInfo { get; set; }

        public object Clone()
        {
            PersonDeepCopy clone = (PersonDeepCopy)MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = string.Copy(Name);
            return clone;
        }
    }
}
