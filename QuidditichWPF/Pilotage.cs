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
        public static void LoadAll()
        {
            string userName = Environment.UserName;
            try
            {
                FileStream input = new FileStream(userName + ".preferences", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                preferences = (Dictionary<string, WindowPreference>)bf.Deserialize(input);
                input.Close();
            }
            catch (Exception e)
            {
                Init();
            }
        }

        public static void Init() {
            preferences = new Dictionary<string, WindowPreference>();
            AddWindow("Authentification", 263, 296, 100, 100);
            AddWindow("ListeCoupesWindow", 470, 300, 100, 100);
            AddWindow("ListeEquipesWindow", 450, 300, 100, 100);
            AddWindow("ListeJoueursWindow", 700, 400, 100, 100);
            AddWindow("ListeMatchsWindow", 670, 440, 100, 100);
            AddWindow("ListeReservationsWindow", 530, 450, 100, 100);
            AddWindow("ListeStadesWindow", 637, 400, 100, 100);
            AddWindow("MainWindow", 525, 350, 100, 100);
            SaveAll();
            LoadAll();
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
            string name = win.GetType().Name;
            WindowPreference wp = preferences[name];
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
            string userName = Environment.UserName;
            FileStream output = new FileStream(userName + ".preferences", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(output, preferences);
            output.Close();
        }
    }
}