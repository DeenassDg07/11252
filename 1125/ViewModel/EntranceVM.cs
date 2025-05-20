using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1125.DB;
using _1125.Model;
using _1125.View;
using _1125.VMTools;

namespace _1125.ViewModel
{
    internal class EntranceVM : BaseVM
    {
        static User UsingUser;
        private List<User> userlist;
        private string login;
        private string password;
        public string DirectorLogin = "211007";
        public string DirectorPassword = "211007700112";
        
        public ICommand Logingo { get; set; }

        public List<User> Userlist
        {
            get => userlist;
            set
            {
                userlist = value;
                Signal();
            }
        }
        public string Login
        {
            get => login;
            set
            {
                login = value;
                Signal();
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                Signal();
            }

        }    
        public ICommand Registration { get; set; }
        public EntranceVM()
        {
            Logingo = new CommandVM(() =>
            {
                var user = UserDB.GetDb().Auth(login, password);
                if (user.Id != 0)
                {
                    //if(user.Role == )
                    // надо куда-то сохранить пользователя, чтобы дальше с ним можно было работать
                    CategoryWindow categoryWindow = new CategoryWindow();
                    categoryWindow.ShowDialog();
                    close?.Invoke();
                }
            });
            Registration = new CommandVM(() =>
                {
                    RegistrationWindow registrationWindow = new RegistrationWindow();
                    close?.Invoke();
                    registrationWindow.ShowDialog();
                });
        }
        public EntranceVM(bool canRegister)
        {
            CanRegister = canRegister;
            Logingo = new CommandVM(() =>
            {
                var user = UserDB.GetDb().Auth(login, password);
                if (user.Id != 0)
                {
                    if (user.Role == "user")
                    {
                        // надо куда-то сохранить пользователя, чтобы дальше с ним можно было работать
                        CategoryWindow categoryWindow = new CategoryWindow();
                        categoryWindow.ShowDialog();
                        close?.Invoke();
                    }
                    else if (user.Role == "director")
                    {

                        // надо куда-то сохранить пользователя, чтобы дальше с ним можно было работать
                        CategoryWindow categoryWindow = new CategoryWindow();
                        categoryWindow.ShowDialog();
                        close?.Invoke();

                    }
                }
            });
            Registration = new CommandVM(() =>
            {
                RegistrationWindow registrationWindow = new RegistrationWindow();
                close?.Invoke(); 
                registrationWindow.Show();
            });
        }
        public bool CanRegister { get; } = true;
        
        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}


