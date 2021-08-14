using LogiCalc.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCalc.Core.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public Dispoplan Dispoplan { get; set; }
        public string[] Froms
        {
            get
            {
                return this.Dispoplan.Routes.Select(x => x.From).Distinct().OrderBy(x => x).ToArray();
            }
        }
        public string[] Tos
        {
            get
            {
                return this.Dispoplan.Routes.Select(x => x.To).Distinct().OrderBy(x => x).ToArray();
            }
        }
        private string selectedFrom;
        public string SelectedFrom
        {
            get
            {
                return selectedFrom;
            }
            set
            {
                this.selectedFrom = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedFrom"));
            }
        }
        private string selectedTo;
        public string SelectedTo
        {
            get
            {
                return selectedTo;
            }
            set
            {
                this.selectedTo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTo"));
            }
        }
        public MainViewModel()
        {
            this.Dispoplan = new Dispoplan();
        }
        public void ChangeDispoplan(string rawText)
        {
            if (!string.IsNullOrEmpty(rawText))
            {
                this.Dispoplan.FillPlan(rawText);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Froms"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tos"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dispoplan"));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
