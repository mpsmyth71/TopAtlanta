using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopAtlanta.Common;

namespace TopAtlanta.Web
{
    public class MenuConfig
    {
        public static void RegisterMenus(IDictionary<string, Menu> menus)
        {
            menus.Add("main", BuildMainMenu());
        }

        private static Menu BuildMainMenu()
        {
            var mainMenu = new Menu();

            mainMenu.Items.Add(new MenuItem("Home"));
            mainMenu.Items.Add(new MenuItem("Accounts"));

            return mainMenu;

        }
    }
}