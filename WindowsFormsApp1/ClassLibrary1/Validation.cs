using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logic
{
    public class Validation
    {
        public static bool textFieldInteTomt(TextBox field, string label)
        {
            if (field.Text == "")
            {
                MessageBox.Show(label + " måste fyllas i. Vänligen ange ett värde.");
                field.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool textFieldOchComboboxInteTomt(TextBox field, ComboBox combo)
        {
            if (field.Text == "" && combo.Text == "")
            {
                MessageBox.Show("Du måste välja en kategori eller skapa en ny.");
                field.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool textFieldOchComboboxEndastEnVald(TextBox field, ComboBox combo)
        {
            if (field.Text != "" && combo.Text != "")
            {
                MessageBox.Show("Du kan inte skapa en ny kategori och lägga till podcasten i en annan samtidigt.");
                combo.Items.Clear();
                field.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool textFieldInteTomt(TextBox field1, TextBox field2, string label1, string label2)
        {
            if (field1.Text == "")
            {
                MessageBox.Show(label1 + " måste fyllas i. Vänligen ange ett värde.");
                field1.Focus();
                return false;
            } else if (field2.Text == "")
            {
                MessageBox.Show(label2 + " måste fyllas i. Vänligen ange ett värde.");
                field2.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool textFieldInteTomt(TextBox field1, TextBox field2, TextBox field3, string label1, string label2, string label3)
        {
            if (field1.Text == "")
            {
                MessageBox.Show(label1 + " måste fyllas i. Vänligen ange ett värde.");
                field1.Focus();
                return false;
            }
            else if (field2.Text == "")
            {
                MessageBox.Show(label2 + " måste fyllas i. Vänligen ange ett värde.");
                field2.Focus();
                return false;
            } else if (field3.Text == "")
            {
                MessageBox.Show(label3 + " måste fyllas i. Vänligen ange ett värde.");
                field3.Focus();
                return false;
            } 
            else
            {
                return true;
            }
        }

        public static bool kollaUrl(string url)
        {
            try
            {
                var xml = "";
                using (var client = new System.Net.WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    xml = client.DownloadString(url);
                    return true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vänligen ange en korrekt url.");
                return false;
            }
        }




        public static bool comboBoxInteTomt(ComboBox combo, string label)
        {
            if (combo.Text == "")
            {
                MessageBox.Show(label + " är inte valt, vänligen ange ett värde");
                combo.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool comboBoxInteTomt(ComboBox combo1, ComboBox combo2, string label)
        {
            if (combo1.Text == "")
            {
                MessageBox.Show(label + " är inte valt, vänligen ange ett värde");
                combo1.Focus();
                return false;
            } else if (combo2.Text == "")
            {
                MessageBox.Show(label + " är inte valt, vänligen ange ett värde");
                combo2.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        //kolla att kraven för att lägga till är uppfyllda (namn, kategori och intervall)
        //kolla att nytt namn på kategori inte är taget


    }



}

