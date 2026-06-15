using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using ShellDotSp.Plugin.GelatoClubCore.Model;
using ShellDotSp.Plugin.GelatoClubProduzione.Presenters;


using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShellDotSp.Plugin.GelatoClubProduzione.Forms
{
    public partial class FrmArticoli : XtraForm
    {
        private readonly MainPresenter _presenter;
        private readonly Timer _debounceTimer;
        private const int DebounceDelay = 400; // ms
        private const int MinSearchLength = 3;

        public VArticoloGestionale ArticoloSelezionato { get; set; }

        public FrmArticoli(MainPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;

            _debounceTimer = new Timer();
            _debounceTimer.Interval = DebounceDelay;
            _debounceTimer.Tick += DebounceTimer_Tick;
        }

        private void txRicerca_TextChanged(object sender, EventArgs e)
        {
            _debounceTimer.Stop();  // reset timer
            _debounceTimer.Start(); // riparte ogni volta che digiti
        }

        private void btnAzzeraArticolo_Click(object sender, EventArgs e)
        {
            txRicerca.Text = string.Empty;
        }

        private void DebounceTimer_Tick(object sender, EventArgs e)
        {
            _debounceTimer.Stop();  // ferma prima di eseguire

            if (txRicerca.Text.Length >= MinSearchLength)
            {
                bndArticoli.DataSource = _presenter.SearchArticoli(txRicerca.Text);
            }
            else
            {
                bndArticoli.Clear();
            }

        }

        private void FrmClienti_Activated(object sender, EventArgs e)
        {
            txRicerca.Focus();
        }

        private void FrmClienti_Load(object sender, EventArgs e)
        {
            btnConferma.Enabled = false;
        }

        private void gridControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.Views[0] as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            view.SelectRow(hitInfo.RowHandle);

            if ((e.Button & MouseButtons.Left) != 0 & hitInfo.InRow & !view.IsGroupRow(hitInfo.RowHandle))
            {
                if (view.GetSelectedRows().Length == 1)
                {
                    SetArticoloSelezionato((VArticoloGestionale)view.GetRow(hitInfo.RowHandle));
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void SetArticoloSelezionato(VArticoloGestionale articoloGestionale)
        {
            ArticoloSelezionato = articoloGestionale;
            btnConferma.Enabled = articoloGestionale != null;
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.Views[0] as GridView;
            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            view.SelectRow(hitInfo.RowHandle);

            if ((e.Button & MouseButtons.Left) != 0 & hitInfo.InRow & !view.IsGroupRow(hitInfo.RowHandle))
            {
                if (view.GetSelectedRows().Length == 1)
                {
                    SetArticoloSelezionato((VArticoloGestionale)view.GetRow(hitInfo.RowHandle));
                }
            }
        }

        private void btnConferma_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
