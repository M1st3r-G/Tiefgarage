namespace Tiefgarage
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new CreateMenu().Show();
        }
    }
}