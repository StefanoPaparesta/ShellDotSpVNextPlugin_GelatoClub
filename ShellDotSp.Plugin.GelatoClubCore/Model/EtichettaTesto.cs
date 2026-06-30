using NPoco;

using System.ComponentModel;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    [TableName("EtichetteTesti")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class EtichettaTesto
    {
        public int Id { get; set; }
        public string CodiceArticolo { get; set; }
        public int Tipo { get; set; }
        public string DescrizioneBreve { get; set; }
        public string DescrizioneCompleta { get; set; }
    }
    public class EtichettaTestoCollection : BindingList<EtichettaTesto> { }
}
