namespace iOS_EntryIssueTest
{
    public class AccessoryModel : Changeable
    {
        private string __Description;

        public string Description
        {
            get => __Description;
            set
            {
                __Description = value;
                OnPropertyChanged();
            }
        }
        public bool IsEditMode { get; set; }
    }
}
