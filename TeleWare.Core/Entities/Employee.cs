namespace TeleWareAssessment.Entities
{
    public class Employee
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
