


namespace VLilleIKOS
{
    public class Parameters
    {
        public string dataset { get; set; }
        public string timezone { get; set; }
        public int rows { get; set; }
        public int start { get; set; }
        public string format { get; set; }
    }
    public class records
    {
        public string datasetid { get; set; }
        public string recordid { get; set; }
        public field fields { get; set; }
        public geometry geometr { get; set; }
        public string record_timestamp { get; set; }


    }
    public class field
    {
        public string etat { get; set; }
        public string etatconnexion { get; set; }
        public int nbvelodispo { get; set; }
        public int nbplacesdispo { get; set; }
        public string commune { get; set; }
        public string type { get; set; }
        public int libelle { get; set; }
        public Nullable<system.Datetime> datemiseajour { get; set; }
        public localisation loc { get; set; }
        public string nom { get; set; }
        public string addresse { get; set; }
        public geo geoloc { get; set; }

    }
    public class localisation
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    public class geo
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    public class geometry
    {
        public string type { get; set; }
        public class coordinate
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
    }

	public class Vlille
    {
        public int nhits { get; set; }
        public Parameters parameters { get; set; }
        public List<records> record { get; set; }

    }

}
