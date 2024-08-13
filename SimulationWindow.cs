using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Tiefgarage
{
    public partial class SimulationWindow : Form
    {
        public static Action<string> OnConsolePrint;

        private readonly Parkhaus current;
        private int currentLevel = 0;

        public SimulationWindow(string path)
        {
            InitializeComponent();
            tbxTitle.Text = path.Replace(Main.savePath, "").Replace(".parkhaus", "");
            current = JsonConvert.DeserializeObject<Parkhaus>(File.ReadAllText(path))
                ?? throw new NullReferenceException("Parkhaus konnte nicht gelesen werden");
            SetDisplayToLevel(0);
            lblFreeSlots.Text = current.GibAnzahlPlaetze().ToString();

            OnConsolePrint += RefreshConsoleDisplay;
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
                    Text = bucht.HatFreienPlatz(out Fahrzeug? f) ? $"Bucht {index + 1}-{i + 1}" : $"{f.GibId()}",
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
            List<Auto> tmpCars = new List<Auto>();

            int numberOfCars = (int)((new Random().NextDouble() * 0.5f + 0.25f) * current.GibAnzahlPlaetze(false, true, FahrzeugTyp.Auto));

            for (int i = 0; i < numberOfCars; i++)
            {
                tmpCars.Add(new Auto());
                cbbxCars.Items.Add(tmpCars[^1]);
                tmpCars[^1].ParkhausBefahren(current);
            }

            SetDisplayToLevel(currentLevel);
            lblFreeSlots.Text = current.GibAnzahlPlaetze().ToString();
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            cbbxCars.Items.Add(new Auto());
            cbbxCars.Items.Add(new Motorrad());
        }

        private void btnRemoveCar_Click(object sender, EventArgs e)
        {
            int tmp = cbbxCars.SelectedIndex;

            if (cbbxCars.SelectedIndex == -1) return;

            if (((Fahrzeug)cbbxCars.SelectedItem).GibParkhaus() != null)
            {
                OnConsolePrint?.Invoke("Fahrzeug kann nicht entfernt werden, es befindet sich im Parkhaus");
                return;
            }

            cbbxCars.Items.RemoveAt(cbbxCars.SelectedIndex);

            cbbxCars.SelectedIndex = tmp - 1 >= 0 ? tmp - 1 : -1;
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
                lblFreeSlots.Text = current.GibAnzahlPlaetze().ToString();
            }
            else OnConsolePrint?.Invoke("Auto konnte nicht einfahren.");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cbbxCars.SelectedItem == null) return;

            Fahrzeug tmp = (Fahrzeug)cbbxCars.SelectedItem;

            tmp.ParkhausVerlassen();

            SetDisplayToLevel(currentLevel);
            lblFreeSlots.Text = current.GibAnzahlPlaetze().ToString();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (cbbxCars.SelectedItem == null) return;
            Fahrzeug tmp = (Fahrzeug)cbbxCars.SelectedItem;

            if (current.GibPlatzVonFahrzeug(tmp, out Parkbucht? bucht, out Point? pos))
            {
                SetDisplayToLevel(pos.Value.X);
                displayContainer.Controls[pos.Value.Y].ForeColor = Color.Red;

                OnConsolePrint?.Invoke($"Fahrzeug befindet sich auf Bucht {pos.Value.X + 1}-{pos.Value.Y + 1}");
            }
            else OnConsolePrint?.Invoke("Fahrzeug konnte nicht gefunden werden.");
        }   

        private void btnClear_Click(object sender, EventArgs e)
        {
            current.Clear();
            SetDisplayToLevel(currentLevel);
            lblFreeSlots.Text = current.GibAnzahlPlaetze().ToString();
        }

        private void RefreshConsoleDisplay(string msg)
        {
            tbxOutput.Text = msg;
            Debug.WriteLine(msg);
        }
    }
}
