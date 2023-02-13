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
        public IActionResult Add(string name) // ���������� �����
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name) // ��������� ����� �� �������
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("����� ������ ��������!!!!");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index) // �������� �� �������
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("����� ������ ��������!");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]

        public string GetName(int index) // ����� ����� �� �������
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "����� ������ �� ������!";
            }
            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int Find(string name) // ���������� ������� �� �����
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
        // ����� ��� ������ ����� ������, �������������� (�� �����������/��������)
        public IActionResult GetAll(int? sortStrategy) // sortStrategy - �������������� ��������
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
                return BadRequest("������������ �������� ��������� sortStrategy");
            }
        }
    }
}