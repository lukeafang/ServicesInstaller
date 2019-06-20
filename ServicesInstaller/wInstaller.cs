using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesInstaller
{
    public partial class wInstaller : Form
    {
        public wInstaller()
        {
            InitializeComponent();
        }

        private void cbServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnServiceInstall_Click(object sender, EventArgs e)
        {

        }

        private void btnServiceUninstall_Click(object sender, EventArgs e)
        {

        }

        private void wInstaller_Shown(object sender, EventArgs e)
        {
            string version = System.Windows.Forms.Application.ProductVersion;
            this.lblInstallerVersion.Text = String.Format("Version:{0}", version);

            updateUIValue();
        }

        private void updateUIValue()
        {

        }
    }
}
