using Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Utilities
{
    internal class ViewNavigationOption
    {
        public string DisplayName { get; set; }
        public IViewable GoToView { get; set; }

        public ViewNavigationOption(string displayName, IViewable goToView)
        {
            DisplayName = displayName;
            GoToView = goToView;
        }
    }
}
