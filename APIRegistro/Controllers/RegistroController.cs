using APIRegistro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRegistro.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistroController : ControllerBase
	{
		private readonly List<Registro> _registros;

		public RegistroController()
		{
			//INICIALIZAMOS LA LISTA DE REGISTROS
			//ID DNI Nombre Apellido Valido
			_registros = new List<Registro>
			{
				new Registro(){ID=1, DNI="40458641", Nombre="Juan", Apellido="Perez", Valido=true},
				new Registro(){ID=2, DNI="40458642", Nombre="Juan", Apellido="Perez", Valido=true},
				new Registro(){ID=3, DNI="40458643", Nombre="Juan", Apellido="Perez", Valido=true},
				new Registro(){ID=4, DNI="40458644", Nombre="Juan", Apellido="Perez", Valido=true}
			};

		}

		[HttpGet]
		public ActionResult<IEnumerable<Registro>> Get()
		{
			return _registros;
		}

		[HttpGet("{id}")]
		public ActionResult<Registro> Get(int id)
		{
			var registro = _registros.FirstOrDefault(r => r.ID == id);
			if (registro == null)
			{
				return NotFound();
			}
			return registro;
		}

		//armar el http post - ponerle un nombre como createRegistro - armar el public actionResult de tipo Post - 
		//guardar en el registro y luego hacer un save change
		// ponerlo dentro de un try catch dependiendo si lo pudo hacer o no - entre <> va a devolver un booleano por try catch

		[HttpPost]
		public ActionResult<bool> CreateRegistro(Registro registro) { 
			bool estado = false;
			try
			{
				if(registro != null)
				{
					_registros.Add(registro);
					estado = true;
				}
			}
			catch (Exception)
			{
				estado = false;
			}
			return estado;
		}
	}
}
//de tarea armar el contexto