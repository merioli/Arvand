using Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

//class OvalPictureBox : PictureBox
//{
//    public OvalPictureBox()
//    {
//        this.BackColor = Color.DarkGray;
//    }
//    protected override void OnResize(EventArgs e)
//    {
//        base.OnResize(e);
//        using (var gp = new GraphicsPath())
//        {
//            gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
//            this.Region = new Region(gp);
//        }
//    }
//}
namespace realstate
{
    public partial class Form2 : Form
    {
        ListOfAdds.Datum obj = new ListOfAdds.Datum();
        // List<string> checkBoxList = new List<string>() { "sanad", "samt", "senn", "ashpazkhane3", "ashpazkhane2", "ashpazkhane1", "seraydar", "kaf_type", "garmayesh_sarmayesh", "apartment"
        //, "villa", "mostaghellat", "kolangi", "office", "mantaghe_name", "mantaghe_id" };
        CatsAndAreasObject CATS = null;
        CatsAndAreasObject cats2 = new CatsAndAreasObject();


        private Dictionary<string, string> fileData = new Dictionary<string, string>();

        public string getChangedValue(string value)
        {
            string final = "";
            if (value == "-1")
            {
                final = "توافقی";

            }
            else if (value == "-2")
            {
                final = "رایگان";
            }
            else
            {
                final = string.Format(CultureInfo.InvariantCulture, "{0:#,##0}", Convert.ToInt64(value));
            }
            return final;
        }
        public void InitControlAuto()
        {
            if (GlobalVariable.isadmin == "1")
            {
                CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            }
            try
            {

                foreach (var item in GlobalVariable.controllist)
                {

                    string name = item.Name;
                    string valueofProperty = "";
                    try
                    {
                        //valueofProperty= fileData[name];

                        Type type = obj.GetType();
                        PropertyInfo[] properties = type.GetProperties();
                        //valueofProperty = (from p in properties
                        //                   where p.Name == name
                        //                   select p.GetValue(obj, null).ToString()).First();

                        foreach (var foreachItem in properties)
                        {
                            if (foreachItem.Name == name)
                            {
                                valueofProperty = foreachItem.GetValue(obj, null).ToString();
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }


                    if (name == "phone1" || name == "phone2" || name == "phone2")
                    {

                    }
                    else if (item is CheckBox)
                    {
                        CheckBox cb = (CheckBox)item;
                        cb.Checked = valueofProperty == "0" ? false : true;
                    }
                    //else if (item is ComboBox)
                    //{
                    //    if (valueofProperty != "0")
                    //    {
                    //        switch (name)
                    //        {

                    //            case "sanad":
                    //                item.Text = (from q in CATS.result.sanad
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "samt":
                    //                item.Text = (from q in CATS.result.samt
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "senn":
                    //                item.Text = (from q in CATS.result.senn
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "ashpazkhane3":
                    //                if (valueofProperty.Length > 0)
                    //                {
                    //                    string final = "";
                    //                    string srt = valueofProperty.Remove(valueofProperty.Length - 1, 1);
                    //                    srt = srt.Remove(0, 1);

                    //                    if (srt.Contains(','))
                    //                    {
                    //                        List<string> lstsg3 = srt.Split(',').ToList();
                    //                        foreach (var itemm in lstsg3)
                    //                        {
                    //                            final = final + (from q in CATS.result.ashpazkhane
                    //                                             where q.ID == itemm
                    //                                             select q.title).First() + ",";
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        final = (from q in CATS.result.ashpazkhane
                    //                                 where q.ID == srt
                    //                                 select q.title).First();
                    //                    }

                    //                    item.Text = final;

                    //                }

                    //                break;
                    //            case "ashpazkhane2":
                    //                if (valueofProperty.Length > 0)
                    //                {
                    //                    string final = "";
                    //                    string srt = valueofProperty.Remove(valueofProperty.Length - 1, 1);
                    //                    srt = srt.Remove(0, 1);

                    //                    if (srt.Contains(','))
                    //                    {
                    //                        List<string> lstsg3 = srt.Split(',').ToList();
                    //                        foreach (var itemm in lstsg3)
                    //                        {
                    //                            final = final + (from q in CATS.result.ashpazkhane
                    //                                             where q.ID == itemm
                    //                                             select q.title).First() + ",";
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        final = (from q in CATS.result.ashpazkhane
                    //                                 where q.ID == srt
                    //                                 select q.title).First();
                    //                    }

                    //                    item.Text = final;
                    //                }
                    //                break;
                    //            case "ashpazkhane1":
                    //                if (valueofProperty.Length > 0)
                    //                {
                    //                    string final = "";
                    //                    string srt = valueofProperty.Remove(valueofProperty.Length - 1, 1);
                    //                    srt = srt.Remove(0, 1);

                    //                    if (srt.Contains(','))
                    //                    {
                    //                        List<string> lstsg3 = srt.Split(',').ToList();
                    //                        foreach (var itemm in lstsg3)
                    //                        {
                    //                            final = final + (from q in CATS.result.ashpazkhane
                    //                                             where q.ID == itemm
                    //                                             select q.title).First() + ",";
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        final = (from q in CATS.result.ashpazkhane
                    //                                 where q.ID == srt
                    //                                 select q.title).First();
                    //                    }

                    //                    item.Text = final;
                    //                }
                    //                break;
                    //            case "seraydar":
                    //                item.Text = (from q in CATS.result.seraydar
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "kaf_type":
                    //                item.Text = (from q in CATS.result.kaf_type
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "garmayesh_sarmayesh":
                    //                if (valueofProperty.Length > 0)
                    //                {
                    //                    string final = "";
                    //                    string srt = valueofProperty.Remove(valueofProperty.Length - 1, 1);
                    //                    srt = srt.Remove(0, 1);

                    //                    if (srt.Contains(','))
                    //                    {
                    //                        List<string> lstsg3 = srt.Split(',').ToList();
                    //                        foreach (var itemm in lstsg3)
                    //                        {
                    //                            final = final + (from q in CATS.result.garmayesh_sarmayesh
                    //                                             where q.ID == itemm
                    //                                             select q.title).First() + ",";
                    //                        }
                    //                    }
                    //                    else
                    //                    {
                    //                        final = (from q in CATS.result.garmayesh_sarmayesh
                    //                                 where q.ID == srt
                    //                                 select q.title).First();
                    //                    }

                    //                    item.Text = final;
                    //                }

                    //                break;
                    //            case "apartment":
                    //                item.Text = (from q in CATS.result.apartment
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "villa":
                    //                item.Text = (from q in CATS.result.villa
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "mostaghellat":
                    //                item.Text = (from q in CATS.result.mostaghellat
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "kolangi":
                    //                item.Text = (from q in CATS.result.kolangi
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "office":
                    //                item.Text = (from q in CATS.result.office
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "mantaghe_name":
                    //                item.Text = (from q in CATS.result.mantaghe
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;
                    //            case "mantaghe_id":
                    //                item.Text = (from q in CATS.result.mantaghe_id
                    //                             where q.ID == valueofProperty
                    //                             select q.title).First();
                    //                break;


                    //        }
                    //    }
                    //    else
                    //    {
                    //        item.Text = "-";
                    //    }



                    //}
                    else
                    {
                        item.Text = valueofProperty;
                    }
                }

            }
            catch (Exception)
            {


            }

        }
        public void InitControl()
        {
            if (GlobalVariable.isadmin == "1")
            {
                CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            }

            title.Text = obj.title;
            phone1.Text = obj.phones[0];
            phone2.Text = obj.phones[1];
            phone3.Text = obj.phones[2];

            owner.Text = obj.malek;
            address.Text = obj.address;
            date_created.Text = obj.date_updated;
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
            tabaghe_1_rahn.Text = getChangedValue(obj.tabaghe_1_rahn);
            tabaghe_2_rahn.Text =getChangedValue( obj.tabaghe_2_rahn);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_rahn));
            tabaghe_3_rahn.Text = getChangedValue(obj.tabaghe_3_rahn);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_rahn));
            tabaghe_1_ejare.Text = getChangedValue(obj.tabaghe_1_ejare);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_1_ejare));
            tabaghe_2_ejare.Text = getChangedValue(obj.tabaghe_2_ejare);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_ejare));
            tabaghe_3_ejare.Text = getChangedValue(obj.tabaghe_3_ejare);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_ejare));
            tabaghe_1_total_price.Text = getChangedValue(obj.tabaghe_1_total_price );//== "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_1_total_price));
            tabaghe_2_total_price.Text = getChangedValue(obj.tabaghe_2_total_price);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_2_total_price));
            tabaghe_3_total_price.Text =getChangedValue( obj.tabaghe_3_total_price);// == "-2" ? "رایگان" : string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64(obj.tabaghe_3_total_price));
            tabaghe_1_metri.Text =getChangedValue(obj.tabaghe_1_metri);// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tabaghe_2_metri.Text =getChangedValue(obj.tabaghe_2_metri);// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
            tabaghe_3_metri.Text = getChangedValue(obj.tabaghe_3_metri);// string.Format(CultureInfo.InvariantCulture, "{0:0,0}", Convert.ToInt64();
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

            mantaghe_id.Text = obj.mantaghe_id == "0" ? "-" : (from q in CATS.result.mantaghe_id
                                                               where q.ID == obj.mantaghe_id
                                                               select q.title).First();

            mantaghe_name.Text = obj.mantaghe_name == "0" ? "-" : (from q in CATS.result.mantaghe
                                                                   where q.ID == obj.mantaghe_name
                                                                   select q.title).First();


            apartment.Text = obj.apartment == "0" ? "-" : (from q in CATS.result.apartment
                                                           where q.ID == obj.apartment
                                                           select q.title).First();

            office.Text = obj.office == "0" ? "-" : (from q in CATS.result.office
                                                     where q.ID == obj.office
                                                     select q.title).First();

            villa.Text = obj.villa == "0" ? "-" : (from q in CATS.result.villa
                                                   where q.ID == obj.villa
                                                   select q.title).First();

            mostaghellat.Text = obj.mostaghellat == "0" ? "-" : (from q in CATS.result.mostaghellat
                                                                 where q.ID == obj.mostaghellat
                                                                 select q.title).First();


            kolangi.Text = obj.kolangi == "0" ? "-" : (from q in CATS.result.kolangi
                                                       where q.ID == obj.kolangi
                                                       select q.title).First();

            seraydar.Text = obj.seraydar == "0" ? "-" : (from q in CATS.result.seraydar
                                                         where q.ID == obj.seraydar
                                                         select q.title).First();

            kaf_type.Text = obj.kaf_type == "0" ? "-" : (from q in CATS.result.kaf_type
                                                         where q.ID == obj.kaf_type
                                                         select q.title).First();

            if (obj.garmayesh_sarmayesh.Length > 1)
            {
                string final = "";
                string srt = obj.garmayesh_sarmayesh.Remove(obj.garmayesh_sarmayesh.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.result.garmayesh_sarmayesh
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.result.garmayesh_sarmayesh
                             where q.ID == srt
                             select q.title).First();
                }

                final = final.Remove(final.Length - 1, 1);
                garmayesh_sarmayesh.Text = final;

            }
            else if (obj.garmayesh_sarmayesh.Length == 1)
            {

                if (obj.garmayesh_sarmayesh == "0")
                {
                    garmayesh_sarmayesh.Text = "-";
                }
                else
                {
                    garmayesh_sarmayesh.Text = (from q in CATS.result.garmayesh_sarmayesh
                                                where q.ID == obj.garmayesh_sarmayesh
                                                select q.title).First();
                }

            }
            else
            {
                garmayesh_sarmayesh.Text = "-";
            }

            if (obj.ashpazkhane1.Length > 1)
            {
                string final = "";
                string srt = obj.ashpazkhane1.Remove(obj.ashpazkhane1.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.result.ashpazkhane
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.result.ashpazkhane
                             where q.ID == srt
                             select q.title).First();
                }
                final = final.Remove(final.Length - 1, 1);
                ashpazkhane1.Text = final;

            }
            else if (obj.ashpazkhane1.Length == 1)
            {

                if (obj.ashpazkhane1 == "0")
                {
                    ashpazkhane1.Text = "-";
                }
                else
                {
                    ashpazkhane1.Text = (from q in CATS.result.ashpazkhane
                                         where q.ID == obj.ashpazkhane1
                                         select q.title).First();
                }

            }
            else
            {
                ashpazkhane1.Text = "-";
            }

            if (obj.ashpazkhane2.Length > 0)
            {
                string final = "";
                string srt = obj.ashpazkhane2.Remove(obj.ashpazkhane2.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.result.ashpazkhane
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.result.ashpazkhane
                             where q.ID == srt
                             select q.title).First();
                }
                final = final.Remove(final.Length - 1, 1);
                ashpazkhane2.Text = final;

            }

            else if (obj.ashpazkhane2.Length == 1)
            {

                if (obj.ashpazkhane2 == "0")
                {
                    ashpazkhane2.Text = "-";
                }
                else
                {
                    ashpazkhane2.Text = (from q in CATS.result.ashpazkhane
                                         where q.ID == obj.ashpazkhane2
                                         select q.title).First();
                }

            }
            else
            {
                ashpazkhane2.Text = "-";
            }
            if (obj.ashpazkhane3.Length > 0)
            {
                string final = "";
                string srt = obj.ashpazkhane3.Remove(obj.ashpazkhane3.Length - 1, 1);
                srt = srt.Remove(0, 1);

                if (srt.Contains(','))
                {
                    List<string> lstsg3 = srt.Split(',').ToList();
                    foreach (var itemm in lstsg3)
                    {
                        final = final + (from q in CATS.result.ashpazkhane
                                         where q.ID == itemm
                                         select q.title).First() + ",";
                    }
                }
                else
                {
                    final = (from q in CATS.result.ashpazkhane
                             where q.ID == srt
                             select q.title).First();
                }
                final = final.Remove(final.Length - 1, 1);
                ashpazkhane3.Text = final;

            }
            else if (obj.ashpazkhane3.Length == 1)
            {

                if (obj.ashpazkhane3 == "0")
                {
                    ashpazkhane3.Text = "-";
                }
                else
                {
                    ashpazkhane3.Text = (from q in CATS.result.ashpazkhane
                                         where q.ID == obj.ashpazkhane3
                                         select q.title).First();
                }

            }
            else
            {
                ashpazkhane3.Text = "-";
            }
            senn.Text = obj.senn == "0" ? "-" : (from q in CATS.result.senn
                                                 where q.ID == obj.senn
                                                 select q.title).First();

            samt.Text = obj.samt == "0" ? "-" : (from q in CATS.result.samt
                                                 where q.ID == obj.samt
                                                 select q.title).First();

            sanad.Text = obj.sanad == "0" ? "-" : (from q in CATS.result.sanad
                                                   where q.ID == obj.sanad
                                                   select q.title).First();







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

        protected override void OnLoad(EventArgs e)
        {
            //List<Control> controllist = new List<Control>();
            //controllist.Add(apartment);
            //controllist.Add(title);
            //controllist.Add(phone1);
            //controllist.Add(phone2);
            //controllist.Add(phone3);
            //controllist.Add(address);
            //controllist.Add(mantaghe_id);
            //controllist.Add(mantaghe_name);
            //controllist.Add(owner);
            //controllist.Add(ID);
            //controllist.Add(date_created);
            //controllist.Add(hasEstakhr);
            //controllist.Add(hasSauna);
            //controllist.Add(hasJakoozi);
            //controllist.Add(takhlie);
            //controllist.Add(sell2khareji);
            //controllist.Add(suit);
            //controllist.Add(maghaze);
            //controllist.Add(office);
            //controllist.Add(kolangi);
            //controllist.Add(mostaghellat);
            //controllist.Add(villa);
            //controllist.Add(isMoaveze);
            //controllist.Add(isMosharekat);
            //controllist.Add(isRahn);
            //controllist.Add(isEjare);
            //controllist.Add(isForoosh);
            //controllist.Add(seraydar);
            //controllist.Add(kaf_type);
            //controllist.Add(garmayesh_sarmayesh);
            //controllist.Add(total_floor);
            //controllist.Add(total_vahed);
            //controllist.Add(vahed_per_floor);
            //controllist.Add(zirbana1);
            //controllist.Add(zirbana2);
            //controllist.Add(zirbana3);
            //controllist.Add(khab1);
            //controllist.Add(khab2);
            //controllist.Add(khab3);
            //controllist.Add(tabaghe1);
            //controllist.Add(tabaghe2);
            //controllist.Add(tabaghe3);
            //controllist.Add(ashpazkhane1);
            //controllist.Add(ashpazkhane2);
            //controllist.Add(ashpazkhane3);
            //controllist.Add(balkon1);
            //controllist.Add(balkon2);
            //controllist.Add(balkon3);
            //controllist.Add(asansor1);
            //controllist.Add(asansor2);
            //controllist.Add(asansor3);
            //controllist.Add(anbari1);
            //controllist.Add(anbari2);
            //controllist.Add(anbari3);
            //controllist.Add(parking1);
            //controllist.Add(parking2);
            //controllist.Add(parking3);
            //controllist.Add(tabaghe_1_rahn);
            //controllist.Add(tabaghe_2_rahn);
            //controllist.Add(tabaghe_3_rahn);
            //controllist.Add(tabaghe_1_ejare);
            //controllist.Add(tabaghe_2_ejare);
            //controllist.Add(tabaghe_3_ejare);
            //controllist.Add(tabaghe_1_total_price);
            //controllist.Add(tabaghe_2_total_price);
            //controllist.Add(tabaghe_3_total_price);
            //controllist.Add(tabaghe_1_metri);
            //controllist.Add(tabaghe_2_metri);
            //controllist.Add(tabaghe_3_metri);
            //controllist.Add(hasGym);
            //controllist.Add(hasShooting);
            //controllist.Add(hasRoofGarden);
            //controllist.Add(isMoble);
            //controllist.Add(hasLobbyMan);
            //GlobalVariable.controllist = controllist;
            CatsAndAreasObject CATS = null;
            if (GlobalVariable.isadmin == "1")
            {
                CATS = JsonConvert.DeserializeObject<CatsAndAreasObject>(GlobalVariable.newCatsAndAreas);
            }
            else
            {
                CATS = GlobalVariable.catsAndAreas;
            }


            List<Control> allControls = GetAllControls(this);
            allControls.ForEach(k => k.Font = GlobalVariable.headerlistFONT);


            if (GlobalVariable.fromwhere != "main")
            {
                next.Visible = false;
                back.Visible = false;
            }
            la7.Font = GlobalVariable.headerlistFONTsmall;
            la8.Font = GlobalVariable.headerlistFONTsmall;
            la9.Font = GlobalVariable.headerlistFONTsmall;
            la10.Font = GlobalVariable.headerlistFONTsmall;
            la11.Font = GlobalVariable.headerlistFONTsmall;
            la12.Font = GlobalVariable.headerlistFONTsmall;
            la13.Font = GlobalVariable.headerlistFONTsmall;
            la14.Font = GlobalVariable.headerlistFONTsmall;
            la15.Font = GlobalVariable.headerlistFONTsmall;
            la16.Font = GlobalVariable.headerlistFONTsmall;
            la17.Font = GlobalVariable.headerlistFONTsmall;
            la18.Font = GlobalVariable.headerlistFONTsmall;
            la19.Font = GlobalVariable.headerlistFONTsmall;
            la20.Font = GlobalVariable.headerlistFONTsmall;
            la21.Font = GlobalVariable.headerlistFONTsmall;
            la22.Font = GlobalVariable.headerlistFONTsmall;
            //label13.Font = GlobalVariable.headerlistFONTsmall;
            //label12.Font = GlobalVariable.headerlistFONTsmall;
            this.MinimizeBox = true;
            this.MaximizeBox = true;
            whishon.Visible = false;
            try
            {
                int port = 8001;
                if (GlobalVariable.port != 0)
                {
                    port = GlobalVariable.port;
                }

                try
                {

                    ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
                    obj = (from p in log.result.data
                           where p.ID == GlobalVariable.selectedIDofList
                           select p).First();

                }
                catch (Exception)
                {

                    throw;
                }


            }

            catch (Exception f)
            {
                Console.Write("Error..... " + f.StackTrace);
            }

            InitControl();


            //Type type = obj.GetType();
            //PropertyInfo[] properties = type.GetProperties();

            //foreach (PropertyInfo property in properties)
            //{
            //    string srt = property.Name;
            //    string value = property.GetValue(obj, null).ToString();
            //    InitControl(srt, value);
            //}

            //phone1.Text = obj.phones[0];

            //phone2.Text = obj.phones[1];

            //phone3.Text = obj.phones[2];

            //phone4.Text = obj.phones[3];

            //owner.Text = obj.malek;

            //owner.ForeColor = Color.Black;

            ////  Date.Text = obj.dat;

            //address.Text = obj.address;


            //mantaghe_name.Text = obj.mantaghe_name;// CATS.result.mantaghe[Convert.ToInt16(obj.mantaghe_name)];


            //number.Text = obj.ID;


            //if (obj.isForoosh == "1")
            //{
            //    isForoosh.Checked = true;
            //}
            //if (obj.isEjare == "1")
            //{
            //    isEjare.Checked = true;
            //}
            //if (obj.isRahn == "1")
            //{
            //    isRahn.Checked = true;
            //}
            //if (obj.isMosharekat == "1")
            //{
            //    isMosharekat.Checked = true;
            //}
            //if (obj.isMoaveze == "1")
            //{
            //    isMoaveze.Checked = true;
            //}
            //if (obj.asansor == "1")
            //{
            //    asansor.Checked = true;
            //}
            //if (obj.anbari == "1")
            //{
            //    anbari.Checked = true;
            //}
            //if (obj.hasEstakhr == "1")
            //{
            //    hasEstakhr.Checked = true;
            //}
            //if (obj.hasJakoozi == "1")
            //{
            //    hasJakoozi.Checked = true;
            //}
            //if (obj.hasSauna == "1")
            //{
            //    hasSauna.Checked = true;
            //}

            //apartment.Text = obj.apartment;// CATS.result.apartment[Convert.ToInt16(obj.apartment)];


            //villa.Text = obj.villa;// CATS.result.villa[Convert.ToInt16(obj.villa)];

            //mostaghellat.Text =  obj.mostaghellat;


            //kolangi.Text = obj.kolangi; // CATS.result.kolangi[Convert.ToInt16(obj.kolangi)];

            //office.Text = obj.office; // CATS.result.office[Convert.ToInt16(obj.office)];
            //garmayesh_sarmayesh.Text = obj.garmayesh_sarmayesh; // CATS.result.garmayesh_sarmayesh[Convert.ToInt16(obj.garmayesh_sarmayesh)];
            //kaf_type.Text = obj.kaf_type;// CATS.result.kaf_type[Convert.ToInt16(obj.kaf_type)];
            //seraydar.Text = obj.seraydar;// CATS.result.seraydar[Convert.ToInt16(obj.seraydar)];

            //if (obj.sell2khareji == "1")
            //{
            //    sell2khareji.Checked = true;
            //}
            //if (obj.maghaze == "1")
            //{
            //    maghaze.Checked = true;
            //}
            //if (obj.suit == "1")
            //{
            //    suit.Checked = true;
            //}
            //samt.Text = obj.samt;// CATS.result.samt[Convert.ToInt16(obj.samt)];

            //total_floor.Text = obj.total_floor;
            //total_vahed.Text = obj.total_vahed;


            //masahat_zamin.Text = obj.masahat_zamin;
            //tarakom.Text = obj.tarakom;
            //eslahi.Text = obj.eslahi;
            //toole_bar.Text = obj.toole_bar;
            //ertefa.Text = obj.ertefa;
            //zirzamin.Text = obj.zirzamin;

            //tabaghe1.Text = obj.tabaghe1;
            //tabaghe2.Text = obj.tabaghe2;
            //tabaghe3.Text = obj.tabaghe3;


            //zirbana1.Text = obj.zirbana1;
            //zirbana2.Text = obj.zirbana2;
            //zirbana3.Text = obj.zirbana3;


            ////khab1.Text = obj.khab
            ////khab2.Text = obj.tabaghe_2_info[2];
            ////khab3.Text = obj.tabaghe_3_info[2];

            // if (obj.balkon1 == "1")
            //{
            //    balkon1.Checked = true;
            //}
            // if (obj.balkon2 == "2")
            //{
            //    balkon2.Checked = true;
            //}
            // if (obj.balkon3 == "3")
            //{
            //    balkon3.Checked = true;
            //}





            //ashpazkhane1.Text = obj.ashpazkhane1;
            //ashpazkhane2.Text = obj.ashpazkhane2;
            //ashpazkhane3.Text = obj.ashpazkhane3;

            //if (obj.parking1 == "1")
            //{
            //    parking1.Checked = true;
            //}
            //if (obj.parking2 == "2")
            //{
            //    parking2.Checked = true;
            //}
            //if (obj.parking3 == "3")
            //{
            //    parking3.Checked = true;
            //}

            //gheymatekol1.Text = obj.tabaghe_1_total_price;
            //gheymatekol2.Text = obj.tabaghe_2_total_price;
            //gheymatekol3.Text = obj.tabaghe_3_total_price;


            //gheymatemetri1.Text = obj.tabaghe_1_metri;
            //gheymatemetri2.Text = obj.tabaghe_2_metri;
            //gheymatemetri3.Text = obj.tabaghe_3_metri;


            //rahn1.Text = obj.tabaghe_1_rahn;
            //rahn2.Text = obj.tabaghe_2_rahn;
            //rahn3.Text = obj.tabaghe_3_rahn;

            //ejare1.Text = obj.tabaghe_1_ejare;
            //ejare2.Text = obj.tabaghe_2_ejare;
            //ejare3.Text = obj.tabaghe_3_ejare;

            //senn.Text = obj.senn; // CATS.result.senn[Convert.ToInt16(obj.senn)];

            ////if (obj.ha == "3")
            ////{
            ////    parking3.Checked = true;
            ////}


            //string text = obj.desc.Replace("\n\r\n", " ");
            //text = text.Replace("\r\n", " ");
            //desc.Text = text;



            //if (mydatum.ejare == true)
            //{
            //    ejare.Checked = true;
            //}





            //  metraj.Text = mydatum.masahat.ToString();
            //  metraj.Font = GlobalVariable.headerlistFONT;
            //  metraj.ForeColor = Color.Black;
            //  vadie.Text = mydatum.vadie.ToString();
            //  vadie.Font = GlobalVariable.headerlistFONT;
            //  vadie.ForeColor = Color.Black;

            //  //cat.Text = mydatum.cat;
            //  //cat.Font = GlobalVariable.headerlistFONT;
            //  cat.ForeColor = Color.Black;
            //  //kind.Text = mydatum.kind;
            //  //kind.Font = GlobalVariable.headerlistFONT;
            //  kind.ForeColor = Color.Black;
            //  ejare.Text = mydatum.ejare.ToString();
            //  ejare.Font = GlobalVariable.headerlistFONT;
            //  ejare.ForeColor = Color.Black;
            //  //year.Text = mydatum.build_year;
            //  //year.Font = GlobalVariable.headerlistFONT;
            //  year.ForeColor = Color.Black;
            //  //tabaghe.Text = mydatum.tabaghe.ToString();
            //  //tabaghe.Font = GlobalVariable.headerlistFONT;
            //  tabaghe.ForeColor = Color.Black;


            //  masahat.Text = mydatum.masahat.ToString();
            //  masahat.Font = GlobalVariable.headerlistFONT;
            //  masahat.ForeColor = Color.Black;
            //  tool_bar.Text = mydatum.tool_bar.ToString();
            //  tool_bar.Font = GlobalVariable.headerlistFONT;
            //  tool_bar.ForeColor = Color.Black;
            //  gozar.Text = mydatum.gozar.ToString();
            //  gozar.Font = GlobalVariable.headerlistFONT;
            //  gozar.ForeColor = Color.Black;
            //  tarakom.Text = mydatum.tarakom.ToString();
            //  tarakom.Font = GlobalVariable.headerlistFONT;
            //  tarakom.ForeColor = Color.Black;
            //  eslahi.Text = mydatum.eslahi.ToString();
            //  eslahi.Font = GlobalVariable.headerlistFONT;
            //  eslahi.ForeColor = Color.Black;

            //  phone2.Text = mydatum.phone2.ToString();
            //  phone2.Font = GlobalVariable.headerlistFONT;
            //  phone2.ForeColor = Color.Black;
            //  phone3.Text = mydatum.phone3;
            //  phone3.Font = GlobalVariable.headerlistFONT;
            //  phone3.ForeColor = Color.Black;
            //  phone4.Text = mydatum.phone4;
            //  phone4.Font = GlobalVariable.headerlistFONT;
            //  phone4.ForeColor = Color.Black;
            //  //direction.Text = mydatum.type;
            //  //direction.Font = GlobalVariable.headerlistFONT;
            //  direction.ForeColor = Color.Black;
            //  //facilities.Text = mydatum.facilites;
            //  //facilities.Font = GlobalVariable.headerlistFONT;
            //  facilities.ForeColor = Color.Black;

            wishoff.Name = "0-" + obj.ID;
            whishon.Name = "1-" + obj.ID;
            saveToPrivate.Name = "2-" + obj.ID;
            next.Name = "3-" + obj.ID;
            back.Name = "4-" + obj.ID;

            string ideas = Settings1.Default.ides;
            if (ideas.Contains("," + obj.ID))
            {
                wishoff.Visible = false;
                whishon.Visible = true;
            }
            else
            {
                whishon.Visible = false;
                wishoff.Visible = true;

            }


            //  l1.Font = GlobalVariable.headerlistFONT;
            //  l2.Font = GlobalVariable.headerlistFONT;
            //  l3.Font = GlobalVariable.headerlistFONT;
            //  l4.Font = GlobalVariable.headerlistFONT;
            //  l5.Font = GlobalVariable.headerlistFONT;
            //  l6.Font = GlobalVariable.headerlistFONT;
            //  l7.Font = GlobalVariable.headerlistFONT;
            //  l8.Font = GlobalVariable.headerlistFONT;
            //  l9.Font = GlobalVariable.headerlistFONT;
            //  l10.Font = GlobalVariable.headerlistFONT;
            //  l11.Font = GlobalVariable.headerlistFONT;
            //  l12.Font = GlobalVariable.headerlistFONT;
            //  l13.Font = GlobalVariable.headerlistFONT;
            //  l14.Font = GlobalVariable.headerlistFONT;
            //  l15.Font = GlobalVariable.headerlistFONT;
            //  l16.Font = GlobalVariable.headerlistFONT;
            //  l17.Font = GlobalVariable.headerlistFONT;
            //  l18.Font = GlobalVariable.headerlistFONT;
            //  l19.Font = GlobalVariable.headerlistFONT;
            //  l20.Font = GlobalVariable.headerlistFONT;
            //  l21.Font = GlobalVariable.headerlistFONT;
            //  l22.Font = GlobalVariable.headerlistFONT;
            ////  l23.Font = GlobalVariable.headerlistFONT;





            // total.Text = mydatum.total;

            base.OnLoad(e);

            //Task.Factory.StartNew
            //(
            // () =>
            // {
            //     Thread.Sleep(500);
            //     Invoke(new Action(MyCode));
            // }
            //);
        }
        private void MyCode()
        {
            if (GlobalVariable.showimage)
            {
                try
                {
                    int port = 8001;
                    if (GlobalVariable.port != 0)
                    {
                        port = GlobalVariable.port;
                    }


                    Console.WriteLine("Connecting.....");

                    int j = 0;
                    ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
                    //   obj = from log.


                    //    if (mydatum.images.Count() != 0)
                    //    {
                    //        for (int i = 1; i <= mydatum.images.Count(); i++)
                    //        {

                    //            try
                    //            {
                    //                TcpClient tcpclnt2 = new TcpClient();
                    //                try
                    //                {
                    //                    tcpclnt2.Connect("192.168.0.1", port);

                    //                }
                    //                catch (Exception)
                    //                {


                    //                }


                    //                Stream stm3 = tcpclnt2.GetStream();
                    //              //  string srtnum = "2" + i.ToString();
                    //                string srtnum = "2" + mydatum.images[i].ToString();

                    //                ASCIIEncoding asen2 = new ASCIIEncoding();
                    //                byte[] ba2 = asen2.GetBytes(srtnum);
                    //                stm3.Write(ba2, 0, ba2.Length);


                    //                string json2 = "";
                    //                const int blockSiz2e = 500000;
                    //                byte[] buffer2 = new byte[blockSiz2e];
                    //                int bytesRead2;

                    //                //stm.Read(buffer, 0, buffer.Length);
                    //                //MemoryStream ms = new MemoryStream(buffer);
                    //                //Image returnImage = Image.FromStream(ms);

                    //                while ((bytesRead2 = stm3.Read(buffer2, 0, buffer2.Length)) > 0)
                    //                {

                    //                }
                    //                MemoryStream ms = new MemoryStream(buffer2);
                    //                try
                    //                {
                    //                    Image returnImage = Image.FromStream(ms);


                    //                    tcpclnt2.Close();
                    //                    switch (j)
                    //                    {
                    //                        case 0:
                    //                            pictureBox1.Image = returnImage;
                    //                            break;
                    //                        case 1:
                    //                            pictureBox2.Image = returnImage;
                    //                            break;
                    //                        case 2:
                    //                            pictureBox3.Image = returnImage;
                    //                            break;
                    //                        case 3:
                    //                            pictureBox4.Image = returnImage;
                    //                            break;
                    //                        case 4:
                    //                            pictureBox5.Image = returnImage;
                    //                            break;
                    //                        case 5:
                    //                            pictureBox6.Image = returnImage;
                    //                            break;
                    //                        case 6:
                    //                            pictureBox7.Image = returnImage;
                    //                            break;


                    //                    }
                    //                    j++;
                    //                }
                    //                catch (Exception)
                    //                {


                    //                }

                    //            }
                    //            catch (Exception imgerro)
                    //            {

                    //                throw;
                    //            }
                    //        }
                    //    }
                    //    else
                    //    {

                    //    }







                }

                catch (Exception f)
                {
                    Console.Write("Error..... " + f.StackTrace);
                }

            }
        }
        // your "special" method to handle "load is complete" event

        string form2id = "";
        List<System.Drawing.Image> imglist = new List<System.Drawing.Image>();

        //string metraj = "";
        //string cat = "";
        //string room = "";
        //string title = "";
        //string desc = "";

        public Form2(string id)
        {
            GlobalVariable.showimage = true;
            //form2id = id;
            InitializeComponent();
            // radRotator1.BeginRotate += new BeginRotateEventHandler(radRotator1_BeginRotate);
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form2_Load(object sender, EventArgs e)
        {



        }


        void radRotator1_BeginRotate(object sender, BeginRotateEventArgs e)
        {
            // radLabelElement1.Text = String.Format("Rotating from item {0} to {1}", e.From, e.To);
        }



        private void Form2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void wishoff_Click(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Application.StartupPath, "Resources", "wishList.txt");
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



            var pic = (PictureBox)sender;
            string name = pic.Name;
            string id = name.Substring(2, name.Length - 2);
            ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
            ListOfAdds.Datum newobj = log.result.data.Where(p => p.ID == id).Single();
            list.Add(newobj);
            string jsonmodel = JsonConvert.SerializeObject(list);
            try
            {
                string path = Path.Combine(Application.StartupPath, "Resources", "wishList.txt");
                System.IO.File.WriteAllText(path, jsonmodel);

            }
            catch (Exception)
            {

            }
            wishoff.Visible = false;
            whishon.Visible = true;
            string ideas = Settings1.Default.ides;
            Settings1.Default.ides = ideas + "," + id;
            Settings1.Default.Save();
        }

        private void whishon_Click(object sender, EventArgs e)
        {
            string filepath = Path.Combine(Application.StartupPath, "Resources", "wishlist.txt");
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



            var pic = (PictureBox)sender;
            string name = pic.Name;
            string id = name.Substring(2, name.Length - 2);
            ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
            list.RemoveAll(p => p.ID == id);
            string jsonmodel = JsonConvert.SerializeObject(list);
            try
            {
                string path = Path.Combine(Application.StartupPath, "Resources", "wishlist.txt");
                System.IO.File.WriteAllText(path, jsonmodel);


            }
            catch (Exception)
            {

            }
            string idesss = Settings1.Default.ides.Remove(0, 1);
            List<string> TagIds = idesss.Split(',').ToList();
            int index = 0;
            foreach (var item in TagIds)
            {
                if (item.ToString() == id)
                {
                    index = TagIds.IndexOf(item);
                }
            }
            TagIds.RemoveAt(index);
            string ides = "";
            foreach (var item in TagIds)
            {
                ides = "," + item;
            }

            Settings1.Default.ides = ides;
            Settings1.Default.Save();
            wishoff.Visible = true;
            whishon.Visible = false;
        }

        private void saveToPrivate_Click(object sender, EventArgs e)
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



            var pic = (PictureBox)sender;
            string name = pic.Name;
            string id = name.Substring(2, name.Length - 2);
            ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
            ListOfAdds.Datum newobj = log.result.data.Where(p => p.ID == id).Single();
            list.Add(newobj);
            string jsonmodel = JsonConvert.SerializeObject(list);
            try
            {
                string path = Path.Combine(Application.StartupPath, "Resources", "objects.txt");
                System.IO.File.WriteAllText(path, jsonmodel);
                MessageBox.Show("فایل مورد نظر با موفقیت به فایل های اختصاصی شما اضافه شد");

            }
            catch (Exception)
            {

            }
        }

        private void next_Click(object sender, EventArgs e)
        {

            string id = ID.Text;
            ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
            ListOfAdds.Datum newobj = log.result.data.Where(p => p.ID == id).Single();
            int Indexof = log.result.data.IndexOf(newobj);
            int mustbe = Indexof + 1;
            if (mustbe <= log.result.data.Count() - 1 && mustbe >= 0)
            {
                obj = log.result.data[mustbe];
                InitControl();

            }
           
        }

        private void back_Click(object sender, EventArgs e)
        {
            string id = ID.Text;
            ListOfAdds.RootObject log = JsonConvert.DeserializeObject<ListOfAdds.RootObject>(GlobalVariable.result);
            ListOfAdds.Datum newobj = log.result.data.Where(p => p.ID == id).Single();
            int Indexof = log.result.data.IndexOf(newobj);
            int mustbe = Indexof - 1;
            if (mustbe <= log.result.data.Count()-1 && mustbe >= 0)
            {
                obj = log.result.data[mustbe];
                InitControl();

            }
        }


















    }
}
