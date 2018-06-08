using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITCSurveyReport
{
    public partial class RadioButtonGroup : Control
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler SelectedChanged = delegate { };

        int _selected;

        /// <summary>
        /// 
        /// </summary>
        public RadioButtonGroup()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pe"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        /// <summary>
        /// 
        /// </summary>
        public int Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                int val = 0;
                var radioButton = this.Controls.OfType<RadioButton>()
                    .FirstOrDefault(radio =>
                        radio.Tag != null
                       && int.TryParse(radio.Tag.ToString(), out val) && val == value);

                if (radioButton != null)
                {
                    radioButton.Checked = true;
                    _selected = val;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);

            var radioButton = e.Control as RadioButton;
            if (radioButton != null)
                radioButton.CheckedChanged += radioButton_CheckedChanged;
        }

        void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            var radio = (RadioButton)sender;
            int val = 0;
            if (radio.Checked && radio.Tag != null
                 && int.TryParse(radio.Tag.ToString(), out val))
            {
                _selected = val;
                SelectedChanged(this, new EventArgs());
            }
        }
    }
}
