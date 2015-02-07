using ACModManager.Domain;
using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ACModManager
{
    public partial class Form1 : Form
    {
        public static string FILE = "D:\\ModManagerTest\\mod.xml";
        public static string ZIPFILE = "D:\\ModManagerTest\\Mak_Corp_IFS3_AC_0.6.zip";
        public static string ACDIR = @"D:\Assetto Corsa";
        private Mod mod;
        public Form1()
        {
            mod = new Mod();
            InitializeComponent();
            comboBoxType.DataSource = Enum.GetValues(typeof(ModTypes));
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(Mod));
            FileStream myFileStream = new FileStream(FILE, FileMode.Open);
            mod = (Mod)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
            textBoxName.Text = mod.Name;
            comboBoxType.SelectedItem = mod.Type;
            textBoxVersion.Text = mod.Version;
            textBoxAuthor.Text = mod.Author;
            textBoxDescription.Text = mod.Description;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            mod.Name = textBoxName.Text;
            mod.Type = (ModTypes)comboBoxType.SelectedItem;
            mod.Version = textBoxVersion.Text;
            mod.Author = textBoxAuthor.Text;
            mod.Description = textBoxDescription.Text;
            XmlSerializer writer = new XmlSerializer(typeof(Mod));
            StreamWriter file = new StreamWriter(FILE);
            writer.Serialize(file, mod);
            file.Close();
        }

        private void buttonUnzip_Click(object sender, EventArgs e)
        {
            /*using (var file = File.OpenRead(ZIPFILE))
            using (var zip = new ZipArchive(file, ZipArchiveMode.Read))
            {
                foreach (var entry in zip.)
                {
                    using (var stream = entry.Open())
                    {
                        if (entry.FullName.EndsWith("/content/"))
                        {
                            entry.(ACDIR);
                        }
                    }
                }
            }*/

            ZipFile.ExtractToDirectory(ZIPFILE, ACDIR);
        }
    }
}
