using Xamarin.Forms;

namespace iOS_EntryIssueTest
{
    public partial class AccessoriesPage : ContentPage
    {
        public AccessoriesPage()
        {
            InitializeComponent();
        }

        private void OnEntryUnfocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry _Entry && _Entry.BindingContext is AccessoryModel _AccessoryUIModel)
            {
                if (string.IsNullOrWhiteSpace(_Entry.Text))
                {
                    AccessoriesViewModel.DeleteAccessory(_AccessoryUIModel);
                }
                else
                {
                    AccessoriesViewModel.TryAddCustomAccessory(_AccessoryUIModel);
                }
            }
        }
        public AccessoriesViewModel AccessoriesViewModel => BindingContext as AccessoriesViewModel;
    }
}
