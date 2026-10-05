using ShellDotSp.Core.Config;

namespace ShellDotSp.Plugin.GelatoClubCore.Config
{
    public class CfgPlugin : Configurazioni
    {
        public static new CfgPlugin Instance { get; } = new CfgPlugin();

        public string Cliente { get => ItemsDic[nameof(Cliente)].Valore; }
        public string RepositoryEtichette { get => ItemsDic[nameof(RepositoryEtichette)].Valore; }
    }
}
