using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S1G7Projekt
{
    class Indkoebsliste
    {
        public string Dag { get; set; }
        public List<string> IndkoebslisteList { get; set; }

        #region NavneIngredienserPriser_props

        public string Navn1 { get; set; }
        public string Navn2 { get; set; }
        public string Navn3 { get; set; }
        public string Navn4 { get; set; }
        public string Navn5 { get; set; }
        public string Ingrediens1 { get; set; }
        public string Ingrediens2 { get; set; }
        public string Ingrediens3 { get; set; }
        public string Ingrediens4 { get; set; }
        public string Ingrediens5 { get; set; }
        public double Pris1 { get; set; }
        public double Pris2 { get; set; }
        public double Pris3 { get; set; }
        public double Pris4 { get; set; }
        public double Pris5 { get; set; }
        public double TotalPris1 { get; set; }
        public double TotalPris2 { get; set; }
        public double TotalPris3 { get; set; }
        public double TotalPris4 { get; set; }
        public double TotalPris5 { get; set; }

        #endregion

        public void AddIngrediens()
        {
            switch (Dag)
            {
                case "Mandag":
                    //Do something
                    break;
                case "Tirsdag":
                        //Do something
                        break;
                case "Onsdag":
                        //Do something
                        break;
                case "Torsdag":
                        //Do something
                        break;
            }
        }

        public void RemoveIngrediens()
        {
            switch ()
            {
                
            }
        }
    }
}
