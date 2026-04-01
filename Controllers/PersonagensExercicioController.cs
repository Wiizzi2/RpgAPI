using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using RpgApi.Models;
using RpgApi.Models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensExercicioController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 4, Nome = "Artur", PontosVida=120, Forca=28, Defesa=35, Inteligencia=25, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 5, Nome = "Lancelote", PontosVida=115, Forca=30, Defesa=32, Inteligencia=24, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 6, Nome = "Gawain", PontosVida=125, Forca=26, Defesa=30, Inteligencia=22, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 7, Nome = "Bedivere", PontosVida=110, Forca=25, Defesa=28, Inteligencia=26, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 8, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 9, Nome = "Merlin", PontosVida=85, Forca=14, Defesa=15, Inteligencia=45, Classe=ClasseEnum.Mago},
            new Personagem() { Id = 10, Nome = "Saruman", PontosVida=90, Forca=16, Defesa=14, Inteligencia=48, Classe=ClasseEnum.Mago},
            new Personagem() { Id = 11, Nome = "Morgana", PontosVida=88, Forca=13, Defesa=16, Inteligencia=50, Classe=ClasseEnum.Mago},
            new Personagem() { Id = 12, Nome = "Radagast", PontosVida=92, Forca=15, Defesa=13, Inteligencia=42, Classe=ClasseEnum.Mago},
            new Personagem() { Id = 13, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 14, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 15, Nome = "Elara", PontosVida=105, Forca=18, Defesa=24, Inteligencia=40, Classe=ClasseEnum.Clerigo},
            new Personagem() { Id = 16, Nome = "Isolda", PontosVida=100, Forca=16, Defesa=26, Inteligencia=38, Classe=ClasseEnum.Clerigo},
            new Personagem() { Id = 17, Nome = "Taliesin", PontosVida=102, Forca=17, Defesa=22, Inteligencia=41, Classe=ClasseEnum.Clerigo},
            new Personagem() { Id = 18, Nome = "Morgaine", PontosVida=108, Forca=19, Defesa=25, Inteligencia=39, Classe=ClasseEnum.Clerigo},
            new Personagem() { Id = 19, Nome = "Karsen", PontosVida=110, Forca=32, Defesa=100, Inteligencia=80, Classe=ClasseEnum.Espadachim},
            new Personagem() { Id = 20, Nome = "Conan", PontosVida=130, Forca=35, Defesa=20, Inteligencia=18, Classe=ClasseEnum.Espadachim},
            new Personagem() { Id = 21, Nome = "Beowulf", PontosVida=128, Forca=33, Defesa=22, Inteligencia=19, Classe=ClasseEnum.Espadachim},
            new Personagem() { Id = 22, Nome = "Sigurd", PontosVida=125, Forca=31, Defesa=24, Inteligencia=20, Classe=ClasseEnum.Espadachim},
            new Personagem() { Id = 23, Nome = "Heracles", PontosVida=135, Forca=36, Defesa=19, Inteligencia=17, Classe=ClasseEnum.Espadachim},
            new Personagem() { Id = 24, Nome = "Robin", PontosVida=95, Forca=19, Defesa=18, Inteligencia=35, Classe=ClasseEnum.Arqueiro},
            new Personagem() { Id = 25, Nome = "Sofiz", PontosVida=100, Forca=15, Defesa=20, Inteligencia=60, Classe=ClasseEnum.Arqueiro},
            new Personagem() { Id = 26, Nome = "Legolas", PontosVida=98, Forca=21, Defesa=16, Inteligencia=32, Classe=ClasseEnum.Arqueiro},
            new Personagem() { Id = 27, Nome = "Artemis", PontosVida=100, Forca=20, Defesa=17, Inteligencia=38, Classe=ClasseEnum.Arqueiro},
            new Personagem() { Id = 28, Nome = "Hawkeye", PontosVida=93, Forca=18, Defesa=19, Inteligencia=36, Classe=ClasseEnum.Arqueiro},
            new Personagem() { Id = 29, Nome = "Darthur", PontosVida=96, Forca=22, Defesa=15, Inteligencia=34, Classe=ClasseEnum.Arqueiro}
        };

        [HttpGet("GetByName/{personagemName}")]

        public IActionResult GetByName(string personagemName)
        {
            Personagem pBuscar = personagens.FirstOrDefault(p => p.Nome.ToUpper().Contains(personagemName.ToUpper()));
            if (string.IsNullOrEmpty(personagemName))
                return BadRequest("O personagem não existe.");
            if (pBuscar == null)
                return NotFound("O personagem não foi encontrado, tente novamente.");
            return Ok(pBuscar);
        }

        [HttpGet("GetClerigoMago")]

        public IActionResult GetClerigoMago()
        {
            List<Personagem> cavaleiros = personagens.Where(p => p.Classe == ClasseEnum.Cavaleiro).ToList();
            foreach (Personagem cavaleiro in cavaleiros)
            {
                personagens.Remove(cavaleiro);
            }

            return Ok(personagens.OrderByDescending(p => p.PontosVida).ToList());
        }


        [HttpGet("GetEstatisticas")]
        public IActionResult GetEstatisticas()
        {
            return Ok("Quantidade de Personagens: " + personagens.Count() + " Somatório de Inteligencia do Grupo: " + personagens.Sum(p => p.Inteligencia));

        }

        [HttpPost("PostValidacao")]
        public IActionResult PostValidacao(Personagem newCharacter)
        {
            if (newCharacter.Defesa < 10)
                return BadRequest("Um personagem não pode ser adicionado com defesa menor que 10");

            if (newCharacter.Inteligencia < 30)
                return BadRequest("Um personagem não nascer com 30 de inteligência");


            personagens.Add(newCharacter);
            return Ok(personagens);
        }

        [HttpPost("PostValidacaoMago")]

        public IActionResult PostValidacaoMago(Personagem newCharacter)
        {
            if (newCharacter.Classe == ClasseEnum.Mago && newCharacter.Inteligencia < 35)
            {
                return BadRequest("Mago não pode ser incluído com Inteligência menor que 35");
            }
            personagens.Add(newCharacter);
            return Ok(personagens);
        }

        [HttpGet("GetByClasse/{enumId}")]

        public IActionResult GetByClasse(int enumId)
        {
            ClasseEnum EnumDigitado = (ClasseEnum)enumId;
            List<Personagem> characterSearch = personagens.FindAll(character => character.Classe == EnumDigitado);
            return Ok(characterSearch);
        }

    }
}