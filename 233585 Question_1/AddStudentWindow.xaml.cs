using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Question_1;  // Ensure you're importing the correct namespace for Student

namespace Question_1
{
    
        public class Student
        {
            public int StudentID { get; set; } 
            public string Name { get; set; }
            public string Grade { get; set; }
            public string Subject { get; set; }
            public int Marks { get; set; }
            public int Attendance { get; set; }
    }
    



//    public partial class AddStudentsWindow : Window
//    {
//        private string connectionString = "Data Source=DESKTOP-GHAURI\\SQLEXPRESS;Initial Catalog=StudentTrackerDB;Integrated Security=True";

//        public AddStudentsWindow()
//        {
//            InitializeComponent();
//        }

//        private void SaveButton_Click(object sender, RoutedEventArgs e)
//        {
//            // Validate inputs
//            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
//                GradeComboBox.SelectedItem == null ||
//                SubjectComboBox.SelectedItem == null ||
//                string.IsNullOrWhiteSpace(MarksTextBox.Text) ||
//                string.IsNullOrWhiteSpace(AttendanceTextBox.Text))
//            {
//                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
//                return;
//            }

//            try
//            {
//                // Create a new instance of the Student class
//                Student newStudent = new Student
//                {
//                    Name = NameTextBox.Text,
//                    Grade = (GradeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
//                    Subject = (SubjectComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
//                    Marks = int.Parse(MarksTextBox.Text),
//                    Attendance = int.Parse(AttendanceTextBox.Text)
//                };

//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    string query = "INSERT INTO Students (Name, Grade, Subject, Marks, Attendance) VALUES (@Name, @Grade, @Subject, @Marks, @Attendance)";
//                    SqlCommand cmd = new SqlCommand(query, connection);
//                    cmd.Parameters.AddWithValue("@Name", newStudent.Name);
//                    cmd.Parameters.AddWithValue("@Grade", newStudent.Grade);
//                    cmd.Parameters.AddWithValue("@Subject", newStudent.Subject);
//                    cmd.Parameters.AddWithValue("@Marks", newStudent.Marks);
//                    cmd.Parameters.AddWithValue("@Attendance", newStudent.Attendance);
//                    cmd.ExecuteNonQuery();
//                }

//                MessageBox.Show("Student added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
//                this.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"An error occurred while adding the student: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//            }
//        }

//        private void CancelButton_Click(object sender, RoutedEventArgs e)
//        {
//            this.Close();
//        }
//    }
//}


        public partial class AddStudentsWindow : Window
        {
            private string connectionString = "Data Source=DESKTOP-GHAURI\\SQLEXPRESS;Initial Catalog=StudentTrackerDB;Integrated Security=True";
            private Student studentToEdit;  // Store the student to edit, if any

            // Constructor for adding a new student
            public AddStudentsWindow()
            {
                InitializeComponent();
            }

            // Constructor for editing an existing student
            public AddStudentsWindow(Student student)
            {
                InitializeComponent();
                studentToEdit = student;

                // Populate the fields with student data if editing
                if (student != null)
                {
                    NameTextBox.Text = student.Name;
                    GradeComboBox.SelectedItem = GradeComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == student.Grade);
                    SubjectComboBox.SelectedItem = SubjectComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == student.Subject);
                    MarksTextBox.Text = student.Marks.ToString();
                    AttendanceTextBox.Text = student.Attendance.ToString();
                }
            }

            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    GradeComboBox.SelectedItem == null ||
                    SubjectComboBox.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(MarksTextBox.Text) ||
                    string.IsNullOrWhiteSpace(AttendanceTextBox.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                try
                {
                    // Create a new instance of the Student class
                    Student newStudent = new Student
                    {
                        Name = NameTextBox.Text,
                        Grade = (GradeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                        Subject = (SubjectComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                        Marks = int.Parse(MarksTextBox.Text),
                        Attendance = int.Parse(AttendanceTextBox.Text)
                    };

                    // If we're editing an existing student, set the ID
                    if (studentToEdit != null)
                    {
                        newStudent.StudentID = studentToEdit.StudentID;
                        UpdateStudentInDatabase(newStudent);
                    }
                    else
                    {
                        AddStudentToDatabase(newStudent);
                    }

                    MessageBox.Show("Student saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Method to insert a new student into the database
            private void AddStudentToDatabase(Student student)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Students (Name, Grade, Subject, Marks, Attendance) VALUES (@Name, @Grade, @Subject, @Marks, @Attendance)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Grade", student.Grade);
                    cmd.Parameters.AddWithValue("@Subject", student.Subject);
                    cmd.Parameters.AddWithValue("@Marks", student.Marks);
                    cmd.Parameters.AddWithValue("@Attendance", student.Attendance);
                    cmd.ExecuteNonQuery();
                }
            }

            // Method to update an existing student's data in the database
            private void UpdateStudentInDatabase(Student student)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Students SET Name = @Name, Grade = @Grade, Subject = @Subject, Marks = @Marks, Attendance = @Attendance WHERE StudentID = @StudentID";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Grade", student.Grade);
                    cmd.Parameters.AddWithValue("@Subject", student.Subject);
                    cmd.Parameters.AddWithValue("@Marks", student.Marks);
                    cmd.Parameters.AddWithValue("@Attendance", student.Attendance);
                    cmd.Parameters.AddWithValue("@StudentID", student.StudentID);  // Use StudentID for the update
                    cmd.ExecuteNonQuery();
                }
            }

            private void CancelButton_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
    }
