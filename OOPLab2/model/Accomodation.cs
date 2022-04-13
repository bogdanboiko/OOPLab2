using System.Text;

namespace OOPLab2
{
    public class Accomodation : ICloneable, IComparable<Accomodation>
    {
        private AccomodationType type { get; }
        private int id { get; }
        private int size { get; }
        private int costOfCleaning { get; }
        private List<AnimalAccount> animalAccounts { get; }

        public Accomodation(AccomodationType type, int id, int size, int costOfCleaning, List<AnimalAccount> animalAccounts)
        {
            if (size <= 0)
            {
                throw new Exception("Size must be grater than 0");
            } else if (costOfCleaning < 0)
            {
                throw new Exception("Cost of cleaning must be grater than 0");
            }

            this.type = type;
            this.id = id;
            this.size = size;
            this.costOfCleaning = costOfCleaning;
            this.animalAccounts = animalAccounts;
        }

        public void addAnimal(AnimalAccount animalAccount)
        {
            animalAccounts.Add(animalAccount);
        }

        public AccomodationDto MapModelToDto()
        {
            return new AccomodationDto(type, id, size, costOfCleaning, animalAccounts.ConvertAll(account => account.MapModelToDto()));
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder($"Accomodation {type} with {size}m2 size cost {costOfCleaning}$ for cleaning and contains such animals: ");
            animalAccounts.ForEach(animalAccounts => {
                res.AppendLine(animalAccounts.ToString());
            });

            return res.ToString();
        }

        public string ToShortString()
        {
            StringBuilder res = new StringBuilder($"{size}m2 {type} cost {costOfCleaning}$ for cleaning and contains: ");
            animalAccounts.ForEach(animalAccounts => {
                res.AppendLine(animalAccounts.ToShortString());
            });

            return res.ToString();
        }

        public object Clone()
        {
            List<AnimalAccount> accounts = new List<AnimalAccount>();
            animalAccounts.ForEach(account => { accounts.Add((AnimalAccount)account.Clone()); });
            return new Accomodation(type, id, size, costOfCleaning, accounts);
        }

        public int CompareTo(Accomodation? obj)
        {
            if (obj == null)
            {
                throw new ArgumentException("Compared instance is null");
            }

            int partialRes = type.CompareTo(obj.type);

            if (partialRes != 0)
            {
                return partialRes;
            } else
            {
                partialRes = id.CompareTo(obj.id);
                if (partialRes != 0)
                {
                    return partialRes;
                } else
                {
                    partialRes = size.CompareTo(obj.size);
                    if (partialRes != 0)
                    {
                        return partialRes;
                    }
                    else
                    {
                        partialRes = costOfCleaning.CompareTo(obj.costOfCleaning);
                        if (partialRes != 0)
                        {
                            return partialRes;
                        }
                        else
                        {
                            partialRes = animalAccounts.Count.CompareTo(obj.animalAccounts.Count);
                            if (partialRes == 0)
                            {
                                for (int i = 0; i < animalAccounts.Count; i++)
                                {
                                    partialRes = animalAccounts[i].CompareTo(obj.animalAccounts[i]);

                                    if (partialRes != 0)
                                    {
                                        return partialRes;
                                    }
                                }
                                return partialRes;
                            }
                            else
                            {
                                return partialRes;
                            }
                        }
                    }
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

            Accomodation other = (Accomodation)obj;

            bool partialRes = true;

            if (animalAccounts.Count == other.animalAccounts.Count)
            {
                for (int i = 0; i < animalAccounts.Count; i++)
                {
                    partialRes = animalAccounts[i].Equals(other.animalAccounts[i]);

                    if (!partialRes)
                    {
                        return partialRes;
                    }
                }
            }
            else
            {
                return false;
            }

            return type == other.type && id == other.id && size == other.size && costOfCleaning == other.costOfCleaning && partialRes;
        }

        public override int GetHashCode()
        {
            int hashCode = 17;

            hashCode = (hashCode * 23) + type.GetHashCode();

            hashCode = (hashCode * 23) + id.GetHashCode();

            hashCode = (hashCode * 23) + size.GetHashCode();

            hashCode = (hashCode * 23) + costOfCleaning.GetHashCode();

            animalAccounts.ForEach(account => { hashCode = (hashCode * 23) + size.GetHashCode(); });

            return hashCode;         
        }
    }
}
