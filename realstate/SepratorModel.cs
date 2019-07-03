﻿using System;
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
    class SepratorModel : RadPanelElement
    {
        public SepratorModel(int width)
        {

            this.RightToLeft = true;
            this.PanelBorder.Visibility = ElementVisibility.Visible;
            this.PanelFill.GradientStyle = GradientStyles.Solid;
            this.PanelFill.BackColor = Color.WhiteSmoke;
            this.Padding = new System.Windows.Forms.Padding(0); 
            this.Size = new System.Drawing.Size(width, 4);
           
            
        }

    }
}
