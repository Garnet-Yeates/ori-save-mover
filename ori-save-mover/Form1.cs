using System.Security;
using System.Text.RegularExpressions;

namespace ori_save_mover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoSize = true;
            infoLabel.Text = DefaultLabelText;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            shiftUpwardsButton.Enabled = false;
            shiftDownwardsButton.Enabled = false;
        }

        private readonly Regex rg = new(@"\A[0-9]+\b");
        private readonly Regex rg = new(@"\A[0-9]+");

        private string[] fileNames = Array.Empty<string>();
        private string path = "";
        private string fileName = "";
        private string directory = "";
        private int start = -1;

        private void resetAllFields()
        {
            this.path = "";
            this.fileName = "";
            this.directory = "";
            this.start = -1;
            this.fileNames = Array.Empty<string>();
            this.infoLabel.Text = DefaultLabelText;
            this.shiftUpwardsButton.Enabled = false;
            this.shiftDownwardsButton.Enabled = false;
            this.readOnlyPathTextBox.Text = "";
        }

        private void chooseFile_Click(object sender, EventArgs e)
        {
            resetAllFields();

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.path = openFileDialog1.FileName;

                    FileInfo info = new(path);
                    if (info.DirectoryName is null)
                    {
                        // This should never happen, but just in case....
                        resetAllFields();
                        this.infoLabel.Text = "Error finding directory name";
                        return;
                    }

                    this.fileName = info.Name;
                    this.directory = info.DirectoryName;
                    this.fileNames = Directory.GetFiles(directory, "*.uberstate").Select(path => new FileInfo(path).Name).ToArray();

                    // fileNames is sorted the same way windows explorer sorts by name
                    // When you choose a file to shift up, it will shift itself up, as well as all of the files that come after it
                    // (based on how you see the files are ordered in windows explorer list mode, sorted alphabetically)
                    // This means that if you have file structure that looks like this:
                    //   001 - YStart to Glades
                    //   001 - ZStart to Glades
                    // And you choose to shift ZStart to glades up, it will NOT shift YStart to glades up with it, since Z start is later
                    Array.Sort(this.fileNames, new NumericComparer());

                    if (!this.fileNames.Any())
                    {
                        resetAllFields();
                        this.infoLabel.Text = "Could not find any uberstate files here";
                        return;
                    }

                    // Scan directory and make sure ALL files match the pattern properly
                    foreach (string fileName in fileNames)
                    {
                        Match match = rg.Match(fileName);
                        if (!match.Success)
                        {
                            resetAllFields();
                            this.infoLabel.Text = "ALL uberstate files must match pattern '### - Name'";
                            return;
                        }
                    }

                    this.infoLabel.Text = "Press a shift button :)";

                    // Find start index
                    for (int i = 0; i < fileNames.Length; i++)
                        if (fileNames[i].Equals(fileName))
                            this.start = i;

                    if (this.start == -1)
                    {
                        resetAllFields();
                        this.infoLabel.Text = $"Could not find start index";
                        return;
                    }

                    this.shiftUpwardsButton.Enabled = true;
                    this.shiftDownwardsButton.Enabled = true;
                    this.readOnlyPathTextBox.Text = path;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void shiftDownwardsButton_Click(object sender, EventArgs e)
        {
            Shift(-1);
        }

        private void shiftUpwardsButton_Click(object sender, EventArgs e)
        {
            Shift(1);
        }

        public void Shift(int direction)
        {
            // Map full path to just file names
            string[] fileNamesNew = new string[fileNames.Length];

            if (direction == -1 && start == 0 && int.Parse(rg.Match(fileNames[0]).Value) == 0)
            {
                resetAllFields();
                this.infoLabel.Text = $"Cannot downshift starting 0";
                return;
            }

            // We know matches for sure exist here
            // fileNames is sorted the same way windows explorer sorts by name
            for (int i = 0; i < fileNames.Length; i++)
            {
                string currFileName = fileNames[i];
                fileNamesNew[i] = currFileName;

                Match match = rg.Match(currFileName);

                string oldPrefix = match.Value;
                int prefixAsInt = int.Parse(oldPrefix);

                if (i >= this.start)
                {
                    // Create a formatter that follows the same format they did
                    // (e.g: if they did "123" it will be "000" format, if they did "12" it will be "00" format)
                    string format = new('0', oldPrefix.Length);

                    // Change the prefix to be the old one, but up or down shifted by 1, then formatted the same way they formatted it
                    string newPrefix = (prefixAsInt + direction).ToString(format);

                    // Replace the 
                    string newFileName = currFileName.Replace(oldPrefix, newPrefix);

                    string oldFullPath = $"{directory}\\{currFileName}";
                    string newFullPath = $"{directory}\\{newFileName}";

                    File.Move(oldFullPath, newFullPath);
                }
            }

            resetAllFields();
            this.infoLabel.Text = $"Done! Another one?";

        }

        private void infoLabel_Click(object sender, EventArgs e)
        {

        }
    }
}