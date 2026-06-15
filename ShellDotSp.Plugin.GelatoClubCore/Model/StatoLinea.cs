using NPoco;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    [TableName("StatoLinee")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class StatoLinea
    {
        public int Id { get; set; }
        public string CodiceLinea { get; set; }
        public string CodiceArticolo { get; set; }
        public string Stato { get; set; }
    }
}
