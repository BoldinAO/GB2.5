using MyCompany.Company;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyCompany
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Departments departments = new Departments();
        People people = new People();
        public MainWindow()
        {
            InitializeComponent();
            People.AnyEmployeeDo += listView.Items.Add;
            Departments.AnyDepartmentDo += comboBox.Items.Add;
            departments.AddDepartment("Первый департамент");
            departments.AddDepartment("Второй департамент");
            comboBox.Items.Clear();
            departments.AddDepartment("Третий департамент");
            people.AddEmployee(0, "Тест", "Тест", "Тест", new DateTime(1990, 3, 4), departments.Departs[0], "Женский");
            people.AddEmployee(1, "Тест", "Тест", "Тест", new DateTime(1990, 3, 5), departments.Departs[1], "Мужской");
            listView.Items.Clear();
            people.AddEmployee(2, "Тест", "Тест", "Тест", new DateTime(1990, 3, 6), departments.Departs[2], "Женский");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = listView.SelectedIndex;
            listView.Items.Clear();
            people.ChangeEmployeeData(index, "Тест", "Тест", "Тест", new DateTime(1990, 3, 6), departments.Departs[comboBox.SelectedIndex], "Мужской");
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text != "")
            {
                comboBox.Items.Clear();
                departments.AddDepartment(textBox.Text);
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox.Text.Length > 0)
                button1.IsEnabled = true;
            else button1.IsEnabled = false;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string name = textBox1.Text;
            string firstName = textBox2.Text;
            listView.Items.Clear();
            people.AddEmployee(3, name, firstName, "Тест", new DateTime(1990, 3, 6), departments.Departs[2], "Женский");
        }

        private void ListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            textBox1.Text = listView.SelectedIndex == -1 ? "" : people.Peoples[listView.SelectedIndex].Name;
            textBox2.Text = listView.SelectedIndex == -1 ? "" : people.Peoples[listView.SelectedIndex].FirstName;
        }
    }
}
