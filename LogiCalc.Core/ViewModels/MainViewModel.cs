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
        private readonly IStorageProvider _storageProvider;
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BlockDistanceEdit"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Distance"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaximalPrice"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinimalPrice"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BlockDistanceEdit"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Distance"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaximalPrice"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinimalPrice"));
            }
        }
        private double distance { get; set; }
        public double Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                this.distance   = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Distance"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinimalPrice"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaximalPrice"));
            }
        }
        public double MaximalPrice
        {
            get
            {
                var route = this.Dispoplan.Routes.FirstOrDefault(x => x.To == this.SelectedTo && x.From == this.SelectedFrom);
                return (this.Dispoplan != null && route != null) ? this.Distance * route.Maximum : 0;
            }
        }
        public double MinimalPrice
        {
            get
            {
                var route = this.Dispoplan.Routes.FirstOrDefault(x => x.To == this.SelectedTo && x.From == this.SelectedFrom);
                return (this.Dispoplan != null && route != null) ? this.Distance * route.Minimum : 0;
            }
        }
        public bool BlockDistanceEdit
        {
            get
            {
                return string.IsNullOrEmpty(this.SelectedFrom) && string.IsNullOrEmpty(this.SelectedTo);
            }
        }
        public string RawText
        {
            get
            {
                return this.Dispoplan?.RawText;
            }
            set
            {
                if(this.Dispoplan != null)
                {
                    this.Dispoplan.RawText = value;
                    ChangeDispoplan(value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RawText"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedTo"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("From"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BlockDistanceEdit"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Distance"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MaximalPrice"));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MinimalPrice"));
                }
            }
        }
        public MainViewModel(IStorageProvider storageProvider)
        {
            this.Dispoplan = new Dispoplan();
            this._storageProvider = storageProvider;
            this.LoadDispoplan();
        }
        private void LoadDispoplan()
        {
            var plan = this._storageProvider.Load<Dispoplan>();
            if(plan.ActualBy.Day == DateTime.Now.Day)
            {
                this.Dispoplan = plan;
            }
        }
        public void ChangeDispoplan(string rawText)
        {
            if (!string.IsNullOrEmpty(rawText))
            {
                this.Dispoplan.FillPlan(rawText);
                this.Dispoplan.SavePlan(this._storageProvider);
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Froms"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tos"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Dispoplan"));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
