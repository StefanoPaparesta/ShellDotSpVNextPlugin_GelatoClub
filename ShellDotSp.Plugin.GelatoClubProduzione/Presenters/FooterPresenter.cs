using ShellDotSp.Core.Base;
using ShellDotSp.Plugin.GelatoClubProduzione.Interfaces;

using System;

namespace ShellDotSp.Plugin.GelatoClubProduzione.Presenters
{
    public class FooterPresenter : Presenter<IFooterView>
    {

        public FooterPresenter(IFooterView View) : base(View)
        {

        }

        protected override void CloseView(object sender, EventArgs e)
        {
            Dispose();
        }

        protected override void ViewInitialized(object sender, EventArgs e)
        {

        }

    }
}
