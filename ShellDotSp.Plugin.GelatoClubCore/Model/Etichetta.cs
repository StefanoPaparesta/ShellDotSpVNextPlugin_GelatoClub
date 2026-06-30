using System.ComponentModel;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    public class Etichetta
    {
        public int Id { get; set; }
        public string Codice { get; set; }
        public string Valore { get; set; }
        public string ValoreStr1 { get; set; }
    }
    public class EtichettaCollection : BindingList<Etichetta> { }
}
