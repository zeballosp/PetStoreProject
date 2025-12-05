using Microsoft.AspNetCore.Mvc;
using pet_microservice.Models;

namespace pet_microservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : Controller
    {
        private static List<Pet> Pets = new List<Pet>();

        private void PreloadData()
        {
            Pets.Clear();
            Pet cat1 = new Pet()
            {
                Id = 1,
                Name = "Latte",
                PhotoUrl = "assets/images/cat1.jpg",
                Type = PetType.Cat
            };
            Pets.Add(cat1);

            Pet cat2 = new Pet()
            {
                Id = 1,
                Name = "Expresso",
                PhotoUrl = "assets/images/cat2.jpg",
                Type = PetType.Cat
            };
            Pets.Add(cat2);

            Pet cat3 = new Pet()
            {
                Id = 1,
                Name = "Capucchino",
                PhotoUrl = "assets/images/cat3.jpg",
                Type = PetType.Cat
            };
            Pets.Add(cat3);

            Pet cat4 = new Pet()
            {
                Id = 1,
                Name = "Beans",
                PhotoUrl = "assets/images/cat4.jpg",
                Type = PetType.Cat
            };
            Pets.Add(cat4);
        }



        [HttpGet]
        public IActionResult Get()
        {
            PreloadData();
            return Ok(Pets);
        }

        [HttpPost]
        public IActionResult Post(Pet pet)
        {
            pet.Id = Pets.Count + 1;
            Pets.Add(pet);
            return Ok(pet);
        }
    }
}
