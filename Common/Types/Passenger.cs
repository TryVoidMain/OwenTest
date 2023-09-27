namespace Common.Types
{
    public class Passenger 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronomyc { get; set; }
        public Passenger() { }
        public Passenger(string firstName, string lastName, string patronomyc)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronomyc = patronomyc;
        }
    } 
}
