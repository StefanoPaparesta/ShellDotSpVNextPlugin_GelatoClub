using System.ComponentModel;

namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    public class LookUpdataTesto
    {
        public int Id { get; set; }
        public string Codice { get; set; }
        public int CodiceNumerico { get; set; }
        public string DescrizioneBreve { get; set; }
        public string DescrizioneCompleta { get; set; }
    }

    public class LookUpDataTestoCollection : BindingList<LookUpdataTesto> { }
}
