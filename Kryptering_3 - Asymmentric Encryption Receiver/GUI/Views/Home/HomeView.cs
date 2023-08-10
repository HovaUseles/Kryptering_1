using Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Interfaces;
using Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Views.Home
{
    internal class HomeView : IViewable
    {
        public IViewable Show()
        {
            ViewComponents.DisplayViewHeader("Hello world");
            Console.ReadKey();

            return null;
        }
    }
}
