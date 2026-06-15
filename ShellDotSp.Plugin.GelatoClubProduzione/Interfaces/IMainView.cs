using ShellDotSp.Contract.View;
using ShellDotSp.Plugin.GelatoClubProduzione.Core;

namespace ShellDotSp.Plugin.GelatoClubProduzione.Interfaces
{
    public interface IMainView : IView
    {
        void UpdateUI(MessaggioPlugin messaggio);
    }
}
