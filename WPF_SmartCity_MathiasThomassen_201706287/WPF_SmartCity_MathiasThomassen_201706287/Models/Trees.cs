using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace WPF_SmartCity_MathiasThomassen_201706287.Models
{
    class Trees : BindableBase
    {
        private string _sort;
        private int _number;
        public Trees()
        {
        }

        public string Sort
        {
            get { return _sort;}
            set { SetProperty(ref _sort,value); }
        }
        public int number { get; set; }
    }
}
