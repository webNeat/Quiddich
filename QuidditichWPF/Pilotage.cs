using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace QuidditichWPF
{
    [Serializable]
    struct WindowPreference
    {
        public double Width
        {
            get;
            set;
        }
        public double Height
        {
            get;
            set;
        }
        public double Top
        {
            get;
            set;
        }
        public double Left
        {
            get;
            set;
        }
    }
    class Pilotage
    {
        private static Dictionary<string, WindowPreference> preferences;
        public static void Init()
        {
            preferences = new Dictionary<string, WindowPreference>();
            AddWindow("Authentification", 200, 200, 200, 200);
            AddWindow("ListeCoupesWindow", 200, 200, 200, 200);
            AddWindow("ListeequipesWindow", 200, 200, 200, 200);
            AddWindow("ListeJoueursWindow", 200, 200, 200, 200);
            AddWindow("ListeMatchsWindow", 200, 200, 200, 200);
            AddWindow("ListeReservationsWindow", 200, 200, 200, 200);
            AddWindow("ListestadesWindow", 200, 200, 200, 200);
            AddWindow("MainWindow", 200, 200, 200, 200);
            SaveAll();
        }
        public static void LoadAll()
        {
            string userName = Environment.UserName;
            if (! File.Exists(userName + ".preferences"))
            {
                Init();
            }
            FileStream input = new FileStream(userName + ".preferences", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            preferences = (Dictionary<string, WindowPreference>) bf.Deserialize(input);
            input.Close();
        }

        public static void AddWindow(string name, double width, double height, double top, double left)
        {
            WindowPreference wp = new WindowPreference();
            wp.Height = height;
            wp.Width = width;
            wp.Top = top;
            wp.Left = left;
            preferences.Add(name, wp);
        }

        public static void LoadPreferences(Window win)
        {
            WindowPreference wp = preferences[win.GetType().Name];
            win.Width = wp.Width;
            win.Height = wp.Height;
            win.Top = wp.Top;
            win.Left = wp.Left;
        }

        public static void SavePreferences(Window win)
        {
            WindowPreference wp = new WindowPreference();
            wp.Width = win.Width;
            wp.Height = win.Height;
            wp.Top = win.Top;
            wp.Left = win.Left;
            preferences[win.GetType().Name] = wp;
        }

        public static void SaveAll()
        {
            // String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string userName = Environment.UserName;
            FileStream output = new FileStream(userName + ".preferences", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(output, preferences);
            output.Close();
        }
    }
}