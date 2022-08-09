using Gunter.Core.Constants;
using Gunter.Core.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public partial class InfoSourceViewer : UserControl
    {
        public IGunterInfoSource? InfoSource{ get; set; }

        public InfoSourceViewer()
        {
            InitializeComponent();
        }

        public InfoSourceViewer(IGunterInfoSource infoSource)
        {
            InitializeComponent();
            InfoSource = infoSource;
            LoadInfoItem();
        }

        private void LoadInfoItem()
        {
            if (InfoSource is null)
                return;

            txtId.Text = InfoSource.Id;
            txtBaseClass.Text = IdentificationConstants.CLASSID.ClassIdNameOf(InfoSource.ClassId);
            txtNombre.Text = InfoSource.Name;
            txtCategory.Text = InfoSource.Category;
            txtSubCategory.Text = InfoSource.SubCategory;
            specialPropertiesViewer1.SetProperties(InfoSource.SpecialProperties);

            var data = InfoSource.GetData();
            if (data is null)
                return;

            try
            {
                string json = JsonConvert.SerializeObject(data);
                JObject obj = JObject.Parse(json);
                treeView1.BeginUpdate();
                treeView1.Nodes.Clear();
                TreeNode parent = Ele2Node(obj);
                parent.Tag = obj;
                parent.Text = $"Last Data";
                parent.ToolTipText = $"Last data was {data.GetType().ToString()}";
                treeView1.Nodes.Add(parent);

                propertyGrid1.SelectedObject = obj;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            finally
            {
                treeView1.EndUpdate();
                treeView1.ExpandAll();
            }

            //propertyGrid1.SelectedObject = data;
        }

        public static void JsonToTreeview(TreeView oTV, string sJSON, string rootName)
        {
            JContainer json = sJSON.StartsWith("[")
                            ? (JContainer)JArray.Parse(sJSON)
                            : (JContainer)JObject.Parse(sJSON);

            oTV.Nodes.Add(Ele2Node(json, rootName));
        }

        private static TreeNode Ele2Node(object oJthingy, string text = "")
        {
            TreeNode oThisNode = new TreeNode(text);

            switch (oJthingy.GetType().Name) //~mwr could not find parent object for all three JObject, JArray, JValue
            {
                case "JObject":
                    foreach (KeyValuePair<string, JToken> oJtok in (JObject)oJthingy)
                    {
                        var child = Ele2Node(oJtok.Value, oJtok.Key);
                        child.Tag = oJtok.Value;
                        oThisNode.Nodes.Add(child);
                    }
                    break;
                case "JArray":
                    int i = 0;
                    foreach (JToken oJtok in (JArray)oJthingy)
                        oThisNode.Nodes.Add(Ele2Node(oJtok, string.Format("[{0}]", i++)));

                    if (i == 0) oThisNode.Nodes.Add("[]"); //to handle empty arrays
                    break;
                case "JValue":
                    oThisNode.Nodes.Add(new TreeNode(oJthingy.ToString()));
                    break;
                default:
                    throw new System.Exception("clsJSON2Treeview can't interpret object:" + oJthingy.GetType().Name);
            }

            return oThisNode;
        }

        private TreeNode Json2Tree(JObject obj)
        {
            //create the parent node
            TreeNode parent = new TreeNode();
            //loop through the obj. all token should be pair<key, value>
            foreach (var token in obj)
            {
                //change the display Content of the parent
                parent.Text = token.Key.ToString();
                //create the child node
                TreeNode child = new TreeNode();
                child.Text = token.Key.ToString();
                //check if the value is of type obj recall the method
                if (token.Value.Type.ToString() == "Object")
                {
                    // child.Text = token.Key.ToString();
                    //create a new JObject using the the Token.value
                    JObject o = (JObject)token.Value;
                    //recall the method
                    child = Json2Tree(o);
                    //add the child to the parentNode
                    parent.Nodes.Add(child);
                    child.Tag = o;
                }
                //if type is of array
                else if (token.Value.Type.ToString() == "Array")
                {
                    int ix = -1;
                    //  child.Text = token.Key.ToString();
                    //loop though the array
                    foreach (var itm in token.Value)
                    {
                        //check if value is an Array of objects
                        if (itm.Type.ToString() == "Object")
                        {
                            TreeNode objTN = new TreeNode();
                            //child.Text = token.Key.ToString();
                            //call back the method
                            ix++;

                            JObject o = (JObject)itm;
                            objTN = Json2Tree(o);
                            objTN.Text = token.Key.ToString() + "[" + ix + "]";
                            objTN.Tag = o;
                            child.Nodes.Add(objTN);
                            parent.Collapse();
                            //parent.Nodes.Add(child);
                        }
                        //regular array string, int, etc
                        else if (itm.Type.ToString() == "Array")
                        {
                            ix++;
                            TreeNode dataArray = new TreeNode();
                            foreach (var data in itm)
                            {
                                dataArray.Text = token.Key.ToString() + "[" + ix + "]";
                                dataArray.Nodes.Add(data.ToString());
                            }
                            child.Nodes.Add(dataArray);
                        }

                        else
                        {
                            child.Nodes.Add(itm.ToString());
                        }
                    }
                    parent.Nodes.Add(child);
                }
                else
                {
                    //if token.Value is not nested
                    // child.Text = token.Key.ToString();
                    //change the value into N/A if value == null or an empty string 
                    if (token.Value.ToString() == "")
                        child.Nodes.Add("N/A");
                    else
                        child.Nodes.Add(token.Value.ToString());
                    parent.Nodes.Add(child);
                }
            }
            return parent;

        }

        private void specialPropertiesViewer1_OnPropertyChanged(object sender, GunterUI.SpecialPropertiesViewer.PropertyUpdatedEventArgs e)
        {
            InfoSource?.SetSpecialProperties(specialPropertiesViewer1.SpecialProperties);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node;
            if (node is null)
                return;

            treeView1.SelectedNode = e.Node;
            node.EnsureVisible();
            propertyGrid1.SelectedObject = null;
            if (node?.Tag is not null)
                propertyGrid1.SelectedObject = (JToken)node.Tag;
        }
    }
}
