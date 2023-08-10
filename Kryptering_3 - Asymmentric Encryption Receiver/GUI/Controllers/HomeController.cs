using Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Interfaces;
using Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Utilities;
using Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kryptering_3___Asymmentric_Encryption_Receiver.GUI.Controllers
{
    internal static class HomeController
    {
        public static IViewable Index()
        {
            return new HomeView();
        }
    }
}
