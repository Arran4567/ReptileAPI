using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReptileAPI.Authentication;
using ReptileAPI.Data.DAL.WorkUnits;
using ReptileAPI.Models;
using System.Linq.Expressions;

namespace ReptileAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly AnimalWorkUnit _animalWorkUnit;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnimalController(ILogger<AnimalController> logger, AnimalWorkUnit animalWorkUnit, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _animalWorkUnit = animalWorkUnit;
            _userManager = userManager;
        }

        [Roles(UserRoles.Admin, UserRoles.User)]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var filters = new Expression<Func<Animal, bool>>[] { x => x.User == user };
                var includes = new Expression<Func<Animal, object>>[] { x => x.Morphs, x => x.Species, x => x.User };
                return Ok(_animalWorkUnit.AnimalRepository.Get(filters: filters, includes: includes));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        [Roles(UserRoles.Admin, UserRoles.User)]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var animal = _animalWorkUnit.AnimalRepository.GetByID(id);
            return animal.User == user ? Ok(animal) : BadRequest();
        }

        [HttpPost]
        [Route("Create")]
        [Roles(UserRoles.Admin, UserRoles.User)]
        public async Task<IActionResult> Create(Animal animal)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                animal.User = user;
                _animalWorkUnit.AnimalRepository.Insert(animal);
                _animalWorkUnit.Save();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Update")]
        [Roles(UserRoles.Admin, UserRoles.User)]
        public async Task<IActionResult> Update(Animal animal)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (animal.User == user)
                {
                    _animalWorkUnit.AnimalRepository.Update(animal);
                    _animalWorkUnit.Save();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteById")]
        [Roles(UserRoles.Admin, UserRoles.User)]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var animal = _animalWorkUnit.AnimalRepository.GetByID(id);
                if(animal.User == user){
                    _animalWorkUnit.AnimalRepository.Delete(id);
                    _animalWorkUnit.Save();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete")]
        [Roles(UserRoles.Admin, UserRoles.User)]
        public async Task<IActionResult> DeleteEntity(Animal animal)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (animal.User == user)
                {
                    _animalWorkUnit.AnimalRepository.Delete(animal);
                    _animalWorkUnit.Save();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}