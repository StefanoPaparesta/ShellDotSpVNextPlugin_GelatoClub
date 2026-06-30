using NPoco;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    [TableName("EtichetteTestiPersonalizzati")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class EtichettaTestoPersonalizzata
    {
        public int Id { get; set; }
        public string CodiceArticolo { get; set; }
        public int IdTesto { get; set; }
        public int Tipo { get; set; }
    }
}
