using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Controls
{
    /// <summary>
    /// Interaction logic for ChangePasswordDialog.xaml
    /// </summary>
    public partial class ChangePasswordDialog : Window
    {
        public ChangePasswordDialog()
        {
            InitializeComponent();
        }

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
    }
}
