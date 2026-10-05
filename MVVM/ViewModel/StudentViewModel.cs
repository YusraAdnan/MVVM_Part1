using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MVVM.ViewModel
{
    /* The middle layer of the MVVM structure 
     * The brain - logic sits here 
     * It does not explicitly say that update a specific list box/text box etc. 
     * It just updates it's properties and the UI reacts to that update automatically */
    public class StudentViewModel : INotifyPropertyChanged
    {
        // Just declaration of an event
        public event PropertyChangedEventHandler? PropertyChanged;

        private void onPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        //Storing the students in a list
        public ObservableCollection<Student> Students { get; set; }

        //Constructor - initializes the class values
        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>
            {
                new Student { Name = "Alice"},
                new Student { Name = "Bob"},
                new Student { Name = "Tinky"}
            };
        }

        //
        private string _newName; //is the secure variable holding the current value
        public string NewName
        {
            get => _newName;
            set 
            {
                _newName = value;
                onPropertyChanged(nameof(NewName)); //tells the UI: NewName changed
            }
        }

    }
}
