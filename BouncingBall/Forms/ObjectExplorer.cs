﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Engine.Forms
{
    public partial class ObjectExplorer : Form
    {
        public ObjectExplorer()
        {
            InitializeComponent();
        }

        private void ObjectExplorer_Load(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
