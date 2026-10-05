using ShellDotSp.Contract.View;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Core;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.Interfaces
{
    public interface IMainView : IView
    {
        void UpdateUI(MessaggioPlugin messaggio);
    }
}
