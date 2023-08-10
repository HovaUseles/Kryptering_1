using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_4___Asymmetric_Encryption_Receiver.GUI.Utilities
{
    internal class ViewNavigationOption
    {
        public string DisplayName { get; set; }
        public Action GoToView { get; set; }

        public ViewNavigationOption(string displayName, Action goToView)
        {
            DisplayName = displayName;
            GoToView = goToView;
        }
    }
}
