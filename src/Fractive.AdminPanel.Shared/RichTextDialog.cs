using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractive.AdminPanel.Shared {
    public partial class RichTextDialog : Form {
        public RichTextDialog(string text) {
            InitializeComponent();
            richTextBox1.Text = text;
        }
    }
}
