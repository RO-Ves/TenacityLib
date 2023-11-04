using System.Collections.Generic;

namespace TenacityLib
{
    public class TenacityOption
    {
        public string Name;
        public TenacityOptionType OptionType;
        public bool Enabled;
        public List<string> DropdownOptions = new List<string>();
        public string SelectedDropdown;

        public enum TenacityOptionType
        {
            Toggle,
            Dropdown
        }
    }
}
