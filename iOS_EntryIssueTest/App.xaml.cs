using Xamarin.Forms;

namespace iOS_EntryIssueTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AccessoriesPage();
            AccessoriesViewModel accessoriesViewModel = new AccessoriesViewModel();
            MainPage.BindingContext = accessoriesViewModel;
            accessoriesViewModel.Init();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
