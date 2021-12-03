


namespace VLilleIKOS
{
	using System;
	public partial class Vlille
	{
	

	public int ID { get; set; }
	public string Nom { get; set; }
	public string Addresse { get; set; }
	public string Commune { get; set; }
	public string Etat { get; set; }
	public string Type { get; set; }
	public string Geo { get; set; }
	public int nbVelosDispo { get; set; }
	public int nbPlacesDispo { get; set; }
	public string etatConnexion { get; set; }
	public Nullable<System.DateTime> datemisajour { get; set; }
	public string Localisation { get; set; }

	}
}
