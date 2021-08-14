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
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
