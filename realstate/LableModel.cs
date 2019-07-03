using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Telerik.WinControls.UI;
using Telerik.WinControls.Data;
using System.Windows.Forms;
using System.Drawing;
using Telerik.WinControls;
using System.IO;


namespace realstate
{
    class LableModel: RadLabelElement
    {
        public LableModel(float width, int type) {

            float listwidth = (width * 93) / 100;
            float cellwidth = listwidth / 11 + 10;
            float firstmargin = 12*cellwidth;
            //float title = (listwidth) + 100 - cellwidth;
            //float kindcell = (listwidth * 3) / 16;
            //float kindmargin = title - kindcell;
            //float totalcell = ((listwidth * 3) / 16) ;
            //float totalmargin = kindmargin - totalcell;


            if (type == 1)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(9 * cellwidth) , 0, 0, 0);
               // this.Padding = new Padding(0, 15, 0, 0);
                this.ForeColor = Color.DarkSlateGray;
                this.Font = new System.Drawing.Font("B Nazanin", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                this.BorderVisible = true;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            }
            if (type == 2)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(8 * cellwidth)  , 0, 0, 0);
                this.ForeColor = Color.Black;
                this.BorderVisible = true;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            }
            else if (type == 3)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(7 * cellwidth), 0, 0, 0);
                this.ForeColor = Color.Black;
                this.BorderVisible = true;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            }
            else if(type == 4)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(6 * cellwidth) , 0, 0, 0);

                this.ForeColor = Color.Black;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                this.BorderVisible = true;

            }
            else if(type == 5)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(5 * cellwidth) , 0, 0, 0);
                this.ForeColor = Color.Black;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                this.BorderVisible = true;

            }
            else if (type == 6)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(4 * cellwidth) , 0, 0, 0);
                this.ForeColor = Color.Black;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                this.BorderVisible = true;
            }
            else if (type == 7)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(3 * cellwidth) , 0, 0, 0);
                this.ForeColor = Color.Black;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                this.BorderVisible = true;

            }
            else if (type == 8)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(2 * cellwidth) , 0, 0, 0);
                this.ForeColor = Color.Black;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                this.BorderVisible = true;

            }
            else if (type == 9)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding((int)(1 * cellwidth) , 0, 0, 0);
                this.ForeColor = Color.Black;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                this.BorderVisible = true;

            }
            else if (type == 10)
            {
                this.Size = new Size((int)cellwidth, 30);
                this.Margin = new Padding(0, 0, 0, 0);
                this.ForeColor = Color.Black;
                this.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
                this.BorderVisible = true;

            }


            this.AutoSize = false;
            this.PositionOffset = new SizeF(0, 0);
            this.RightToLeft = true;
            this.TextAlignment = ContentAlignment.MiddleCenter;
            this.Font = GlobalVariable.headerlistFONT;
          
           
        }

    }
}
