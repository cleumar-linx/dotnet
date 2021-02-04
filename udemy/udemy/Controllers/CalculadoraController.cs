using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {

        private readonly ILogger<CalculadoraController> _logger;

        public CalculadoraController(ILogger<CalculadoraController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Get(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var sum = ConvertToDecimal(primeiroNumero) + ConvertToDecimal(segundoNumero);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        private bool IsNumeric(string strNumero)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumero,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;

        }

        private decimal ConvertToDecimal(string strNumero)
        {
            decimal decimalValue;
            if(decimal.TryParse(strNumero, out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        
    }
}
