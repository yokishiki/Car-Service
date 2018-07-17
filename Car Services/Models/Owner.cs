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
    }
}
