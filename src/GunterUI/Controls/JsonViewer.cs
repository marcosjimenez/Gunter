using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telegram.Bot.Types;
using System.Text;

namespace Controls
{
    public partial class JsonViewer : UserControl
    {

        private const string DefaultFileFilters = @"json files (*.json)|*.json";

        #region >> Delegates

        private delegate void SetActionStatusDelegate(string text, bool isError);

        private delegate void SetJsonStatusDelegate(string text, bool isError);

        #endregion

        #region >> Fields

        private string internalOpenedFileName;

        private System.Timers.Timer jsonValidationTimer;

        #endregion

        #region >> Properties

        /// <summary>
        /// Accessor to file name of opened file.
        /// </summary>
        string OpenedFileName
        {
            get { return internalOpenedFileName; }
            set
            {
                internalOpenedFileName = value;
                saveToolStripMenuItem.Enabled = internalOpenedFileName != null;
                saveAsToolStripMenuItem.Enabled = internalOpenedFileName != null;
                Text = (internalOpenedFileName ?? "") + @" - Json Editor by ZTn";
            }
        }

        #endregion

        #region >> Constructor

        public JsonViewer()
        {
            InitializeComponent();

            jsonTypeComboBox.DataSource = Enum.GetValues(typeof(JTokenType));

            OpenedFileName = null;
            SetActionStatus(@"Empty document.", true);
            SetJsonStatus(@"", false);

            var commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Skip(1).Any())
            {
                OpenedFileName = commandLineArgs[1];
                try
                {
                    using (var stream = new FileStream(commandLineArgs[1], FileMode.Open))
                    {
                        SetJsonSourceStream(stream, commandLineArgs[1]);
                    }
                }
                catch
                {
                    OpenedFileName = null;
                }
            }
            //auto create empty object
            newJsonObjectToolStripMenuItem_Click(this, null);

        }

        public void LoadObject(object objectToLoad)
        {
            var json = JsonConvert.SerializeObject(objectToLoad);

            using var reader = new MemoryStream(Encoding.UTF8.GetBytes(json));
            LoadJsonFile(string.Empty, reader);
        }

        public void LoadJsonFile(string jsonFile)
        {
            using var stream = new FileStream(jsonFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            LoadJsonFile(jsonFile, stream);
        }

        public void LoadJsonFile(string jsonFile, Stream stream)
        => SetJsonSourceStream(stream, jsonFile);

        #endregion

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"json files (*.json)|*.json|All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using var stream = openFileDialog.OpenFile();
                LoadJsonFile(openFileDialog.FileName, stream);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenedFileName == null)
            {
                return;
            }

            try
            {
                using (var stream = new FileStream(OpenedFileName, FileMode.Open))
                {
                    jTokenTree.SaveJson(stream);
                }
            }
            catch
            {
                MessageBox.Show(this, $"An error occured when saving file as \"{OpenedFileName}\".", @"Save As...");

                OpenedFileName = null;
                SetActionStatus(@"Document NOT saved.", true);

                return;
            }

            SetActionStatus(@"Document successfully saved.", false);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = DefaultFileFilters,
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                OpenedFileName = saveFileDialog.FileName;
                using (var stream = saveFileDialog.OpenFile())
                {
                    if (stream.CanWrite)
                    {
                        jTokenTree.SaveJson(stream);
                    }
                }
            }
            catch
            {
                MessageBox.Show(this, $"An error occured when saving file as \"{OpenedFileName}\".", @"Save As...");

                OpenedFileName = null;
                SetActionStatus(@"Document NOT saved.", true);

                return;
            }

            SetActionStatus(@"Document successfully saved.", false);
        }

        private void newJsonObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jTokenTree.SetJsonSource("{}");

            saveAsToolStripMenuItem.Enabled = true;
            SetActionStatus(@"Document Loaded", false);
        }

        private void newJsonArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jTokenTree.SetJsonSource("[]");

            saveAsToolStripMenuItem.Enabled = true;
        }

        private void aboutJsonEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void jsonValueTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!isValidating)
            {
                StartValidationTimer();
            }
        }

        private void jsonValueTextBox_Leave(object sender, EventArgs e)
        {
            jsonValueTextBox.TextChanged -= jsonValueTextBox_TextChanged;
        }

        private void jsonValueTextBox_Enter(object sender, EventArgs e)
        {
            jsonValueTextBox.TextChanged += jsonValueTextBox_TextChanged;
        }

        private void jTokenTree_AfterSelect(object sender, ZTn.Json.JsonTreeView.AfterSelectEventArgs eventArgs)
        {
            newtonsoftJsonTypeTextBox.Text = eventArgs.TypeName;

            jsonTypeComboBox.Text = eventArgs.JTokenTypeName;

            // If jsonValueTextBox is focused then it triggers this event in the update process, so don't update it again ! (risk: infinite loop between events).
            if (!jsonValueTextBox.Focused)
            {
                jsonValueTextBox.Text = eventArgs.GetJsonString();
            }
        }

        private void SetJsonSourceStream(Stream stream, string fileName)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            OpenedFileName = fileName;

            try
            {
                jTokenTree.SetJsonSource(stream);
            }
            catch
            {
                MessageBox.Show(this, $"An error occured when reading \"{OpenedFileName}\"", @"Open...");

                OpenedFileName = null;
                SetActionStatus(@"Document NOT loaded.", true);

                return;
            }

            SetActionStatus(@"Document successfully loaded.", false);
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void SetActionStatus(string text, bool isError)
        {
            if (InvokeRequired)
            {
                Invoke(new SetActionStatusDelegate(SetActionStatus), text, isError);
                return;
            }

            actionStatusLabel.Text = text;
            actionStatusLabel.ForeColor = isError ? Color.OrangeRed : Color.Black;
        }

        private void SetJsonStatus(string text, bool isError)
        {
            if (InvokeRequired)
            {
                Invoke(new SetJsonStatusDelegate(SetActionStatus), text, isError);
                return;
            }

            jsonStatusLabel.Text = text;
            jsonStatusLabel.ForeColor = isError ? Color.OrangeRed : Color.Black;
        }
        private bool isValidating;

        private void StartValidationTimer()
        {
            //jsonValidationTimer?.Stop();

            //jsonValidationTimer = new System.Timers.Timer(250);

            //jsonValidationTimer.Elapsed += (o, args) =>
            //{
            //    if (isValidating)
            //    {
            //        return;
            //    }
            //    else
            //    {
            //        isValidating = true;
            //    }

            //    jsonValidationTimer.Stop();

            //    jTokenTree.Invoke(new Action(JsonValidationTimerHandler));
            //    isValidating = false;

            //};

            //jsonValidationTimer.Start();
        }

        private void JsonValidationTimerHandler()
        {
            try
            {
                jTokenTree.UpdateSelected(jsonValueTextBox.Text);
                //reformat json to be pretty
                jsonValueTextBox.Text = JsonConvert.SerializeObject(
                    JsonConvert.DeserializeObject(jsonValueTextBox.Text),
                    Formatting.Indented);

                SetJsonStatus("Json format validated.", false);

            }
            catch (JsonReaderException exception)
            {
                SetJsonStatus(
                    $"INVALID Json format at (line {exception.LineNumber}, position {exception.LinePosition})",
                    true);
            }
            catch
            {
                SetJsonStatus("INVALID Json format", true);
            }
        }

        private void jsonValueTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //remove styles from richtextbox
            if (e.Control && e.KeyCode == Keys.V)
            {
                ((RichTextBox)sender).Paste(DataFormats.GetFormat("Text"));
                e.Handled = true;
            }
        }

    }
}
