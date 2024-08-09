using Newtonsoft.Json;
using System.Diagnostics;

namespace Tiefgarage
{
    public partial class SimulationWindow : Form
    {
        private readonly Parkhaus current;
        private int currentLevel = 0;

        public SimulationWindow(string path)
        {
            InitializeComponent();
            tbxTitle.Text = path.Replace(Main.savePath, "").Replace(".parkhaus", "");
            current = JsonConvert.DeserializeObject<Parkhaus>(File.ReadAllText(path))
                ?? throw new NullReferenceException("Parkhaus konnte nicht gelesen werden");
            SetDisplayToLevel(0);
        }

        public void SetDisplayToLevel(int index)
        {
            Parketage etage = current.GibParketagen()[index];

            displayContainer.Controls.Clear();

            List<Parkbucht> buchten = etage.GibParkbuchten();
            for (int i = 0; i < buchten.Count; i++)
            {
                Parkbucht bucht = buchten[i];
                Button newButton = new()
                {
                    Text = bucht.HatFreienPlatz(out Fahrzeug? f) ? $"Bucht {index + 1}-{i + 1}" : $"{index + 1}-{i + 1}: ({f})",
                    AutoSize = true,
                    BackColor = bucht.GibTyp() == FahrzeugTyp.Auto ? Color.DarkRed : Color.DarkBlue,
                    ForeColor = bucht.HatFreienPlatz(out _) ? Color.White : Color.Gray
                };

                displayContainer.Controls.Add(newButton);
            }

            lblIndex.Text = $"{currentLevel + 1}/{current.GibParketagen().Count}";
        }
        private void NavDirection(int direction)
        {
            int max = current.GibParketagen().Count;
            if (max == 1) return; // Dont Reload 

            currentLevel += direction;

            if (currentLevel < 0) currentLevel = max - 1;
            if (currentLevel >= max) currentLevel = 0;

            SetDisplayToLevel(currentLevel);
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            cbbxCars.Items.Add(new Auto(FahrzeugUtils.GibFreieId()));
            cbbxCars.Items.Add(new Motorrad(FahrzeugUtils.GibFreieId()));
        }

        private void btnRemoveCar_Click(object sender, EventArgs e)
        {
            if (cbbxCars.SelectedIndex == -1) return;
            cbbxCars.Items.RemoveAt(cbbxCars.SelectedIndex);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (tbxTitle.Text.Length == 0) return;

            float height = tbxTitle.Height * 0.99f;
            float width = tbxTitle.Width * 0.99f;

            tbxTitle.SuspendLayout();

            Font tryFont = tbxTitle.Font;
            Size tempSize = TextRenderer.MeasureText(tbxTitle.Text, tryFont);

            float heightRatio = height / tempSize.Height;
            float widthRatio = width / tempSize.Width;

            tryFont = new Font(tryFont.FontFamily, tryFont.Size * Math.Min(widthRatio, heightRatio), tryFont.Style);

            tbxTitle.Font = tryFont;
            tbxTitle.ResumeLayout();
        }
        private void btnBack_Click(object sender, EventArgs e) => Close();
        private void btnNavLeft_Click(object sender, EventArgs e) => NavDirection(-1);
        private void btnNavRight_Click(object sender, EventArgs e) => NavDirection(1);

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (cbbxCars.SelectedItem == null) return;

            Fahrzeug tmp = (Fahrzeug)cbbxCars.SelectedItem;
            tmp.ParkhausBefahren(current);
            if (current.GibPlatzVonFahrzeug(tmp, out Parkbucht? bucht, out Point? pos))
            {
                SetDisplayToLevel(pos.Value.X);
            }
            else Debug.WriteLine("Auto konnte nicht einfahren.");
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cbbxCars.SelectedItem == null) return;
            Fahrzeug tmp = (Fahrzeug)cbbxCars.SelectedItem;
            
            if (current.GibPlatzVonFahrzeug(tmp, out Parkbucht? bucht, out Point? pos))
            {
                SetDisplayToLevel(pos.Value.X);
                displayContainer.Controls[pos.Value.Y].ForeColor = Color.Red;
            }
            else Debug.WriteLine("Auto konnte nicht gefunden werden.");
        }
    }
}
