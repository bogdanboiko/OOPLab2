namespace OOPLab2
{
    public class AccomodationDto
    {
        public AccomodationType type { get; }
        public int id { get; }
        public int size { get; }
        public int costOfCleaning { get; }
        public List<AnimalAccountDto> animalAccounts { get; }

        public AccomodationDto(AccomodationType type, int id, int size, int costOfCleaning, List<AnimalAccountDto> animalAccounts)
        {
            this.id = id;
            this.size = size;
            this.costOfCleaning = costOfCleaning;
            this.animalAccounts = animalAccounts;
        }

        public Accomodation MapDtoToModel()
        {
            return new Accomodation(type, id, size, costOfCleaning, animalAccounts.ConvertAll(input => input.MapDtoToModel()));
        }
    }
}
