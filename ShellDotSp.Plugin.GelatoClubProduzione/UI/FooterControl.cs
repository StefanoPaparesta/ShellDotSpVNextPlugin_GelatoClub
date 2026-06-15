using ShellDotSp.Plugin.GelatoClubProduzione.Interfaces;
using ShellDotSp.Plugin.GelatoClubProduzione.Presenters;

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubProduzione.UI
{
    [ToolboxItem(false)]
    public partial class FooterControlGelatoClubProduzione : UserControl, IFooterView
    {

        private FooterPresenter _presenter;

        public FooterControlGelatoClubProduzione()
        {
            InitializeComponent();
            _presenter = new FooterPresenter(this);
        }

        public string Caption { get; set; }

        private event EventHandler viewInitialized;
        private event EventHandler closeView;

        public event EventHandler CloseView
        {
            add { closeView += value; }
            remove { closeView -= value; }
        }
        public event EventHandler ViewInitialized
        {
            add { viewInitialized += value; }
            remove { viewInitialized -= value; }
        }

        private void InvokeViewInitialized(EventArgs e)
        {
            viewInitialized?.Invoke(this, e);
        }
        private void InvokeCloseView(EventArgs e)
        {
            closeView?.Invoke(this, e);
        }

        public void Finalizza()
        {
            InvokeCloseView(EventArgs.Empty);
        }
        public void Inizializza()
        {
            InvokeViewInitialized(EventArgs.Empty);
        }

    }
}
