using CarApp2.Core;
using CarApp2.MVVM.View;
using System;



namespace CarApp2.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        


        private object _currentView;


        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }
        public RelayCommand AboutViewCommand { get; set; }
        public RelayCommand SigupViewcommand { get; set; }


        public HomeViewModel HomeVm { get; set; }
        public loginViewModel LoginVM { get; set; }
        public aboutViewModel AboutVM { get; set; }

        public signupviewModel signupVM { get; set; }



        public Object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
           



            HomeVm = new HomeViewModel();
            LoginVM = new loginViewModel();
            AboutVM = new aboutViewModel();
            signupVM = new signupviewModel();
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVm;
            });

            LoginViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoginVM;
            });

            AboutViewCommand = new RelayCommand(o =>
            {
                CurrentView = AboutVM;
            });

            AboutViewCommand = new RelayCommand(o =>
            {
                CurrentView = AboutVM;
            });

            SigupViewcommand = new RelayCommand(o =>
            {
                CurrentView = signupVM;
            });

        }
        
    }
}
