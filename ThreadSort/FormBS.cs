using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSort {
    public class FormBS : Form {

        public int prgBarLength = 200;
        public int prgBarWidth = 10;
        public int prgBarSpace = 10;
        public int pad = 10;
        public int[] data;
        ProgressBar[] prgBars = new ProgressBar[15];

        public FormBS() {
            this.SuspendLayout();
            // 
            // progressBars 1-15
            //
            for (int i = 0; i < 15; i++) {
                ProgressBar prgBar = new System.Windows.Forms.ProgressBar();
                prgBar.Location = new System.Drawing.Point(10, (prgBarSpace + prgBarWidth) * (i + 1));
                prgBar.Name = "prgBar" + (i + 1);
                prgBar.Size = new System.Drawing.Size(prgBarLength, prgBarWidth);
                prgBar.Style = ProgressBarStyle.Continuous;
                prgBar.ForeColor = Color.DarkGreen;
                prgBar.TabIndex = i;
                prgBars[i] = prgBar;
                Controls.Add(prgBar);
            }

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(prgBarLength + 2 * pad, ((prgBarWidth + prgBarSpace) * this.Controls.Count) + prgBarSpace + (2 * pad));
            this.Padding = new Padding(pad, pad, pad, pad);
            this.Name = "FormBS";
            this.Text = "Bubble Sort";
            this.ResumeLayout(false);

        }
        public FormBS(int[] data) : this() {
            this.data = data;
        }

        public void ShowData(int a, int b) {
            for (int i = 0; i < data.Length; i++) {
                prgBars[i].Value = data[i];
                if (i == a) {
                    prgBars[i].ForeColor = Color.LightGreen;
                } else if (i == b) {
                    prgBars[i].ForeColor = Color.LightSalmon;
                } else {
                    prgBars[i].ForeColor = Color.DarkGreen;
                }
                prgBars[i].Refresh();
            }
        }



    }
}
