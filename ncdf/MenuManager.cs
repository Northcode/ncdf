using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ncdf
{
    interface IMenu
    {
        string Name;

        void Output();
    }

    class MenuManager
    {
        static IMenu[] menus = new IMenu[0];
        static int selectedMenu;

        static void ShowMenu(string Name)
        {
            for (selectedMenu = 0; menus[selectedMenu] != null && menus[selectedMenu].Name != Name; selectedMenu++) ;
        }

        static void ShowMenu(int n)
        {
            selectedMenu = n;
        }

        static void Output()
        {
            menus[selectedMenu].Output();
        }
    }
}
