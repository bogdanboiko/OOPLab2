using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab2
{
    public class Animal : ICloneable, IComparable<Animal>
    {
        private string type { get; }
        private string homeland { get; }
        private string name { get; }
        private DateTime birth { get; }

        public Animal(string type, string homeland, string name, DateTime birth)
        {
            if (birth.CompareTo(DateTime.Now) > 0)
            {
                throw new Exception("Animal birth date is greater than current date");
            } else if (birth.Year - DateTime.Now.Year > 200)
            {
                throw new Exception("Animal can't be so old");
            }

            this.type = type;
            this.homeland = homeland;
            this.name = name;
            this.birth = birth;
        }

        public AnimalDto MapModelToDto()
        {
            return new AnimalDto(type, homeland, name, birth);
        }

        public override string ToString()
        {
            return $"animal {type} from {homeland} named {name} birth date {birth.ToShortDateString()}";
        }

         public string ToShortString()
        {
            return $"{type} {name} from {homeland} birth {birth.ToShortDateString()}";
        }

        public int CompareTo(Animal? other)
        {
            if (other == null)
            {
                throw new ArgumentException("Compared instance is null");
            }

            int partialRes = type.CompareTo(other.type);

            if (partialRes != 0)
            {
                return partialRes;
            }
            else
            {
                partialRes = homeland.CompareTo(other.homeland);

                if (partialRes != 0)
                {
                    return partialRes;
                }
                else
                {
                    partialRes = name.CompareTo(other.name);

                    if (partialRes != 0)
                    {
                        return partialRes;
                    } 
                    else
                    {
                        partialRes = birth.CompareTo(other.birth);
                        return partialRes;
                    }
                }
            }
        }

        public object Clone()
        {
            return new Animal(type, homeland, name, new DateTime(birth.Ticks));
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

            Animal other = (Animal)obj;

            return type == other.type && homeland == other.homeland && name == other.name && birth.Equals(other.birth);
        }

        public override int GetHashCode()
        {
            int hashCode = 17;

            hashCode = (hashCode * 23) + type.GetHashCode();

            hashCode = (hashCode * 23) + homeland.GetHashCode();

            hashCode = (hashCode * 23) + name.GetHashCode();

            hashCode = (hashCode * 23) + birth.GetHashCode();

            return hashCode;
        }
    }
}
