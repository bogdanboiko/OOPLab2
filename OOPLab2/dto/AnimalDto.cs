namespace OOPLab2
{
    public class AnimalDto
    {
        public string type { get; }
        public string homeland { get; }
        public string name { get; }
        public DateTime birth { get; }

        public AnimalDto(string type, string homeland, string name, DateTime birth)
        {
            this.type = type;
            this.homeland = homeland;
            this.name = name;
            this.birth = birth;
        }

        public Animal MapDtoToModel()
        {
            return new Animal(type, homeland, name, new DateTime(birth.Ticks));
        }
    }
}
