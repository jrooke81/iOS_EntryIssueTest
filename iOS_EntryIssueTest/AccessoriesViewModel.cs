using Acr.UserDialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace iOS_EntryIssueTest
{
    public class AccessoriesViewModel : Changeable
    {
        private ObservableCollection<AccessoryModel> __Accessories;

        public AccessoriesViewModel()
        {
            AssignCommands();
        }

        private void AssignCommands()
        {
            AddAccessoryCommand = new Command(BeginAddNewAccessory);
            AddAccessoryEntryReturnCommand = new Command<Entry>(OnReturnPressed);
        }

        private void BeginAddNewAccessory()
        {
            if (!IsAddingNewAccessory)
            {
                __Accessories.Add(new AccessoryModel { IsEditMode = true, Description = string.Empty });
            }
        }

        public void DeleteAccessory(AccessoryModel accessoryUIModel)
        {
            __Accessories.Remove(accessoryUIModel);
        }

        public void Init()
        {
            Accessories = new ObservableCollection<AccessoryModel>(new List<AccessoryModel>
            {
                new AccessoryModel
                {
                    Description = "Accessory One",
                },
                new AccessoryModel
                {
                    Description = "Accessory Two",
                },
                new AccessoryModel
                {
                    Description = "Accessory Three",
                }
            });
        }

        private void OnReturnPressed(Entry entry)
        {
            if (entry.BindingContext is AccessoryModel _AccessoryUIModel)
            {
                if (!string.IsNullOrWhiteSpace(_AccessoryUIModel.Description))
                {
                    TryAddCustomAccessory(_AccessoryUIModel);
                }
            }
        }

        public void TryAddCustomAccessory(AccessoryModel accessoryUIModel)
        {
            if (__Accessories.Where(accessory => accessory.Description.ToLower() == accessoryUIModel.Description.ToLower()).Count() > 1)
            {
                UserDialogs.Instance.Toast("Can't add accessory with duplicate description");
            }
            else
            {
                __Accessories.Remove(accessoryUIModel);
                accessoryUIModel.IsEditMode = false;
                __Accessories.Add(accessoryUIModel);
            }
        }

        public Command AddAccessoryCommand { get; private set; }
        public Command<Entry> AddAccessoryEntryReturnCommand { get; private set; }

        public ObservableCollection<AccessoryModel> Accessories
        {
            get => __Accessories;
            set
            {
                __Accessories = value;
                OnPropertyChanged();
            }
        }

        public bool IsAddingNewAccessory => __Accessories.Any(accessory => accessory.IsEditMode);
    }
}
