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
        public static bool textFieldNotEmpty(TextBox field, string label)
        {
            if (field.Text == "")
            {
                MessageBox.Show(label + "måste fyllas i. Vänligen ange ett värde.");
                field.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool checkIfValidUrl(string url)
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

        public static bool checkIfUrlExists (string url)
            {
            if (url ==??)
            {
                MessageBox.Show("Url:en är redan tillagd");
                return false;
            }
            else
            {
                return true;
            }
   
        }

        public static bool checkIfNameExists(string namn)
        {
            if (namn == "")
            {
                MessageBox.Show(namn + "är redan tillagt, vänligen välj ett annat");
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

