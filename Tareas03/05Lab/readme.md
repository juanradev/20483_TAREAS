### Módulo 5: Creación de una jerarquía de clases mediante la herencia

### Laboratorio: Refactorización de la funcionalidad común en la clase de usuario

#### Ejercicio 1: creación y herencia de la clase base de usuario


Creacción de clase abstracta User con implementacion del metodo VerifyPassword

````c#
public abstract class User    
    {

        public string UserName { get; set; }
        private string _password = Guid.NewGuid().ToString(); // password generada de forma automatica por defecto

        public string Password   // np get ya que la propiedad es de solo escritura
        {
             set => _password = value;
        }
        public bool VerifyPassword(string pass) => (String.Compare(pass , _password)==0);
    }
````
Student : User    
````
 // TODO: Exercise 1: Task 2a: Inherit from the User class
    // Tasks eliminar la propiedad Student.UserName ya que hereda de User
    // Tasks eliminar la propiedad Student.Password ya que hereda de User
    // Tasks eliminar el metodo  Student.VerifyPassword ya que hereda de User
    public class Student : User, IComparable<Student>  // Icomparable debe implementar el metodo public int CompareTo(Student other)
    {
        public int StudentID { get; set; }
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor to initialize the properties of a new Student
        public Student(int studentID, string userName, string password, string firstName, string lastName, int teacherID)
        {
            StudentID = studentID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherID;
        }

        // Default constructor 
        public Student()
        {
            StudentID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            TeacherID = 0;
        }

        // Compare Student objects based on their LastName and FirstName properties
        public int CompareTo(Student other)
        {
            // Concatenate the LastName and FirstName of this student
            string thisStudentsFullName = LastName + FirstName;

            // Concatenate the LastName and FirstName of the "other" student
            string otherStudentsFullName = other.LastName + other.FirstName;

            // Use String.Compare to compare the concatenated names and return the result
            return(String.Compare(thisStudentsFullName, otherStudentsFullName));
        }

        // Add a grade to a student (the grade is already populated)
        public void AddGrade(Grade grade)
        {
            // Verify that the grade does not belong to another student - the StudentID should be zero
            if (grade.StudentID == 0)
            {
                // Add the grade to the student's record
                grade.StudentID = StudentID;
            }
            else
            {
                // If the grade belongs to a different student, throw an ArgumentException
                throw new ArgumentException("Grade", "Grade belongs to a different student");
            }   
        }
    }
````
Teacher: User   

````
  // TODO: Exercise 1: Task 2e: Inherit from the User class
    // Task : Eliminar las propiedades y métodos  heredables de Users
    public class Teacher : User
    {
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        // Constructor to initialize the properties of a new Teacher
        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        // Default constructor
        public Teacher()
        {
            TeacherID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Class = String.Empty;
        }

        // Enroll a student in the class for this teacher
        public void EnrollInClass(Student student)
        {
            // Verify that the student is not already enrolled in another class
            if (student.TeacherID == 0)
            {
                // Set the TeacherID property of the student
                student.TeacherID = TeacherID;
            }
            else
            {
                // If the student is already assigned to a class, throw an ArgumentException
                throw new ArgumentException("Student", "Student is already assigned to a class");
            }            
        }

        // Remove a student from the class for this teacher
        public void RemoveFromClass(Student student)
        {
            // Verify that the student is actually assigned to the class for this teacher
            if (student.TeacherID == TeacherID)
            {
                // Reset the TeacherID property of the student
                student.TeacherID = 0;
            }
            else
            {
                // If the student is not assigned to the class for this teacher, throw an ArgumentException
                throw new ArgumentException("Student", "Student is not assigned to this class");
            } 
        }
    }
````

#### Ejercicio 2: implementación de la complejidad de las contraseñas mediante un método abstracto

Se trata de definir ele metodo como abstracto en la clase abstracta
e implementarlo de forma correspondiente en las clases heredables


// creamos el metodo abstracto y en el set de Password eliminamos la asignación y levantamos una excepción si !SetPassword

````
    public abstract class User
    {
        public string UserName { get; set; }
        protected string _password = Guid.NewGuid().ToString();  // el campo pasa a ser protegido para que pueda ser accedido por las clases derivadas
        public string Password
        {
            set
            {
                if (!SetPassword(value))
                {
                    throw new ArgumentException("Password not complex enough", "Password");
                }
            }
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }

        public abstract bool SetPassword(string pwd);
    }
 ````   

 Implementamos VerifyPassword en Student

 ````
         // The password policy is very simple - the password must be at least 6 characters long,
        //but there are no other restrictions
        public override bool SetPassword(string pwd)
        {
            if (pwd.Length >= 6 )
            {
                _password = pwd;
                return true;
            }
            return false;
        }
````

Implementamos VerifyPassword en Student

``````
     // the password should be  at least 8 characters long and contains at least two numeric
        // en el lab nos piden expresión regurar
        public override bool SetPassword(string pwd)
        {
            Match numericMatch = Regex.Match(pwd, @".*[0-9]+.*[0-9]+.*");

            // If the password provided as the parameter is at least 8 characters long and contains at least two numeric characters then save it and return true
            if (pwd.Length >= 8 && numericMatch.Success)
            {
                _password = pwd;
                return true;
            }
            // If the password is not complex enough, then do not save it and return false
            return false;
        }
``````

modificamos en StudentsPage los metodos de añadir nuevo estudiante


``````
 // TODO: Exercise 2: Task 3a: Use the SetPassword method to set the password.
	//newStudent.Password = sd.password.Text;

	if (!newStudent.SetPassword(sd.password.Text))
	{
		throw new Exception("Password must be at least 6 characters long. Student not created");
	}
``````

Modificar la utilidad ChangePassword en ChangePasswordDialog.ok_Click

````
// If the user clicks OK to change the password, validate the information that the user has provided
        // TODO: Exercise 2: Task 4a: Get the details of the current user
        // TODO: Exercise 2: Task 4b: Check that the old password is correct for the current user
        // TODO: Exercise 2: Task 4c: Check that the new password and confirm password fields are the same
        // TODO: Exercise 2: Task 4d: Attempt to change the password
        // If the password is not sufficiently complex, display an error message
        // nota en el xmal tenenemos los campos oldpasswrod y newpassword y confirm
        // puedo acceder a su campo de texto mediante su propiedad .Password

        private void ok_Click(object sender, RoutedEventArgs e)
        {
          
            User currentUser = ( SessionContext.UserRole == Role.Teacher)  ?  (User) SessionContext.CurrentTeacher : (User) SessionContext.CurrentStudent;
            var oldp = oldPassword.Password;
            var newp = newPassword.Password;
            var cfrp = confirm.Password;

            if (!currentUser.VerifyPassword(oldp))
            {
                MessageBox.Show("Old password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
          
            if (String.Compare(newp, cfrp) != 0)
            {
                MessageBox.Show("The new password and confirm password fields are different", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

             if (!currentUser.SetPassword(newp))
            {
                MessageBox.Show("The new password is not sufficiently complex", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            this.DialogResult = true;
        }

````

#### Ejercicio 3: creación de la excepción personalizada ClassFullException

implementar la clase ClassFullException (añdir propiedad string ClassName y constructores 

````
    [Serializable]
    class ClassFullException : Exception
    {
        // TODO: Exercise 3: Task 1a: Add custom data: the name of the class that is full
        // Code that catches this exception can query the public ClassName property to determine which class caused the exception
        // TODO: Exercise 3: Task 1b: Delegate functionality for the common constructors directly to the Exception class
        // TODO: Exercise 3: Task 1c: Add custom constructors that populate the _className field.
        // The code that invokes this exception is expected to provide the class name

        private string _className;
        public string ClassName 
		{ get => _className; set => _className = value; }
        public ClassFullException() { }
        public ClassFullException(string message, string cls) : base(message) => _className = cls;
        public ClassFullException(string message, string cls, Exception innerException) : base(message, innerException) => _className = cls;

			...................................

````
lanzar y capturar la ClassFullException

la excepcion se lanzara cuando queramos inscribir a un estudiante en una clase llena

para ello en la clase profesor definimos un campo MAX_CLASS_SIZE
 
````
 // TODO: Exercise 3: Task 2a: Set the maximum class size for any teacher
        private const int MAX_CLASS_SIZE = 8;
````		
y en el metodo EnrollInClass(Student student) lanzamos la excepcion si supera ese numero  
````
            if (numStudents == MAX_CLASS_SIZE)
            {
                // Throw a ClassFullException and specify the class that is full
                throw new ClassFullException("Class full: Unable to enroll student", Class);
            }
 ````        
ese metodo se utiliza en AssignStudentDialog por lo que habrá qu manejar la excepcion   
````
private void Student_Click(object sender, RoutedEventArgs e)
        {
            try
            {	..............
				if (reply == MessageBoxResult.Yes)
					{
						// Get the ID of the currently logged-on teacher
						int teacherID = SessionContext.CurrentTeacher.TeacherID;

						// Assign the student to this teacher's class
						SessionContext.CurrentTeacher.EnrollInClass(student);

						// Refresh the display - the newly assigned student should disappear from the list of unassigned students
						Refresh();
					}
				 }
            // TODO: Exercise 3: Task 2c: Catch and handle the ClassFullException
			// la ponemos antes de la excepcion mas generica
            catch (ClassFullException cfe)
            {
                MessageBox.Show(String.Format("{0}. Class: {1}", cfe.Message, cfe.ClassName), "Error enrolling student", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error enrolling student", MessageBoxButton.OK, MessageBoxImage.Error);
            }

````