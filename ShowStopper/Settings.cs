using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowStopper
{
    public class Settings
    {
        public string RootDir { get; private set; }
        public string SettingsFilePath { get; private set; }
        public string Message { get; private set; }

        public struct ColorSet
        {
            public string buttonType;
            public string bgColor;
            public string fgColor;
            public string tracked;
            public ColorSet(string t, string f, string b,string tr)
            {
                this.buttonType = t;
                this.fgColor = f;
                this.bgColor = b;
                this.tracked = tr;
            }
        }

        public struct ButtonSpec
        {
            public string buttonLabel;
            public string buttonType;
            public string buttonMessage;
            public ButtonSpec(string l, string t, string m)
            {
                this.buttonLabel = l;
                this.buttonType = t;
                this.buttonMessage = m;
            }
        }

        public Dictionary<string, ColorSet> colors;
        public Dictionary<string, ButtonSpec> buttons;

        public Settings()
        {
            this.RootDir = Environment.ExpandEnvironmentVariables("%AppData%\\ShowStopper");
            this.SettingsFilePath = Path.Combine(this.RootDir, "settings.txt");
            this.Message = "";
            this.colors = new Dictionary<string, ColorSet>();
            this.buttons = new Dictionary<string, ButtonSpec>();

            this.initializeDir();
            this.load();

        }

        public List<string> getButtonTypes()
        {
            List<string> rtn = new List<string>();
            foreach (KeyValuePair<string, ColorSet> entry in this.colors)
            {
                rtn.Add(entry.Key);
            }
            return rtn;
        }

        public void clearColors()
        {
            this.colors.Clear();
        }

        public void addColor(ColorSet cs)
        {
            this.colors.Add(cs.buttonType, cs);
        }

        public void clearButtons()
        {
            this.buttons.Clear();
        }

        public void addButton(ButtonSpec bs)
        {
            this.buttons.Add(bs.buttonLabel, bs);
        }

        public ColorSet getColorSet(string n)
        {
            ColorSet rtn = new ColorSet(n, "0,0,0", "255,255,255","0");
            if(this.colors.ContainsKey(n))
            {
                rtn = this.colors[n];
            }
            return rtn;
        }

        public ButtonSpec getButtonSpec(string n)
        {
            ButtonSpec rtn = new ButtonSpec(n, "", "");
            if(this.buttons.ContainsKey(n))
            {
                rtn = this.buttons[n];
            }
            return rtn;
        }
        private void initializeDir()
        {
            try
            {
                if (!Directory.Exists(this.RootDir))
                {
                    DirectoryInfo di = Directory.CreateDirectory(this.RootDir);
                    // save the default colors to a new file

                    colors.Add("PROFANITY", new ColorSet("SWEAR", "255, 255, 255", "255,0,0","0"));
                    colors.Add("REVEAL", new ColorSet("REVEAL", "255,0,0", "255,255,255","0"));
                    colors.Add("TOPIC", new ColorSet("TOPIC", "255,255,255", "0,0,0","1"));
                    this.save();
                }
            }
            catch(Exception ex)
            {
                this.Message = ex.Message;
            }

        }

        public void load()
        {
            this.clearColors();
            this.clearButtons();
            if (File.Exists(this.SettingsFilePath))
            {
                string[] lines = File.ReadAllLines(this.SettingsFilePath);
                foreach (string line in lines)
                {
                    string[] sa = line.Split('|');
                    if (sa[0] == "button")
                    {
                        // button|buttonLabel|buttonType|buttonMessage
                        ButtonSpec bs = new ButtonSpec(sa[1], sa[2], sa[3]);
                        this.addButton(bs);
                    }
                    else if (sa[0] == "color")
                    {
                        // color|buttonType|bg|fg|tracked
                        ColorSet cs = new ColorSet(sa[1], sa[2], sa[3], sa[4]);
                        this.addColor(cs);
                    }
                }
            }
        }
        public void save()
        {
            List<string> ls = new List<string>();
            foreach(KeyValuePair<string, ColorSet> entry in this.colors)
            {
                ls.Add("color|" + entry.Value.buttonType + "|" + entry.Value.fgColor + "|" + entry.Value.bgColor + "|" + entry.Value.tracked);
            }

            foreach (KeyValuePair <string, ButtonSpec> entry in this.buttons)
            {
                ls.Add("button|" + entry.Value.buttonLabel + "|" + entry.Value.buttonType + "|" + entry.Value.buttonMessage);
            }
            File.WriteAllLines(this.SettingsFilePath, ls.ToArray());
        }
    }
}
