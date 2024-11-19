using CarApp2.Core;
using CarApp2.MVVM.View;
using System;


namespace CarApp2.MVVM.ViewModel
{
     class MainDashboardViewModel : ObservableObject
    {

        private object _currentView;


        public RelayCommand ModelViewCommand { get; set; }
        public RelayCommand DashboardHomeViewCommand { get; set; }
        public RelayCommand customizeViewCommand { get; set; }
        public RelayCommand PurchaseDeatilsViewCommand { get; set; }
        public RelayCommand ReturnViewCommand { get; set; }
        public RelayCommand supportViewCommand { get; set; }


        public DashboardHomeViewModel dashboardHomeVm { get; set; }

        public modelViewModel modelVm { get; set; }
        public customizeViewModel customizeVm { get; set; }
        public PurchaseDetailsViewModel purchaseVm { get; set; }

        public ReturnViewModel returnVM { get; set; }
        public supportViewModel supportVm { get; set; }





        public Object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainDashboardViewModel()
        {




            dashboardHomeVm = new DashboardHomeViewModel();
            modelVm = new modelViewModel();
            customizeVm = new customizeViewModel();
            purchaseVm = new PurchaseDetailsViewModel();
            returnVM = new ReturnViewModel();
            supportVm = new supportViewModel();


            CurrentView = dashboardHomeVm;



            DashboardHomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = dashboardHomeVm;
            });

            ModelViewCommand = new RelayCommand(o =>
            {
                CurrentView = modelVm;
            });

            customizeViewCommand = new RelayCommand(o =>
            {
                CurrentView = customizeVm;
            });

            PurchaseDeatilsViewCommand = new RelayCommand(o =>
            {
                CurrentView = purchaseVm;
            });

            ReturnViewCommand = new RelayCommand(o =>
            {
                CurrentView = returnVM;
            });
            supportViewCommand = new RelayCommand(o =>
            {
                CurrentView = supportVm;
            });




        }

    }
}
