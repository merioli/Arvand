﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using System.Reflection;

namespace realstate
{
    public partial class Form6 : Form
    {
        ListOfAdds.Datum obj = new ListOfAdds.Datum();
        CatsAndAreasObject CATS = null;
        public Form6()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
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

       
        public string SetDropDownValue(string value , string collection) {
            string final = "";
            if (value == "0")
            {
                return "-";
            }
            if (!value.All(char.IsDigit))
            {
                final = value;
            }

            else if (value.Contains(","))
            {

                string srt = value.Remove(value.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        switch (collection)
                        {
                            case "apartment" :
                                final = final + (from q in CATS.result.apartment
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "villa":
                                final = final + (from q in CATS.result.villa
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "office":
                                final = final + (from q in CATS.result.office
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "mostaghellat":
                                final = final + (from q in CATS.result.mostaghellat
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "kolangi":
                                final = final + (from q in CATS.result.kolangi
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "samt":
                                final = final + (from q in CATS.result.samt
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "senn":
                                final = final + (from q in CATS.result.senn
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "sanad":
                                final = final + (from q in CATS.result.sanad
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "seraydar":
                                final = final + (from q in CATS.result.seraydar
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "mantaghe_id":
                                final = final + (from q in CATS.result.mantaghe_id
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "mantaghe":
                                final = final + (from q in CATS.result.mantaghe
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "kaf_type":
                                final = final + (from q in CATS.result.kaf_type
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "garmayesh_sarmayesh":
                                final = final + (from q in CATS.result.garmayesh_sarmayesh
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "ashpazkhane1":
                                final = final + (from q in CATS.result.ashpazkhane
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "ashpazkhane2":
                                final = final + (from q in CATS.result.ashpazkhane
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                            case "ashpazkhane3":
                                final = final + (from q in CATS.result.ashpazkhane
                                                 where q.ID == itemm
                                                 select q.title).First() + ",";
                                break;
                          
                        }
                        
                    }
                }
                

                final = final.Remove(final.Length - 1, 1);
              

            }
            else
            {
                switch (collection)
                {
                    case "apartment":
                        final = (from q in CATS.result.apartment
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "villa":
                        final = (from q in CATS.result.villa
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "office":
                        final = (from q in CATS.result.office
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "mostaghellat":
                        final = (from q in CATS.result.mostaghellat
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "kolangi":
                        final = (from q in CATS.result.kolangi
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "samt":
                        final = (from q in CATS.result.samt
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "senn":
                        final = (from q in CATS.result.senn
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "sanad":
                        final = (from q in CATS.result.sanad
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "seraydar":
                        final = (from q in CATS.result.seraydar
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "mantaghe_id":
                        final = (from q in CATS.result.mantaghe_id  
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "mantaghe":
                        final = (from q in CATS.result.mantaghe
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "kaf_type":
                        final = (from q in CATS.result.kaf_type
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "garmayesh_sarmayesh":
                        final = (from q in CATS.result.garmayesh_sarmayesh
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "ashpazkhane1":
                        final = (from q in CATS.result.ashpazkhane
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "ashpazkhane2":
                        final = (from q in CATS.result.ashpazkhane
                                 where q.ID == value
                                 select q.title).First();
                        break;
                    case "ashpazkhane3":
                        final = (from q in CATS.result.ashpazkhane
                                         where q.ID == value
                                         select q.title).First() ;
                        break;

                }
            }
             
            return final;

        }
        public void InitControl()
        {
            if (GlobalVariable.isadmin == "1")
            {
                CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
               
            }
            else
            {
              CATS=   GlobalVariable.catsAndAreas;
              
            }

            title.Text = obj.title;
            //phone
            owner.Text = obj.malek;
            address.Text = obj.address;
            date_updated.Text = obj.date_updated;
            ID.Text = obj.ID;
            total_vahed.Text = obj.total_vahed;
            total_floor.Text = obj.total_floor;
            vahed_per_floor.Text = obj.vahed_per_floor;
            zirbana1.Text = obj.zirbana1;
            zirbana2.Text = obj.zirbana2;
            zirbana3.Text = obj.zirbana3;
            khab1.Text = obj.bed1;
            khab2.Text = obj.bed2;
            khab3.Text = obj.bed3;
            tabaghe1.Text = obj.tabaghe1;
            tabaghe2.Text = obj.tabaghe2;
            tabaghe3.Text = obj.tabaghe3;
            tabaghe_1_rahn.Text = obj.tabaghe_1_rahn;
            tabaghe_2_rahn.Text = obj.tabaghe_2_rahn;
            tabaghe_3_rahn.Text = obj.tabaghe_3_rahn;
            tabaghe_1_ejare.Text = obj.tabaghe_1_ejare;
            tabaghe_2_ejare.Text = obj.tabaghe_2_ejare;
            tabaghe_3_ejare.Text = obj.tabaghe_3_ejare;
            tabaghe_1_total_price.Text = obj.tabaghe_1_total_price;
            tabaghe_2_total_price.Text = obj.tabaghe_2_total_price;
            tabaghe_3_total_price.Text = obj.tabaghe_3_total_price;
            tabaghe_3_metri.Text = obj.tabaghe_1_metri;
            tabaghe_2_metri.Text = obj.tabaghe_2_metri;
            tabaghe_3_metri.Text = obj.tabaghe_3_metri;
            tarakom.Text = obj.tarakom;
            toole_bar.Text = obj.toole_bar;
            masahat_zamin.Text = obj.masahat_zamin;
            ertefa.Text = obj.ertefa;
            eslahi.Text = obj.eslahi;
            zirzamin.Text = obj.zirzamin;
            desc.Text = obj.desc;
            if (obj.isForoosh == "1")
            {
                isForoosh.Checked = true;
            }
            if (obj.isEjare == "1")
            {
                isEjare.Checked = true;
            }
            if (obj.isRahn == "1")
            {
                isRahn.Checked = true;
            }
            if (obj.isMosharekat == "1")
            {
                isMosharekat.Checked = true;
            }
            if (obj.isMoaveze == "1")
            {
                isMoaveze.Checked = true;
            }
            if (obj.sell2khareji == "1")
            {
                sell2khareji.Checked = true;
            }
            if (obj.maghaze == "1")
            {
                maghaze.Checked = true;
            }
            if (obj.hasEstakhr == "1")
            {
                hasEstakhr.Checked = true;
            }
            if (obj.hasJakoozi == "1")
            {
                hasJakoozi.Checked = true;
            }
            if (obj.hasSauna == "1")
            {
                hasSauna.Checked = true;
            }
            if (obj.takhlie == "1")
            {
                takhlie.Checked = true;
            }
            if (obj.balkon1 == "1")
            {
                balkon1.Checked = true;
            }
            if (obj.balkon2 == "1")
            {
                balkon2.Checked = true;
            }
            if (obj.balkon3 == "1")
            {
                balkon3.Checked = true;
            }

            if (obj.parking1 == "1")
            {
                parking1.Checked = true;
            }
            if (obj.parking2 == "1")
            {
                parking2.Checked = true;
            }
            if (obj.parking3 == "1")
            {
                parking3.Checked = true;
            }

            if (obj.anbari1 == "1")
            {
                anbari1.Checked = true;
            }
            if (obj.anbari2 == "1")
            {
                anbari2.Checked = true;
            }
            if (obj.anbari3 == "1")
            {
                anbari3.Checked = true;
            }
            if (obj.asansor1 == "1")
            {
                asansor1.Checked = true;
            }
            if (obj.asansor2 == "1")
            {
                asansor2.Checked = true;
            }
            if (obj.asansor3 == "1")
            {
                asansor3.Checked = true;
            }

            if (obj.hasGym == "1")
            {
                hasGym.Checked = true;
            }
            if (obj.hasShooting == "1")
            {
                hasShooting.Checked = true;
            }
            if (obj.hasHall == "1")
            {
                hasHall.Checked = true;
            }
            if (obj.hasRoofGarden == "1")
            {
                hasRoofGarden.Checked = true;
            }
            if (obj.isMoble == "1")
            {
                isMoble.Checked = true;
            }
            if (obj.hasLobbyMan == "1")
            {
                hasLobbyMan.Checked = true;
            }

            mantaghe_id.Text = SetDropDownValue(obj.mantaghe_id, "mantaghe_id");

            mantaghe_name.Text = SetDropDownValue(obj.mantaghe_name, "mantaghe");


            apartment.Text = SetDropDownValue(obj.apartment, "apartment");

            office.Text = SetDropDownValue(obj.office, "office");

            villa.Text = SetDropDownValue(obj.villa, "villa");

            mostaghellat.Text = SetDropDownValue(obj.mostaghellat, "mostaghellat");


            kolangi.Text = SetDropDownValue(obj.kolangi, "kolangi");

            seraydar.Text = SetDropDownValue(obj.seraydar, "seraydar");

            kaf_type.Text = SetDropDownValue(obj.kaf_type, "kaf_type");

            garmayesh_sarmayesh.Text = SetDropDownValue(obj.garmayesh_sarmayesh, "garmayesh_sarmayesh");
            ashpazkhane1.Text = SetDropDownValue(obj.ashpazkhane1, "ashpazkhane");
            ashpazkhane2.Text = SetDropDownValue(obj.ashpazkhane2, "ashpazkhane");
            ashpazkhane3.Text = SetDropDownValue(obj.ashpazkhane3, "ashpazkhane");

            senn.Text = SetDropDownValue(obj.senn, "senn");

            samt.Text = SetDropDownValue(obj.samt, "samt");

            sanad.Text =SetDropDownValue( obj.sanad ,"sanad");







        }
        private void Form6_Load(object sender, EventArgs e)
        {
            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);
           
            if (GlobalVariable.isadmin == "1")
            {
                CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            }
            else
            {
                CATS = GlobalVariable.catsAndAreas;
            }

            if (GlobalVariable.fromwhere6 == "main")
            {
                delete.Visible = false;
                deletepanel.Visible = false;
            }
            
           
            this.MinimizeBox = false;
            this.MaximizeBox = false;
           

          

            la12.Font = GlobalVariable.headerlistFONTsmall;
            la13.Font = GlobalVariable.headerlistFONTsmall;
            la16.Font = GlobalVariable.headerlistFONTsmall;
            la17.Font = GlobalVariable.headerlistFONTsmall;
            la18.Font = GlobalVariable.headerlistFONTsmall;
            la19.Font = GlobalVariable.headerlistFONTsmall;
            la09.Font = GlobalVariable.headerlistFONTsmall;
            la20.Font = GlobalVariable.headerlistFONTsmall;
            la21.Font = GlobalVariable.headerlistFONTsmall;
            la22.Font = GlobalVariable.headerlistFONTsmall;


            if (GlobalVariable.selectedOwnObject != null)
            {
                 obj = GlobalVariable.selectedOwnObject;

                InitControl();
            }
            else
            {
                if (GlobalVariable.isadmin == "1")
                {
                   
                    setcat();

                }
                else
                {
                   
                    setcatforclient();

                }
            }
           
            try
            {
               
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void confirm_MouseHover(object sender, EventArgs e)
        {

        }

        private void confirm_MouseEnter(object sender, EventArgs e)
        {

        }

        private void confirm_MouseLeave(object sender, EventArgs e)
        {

        }
       
        private void confirm_Click(object sender, EventArgs e)
        {
            

            if (title.Text != "")
            {
                string filepath = Path.Combine(Application.StartupPath, "Resources", "objects.txt");
                string allobject = System.IO.File.ReadAllText(filepath);
                List<ListOfAdds.Datum> list = new List<ListOfAdds.Datum>();
                List<ListOfAdds.Datum> list2 = new List<ListOfAdds.Datum>();
                ListOfAdds.Datum obj = new ListOfAdds.Datum();
                try
                {
                    list2 = JsonConvert.DeserializeObject<List<ListOfAdds.Datum>>(allobject);

                }
                catch (Exception)
                {
                    obj = JsonConvert.DeserializeObject<ListOfAdds.Datum>(allobject);
                }

                if (list2 != null)
                {
                    foreach (var item in list2)
                    {
                        list.Add(item);
                    }
                }
                if (obj.title != null)
                {
                    list.Add(obj);
                }
                string id = "";
                if (ID.Text != "")
                {
                    

                     id = ID.Text;
                    list.RemoveAll(p => p.ID == id);
                   
                   
                }
                else
                {
                    id = RandomString(10);
                }

                List<string> PHNS = new List<string>();
                PHNS.Add(phone1.Text);
                PHNS.Add(phone2.Text);
                PHNS.Add(phone3.Text);
                PHNS.Add(phone4.Text);

                 
                ListOfAdds.Datum model = new ListOfAdds.Datum()
                {
                    
                    address = address.Text,

                    anbari1 = anbari1.Checked ? "1" : "0",
                    anbari2 = anbari2.Checked ? "1" : "0",
                    anbari3 = anbari3.Checked ? "1" : "0",
                    apartment = apartment.Text,
                    asansor1 = asansor1.Checked ? "1" : "0",
                    asansor2 = asansor2.Checked ? "1" : "0",
                    asansor3 = asansor3.Checked ? "1" : "0",
                    ashpazkhane1 = ashpazkhane1.Text,
                    ashpazkhane2 = ashpazkhane2.Text,
                    ashpazkhane3 = ashpazkhane3.Text,

                    garmayesh_sarmayesh = garmayesh_sarmayesh.Text,

                    desc = desc.Text,
                    ertefa = ertefa.Text,
                    eslahi = eslahi.Text,
                    hasEstakhr = hasEstakhr.Checked ? "1" : "0",
                    hasJakoozi = hasJakoozi.Checked ? "1" : "0",
                    hasSauna = hasSauna.Checked ? "1" : "0",
                    ID = id,
                    isEjare = isEjare.Checked ? "1" : "0",
                    isForoosh = isForoosh.Checked ? "1" : "0",
                    isMoaveze = isMoaveze.Checked ? "1" : "0",
                    isMosharekat = isMosharekat.Checked ? "1" : "0",
                    isRahn = isRahn.Checked ? "1" : "0",
                    kaf_type = kaf_type.Text,
                    kolangi = kolangi.Text,
                    maghaze = maghaze.Checked ? "1" : "0",
                    malek = owner.Text,
                    mantaghe_id = mantaghe_id.Text,
                    mantaghe_name = mantaghe_name.Text,
                    masahat_zamin = masahat_zamin.Text,
                    mostaghellat = mostaghellat.Text,
                    office = office.Text,
                    phones = PHNS,
                    samt = samt.Text,
                    sell2khareji = sell2khareji.Checked ? "1" : "0",
                    senn = senn.Text,
                    seraydar = seraydar.Text,
                    suit = suit.Checked ? "1" : "0",

                    tabaghe_1_ejare = tabaghe_1_ejare.Text,
                    tabaghe_1_metri = tabaghe_1_metri.Text,
                    tabaghe_1_rahn = tabaghe_1_rahn.Text,
                    tabaghe_1_total_price = tabaghe_1_total_price.Text,

                    tabaghe_2_ejare = tabaghe_2_ejare.Text,
                    tabaghe_2_metri = tabaghe_2_metri.Text,
                    tabaghe_2_rahn = tabaghe_2_rahn.Text,
                    tabaghe_2_total_price = tabaghe_2_total_price.Text,
                    tabaghe_3_ejare = tabaghe_3_ejare.Text,
                    tabaghe_3_metri = tabaghe_3_metri.Text,
                    tabaghe_3_rahn = tabaghe_3_rahn.Text,
                    tabaghe_3_total_price = tabaghe_3_total_price.Text,

                    takhlie = takhlie.Checked ? "1" : "0",
                    tarakom = tarakom.Text,
                    title = title.Text,
                    toole_bar = toole_bar.Text,
                    total_floor = total_floor.Text,
                    total_vahed = total_vahed.Text,
                    villa = villa.Text,
                    zirzamin = zirzamin.Text,
                    tabaghe1 = tabaghe1.Text,
                    tabaghe2 = tabaghe2.Text,
                    tabaghe3 = tabaghe3.Text,
                    balkon1 = balkon1.Text,
                    balkon2 = balkon2.Text,
                    balkon3 = balkon3.Text,
                    bed1 = khab1.Text,
                    bed2 = khab2.Text,
                    bed3 = khab3.Text,
                     date_updated = date_updated.Text,
                    hasGym = hasGym.Checked ? "1" : "0",
                    hasHall = hasHall.Checked ? "1" :  "0",
                    hasLobbyMan = hasLobbyMan.Checked ? "1" : "0",
                    hasRoofGarden = hasRoofGarden.Checked ? "1" : "0",
                    hasShooting = hasShooting.Checked ? "1" : "0",
                    isMoble = isMoble.Checked ? "1" : "0",
                     parking1 = parking1.Text,
                      parking2 = parking2.Text,
                      parking3= parking3.Text,
                      sanad = sanad.Text,
                        zirbana1 = zirbana1.Text,
                         zirbana2 = zirbana2.Text,
                          zirbana3 = zirbana3.Text
                           


                     
                     



                };
                list.Add(model);
              
                string jsonmodel = JsonConvert.SerializeObject(list);
                try
                {
                    string path = Path.Combine(Application.StartupPath, "Resources", "objects.txt");
                    System.IO.File.WriteAllText(path, jsonmodel);
                    MessageBox.Show("تغییرات مورد نظر با موفقیت انجام شد");
                    this.Dispose();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                MessageBox.Show("عنوان فایل وجود ندارد");
            }




        }
       

        private void label14_Click(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Application.StartupPath, "Resources", "objects.txt");
            string allobject = System.IO.File.ReadAllText(filepath);
            List<ListOfAdds.Datum> list = new List<ListOfAdds.Datum>();
            List<ListOfAdds.Datum> list2 = new List<ListOfAdds.Datum>();
            try
            {
                list2 = JsonConvert.DeserializeObject<List<ListOfAdds.Datum>>(allobject);

            }
            catch
            {
            }
            if (list2 != null)
            {
                foreach (var item in list2)
                {
                    list.Add(item);
                }
            }



           
          
            string id = ID.Text;
            list.RemoveAll(p => p.ID == id);
            string jsonmodel = JsonConvert.SerializeObject(list);
            try
            {
                string path = Path.Combine(Application.StartupPath, "Resources", "objects.txt");
                System.IO.File.WriteAllText(path, jsonmodel);

            }
            catch (Exception)
            {

            }
            MessageBox.Show("فایل مورد نظر با موفقیت حذف شد");
            this.Dispose();
        }

        private void radPanel52_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel55_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel64_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel72_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel71_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel63_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel54_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel70_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel62_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel53_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void telephone2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel61_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel69_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel68_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel60_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel51_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel50_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel59_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel76_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radPanel75_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

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


            ashpazkhane1.DisplayMember = "title";
            ashpazkhane1.ValueMember = "ID";
            ashpazkhane1.DataSource = new BindingSource(log.result.ashpazkhane, null);
            ashpazkhane2.DisplayMember = "title";
            ashpazkhane2.ValueMember = "ID";
            ashpazkhane2.DataSource = new BindingSource(log.result.ashpazkhane, null);
            ashpazkhane3.DisplayMember = "title";
            ashpazkhane3.ValueMember = "ID";
            ashpazkhane3.DataSource = new BindingSource(log.result.ashpazkhane, null);

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


            samt.DisplayMember = "title";
            samt.ValueMember = "ID";
            samt.DataSource = new BindingSource(log.result.samt, null);
            senn.DisplayMember = "title";
            senn.ValueMember = "ID";
            senn.DataSource = new BindingSource(log.result.senn, null);

            seraydar.DisplayMember = "title";
            seraydar.ValueMember = "ID";
            seraydar.DataSource = new BindingSource(log.result.seraydar, null);

            kaf_type.DisplayMember = "title";
            kaf_type.ValueMember = "ID";
            kaf_type.DataSource = new BindingSource(log.result.kaf_type, null);


            garmayesh_sarmayesh.DisplayMember = "title";
            garmayesh_sarmayesh.ValueMember = "ID";
            garmayesh_sarmayesh.DataSource = new BindingSource(log.result.garmayesh_sarmayesh, null);
            

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



            ashpazkhane1.DisplayMember = "title";
            ashpazkhane1.ValueMember = "ID";
            ashpazkhane1.DataSource = new BindingSource(log.result.ashpazkhane, null);
            ashpazkhane2.DisplayMember = "title";
            ashpazkhane2.ValueMember = "ID";
            ashpazkhane2.DataSource = new BindingSource(log.result.ashpazkhane, null);
            ashpazkhane3.DisplayMember = "title";
            ashpazkhane3.ValueMember = "ID";
            ashpazkhane3.DataSource = new BindingSource(log.result.ashpazkhane, null);

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


            samt.DisplayMember = "title";
            samt.ValueMember = "ID";
            samt.DataSource = new BindingSource(log.result.samt, null);
            senn.DisplayMember = "title";
            senn.ValueMember = "ID";
            senn.DataSource = new BindingSource(log.result.senn, null);


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



            seraydar.DisplayMember = "title";
            seraydar.ValueMember = "ID";
            seraydar.DataSource = new BindingSource(log.result.seraydar, null);

            kaf_type.DisplayMember = "title";
            kaf_type.ValueMember = "ID";
            kaf_type.DataSource = new BindingSource(log.result.kaf_type, null);


            garmayesh_sarmayesh.DisplayMember = "title";
            garmayesh_sarmayesh.ValueMember = "ID";
            garmayesh_sarmayesh.DataSource = new BindingSource(log.result.garmayesh_sarmayesh, null);

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






    }
}
