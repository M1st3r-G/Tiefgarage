using System.Diagnostics;

namespace Tiefgarage
{
    public partial class CreateMenu : Form
    {
        List<LevelGeneratorUI> Etagen = new();

        public CreateMenu()
        {
            InitializeComponent();
            Etagen.Add(new LevelGeneratorUI(this, new Point(15, 0)));
        }

        private void btnAcceptCreate_Click(object sender, EventArgs e)
        {
            List<List<Tuple<uint, FahrzeugTyp>>> fuerJedeEtage = new();

            foreach (LevelGeneratorUI Etage in Etagen)
            {
                fuerJedeEtage.Add(Etage.GetData());
            }

            Parkhaus meinParkhaus = new(fuerJedeEtage);

            Debug.WriteLine(meinParkhaus.ToString());
        }

        private void btnAddLevel_Click(object sender, EventArgs e)
        {
            int currentLength = Etagen.Aggregate(0, (c, lvl) => c + lvl.GetSize().Height);
            Etagen.Add(new LevelGeneratorUI(this, new Point(15, currentLength)));
        }
    }

    public class LevelGeneratorUI
    {
        private readonly List<SettingsRow> rows = new();
        private readonly Button button;
        private readonly GroupBox group;

        public LevelGeneratorUI(Form form, Point position)
        {
            button = new Button
            {
                Text = "Typ Hinzufügen",
                Size = new Size(100, 25),
                Location = new Point(220, 25) // 30 Offset
            };

            group = new GroupBox
            {
                Text = "Etage 1",
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
                    Location = new Point(position.X, position.Y + 25)
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
