using Xamarin.Forms;

namespace iOS_EntryIssueTest
{
    public class AddAccessoriesDataTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is AccessoryModel _AccessoryUIModel)
            {
                DataTemplate _Template = PredefinedTemplate;

                if (_AccessoryUIModel.IsEditMode)
                {
                    _Template = EditableTemplate;
                }
                return _Template;
            }
            return new DataTemplate();
        }

        public DataTemplate EditableTemplate { get; set; }
        public DataTemplate PredefinedTemplate { get; set; }
    }
}
