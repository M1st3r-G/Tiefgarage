namespace Tiefgarage
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            RefreshList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateMenu createMenu = new();
            createMenu.FormClosed += (_, _) => RefreshList();
            createMenu.Show();
        }

        private void RefreshList()
        {

        }
    }
}