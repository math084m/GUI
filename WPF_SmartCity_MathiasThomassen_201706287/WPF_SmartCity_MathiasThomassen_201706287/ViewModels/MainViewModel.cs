using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using WPF_SmartCity_MathiasThomassen_201706287.Models;
using WPF_SmartCity_MathiasThomassen_201706287.Views;

namespace WPF_SmartCity_MathiasThomassen_201706287.ViewModels
{
    class MainViewModel : BindableBase
    {

        ObservableCollection<Location> location;
        
        private string filterHelper;

        public MainViewModel()
        {
            location = new ObservableCollection<Location>();
            ObservableCollection<Trees> items = new ObservableCollection<Trees>();
            items.Add(new Trees()
            {
                number = 10,
                Sort = "Bøg"
            });
            items.Add(new Trees()
            {
                number = 2,
                Sort = "Eg"
            });

            
            Location.Add(new Location()
            {
                City = "Århus",
                LocationId = 1,
                Name = "Universitets parken",
                Postal = "8200",
                Street = "Finlandsgade",
                StreetNr = "44b",
                Trees = items
            });

            items.Add(new Trees()
            {
                number = 99,
                Sort = "Gran"
            });

            Location.Add(new Location()
            {
                City = "Kolding",
                LocationId = 2,
                Name = "Nørregade-parken",
                Postal = "4800",
                Street = "Nørregade",
                StreetNr = "4",
                Trees = items
            });

            
            currLocation = new Location();

            CurrLocation = Location[0];
            
        }

        #region properties

        

        public ObservableCollection<Location> Location
        {
            get { return location; }
            set { SetProperty(ref location, value); }
        }

        
        private Location currLocation = null;
        public Location CurrLocation {
            get { return currLocation; }
            set { SetProperty(ref currLocation,value); }
        }

        private int currIndex = 0;
        public int CurrIndex
        {
            get { return currIndex;}
            set { SetProperty(ref currIndex,value); }
        }

        #endregion
        
        #region SearchFilter

        private string filter;

        public string Filter
        {
            get { return filter; }
            set
            {
                if (filter!=value)
                {
                    ICollectionView CollectionView = CollectionViewSource.GetDefaultView(Location);
                    SetProperty(ref filter, value);
                    if (filter == "")
                    {
                        CollectionView.Filter = null;
                    }
                    else
                    {
                        CollectionView.Filter = Search;
                    }
                }

            }
        }

        private bool Search(object obj)
        {
            Location loc = obj as Location;
            return (loc.Name.ToLowerInvariant().Contains(Filter.ToLowerInvariant()));
        }


        #endregion


        //most commands are from agent assignement, lecture 11.
        #region Commands

        private ICommand _addNewLocationCommand;

        
        public ICommand AddNewLocationCommand
        {
            get { return _addNewLocationCommand ?? (_addNewLocationCommand = new DelegateCommand((() =>
            {
                int newIndex = Location[Location.Count - 1].LocationId;
                newIndex++;
                var newLocation = new Location()
                {
                    LocationId = newIndex,
                    Trees = new ObservableCollection<Trees>()
                };
                var vm = new AddLocationViewModel(newLocation);
                var dialog = new AddLocation()
                {
                    DataContext = vm
                };
                if (dialog.ShowDialog() == true)
                {
                    
                    Location.Add(newLocation);
                    CurrLocation = newLocation;
                    currIndex++;
                    
                }
            }))); }
        }



        #endregion
    }
}
