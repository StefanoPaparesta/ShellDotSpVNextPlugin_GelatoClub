using System.ComponentModel;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    public class LookUpData
    {
        public int Id { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
    }

    public class LookUpDataCollection : BindingList<LookUpData> { }
}
