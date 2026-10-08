using NPoco;

using System.ComponentModel;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    [TableName("RepositoryEtichette")]
    [PrimaryKey("Id", AutoIncrement = true)]
    public class RepositoryEtichetta
    {
        public int Id { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public int Versione { get; set; }
        public byte[] Layout { get; set; }
        public string StrutturaGs1 { get; set; }
    }
    public class RepositoryEtichettaCollection : BindingList<RepositoryEtichetta> { }
}
