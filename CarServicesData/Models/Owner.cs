using System;

namespace Car_Services
{
    [Serializable]
    public class Owner
    {
        public int OwnerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public int Year { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}. {2}.", LastName, FirstName[0], FatherName[0]);
        }
    }
}
