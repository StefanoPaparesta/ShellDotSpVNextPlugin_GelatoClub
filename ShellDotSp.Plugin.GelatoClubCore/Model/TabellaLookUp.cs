namespace ShellDotSp.Plugin.GelatoClubCore.Model
{
    public class TabellaLookUp
    {
        public int Id { get; set; }
        public string Tabella { get; set; }
        public string Codice { get; set; }
        public int CodiceNumerico { get; set; }
        public string Valore { get; set; }
        public string ValoreStr1 { get; set; }
        public string ValoreStr2 { get; set; }
        public decimal ValoreNum1 { get; set; }
        public string ValoreJson { get; set; }
        public bool ValoreBool { get; set; }
        public string Note { get; set; }
    }
}
