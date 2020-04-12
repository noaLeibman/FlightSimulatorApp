﻿using System;
using System.ComponentModel;
using FlightSimulatorApp.Model;
using Microsoft.Maps.MapControl.WPF;


namespace FlightSimulatorApp.view_models
{
    public class VM_Map : INotifyPropertyChanged
    {

  
     //   public double VM_Latitude
  //      { get 
   //         {
   //             VM_PlanePosition = new Location(this.model.Latitude, this.model.Longitude);
   //             return this.model.Latitude ; }
   //     }
  //      public double VM_Longitude
   //     { 
   //         get 
   //         {
                
   //             return this.model.Longitude; } 
  //      }
        private Location VM_planeposition;
        public Location VM_PlanePosition
        {
            get
            {
                VM_planeposition = new Location(this.model.Latitude, this.model.Longitude);
                Console.WriteLine("in VM"+VM_planeposition);
                return VM_planeposition;

            }
            set
            {
                VM_planeposition = value;
                NotifyPropertyChanged("VM_PlanePosition");
            }
        }

        private ISimulatorModel model;
        public void SetModel(ISimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
