using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SarpArslanHw1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SarpArslanHw1.Controllers
{
    [Route("api/animals")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private static List<Animal> AnimalList = new List<Animal>()
        {
            new Animal(){id = 1, type = "Cat", breed = "American Shorthair",age = 12},
            new Animal(){id = 2, type = "Cat", breed = "Bombay Cat",age = 14},
            new Animal(){id = 3, type = "Dog", breed = "Boxer",age = 5},
            new Animal(){id = 4, type = "Cat", breed = "LaPerm Cat",age = 7},
            new Animal(){id = 5, type = "Cat", breed = "Siberian Cat",age = 8},
            new Animal(){id = 6, type = "Dog", breed = "Pug",age = 4},
            new Animal(){id = 7, type = "Dog", breed = "Beagle",age = 13},
            new Animal(){id = 8, type = "Dog", breed = "Golden",age = 12},
            new Animal(){id = 9, type = "Bird", breed = "Budgerigars",age = 6},
            new Animal(){id = 10, type = "Bird", breed = "Canary",age = 8},
            new Animal(){id = 11, type = "Bird", breed = "Parrot",age = 11},
            new Animal(){id = 12, type = "Dog", breed = "Samoyed",age = 3},
        };

        [HttpGet]
        public IActionResult listAnimals()
        {
            return Ok(AnimalList);
        }

        [HttpGet("{id}")]
        public IActionResult getAnimalById(int id)
        {
            var animal = AnimalList.FirstOrDefault(animal => animal.id == id);
            if (animal != null)
                return Ok(animal);

            return NotFound();
        }

        [HttpGet("list")]
        public IActionResult getListedAnimals([FromQuery] string filter)
        {

            if (filter == "type")
            {
                var filteredList = AnimalList.GroupBy(animal => animal.type).Select(grp => grp.ToList()).ToList();
                return Ok(filteredList);
            }
            
            return NotFound();
        }

        [HttpGet("sort")]
        public IActionResult sortedList([FromQuery] string filter)
        {
            if (filter == "age")
            {
                var ageSortedList = AnimalList.OrderBy(animal => animal.age).ToList();
                return Ok(ageSortedList);
            }
            else if (filter == "type")
            {
                var ageSortedList = AnimalList.OrderBy(animal => animal.type).ToList();
                return Ok(ageSortedList);
            }
            else if (filter == "breed")
            {
                var ageSortedList = AnimalList.OrderBy(animal => animal.breed).ToList();
                return Ok(ageSortedList);
            }
            else
                return NotFound();
        }

        [HttpPost]
        public IActionResult addAnimal([FromBody] AnimalDto animal)
        {
            int newId = AnimalList.LastOrDefault().id;
            AnimalList.Add(new Animal 
            {
             id = ++newId,
             age = animal.age,
             breed = animal.breed,
             type = animal.type
            }
            );

            return Created("Animal added to list",animal);
        }


        [HttpPut("{id}")]
        public IActionResult updateAnimal(int id, [FromBody] AnimalDto animalDto)
        {
            var animal = AnimalList.FirstOrDefault(animal => animal.id == id);

            if (animal != null)
            {
                int index = AnimalList.FindIndex(animal => animal.id == id);
                AnimalList[index] = new Animal { id = id, age = animalDto.age, breed = animalDto.breed, type = animalDto.type };
                return Ok();
            }

            return NotFound();

        }


        [HttpDelete("{id}")]
        public IActionResult deleteAnimal(int id)
        {
            var animal = AnimalList.FirstOrDefault(animal => animal.id == id);

            if (animal != null)
            {
                AnimalList.Remove(animal);
                return Ok();
            }

            return NotFound();
            
        }




    }
}
