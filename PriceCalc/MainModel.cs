﻿using System;
using System.Collections.Generic;
using UIKit;

namespace PriceCalc
{
    public class MainModel
    {

        #region Class Members
        double ticketprice;
        double discount1;
        double discount2;
        double discount3;
        bool isTaxable;
        double weight;
        double unitcost;

        const double taxrate = 0.0625;

        //public myPickerViewModel weightPickerViewModel;
        //public myPickerViewModel unitcostPickerViewModel;
        #endregion

        #region Constructors
        public MainModel(double ticketprice = 0.0, double discount1 = 0.0, double discount2 = 0.0, double discount3 = 0.0, bool isTaxable = true)
        {
            this.ticketprice = ticketprice;
            this.discount1 = discount1;
            this.discount2 = discount2;
            this.discount3 = discount3;
            this.isTaxable = isTaxable;
            this.weight = 2.0;
            this.unitcost = 5.0;
            //this.weightPickerViewModel = new myPickerViewModel(Weights,Weight);
            //this.unitcostPickerViewModel = new myPickerViewModel(UnitCosts, CostPerWeightUnit);
        }
        #endregion

        #region Properties
        public double TicketPrice
        {
            get
            {
                return ticketprice;
            }
            set
            {
                ticketprice = value;
            }
        }

        public double Discount1
        {
            get
            {
                return discount1;
            }
            set
            {
                discount1 = value;
            }
        }

        public double Discount2
        {
            get
            {
                return discount2;
            }
            set
            {
                discount2 = value;
            }
        }

        public double Discount3
        {
            get
            {
                return discount3;
            }
            set
            {
                discount3 = value;
            }
        }

        public bool Taxable
        {
            get
            {
                return isTaxable;
            }
            set
            {
                isTaxable = value;
            }
        }

        public double CostDollar
        {
            get
            {
                var temp = ticketprice * (1 - discount1 / 100) * (1 - discount2 / 100) * (1 - discount3 / 100);
                return isTaxable ? temp * (1 + taxrate) : temp;
            }
        }

        public double CostCNY
        {
            get
            {
                return CostDollar * 7.0;
            }
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }

        public double CostPerWeightUnit
        {
            get
            {
                return unitcost;
            }
            set
            {
                unitcost = value;
            }
        }

        public double FinalPriceDollar
        {
            get
            {
                return CostDollar + unitcost * weight;
            }
        }

        public double FinalPriceCNY
        {
            get
            {
                return FinalPriceDollar * 7.0;
            }
        }

        public List<double> Weights
        {
            get
            {
                return new List<double>
                {
                    2.0,
                    3.0,
                    4.0,
                    5.0,
                    6.0,
                    7.0
                };
            }
        }

        public List<double> UnitCosts
        {
            get
            {
                return new List<double>
                {
                    5.0,
                    5.5,
                    6.0,
                    6.5,
                    7.0
                };
            }
        }
        #endregion

        #region Methods
        public void Reset()
        {
            this.ticketprice = 0.0;
            this.discount1 = 0.0;
            this.discount2 = 0.0;
            this.discount3 = 0.0;
            this.isTaxable = true;
            this.Weight = Weights[0];
            this.CostPerWeightUnit = UnitCosts[0];
        }
        #endregion

        //TODO: http://api.fixer.io/latest?base=USD&symbols=CNY
    }

    public class myPickerViewModel : UIPickerViewModel 
    {
        private IList<double> _myItems;

        protected int selectedIndex = 0;
        public event EventHandler<myPickerChangedEventArgs> PickerChanged;

        public myPickerViewModel(IList<double> items)
        {
            _myItems = items;
        }

        public double SelectedItem
        {
            get
            {
                return _myItems[selectedIndex];
            }
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return _myItems.Count;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return _myItems[(int)row].ToString("N");
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            selectedIndex = (int)row;
            if(this.PickerChanged != null){
                this.PickerChanged(this, new myPickerChangedEventArgs { SelectedValue = SelectedItem });
            }
        }
    }

    public class myPickerChangedEventArgs : EventArgs
    {
        public double SelectedValue { get; set; }
    }
}