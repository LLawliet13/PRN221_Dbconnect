using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.DAO;
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private StudentDAO studentDAO = new StudentDAO();
        public MainWindow()
        {
            
            InitializeComponent();
            loadData();
            this.DataContext = this;
            


        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem typeItem = (ComboBoxItem)Major.SelectedItem;
            string stuMajor = typeItem.Content.ToString();

            
            if (String.IsNullOrEmpty(Name.Text.Trim())) {
                MessageBox.Show("please enter name");
            }
            else if (String.IsNullOrEmpty(Dob.Text.Trim()))
            {
                MessageBox.Show("please enter dob");
            }else if (Male.IsChecked == false && Female.IsChecked == false)
            {
                MessageBox.Show("please choose sex");

            }
            else { 
            
                String stuName = Name.Text.Trim();
                String  stuDob = Dob.Text;
                Boolean male = Male.IsChecked == true;

                String message = stuName + ", " + stuDob + ", " + stuMajor +  ", " + (male ? "Male":"Female")+" Đã lưu nhé";
                MessageBox.Show(message);
                studentDAO.add(new Student(stuName, DateTime.Parse(stuDob), stuMajor, male));
                UpdateDataGrid();
            }

        }
        public void UpdateDataGrid()
        {
            //DataGrid.Items.Clear();
            loadData();
        }
        public ObservableCollection<Student> students { get; set; } 

        public event PropertyChangedEventHandler? PropertyChanged;

        private void SomethingChanged(String objChangedName)
        {
            if(PropertyChanged!=null)
                PropertyChanged(this, new PropertyChangedEventArgs("students"));
        }
        private void loadData()
        {
            students = new ObservableCollection<Student>();
            DbSet<Student> data = studentDAO.getAll();
            foreach (Student student in data)
            {
                students.Add(student);

            }
            SomethingChanged("students");
            DataGrid.ItemsSource = students;
        }

     

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(Student student in students)
            {
                studentDAO.update(student);
            }
            MessageBox.Show("Updated");
            loadData();
        }

        private void DataGrid_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Student row_list = (Student)DataGrid.SelectedItem;
            String student_name = row_list.Name;
            studentDAO.delete(row_list);
            MessageBox.Show("deleted student " + student_name);
            loadData();
        }
    }
}
