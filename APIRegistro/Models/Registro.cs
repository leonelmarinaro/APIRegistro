namespace APIRegistro.Models
{
	public class Registro
	{
			public int ID { get; set; }
			public string DNI { get; set; }
			public string Nombre { get; set; }
			public string Apellido { get; set; }
			public bool Valido { get; set; }
	}
}

//ID DNI Nombre Apellido Valido