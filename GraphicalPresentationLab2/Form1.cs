namespace GraphicalPresentationLab2
{
    public partial class Form1 : Form
    {
        string? type_of_line = null;
        string? type_of_geometric_object = null;

        public Form1()
        {
            InitializeComponent();

            var items = new string[] { "Круг", "Квадрат", "Прямоугольник" };
            geometryObjectsComboBox.Items.AddRange(items);
            geometryObjectsComboBox.SelectedItem = geometryObjectsComboBox.Items[0];
            geometryObjectsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void lineTypeButton_Click(object sender, EventArgs e)
        {
            lineTypeListBox.Items.Add(lineTypeTextBox.Text);
        }

        private void lineTypeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            type_of_line = lineTypeListBox.SelectedItem as string;

            yourChoiceButton.Enabled = type_of_line != null & type_of_geometric_object != null;
        }

        private void geometryObjectsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            type_of_geometric_object = geometryObjectsComboBox.SelectedItem as string;

            yourChoiceButton.Enabled = type_of_line != null && type_of_geometric_object != null;
        }

        private void yourChoiceButton_Click(object sender, EventArgs e)
        {
            if (type_of_line != null && type_of_geometric_object != null)
            {
                yourChoiceTextBox.Text = string.Format(
                    "Тип линии: {0}" + Environment.NewLine + "Вид геометрической фигуры: {1}",
                    type_of_line,
                    type_of_geometric_object
                );
            }
        }
    }
}