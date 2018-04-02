using Newtonsoft.Json;
using System;
using System.Collections.Generic; 
using System.Windows.Forms;

namespace Dict2Json
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class myclass
        {
            public string item1;
            public int item2;
            public DateTime item3;

            public myclass(string _item1, int _item2, DateTime _item3)
            {
                item1 = _item1;
                item2 = _item2;
                item3 = _item3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<UInt32, myclass> dict = new Dictionary<UInt32, myclass>();
            for (int i = 0; i < 2; i++)
            {
                dict.Add((UInt32)i, new myclass(i.ToString(),i,DateTime.Now));
            }

            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            MessageBox.Show(json);

            Dictionary<string, myclass> dict2 = JsonConvert.DeserializeObject < Dictionary <string, myclass>>(json);
           
            foreach (var item in dict2)
            {
                MessageBox.Show(item.Value.item1, item.Key);
            }
        }
    }
}
