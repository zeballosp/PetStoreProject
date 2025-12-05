namespace pet_microservice.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public string PhotoUrl { get; set; }
    }
}
