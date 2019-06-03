using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace WPF_SmartCity_MathiasThomassen_201706287.Models
{
    class Location : BindableBase
    {
        private int locationId;
        private string name;
        private string street;
        private string streetNr;
        private string postal;
        private string city;
        private ObservableCollection<Trees> trees;

        public Location()
        {
        }
        
        public int LocationId
        {
            get { return locationId;}
            set { SetProperty(ref locationId, value); }
        }
        public string Name
        {
            get { return name;}
            set { SetProperty(ref name,value); }
        }
        public string Street
        {
            get { return street;}
            set { SetProperty(ref street,value); }
        }
        public string StreetNr
        {
            get { return streetNr;}
            set { SetProperty(ref streetNr,value); }
        }
        public string Postal
        {
            get { return postal;}
            set { SetProperty(ref postal,value); }
        }
        public string City
        {
            get { return city;}
            set { SetProperty(ref city,value); }
        }
        public ObservableCollection<Trees> Trees
        {
            get { return trees;}
            set { SetProperty(ref trees,value); }
        }
    }
}
