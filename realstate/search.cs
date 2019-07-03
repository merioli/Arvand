using Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;

namespace realstate
{
    public partial class search : Form
    {

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;
        public search()
        {
            InitializeComponent();
            this.MouseClick += mouseClick;
           
        }
      
        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!(mantaghe_name.Focused || mantagheNameText.Focused))
                {
                    paneloflist.Visible = false;
                }
            }
        }
        CatsAndAreasObject log = new CatsAndAreasObject();

        private List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }
        private List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }
        public void initFont()
        {
            byte[] fontData = Properties.Resources.IRANSans_FaNum_;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.IRANSans_FaNum_.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.IRANSans_FaNum_.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            GlobalVariable.headerlistFONT = new Font(fonts.Families[0], 10.0F, System.Drawing.FontStyle.Regular);
            GlobalVariable.headerlistFONTsmall = new Font(fonts.Families[0], 8.0F, System.Drawing.FontStyle.Regular);
            GlobalVariable.headerlistFONTBold = new Font(fonts.Families[0], 11.0F, System.Drawing.FontStyle.Bold);

            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);

        }
        private void search_Load(object sender, EventArgs e)
        {
            initFont();

            if (GlobalVariable.isadmin == "1")
            {
                log = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
                Settings1.Default.IsLogedIn = "1";
                setcat();
              
            }
            else
            {
                log = GlobalVariable.catsAndAreas;
                Settings1.Default.IsLogedIn = "1";
                setcatforclient();
               
            }


         


            panel1.PanelElement.Shape = new RoundRectShape();
            panel1.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel1.PanelElement.PanelFill.BackColor = Color.White;
            panel2.PanelElement.Shape = new RoundRectShape();
            panel2.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel2.PanelElement.PanelFill.BackColor = Color.White;

            panel3.PanelElement.Shape = new RoundRectShape();
            panel3.PanelElement.PanelFill.GradientStyle = GradientStyles.Solid;
            panel3.PanelElement.PanelFill.BackColor = Color.White;

            mantagheNameText.Text = "";

          
        }

        public void setcat()
        {


            CatsAndAreasObject log = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            Settings1.Default.IsLogedIn = "1";


            // سه گزینه زیر اینجا داده نمی شود و در بخش لاگین کاربر
            //GlobalVariable.activezonse = log.result2.active_regions;
            //GlobalVariable.portlimit = log.result2.max_users;
            //GlobalVariable.expirationdate = log.result2.expire_date;
            ////  GlobalVariable.token = log.token;

            //var sourceofApartment = new AutoCompleteStringCollection();
            //foreach (var item in log.result.apartment)
            //{

            //    sourceofApartment.Add(item);
            //}


            //apartment.AutoCompleteCustomSource = sourceofApartment;
            //apartment.AutoCompleteMode = AutoCompleteMode.Append;
            //apartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //apartment.MaxDropDownItems = 10;

            apartment.DisplayMember = "title";
            apartment.ValueMember = "ID";
            apartment.DataSource = new BindingSource(log.result.apartment, null);


            ashpazkhane.DisplayMember = "title";
            ashpazkhane.ValueMember = "ID";
            ashpazkhane.DataSource = new BindingSource(log.result.ashpazkhane, null);

            //var sourceofOffice = new AutoCompleteStringCollection();
            //foreach (var item in log.result.office)
            //{

            //    sourceofOffice.Add(item);
            //}

            //office.AutoCompleteCustomSource = sourceofOffice;
            //office.AutoCompleteMode = AutoCompleteMode.Append;
            //office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //office.MaxDropDownItems = 10;

            office.DisplayMember = "title";
            office.ValueMember = "ID";
            office.DataSource = new BindingSource(log.result.office, null);
           

            //var sourceofKolangi = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kolangi)
            //{

            //    sourceofKolangi.Add(item);
            //}
            //kolangi.AutoCompleteCustomSource = sourceofKolangi;
            //kolangi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kolangi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kolangi.MaxDropDownItems = 10;
            kolangi.DisplayMember = "title";
            kolangi.ValueMember = "ID";
            kolangi.DataSource = new BindingSource(log.result.kolangi, null);

            //var sourceofVilla = new AutoCompleteStringCollection();
            //foreach (var item in log.result.villa)
            //{

            //    sourceofVilla.Add(item);
            //}
            //villa.AutoCompleteCustomSource = sourceofVilla;
            //villa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //villa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //villa.MaxDropDownItems = 10;

            villa.DisplayMember = "title";
            villa.ValueMember = "ID";
            villa.DataSource = new BindingSource(log.result.villa, null);



            //var sourceofMostaghelat = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mostaghellat)
            //{

            //    sourceofMostaghelat.Add(item);
            //}
            //mostaghellat.AutoCompleteCustomSource = sourceofMostaghelat;
            //mostaghellat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mostaghellat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mostaghellat.MaxDropDownItems = 10;
            mostaghellat.DisplayMember = "title";
            mostaghellat.ValueMember = "ID";
            mostaghellat.DataSource = new BindingSource(log.result.mostaghellat, null);

           


            //var sourceofSamt = new AutoCompleteStringCollection();
            //foreach (var item in log.result.samt)
            //{

            //    sourceofSamt.Add(item);
            //}
            //samt.AutoCompleteCustomSource = sourceofSamt;
            //samt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //samt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //samt.MaxDropDownItems = 10;

            //samt.DataSource = log.result.samt;


            //var sourceofSenn = new AutoCompleteStringCollection();
            //foreach (var item in log.result.senn)
            //{

            //    sourceofSenn.Add(item);
            //}
            //senn.AutoCompleteCustomSource = sourceofSenn;
            //senn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //senn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //senn.MaxDropDownItems = 10;
            //  senn.DataSource = log.result.villa;


            //var sourceofMantaghe = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe)
            //{

            //    sourceofMantaghe.Add(item);
            //}
            //mantaghe.AutoCompleteCustomSource = sourceofMantaghe;
            //mantaghe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe.MaxDropDownItems = 10;
            mantaghe_name.DisplayMember = "title";
            mantaghe_name.ValueMember = "ID";
            mantaghe_name.DataSource = new BindingSource(log.result.mantaghe, null);
          

            mantaghe_id.DisplayMember = "title";
            mantaghe_id.ValueMember = "ID";
            mantaghe_id.DataSource = new BindingSource(log.result.mantaghe_id, null);

           

            //var sourceofMantagheID = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe_id)
            //{

            //    sourceofMantagheID.Add(item);
            //}
            //mantaghe_id.AutoCompleteCustomSource = sourceofMantagheID;
            //mantaghe_id.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe_id.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe_id.MaxDropDownItems = 10;
            //  m.DataSource = log.result.mantaghe_id;


            //var sourceofSeraydar = new AutoCompleteStringCollection();
            //foreach (var item in log.result.seraydar)
            //{

            //    sourceofSeraydar.Add(item);
            //}
            //seraydar.AutoCompleteCustomSource = sourceofSeraydar;
            //seraydar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //seraydar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //seraydar.MaxDropDownItems = 10;
            //  seraydar.DataSource = log.result.seraydar;


            //var sourceofKatType = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kaf_type)
            //{

            //    sourceofKatType.Add(item);
            //}
            //kaf_type.AutoCompleteCustomSource = sourceofKatType;
            //kaf_type.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kaf_type.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kaf_type.MaxDropDownItems = 10;
            // kaf_type.DataSource = log.result.kaf_type;


            //var sourceofSarmayesh = new AutoCompleteStringCollection();
            //foreach (var item in log.result.garmayesh_sarmayesh)
            //{

            //    sourceofSarmayesh.Add(item);
            //}
            //garmayesh_sarmayesh.AutoCompleteCustomSource = sourceofSarmayesh;
            //garmayesh_sarmayesh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //garmayesh_sarmayesh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //garmayesh_sarmayesh.MaxDropDownItems = 10;
            // garmayesh_sarmayesh.DataSource = log.result.garmayesh_sarmayesh;

            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("خطا در اتصال به سرور");
            }

        }
        public void setcatforclient()
        {


            CatsAndAreasObject log = GlobalVariable.catsAndAreas;
            Settings1.Default.IsLogedIn = "1";

            // سه گزینه زیر اینجا داده نمی شود و در بخش لاگین کاربر
            //GlobalVariable.activezonse = log.result2.active_regions;
            //GlobalVariable.portlimit = log.result2.max_users;
            //GlobalVariable.expirationdate = log.result2.expire_date;
            ////  GlobalVariable.token = log.token;

            //var sourceofApartment = new AutoCompleteStringCollection();
            //foreach (var item in log.result.apartment)
            //{

            //    sourceofApartment.Add(item);
            //}


            //apartment.AutoCompleteCustomSource = sourceofApartment;
            //apartment.AutoCompleteMode = AutoCompleteMode.Append;
            //apartment.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //apartment.MaxDropDownItems = 10;

            apartment.DisplayMember = "title";
            apartment.ValueMember = "ID";
            apartment.DataSource = new BindingSource(log.result.apartment, null);



            ashpazkhane.DisplayMember = "title";
            ashpazkhane.ValueMember = "ID";
            ashpazkhane.DataSource = new BindingSource(log.result.ashpazkhane, null);

            //var sourceofOffice = new AutoCompleteStringCollection();
            //foreach (var item in log.result.office)
            //{

            //    sourceofOffice.Add(item);
            //}

            //office.AutoCompleteCustomSource = sourceofOffice;
            //office.AutoCompleteMode = AutoCompleteMode.Append;
            //office.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //office.MaxDropDownItems = 10;

            office.DisplayMember = "title";
            office.ValueMember = "ID";
            office.DataSource = new BindingSource(log.result.office, null);


            //var sourceofKolangi = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kolangi)
            //{

            //    sourceofKolangi.Add(item);
            //}
            //kolangi.AutoCompleteCustomSource = sourceofKolangi;
            //kolangi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kolangi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kolangi.MaxDropDownItems = 10;
            kolangi.DisplayMember = "title";
            kolangi.ValueMember = "ID";
            kolangi.DataSource = new BindingSource(log.result.kolangi, null);

            //var sourceofVilla = new AutoCompleteStringCollection();
            //foreach (var item in log.result.villa)
            //{

            //    sourceofVilla.Add(item);
            //}
            //villa.AutoCompleteCustomSource = sourceofVilla;
            //villa.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //villa.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //villa.MaxDropDownItems = 10;

            villa.DisplayMember = "title";
            villa.ValueMember = "ID";
            villa.DataSource = new BindingSource(log.result.villa, null);



            //var sourceofMostaghelat = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mostaghellat)
            //{

            //    sourceofMostaghelat.Add(item);
            //}
            //mostaghellat.AutoCompleteCustomSource = sourceofMostaghelat;
            //mostaghellat.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mostaghellat.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mostaghellat.MaxDropDownItems = 10;
            mostaghellat.DisplayMember = "title";
            mostaghellat.ValueMember = "ID";
            mostaghellat.DataSource = new BindingSource(log.result.mostaghellat, null);




            //var sourceofSamt = new AutoCompleteStringCollection();
            //foreach (var item in log.result.samt)
            //{

            //    sourceofSamt.Add(item);
            //}
            //samt.AutoCompleteCustomSource = sourceofSamt;
            //samt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //samt.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //samt.MaxDropDownItems = 10;

            //samt.DataSource = log.result.samt;


            //var sourceofSenn = new AutoCompleteStringCollection();
            //foreach (var item in log.result.senn)
            //{

            //    sourceofSenn.Add(item);
            //}
            //senn.AutoCompleteCustomSource = sourceofSenn;
            //senn.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //senn.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //senn.MaxDropDownItems = 10;
            //  senn.DataSource = log.result.villa;


            //var sourceofMantaghe = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe)
            //{

            //    sourceofMantaghe.Add(item);
            //}
            //mantaghe.AutoCompleteCustomSource = sourceofMantaghe;
            //mantaghe.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe.MaxDropDownItems = 10;
            mantaghe_name.DisplayMember = "title";
            mantaghe_name.ValueMember = "ID";
            mantaghe_name.DataSource = new BindingSource(log.result.mantaghe, null);


            mantaghe_id.DisplayMember = "title";
            mantaghe_id.ValueMember = "ID";
            mantaghe_id.DataSource = new BindingSource(log.result.mantaghe_id, null);



            //var sourceofMantagheID = new AutoCompleteStringCollection();
            //foreach (var item in log.result.mantaghe_id)
            //{

            //    sourceofMantagheID.Add(item);
            //}
            //mantaghe_id.AutoCompleteCustomSource = sourceofMantagheID;
            //mantaghe_id.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //mantaghe_id.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //mantaghe_id.MaxDropDownItems = 10;
            //  m.DataSource = log.result.mantaghe_id;


            //var sourceofSeraydar = new AutoCompleteStringCollection();
            //foreach (var item in log.result.seraydar)
            //{

            //    sourceofSeraydar.Add(item);
            //}
            //seraydar.AutoCompleteCustomSource = sourceofSeraydar;
            //seraydar.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //seraydar.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //seraydar.MaxDropDownItems = 10;
            //  seraydar.DataSource = log.result.seraydar;


            //var sourceofKatType = new AutoCompleteStringCollection();
            //foreach (var item in log.result.kaf_type)
            //{

            //    sourceofKatType.Add(item);
            //}
            //kaf_type.AutoCompleteCustomSource = sourceofKatType;
            //kaf_type.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //kaf_type.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //kaf_type.MaxDropDownItems = 10;
            // kaf_type.DataSource = log.result.kaf_type;


            //var sourceofSarmayesh = new AutoCompleteStringCollection();
            //foreach (var item in log.result.garmayesh_sarmayesh)
            //{

            //    sourceofSarmayesh.Add(item);
            //}
            //garmayesh_sarmayesh.AutoCompleteCustomSource = sourceofSarmayesh;
            //garmayesh_sarmayesh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //garmayesh_sarmayesh.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //garmayesh_sarmayesh.MaxDropDownItems = 10;
            // garmayesh_sarmayesh.DataSource = log.result.garmayesh_sarmayesh;


            try
            {

            }
            catch (Exception)
            {

                MessageBox.Show("خطا در اتصال به سرور");
            }

        }

        private void label59_Click(object sender, EventArgs e)
        {
            getDataFromServer();
        }
        private void getDataFromServer()
        {

            BackgroundWorker getDataBackGroundWorker = new BackgroundWorker();
            getDataBackGroundWorker.WorkerSupportsCancellation = true;
            getDataBackGroundWorker.DoWork += new DoWorkEventHandler(getDataBackGroundWorker_do);
            getDataBackGroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(getDataBackGroundWorker_done);

            try
            {
                queryModel model = new queryModel()
                {

                };

                model.apartment = (apartment.SelectedValue == null) ? "" : apartment.SelectedValue.ToString();
                model.mantaghe_id = (mantaghe_id.SelectedValue == null) ? "" : mantaghe_id.SelectedValue.ToString();
                model.villa = (villa.SelectedValue == null) ? "" : villa.SelectedValue.ToString();
                model.kolangi = (kolangi.SelectedValue == null) ? "" : kolangi.SelectedValue.ToString();
                model.mostaghellat = (mostaghellat.SelectedValue == null) ? "" : mostaghellat.SelectedValue.ToString();
                model.office = (office.SelectedValue == null) ? "" : office.SelectedValue.ToString();
                model.nama = (nama.SelectedValue == null) ? "" : nama.SelectedValue.ToString();
                model.ashpazkhane = (ashpazkhane.SelectedValue == null) ? "" : ashpazkhane.SelectedValue.ToString();
                model.mantaghe_name = GlobalVariable.mantagheIDes;

                model.anbari = anbari.Checked ? "1" : "";
                model.asansor = asansor.Checked ? "1" : "";
                model.hasEstakhr = hasEstakhr.Checked ? "1" : "";
                model.hasJakoozi = hasJakoozi.Checked ? "1" : "";
                model.hasSauna = hasSauna.Checked ? "1" : "";
                model.isEjare = isEjare.Checked ? "1" : "";
                model.isForoosh = isForoosh.Checked ? "1" : "";
                model.isMoaveze = isMoaveze.Checked ? "1" : "";
                model.isMosharekat = isMosharekat.Checked ? "1" : "";
                model.isRahn = isRahn.Checked ? "1" : "";
                model.sell2khareji = sell2khareji.Checked ? "1" : "";
                model.seraydar = hasSeraydar.Checked ? "1" : "";
                model.hasGym = hasGym.Checked ? "1" : "";
                model.hasShooting = hasShooting.Checked ? "1" : "";
                model.hasHall = hasHall.Checked ? "1" : "";
                model.hasRoofGarden = hasRoofGarden.Checked ? "1" : "";
                model.isMoble = isMoble.Checked ? "1" : "";
                model.parking = parking.Checked ? "1" : "";
                model.labi = labi.Checked ? "1" : "";
                model.parking = parking.Checked ? "1" : "";

                model.address = address.Text;
                model.desc = desc.Text;
                model.tabaghe = tabaghe.Text;
                GlobalVariable.searchTabghe = tabaghe.Text;
                model.phones = phones.Text;
                model.malek = malek.Text;
                model.wc = wc.Text;


                model.zirbana_from = zirbana_from.Text;
                model.zirbana_to = zirbana_to.Text;
                model.senn_from = senn_from.Text;    
                model.senn_to = senn_to.Text;
                model.masahat_from = masahat_from.Text;
                model.masahat_to = masahat_to.Text;
                model.id_from = id_from.Text;
                model.id_to = id_to.Text;
                model.ID = ID.Text;
                model.tabaghe_from = tabaghe_from.Text;
                model.tabaghe_to = tabaghe_to.Text;
                model.rahn_from = rahn_from.Text;
                model.ejare_from = ejare_from.Text;
                model.rahn_to = rahn_to.Text;
                model.ejare_to = ejare_to.Text;
                model.metri_from = metri_from.Text;
                model.metri_to = metri_to.Text;
                model.total_price_from = total_price_from.Text;
                model.total_price_to = total_price_to.Text;
                model.date_from = date_from.Text;
                model.date_to = date_to.Text;
                model.bed_from = bed_from.Text;
                model.bed_to = bed_to.Text;
               


                string str = JsonConvert.SerializeObject(model);

                getDataBackGroundWorker.RunWorkerAsync(argument: str);
                refresh.Visible = true;
            }
            catch (Exception)
            {

                MessageBox.Show("فرم جستجو را کامل کنید ");
                return;
            }


        }
        private void getDataBackGroundWorker_done(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result == "error")
                {
                    refresh.Visible = false;
                }
                else
                {
                    GlobalVariable.fromwhere = "main";
                  
                    Form1 form1 = new Form1();
                    Control clt = form1.Controls.Find("panelOfFirstMessage", true).First();
                    clt.Visible = false;
                   
                    form1.Show();
                    this.Close();
                    refresh.Visible = false;
                    

                }
            }
            catch (Exception)
            {

                MessageBox.Show("موردی وجود ندارد");
                refresh.Visible = false;
            }



        }
        void getDataBackGroundWorker_do(object sender, DoWorkEventArgs e)
        {


            string query = (string)e.Argument;
            // فعلاً پورت 8001 باشه
            int port = 8002;
            if (GlobalVariable.port != 0)
            {
                port = GlobalVariable.port;
            }

            TcpClient tcpclnt = new TcpClient();

            string ip = Settings1.Default.ServerIP;
            if (GlobalVariable.serverIP != null)
            {
                ip = GlobalVariable.serverIP;
            }
            try
            {
                tcpclnt.Connect(ip, port);
            }
            catch (Exception)
            {

                MessageBox.Show("خطا در اتصال به سرور");
                e.Result = "error";
                tcpclnt.Close();
                return;
            }


            try
            {
                // use the ipaddress as in the server program
                Console.WriteLine("Connected with port" + port.ToString());
                //Console.Write("Enter the string to be transmitted : ");

                //String str = Console.ReadLine();

                Stream stm = tcpclnt.GetStream();
                Encoding utf8 = Encoding.UTF8;
                // ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = utf8.GetBytes(query);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);
                string json = "";

                const int blockSize = 30000000;
                byte[] buffer = new byte[blockSize];
                int bytesRead;
                stm.Read(buffer, 0, buffer.Length);
                json = utf8.GetString(buffer);
                //while ((bytesRead = stm.Read(buffer, 0, buffer.Length)) > 0)
                //{
                //    for (int i = 0; i < bytesRead; i++)
                //    {
                //        json = json + Convert.ToChar(buffer[i]);
                //    }
                //}



                GlobalVariable.result = json;



                tcpclnt.Close();


            }
            catch (Exception)
            {

                MessageBox.Show("خطا در ارتباط با سرور");

                tcpclnt.Close();
                return;
                e.Result = "error";
            }
        }



      
      
        private void mantagheNameText_TextChanged(object sender, EventArgs e)
        {
            List<Mantaghe> finallist = new List<Mantaghe>();

            if (mantagheNameText.Text.Length > 0)
            {
                deleteText.Visible = true;
                var srt = mantagheNameText.Text;
                int index = mantagheNameText.Text.LastIndexOf(",");
                if (index != -1)
                {
                    srt = srt.Remove(0, index+1);
                }

                if (srt != "")
                {
                    finallist = (from p in log.result.mantaghe
                                 where p.title.StartsWith(srt)
                                 select p).ToList();
                    mantaghe_name.DataSource = finallist;
                    paneloflist.Visible = true;
                    
                }
                else
                {
                    mantaghe_name.DataSource = log.result.mantaghe;
                    paneloflist.Visible = true;
                   
                }
                
            }
            else
            {
                deleteText.Visible = false;
                mantaghe_name.DataSource = log.result.mantaghe;
                paneloflist.Visible = true;
                
            }
        }


      
        private void mantagheNameText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                mantaghe_name.Focus();
            }
            if (e.KeyCode == Keys.Enter)
            {

                string srt2 = mantaghe_name.Text;
                var srt = mantagheNameText.Text;
                int index = mantagheNameText.Text.LastIndexOf(",");
                
                if (index != -1)
                {
                    srt = srt.Remove(index+1, mantagheNameText.Text.Length - index - 1);
                    mantagheNameText.Text = srt + srt2 + ",";
                    setIndexForMantaghe();
                    paneloflist.Visible = false;
                }

                else
                {
                    mantagheNameText.Text =  srt2 + ",";
                    paneloflist.Visible = false;
                    setIndexForMantaghe();
                }
               
               
                //enter key is down
            }
        }

        private void mantaghe_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                string srt2 = mantaghe_name.Text;
                var srt = mantagheNameText.Text;
                int index = mantagheNameText.Text.LastIndexOf(",");

                if (index != -1)
                {
                    srt = srt.Remove(index + 1, mantagheNameText.Text.Length - index - 1);
                    mantagheNameText.Text = srt + srt2 + ",";
                    paneloflist.Visible = false;
                    setIndexForMantaghe();
                }

                else
                {
                    mantagheNameText.Text = srt2 + ",";
                    paneloflist.Visible = false;
                    setIndexForMantaghe();
                }


                //enter key is down
            }

        }
        public void setIndexForMantaghe() {
            string text = mantagheNameText.Text;
            text = text.Remove(text.Length - 1);
            List<string> list = text.Split(',').ToList();
            string final = ",";
            foreach (var item in list)
            {
                string value = (from p in log.result.mantaghe
                               where p.title == item
                               select p.ID).First();
                final = final + value + ",";
                GlobalVariable.mantagheIDes = final;
            }
        }

        private void deleteText_Click(object sender, EventArgs e)
        {
            mantagheNameText.Text = "";
        }

        private void mantaghe_name_Leave(object sender, EventArgs e)
        {
            paneloflist.Visible = false;
        }

        private void mantagheNameText_Click(object sender, EventArgs e)
        {
            if (paneloflist.Visible == false)
            {
                paneloflist.Visible = true;
            }
            else
	        {
                paneloflist.Visible = false;
	        }
        }

        private void radPanel28_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel18_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void total_price_from_Leave(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            textbox.Text = string.Format("{0:#,##0}", double.Parse(textbox.Text));
        }



    }
}
