using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name) // добавление имени
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name) // изменение имени по индексу
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index) // удаление по индексу
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]

        public string GetName(int index) // вывод имени по индексу
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Такой индекс не найден!";
            }
            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int Find(string name) // количество записей по имени
        {
            int a = 0;
            for(int i=0; i< Summaries.Count(); i++)
            {
                if (Summaries[i] == name)
                    a++;
            }
            return a;
        }

        [HttpGet("sortlist")]
        // Метод для вывода всего списка, сортированного (по возрастанию/убыванию)
        public IActionResult GetAll(int? sortStrategy) // sortStrategy - необязательный параметр
        {
            if (sortStrategy == null)
            {
                Get();
                return Ok();
            }
            else if (sortStrategy == 1)
            {
                Summaries.Sort();
                return Ok();

            }
            else if (sortStrategy == -1)
            {
                Summaries.Reverse();
                return Ok();
            }
            else
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }
        }
    }
}