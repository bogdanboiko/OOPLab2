namespace OOPLab2
{
    public class AnimalAccount : ICloneable, IComparable<AnimalAccount>
    {
        private int cost { get; }
        private Animal animal { get; }
        private DateTime arrivalDate { get; }

        public AnimalAccount(int cost, Animal animal, DateTime arrivalDate)
        {
            if (cost <= 0)
            {
                throw new Exception("Cost must be grater than 0");
            }
            else if (arrivalDate.CompareTo(DateTime.Now) > 0)
            {
                throw new Exception("Arrival date is greater than current date");
            }

            this.cost = cost;
            this.animal = animal;
            this.arrivalDate = arrivalDate;
        }

        public AnimalAccountDto MapModelToDto()
        {
            return new AnimalAccountDto(cost, animal.MapModelToDto(), new DateTime(arrivalDate.Ticks));
        }

        public override string ToString()
        {
            return $"Total account cost {cost}$ for {animal} that was arrived {arrivalDate.ToShortDateString()}";
        }

        public string ToShortString()
        {
            return $"Maintenance {cost}$ for {animal.ToShortString()} arrived {arrivalDate.ToShortDateString()}";
        }

        public object Clone()
        {
            return new AnimalAccount(cost, (Animal)animal.Clone(), new DateTime(arrivalDate.Ticks));
        }

        public int CompareTo(AnimalAccount? other)
        {
            if (other == null)
            {
                throw new ArgumentException("Compared instance is null");
            }

            int partialRes = cost.CompareTo(other.cost);

            if (partialRes != 0)
            {
                return partialRes;
            }
            else
            {
                partialRes = animal.CompareTo(other.animal);

                if (partialRes != 0)
                {
                    return partialRes;
                } 
                else
                {
                    partialRes = arrivalDate.CompareTo(other.arrivalDate);
                    return partialRes;
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            AnimalAccount other = (AnimalAccount)obj;

            return cost == other.cost && animal.Equals(other.animal) && arrivalDate.Equals(other.arrivalDate);

        }

        public override int GetHashCode()
        {
            int hashCode = 17;

            hashCode = (hashCode * 23) + cost.GetHashCode();

            hashCode = (hashCode * 23) + animal.GetHashCode();

            hashCode = (hashCode * 23) + arrivalDate.GetHashCode();

            return hashCode;
        }
    }
}
