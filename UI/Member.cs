using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataGridBinding
{
    public class Member : INotifyPropertyChanged
    {
        private string name = string.Empty;
        private float insto = 0.0f;
        private string description = string.Empty;

        public string BindName
        {
            set {
                if (!value.Equals(name)) {
                    name = value;
                    OnPropertyChanged("BindName");
                }
            }
            get {
                return name;
            }
        }

        public float BindInsto
        {
            set {
                if (!value.Equals(insto)) {
                    insto = value;
                    OnPropertyChanged("BindInsto");
                }
            }
            get { return insto; }
        }

        public string BindDescription
        {
            set {
                if (!value.Equals(description)) {
                    description = value;
                    OnPropertyChanged("BindDescription");
                }
            }
            get { return description; }
        }


        protected void OnPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class MemberCollection : ObservableCollection<Member> { 
    
    }

}
