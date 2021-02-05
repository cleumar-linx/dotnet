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

        [HttpGet]
        public IActionResult Get()
        {
            var msg = "entre com o valores para realizar o calculo" ;
            return Ok(msg.ToString());
        }

        [HttpGet("sum/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetSum(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var sum = ConvertToDecimal(primeiroNumero) + ConvertToDecimal(segundoNumero);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtracao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetSubtracao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var subtracao = ConvertToDecimal(primeiroNumero) - ConvertToDecimal(segundoNumero);
                return Ok(subtracao.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplicacao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetMultiplicacao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var multiplicacao = ConvertToDecimal(primeiroNumero) * ConvertToDecimal(segundoNumero);
                return Ok(multiplicacao.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("divisao/{primeiroNumero}/{segundoNumero}")]
        public IActionResult GetDivisao(string primeiroNumero, string segundoNumero)
        {
            if (IsNumeric(primeiroNumero) && IsNumeric(segundoNumero))
            {
                var divisao = ConvertToDecimal(primeiroNumero) * ConvertToDecimal(segundoNumero);
                return Ok(divisao.ToString());
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
