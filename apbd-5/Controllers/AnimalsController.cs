using Microsoft.AspNetCore.Mvc;
using RestApiApbdPjatkCw4.Data;
using RestApiApbdPjatkCw4.DTO;
using RestApiApbdPjatkCw4.Models;

namespace RestApiApbdPjatkCw4.Controllers;

/// <summary>
/// Kontroler obsługujący żądania dotyczące zwierząt.
/// </summary>
[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    /// <summary>
    /// Pobieranie wszystkich zwierząt.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<IEnumerable<Animal>> GetAllAnimals()
    {
        // return Ok(MemoryDatabase.Animals.ToList());
        try
        {
            var animals = MemoryDatabase.Animals.ToList();
            
            return Ok(animals);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Nie udało się zrealizować żądania przez błąd serwera.");
        }
    }

    /// <summary>
    /// Pobieranie zwierzęcia o podanym id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Animal> GetAnimal([FromRoute] int id)
    {
        try
        {
            var animal = MemoryDatabase.Animals
                .FirstOrDefault(a => a.Id == id);

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    /// <summary>
    /// Dodawanie nowego zwierzęcia.
    /// </summary>
    /// <param name="animal"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Animal> AddAnimal([FromBody] Animal animal)
    {
        try
        {
            var lastId = MemoryDatabase.Animals.Max(a => a.Id);
            
            animal.Id = lastId + 1;
            
            MemoryDatabase.Animals.Add(animal);

            
            return Ok(animal);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    /// <summary>
    /// Aktualizacja danych zwierzęcia.
    /// </summary>
    /// <param name="animal"></param>
    /// <returns></returns>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Animal> UpdateAnimal([FromBody] Animal animal)
    {
        try
        {
            var existingAnimal = MemoryDatabase.Animals.FirstOrDefault(a => a.Id == animal.Id);
            
            if (existingAnimal == null)
                return NotFound();
            
            MemoryDatabase.Animals.Remove(existingAnimal);
            
            existingAnimal.Update(animal);
            
            MemoryDatabase.Animals.Add(existingAnimal);

            return Ok(animal);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    /// <summary>
    /// Usuwanie zwierzęcia o podanym id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<Animal> DeleteAnimal([FromRoute] int id)
    {
        try
        {
            var animal = MemoryDatabase.Animals.FirstOrDefault(a => a.Id == id);

            if (animal == null)
                return NotFound();

            MemoryDatabase.Animals.Remove(animal);
            
            return Ok(animal);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    /// <summary>
    /// Pobieranie listy wizyt powiązanych z danym zwierzęciem
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("getVisits/{id}")]
    public ActionResult<IEnumerable<Visit>> GetVisitsByAnimalId([FromRoute] int id)
    {
        try
        {
            var animal = MemoryDatabase.Animals.FirstOrDefault(a => a.Id == id);

            if (animal == null)
                return NotFound();

            return Ok(animal.Visits);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    /// <summary>
    /// Tworzenie nowej wizyty dla danego zwierzęcia.
    /// </summary>
    /// <param name="visitDto"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("createVisit")]
    public ActionResult<Visit> CreateVisit([FromBody] CreateVisitDTO visitDto)
    {
        try
        {
            var animal = MemoryDatabase.Animals.FirstOrDefault(a => a.Id == visitDto.AnimalId);
            
            if (animal == null)
                return NotFound();
            
            var visit = visitDto.ToVisit();
            
            animal.Visits.Add(visit);
            return Ok(visit);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}