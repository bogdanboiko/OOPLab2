namespace OOPLab2
{
    public class AnimalAccountDto
    {
        public int cost { get; }
        public AnimalDto animal { get; }
        public DateTime arrivalDate { get; }

        public AnimalAccountDto(int cost, AnimalDto animal, DateTime arrivalDate)
        {
            if (animal.birth.CompareTo(arrivalDate) > 0)
            {
                throw new Exception("Arrival date earlier than birth date");
            }
            this.cost = cost;
            this.animal = animal;
            this.arrivalDate = arrivalDate;
        }

        public AnimalAccount MapDtoToModel()
        {
            return new AnimalAccount(cost, animal.MapDtoToModel(), arrivalDate);
        }
    }
}
