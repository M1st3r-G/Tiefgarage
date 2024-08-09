using System.Diagnostics;

namespace Tiefgarage
{
    public partial class Main : Form
    {
        public const string savePath = @"Saves/";

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
            fileContainer.Controls.Clear();
            foreach (string path in Directory.GetFiles(savePath, "*"))
            {
                Button newButton = new()
                {
                    Text = path.Replace(savePath, "").Replace(".parkhaus", ""),
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink
                };

                newButton.Click += (_, _) => Display(path);

                fileContainer.Controls.Add(newButton);
            }
        }

        private void Display(string path)
        {
            Hide();
            SimulationWindow display = new(path);
            display.ShowDialog();
            Show();
        }
    }
}