﻿using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using ZTn.Json.JsonTreeView.Generic;

namespace ZTn.Json.JsonTreeView
{
    /// <summary>
    /// Specialized <see cref="TreeNode"/> for handling <see cref="JObject"/> representation in a <see cref="TreeView"/>.
    /// </summary>
    sealed class JObjectTreeNode : JTokenTreeNode
    {
        #region >> Properties

        public JObject JObjectTag => Tag as JObject;

        #endregion

        #region >> Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JObjectTreeNode"/> class.
        /// </summary>
        public JObjectTreeNode(JObject jObject)
            : base(jObject)
        {
            ContextMenuStrip = SingleInstanceProvider<JObjectContextMenuStrip>.Value;
        }

        #endregion

        #region >> JTokenTreeNode

        /// <inheritdoc />
        public override void AfterCollapse()
        {
            base.AfterCollapse();

            Text = $@"{{{JObjectTag.Type}}} {GetAbstractTextForTag()}";
        }

        /// <inheritdoc />
        public override void AfterExpand()
        {
            base.AfterExpand();

            Text = $@"{{{JObjectTag.Type}}}";
        }

        #endregion
    }
}
