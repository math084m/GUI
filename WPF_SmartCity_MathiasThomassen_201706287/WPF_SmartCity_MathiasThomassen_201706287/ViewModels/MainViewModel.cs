using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using WPF_SmartCity_MathiasThomassen_201706287.Data;
using WPF_SmartCity_MathiasThomassen_201706287.Models;
using WPF_SmartCity_MathiasThomassen_201706287.Views;

namespace WPF_SmartCity_MathiasThomassen_201706287.ViewModels
{
    class MainViewModel : BindableBase
    {

        private ObservableCollection<Location> location;
        private string File_name = "";
        private string filepath = "";
        

        public MainViewModel()
        {
            location = new ObservableCollection<Location>();
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
                
                
                var newLocation = new Location()
                {
                    Trees = new ObservableCollection<Trees>()
                };
                var vm = new AddLocationViewModel(newLocation);
                var dialog = new AddLocation()
                {
                    DataContext = vm
                };
                if (dialog.ShowDialog() == true)
                {
                    if (Location.Count>0)
                    {
                        int newIndex = Location[Location.Count - 1].LocationId;
                        newIndex++;
                        newLocation.LocationId = newIndex;
                    }
                    else
                    {
                        newLocation.LocationId = 0;
                    }
                    Location.Add(newLocation);
                    CurrLocation = newLocation;
                    currIndex++;
                    
                }
            }))); }
        }

       
        private ICommand _NewFileCommand;

        //function taken from lecture 11 - agentassignment.
        public ICommand NewFileCommand
        {
            get
            {
                return _NewFileCommand ?? (_NewFileCommand =
                           new DelegateCommand(NewFileCommand_Execute));
            }
        }

        private void NewFileCommand_Execute()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Location.Clear();
                File_name = "";
            }
        }

        private ICommand _saveAsCommand;

        public ICommand SaveAsCommand
        {
            get
            {
                return _saveAsCommand ?? (_saveAsCommand
                           = new DelegateCommand<string>(SaveAsCommand_Execute));
            }
        }

        private void SaveAsCommand_Execute(string argFilename)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "XML-files|*.xml|All Files|*.*",
                DefaultExt = "xml"
            };
            if (filepath == "")
            {
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            }
            else
            {
                dlg.InitialDirectory = Path.GetDirectoryName(filepath);
            }

            if (dlg.ShowDialog(App.Current.MainWindow) == true)
            {
                filepath = dlg.FileName;
                File_name = Path.GetFileName(filepath);
                SaveFile();
            }

        }

        private ICommand _saveFileCommand;

        public ICommand SaveFileCommand
        {
            get
            {
                return _saveFileCommand ?? (_saveFileCommand
                           = new DelegateCommand(SaveFileCommand_Execute, SaveFileCommand_CanExecute));
            }

        }

        private void SaveFileCommand_Execute()
        {
            SaveFile();
        }

        private bool SaveFileCommand_CanExecute()
        {
            return (File_name != "") && (Location.Count > 0);
        }

        private void SaveFile()
        {
            try
            {
                Repository.SaveFile(filepath, Location);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ICommand _closeAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                return _closeAppCommand ?? (_closeAppCommand = new DelegateCommand(() =>
                {
                    Application.Current.MainWindow.Close();
                }));
            }
        }

        private ICommand _openFileCommand;

        public ICommand OpenFileCommand
        {
            get
            {
                return _openFileCommand ?? (_openFileCommand =
                           new DelegateCommand(OpenFileCommand_Execute));
            }
        }

        private void OpenFileCommand_Execute()
        {
            var dlg = new OpenFileDialog
            {
                Filter = "XML-files|*.xml|All Files|*.*",
                DefaultExt = "xml"
            };

            if (filepath == "")
            {
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            }
            else
            {
                dlg.InitialDirectory = Path.GetDirectoryName(filepath);
            }

            if (dlg.ShowDialog(App.Current.MainWindow) == true)
            {
                filepath = dlg.FileName;
                File_name = Path.GetFileName(filepath);
                try
                {
                    Repository.ReadFile(filepath,out ObservableCollection<Location> tmpLoc);
                    Location = tmpLoc;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        #endregion
    }
}
