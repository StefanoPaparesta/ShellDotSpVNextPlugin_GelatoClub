using NPoco;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    [TableName("EtichettePersonalizzate")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class EtichettaPersonalizzata
    {
        public int Id { get; set; }
        public string CodiceLayout { get; set; }
        public string CodiceArticolo { get; set; }
    }
}
