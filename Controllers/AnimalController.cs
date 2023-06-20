using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Any;
using Newtonsoft.Json.Linq;
using ReptileAPI.Data.DAL.WorkUnits;
using ReptileAPI.Models;

namespace ReptileAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
        "Kaiba", "Mokuba", "Seto", "Anubis", "Iris"
    };

        private readonly ILogger<AnimalController> _logger;
        private readonly AnimalWorkUnit _animalWorkUnit;

        public AnimalController(ILogger<AnimalController> logger, AnimalWorkUnit animalWorkUnit)
        {
            _logger = logger;
            _animalWorkUnit = animalWorkUnit;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Animal> GetAll()
        {
            return _animalWorkUnit.AnimalRepository.Get();
        }

        [HttpGet("GetById")]
        public Animal Get(Guid id)
        {
            return _animalWorkUnit.AnimalRepository.GetByID(id);
        }

        [HttpPost("Create")]
        public void Create(Animal animal)
        {
            _animalWorkUnit.AnimalRepository.Insert(animal);
            _animalWorkUnit.Save();
        }

        [HttpPost("Update")]
        public void Update(Animal animal)
        {
            _animalWorkUnit.AnimalRepository.Update(animal);
            _animalWorkUnit.Save();
        }

        [HttpDelete("DeleteById")]
        public void DeleteById(Guid id)
        {
            _animalWorkUnit.AnimalRepository.Delete(id);
            _animalWorkUnit.Save();
        }

        [HttpDelete("Delete")]
        public void DeleteEntity(Animal animal)
        {
            _animalWorkUnit.AnimalRepository.Delete(animal);
            _animalWorkUnit.Save();
        }
    }
}