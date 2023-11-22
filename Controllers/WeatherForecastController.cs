using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrudExample.Controllers
{
    [ApiController]
    //Aqui declaramos a base das rotas seguintes, neste caso vai ser "http://localhost:5000/api"
    [Route("api")]
    public class WeatherForecastController : ControllerBase
    {
        //Array de Cidades de exemplo para preencher na rota com as temperaturas aleatórias
        private static readonly string[] Cidades = new[]
        {
            "São Paulo", "Rio de Janeiro", "Recife", "Porto Alegre", "Santa Catarina", "Campinas", "Manaus", "Belo Horizonte"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //Aqui declaramos que o tipo da rota vai ser GET para o /api
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            //Declara uma variável para usar o Random nos campos do Objeto WeatherForecast
            //Para simular as temperaturas
            var rng = new Random();

            //Toda requisição nesta rota vai imprimir no log da aplicação
            //a lista de cidades cadastradas
            foreach (var obj in Cidades){
             Console.WriteLine("{0}", obj.ToString());
            }


            //Realiza o select de cada cidade dentro do Array Cidades
            //e gera um RNG para a temperatura
            return Enumerable.Range(0, Cidades.Length).Select(index => new WeatherForecast
            {
                Id = index,   
                Cidade = Cidades[index],
                TemperaturaC = rng.Next(-20, 55),
                Data = DateTime.Now.AddDays(index),                             
            })
            .ToArray();
            //Como é um OBJ a classe WeatherForecast, é preciso informar que ao final ele tem que ser convertido para .ToArray()
            //para retornar uma lista na rota.

            //O Código comentado abaixo é uma variação do código acima, porém usando RNG nas cidades selecionadas também
            // return Enumerable.Range(0, Cidades.Length).Select(index => new WeatherForecast
            // { 
            //     Id = index,
            //     Data = DateTime.Now.AddDays(index),
            //     TemperaturaC = rng.Next(-20, 55),
            //     Cidade = Cidades[rng.Next(Cidades.Length)],                
            // })
            // .ToArray();
            
        }

         //Uma rota do tipo GET que vai ser acessada por ".../api/teste"
         [HttpGet("teste")]
        public String NovaRota()
        {
            var rng = new Random();
            int teste = rng.Next(0, 100);
            return $"Eu sou uma nova rota com número: {teste}";
        }
    }
}
