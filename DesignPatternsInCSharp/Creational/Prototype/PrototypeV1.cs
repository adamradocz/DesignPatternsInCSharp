namespace DesignPatternsInCSharp.Creational.Prototype
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public IdInfo IdInfo { get; set; }

        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person)MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = string.Copy(Name);
            return clone;
        }
    }
}
