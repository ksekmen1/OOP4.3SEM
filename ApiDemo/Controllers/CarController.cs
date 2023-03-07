using Microsoft.AspNetCore.Http;
using ApiDemo;
using ApiDemo.Reposity;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarRepository? _carRepository;

        public CarController(CarRepository? carRepository)
        {
            _carRepository = carRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            List<Car>? cars = _carRepository!.GetAll();
            if (cars != null)
            {
                return Ok(cars);
            }
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car? car = _carRepository!.GetById(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car car)
        {
            try
            {
                Car createdCar = _carRepository!.Add(car);
                return Created($"/{createdCar.Id}", createdCar);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? car = _carRepository!.Delete(id);
            if (car != null)
            {
                return Ok(car);
            }
            return NotFound();
        }

    }
}
