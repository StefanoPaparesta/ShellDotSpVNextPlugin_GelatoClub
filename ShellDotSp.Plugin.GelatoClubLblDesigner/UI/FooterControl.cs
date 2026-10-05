using ShellDotSp.Plugin.GelatoClubLblDesigner.Interfaces;
using ShellDotSp.Plugin.GelatoClubLblDesigner.Presenters;

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubLblDesigner.UI
{
    [ToolboxItem(false)]
    public partial class FooterControlShellLabelDesigner : UserControl, IFooterView
    {

        private FooterPresenter _presenter;

        public FooterControlShellLabelDesigner()
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
