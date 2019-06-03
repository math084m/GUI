using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using WPF_SmartCity_MathiasThomassen_201706287.Models;

namespace WPF_SmartCity_MathiasThomassen_201706287.ViewModels
{
    class AddLocationViewModel : BindableBase
    {
        public AddLocationViewModel(Location location)
        {
            CurrLocation = location;
        }

        #region properties

        Location currLocation;

        public Location CurrLocation
        {
            get { return currLocation; }
            set { SetProperty(ref currLocation, value); }
        }

        public bool isValid
        {
            get
            {
                bool isValid = !(string.IsNullOrWhiteSpace(CurrLocation.Name) ||
                                 string.IsNullOrWhiteSpace(CurrLocation.City) ||
                                 string.IsNullOrWhiteSpace(CurrLocation.Postal) ||
                                 string.IsNullOrWhiteSpace(CurrLocation.Street) ||
                                 string.IsNullOrWhiteSpace(CurrLocation.StreetNr));
                return isValid;
            }
        }

        private string treesSort;
        private int treeNr;

        public string TreeSort
        {
            get { return treesSort; }
            set { SetProperty(ref treesSort, value); }
        }

        public int TreeNr
        {
            get { return treeNr; }
            set { SetProperty(ref treeNr, value); }
        }

        private int currTree;

        public int CurrTree
        {
            get { return currTree; }
            set { SetProperty(ref currTree,value); }
        }

        #endregion

        #region Commands

        private ICommand _addLocationBtnCommand;

        public ICommand AddCommand
        {
            get
            {
                return _addLocationBtnCommand ?? (_addLocationBtnCommand =
                           new DelegateCommand(AddBtnCommand_Execute, AddBtnCommand_CanExecute)
                               .ObservesProperty((() => CurrLocation.City))
                               .ObservesProperty((() => CurrLocation.Name))
                               .ObservesProperty((() => CurrLocation.StreetNr))
                               .ObservesProperty((() => CurrLocation.Street))
                               .ObservesProperty((() => CurrLocation.Postal)));
            }
        }

        //Taken from lecture 11, agent assignment.
        private void AddBtnCommand_Execute()
        {
            //do nothing here.
        }

        private bool AddBtnCommand_CanExecute()
        {
            return isValid;
        }

        private ICommand _addTreeCommand;

        public ICommand AddTreeCommand
        {
            get
            {
                return _addTreeCommand ?? (_addTreeCommand = 
                           new DelegateCommand(AddTree_Execute,AddTree_CanExecute)
                               .ObservesProperty(() => CurrLocation.Trees));

            }
        }

        private void AddTree_Execute()
        {
            if(TreeNr != 0 && TreeSort!=null)
                CurrLocation.Trees.Add(new Trees()
                {
                    number = TreeNr,
                    Sort = TreeSort
                });
        }

        private bool AddTree_CanExecute()
        {
            //rettes hvis tid.
            return true;
        }

        private ICommand _removeTreeCommand;
        public ICommand RemoveTreeCommand
        {
            get
            {
                return _removeTreeCommand ?? (_removeTreeCommand =
                           new DelegateCommand(RemoveTree_Execute, RemoveTree_CanExecute)
                               .ObservesProperty(() => CurrLocation.Trees));
            }
        }

        private void RemoveTree_Execute()
        {
            CurrLocation.Trees.RemoveAt(CurrTree);
        }

        private bool RemoveTree_CanExecute()
        {
            //rettes hvis tid.
            return true;
        }

        #endregion
    }
}
