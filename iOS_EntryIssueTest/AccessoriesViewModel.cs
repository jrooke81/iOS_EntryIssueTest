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

        public Command AddAccessoryCommand { get; private set; }

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
