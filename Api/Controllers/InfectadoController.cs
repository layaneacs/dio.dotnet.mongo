using Api.Data.Collections;
using Api.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongodb;

        IMongoCollection<Infectado> _infectadosCollections;

        public InfectadoController(Data.MongoDB mongodb)
        {
            _mongodb = mongodb;
            _infectadosCollections = _mongodb.db.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfec(InfectadoDTO dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Longitude, dto.Latitude);
            _infectadosCollections.InsertOne(infectado);
            return StatusCode(201, "Adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult<Infectado> ObterTodosInfec()
        {
            var infectados = _infectadosCollections.Find(Builders<Infectado>.Filter.Empty).ToList();
            return Ok(infectados);
        }
    }
}