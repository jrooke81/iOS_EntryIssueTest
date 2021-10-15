using System.Threading.Tasks;
using Xamarin.Forms;

namespace iOS_EntryIssueTest
{
    public partial class AccessoriesPage : ContentPage
    {
        public AccessoriesPage()
        {
            InitializeComponent();
        }

        private async void OnEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry _Entry && _Entry.BindingContext is AccessoryModel _AccessoryUIModel)
            {
                if (string.IsNullOrWhiteSpace(_Entry.Text))
                {
                    //the fix
                    await Task.Delay(1);
                    AccessoriesViewModel.DeleteAccessory(_AccessoryUIModel);
                }
            }
        }
        public AccessoriesViewModel AccessoriesViewModel => BindingContext as AccessoriesViewModel;
    }
}
