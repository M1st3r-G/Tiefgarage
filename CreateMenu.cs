﻿using Newtonsoft.Json;

namespace Tiefgarage
{
    public partial class CreateMenu : Form
    {
        private readonly List<LevelGeneratorUI> Etagen = new();

        public CreateMenu()
        {
            InitializeComponent();
            Etagen.Add(new LevelGeneratorUI(this, new Point(15, 0), 0));
        }

        private void btnAcceptCreate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Das eingegeben Parkhaus kann nach dem erstellen nicht mehr geändert werden",
                                "Sind sie sich sicher?", MessageBoxButtons.OKCancel) == DialogResult.Cancel) return;

            string fileName = (tbxName.Text is "" ? "Unbenanntes Parkhaus" : tbxName.Text);

            if (File.Exists(fileName + ".parkhaus"))
            {
                if (MessageBox.Show($"Es existiert bereits ein Parkhaus mit dem Namen: {fileName}\nWillst du es überschreiben?",
                    "Achtung", MessageBoxButtons.YesNo) == DialogResult.No) return;
            }

            List<List<Tuple<uint, FahrzeugTyp>>> fuerJedeEtage = new();

            foreach (LevelGeneratorUI Etage in Etagen)
            {
                fuerJedeEtage.Add(Etage.GetData());
            }

            Parkhaus meinParkhaus = new(fuerJedeEtage);

            File.WriteAllText(fileName + ".parkhaus", JsonConvert.SerializeObject(meinParkhaus, Formatting.Indented));
            MessageBox.Show($"Es wurde erfolgreich ein {meinParkhaus} erstellt.", "Erfolg", MessageBoxButtons.OK);
            Close();
        }

        private void btnAddLevel_Click(object sender, EventArgs e)
        {
            int currentLength = Etagen.Aggregate(0, (c, lvl) => c + lvl.GetSize().Height);
            Etagen.Add(new LevelGeneratorUI(this, new Point(15, currentLength), Etagen.Count));
        }
    }

    public class LevelGeneratorUI
    {
        private readonly List<SettingsRow> rows = new();
        private readonly Button button;
        private readonly GroupBox group;

        public LevelGeneratorUI(Form form, Point position, int idx)
        {
            button = new Button
            {
                Text = "Typ Hinzufügen",
                Size = new Size(100, 25),
                Location = new Point(220, 25) // 30 Offset
            };

            group = new GroupBox
            {
                Text = $"Etage {idx}",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Location = position
            };

            button.Click += (o, e) => AddRow();

            AddRow();

            group.Controls.Add(button);
            form.Controls.Add(group);
        }

        public void AddRow()
        {
            if (rows.Count == 1) button.Enabled = false;

            Point position = new(10, rows.Count * 30);
            rows.Add(new SettingsRow(group, position));

            // Update Size
        }

        public List<Tuple<uint, FahrzeugTyp>> GetData() =>
            rows.Select(r => r.GetData()).ToList();

        public Size GetSize() => group.Size;

        private class SettingsRow
        {
            private readonly NumericUpDown number;
            private readonly ComboBox dropdown;

            public SettingsRow(GroupBox group, Point position)
            {
                number = new NumericUpDown
                {
                    Maximum = 500,
                    Value = 100,
                    Minimum = 1,
                    Size = new Size(100, 50),
                    Location = new Point(position.X, position.Y + 25),
                    Increment = 10
                };

                dropdown = new ComboBox
                {
                    DataSource = Enum.GetValues(typeof(FahrzeugTyp)),
                    Size = new Size(75, 50),
                    Location = new Point(position.X + 115, position.Y + 25),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                group.Controls.Add(number);
                group.Controls.Add(dropdown);
            }

            public Tuple<uint, FahrzeugTyp> GetData() =>
                new((uint)number.Value, (FahrzeugTyp)dropdown.SelectedItem);
        }
    }
}
