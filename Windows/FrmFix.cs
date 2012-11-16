﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XCoder
{
    public partial class FrmFix : Form
    {
        public FrmFix()
        {
            InitializeComponent();

            this.Icon = FileSource.GetIcon();
        }

        public static FrmFix Create(XConfig config)
        {
            var frm = new FrmFix();
            frm.Config = config;
            frm.LoadConfig();

            return frm;
        }

        private XConfig _Config;
        /// <summary>配置</summary>
        public XConfig Config { get { return _Config; } set { _Config = value; } }

        void LoadConfig()
        {
            cbNeedFix.Checked = Config.NeedFix;
            txtPrefix.Text = Config.Prefix;
            cbCutPrefix.Checked = Config.AutoCutPrefix;
            cbCutTableName.Checked = Config.AutoCutTableName;
            cbFixWord.Checked = Config.AutoFixWord;
            cbUseID.Checked = Config.UseID;
        }

        void SaveConfig()
        {
            Config.NeedFix = cbNeedFix.Checked;
            Config.Prefix = txtPrefix.Text;
            Config.AutoCutPrefix = cbCutPrefix.Checked;
            Config.AutoCutTableName = cbCutTableName.Checked;
            Config.AutoFixWord = cbFixWord.Checked;
            Config.UseID = cbUseID.Checked;
        }

        private void FrmFix_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }
    }
}
