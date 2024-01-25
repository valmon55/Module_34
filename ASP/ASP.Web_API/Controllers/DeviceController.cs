using ASP.Web_API.Configuration;
using ASP.Web_API.Contracts.Devices;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace ASP.Web_API.Controllers
{
    /// <summary>
    /// Контроллер статусов устройств
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add([FromBody] // Атрибут, указывающий, откуда брать значение объекта
                                    AddDeviceRequest request)
        {
            //Ручная валидация
            if (request.CurrentVolts < 120)
            {
                //return StatusCode(403, $"Устройства с напряжением меньше 120 вольт не поддерживаются!");
                //ручная валидация в формате валидации на атрибутах
                ModelState.AddModelError("currentVolts", "Устройства с напряжением меньше 120 вольт не поддерживаются!");
                return BadRequest(ModelState);
            }
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }
    }
}
