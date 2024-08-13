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
            createMenu.ShowDialog();
            RefreshList();
        }

        private void RefreshList()
        {
            cbbxSaved.Items.Clear();
            foreach (string path in Directory.GetFiles(savePath, "*"))
            {
                NamedPath tmp = new NamedPath(path.Replace(savePath, "").Replace(".parkhaus", ""), path);
                cbbxSaved.Items.Add(tmp);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if(cbbxSaved.SelectedIndex == -1) return;

            Hide();
            SimulationWindow display = new(((NamedPath)cbbxSaved.SelectedItem).Path);
            display.ShowDialog();
            Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(cbbxSaved.SelectedIndex == -1) return;

            if (MessageBox.Show($"Willst du das Parkhaus {((NamedPath)cbbxSaved.SelectedItem).Name} wirklich löschen", "Achtung", MessageBoxButtons.YesNo) == DialogResult.No) return;
        
            string path = ((NamedPath)cbbxSaved.SelectedItem).Path;
            cbbxSaved.Items.RemoveAt(cbbxSaved.SelectedIndex);

            File.Delete(path);
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(cbbxSaved.SelectedIndex == -1) return;
            CreateMenu createMenu = new(((NamedPath)cbbxSaved.SelectedItem).Path);
            createMenu.ShowDialog();
        }
    
        private class NamedPath
        {
            public string Path { get; set; }
            public string Name { get; set; }

            public NamedPath(string name, string path)
            {
                Name = name;
                Path = path;
            }

            public string GetPath() => Path;

            public override string ToString()
            {
                return Name;
            }

        }
    }
}