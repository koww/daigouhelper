using System;
using System.Globalization;

using UIKit;
using Foundation;

namespace PriceCalc
{
    public partial class ViewController : UIViewController
    {
        MainModel model = new MainModel();
        const string resetStr = "0.0";
		myPickerViewModel weightPickerModel, costPickerModel;
		UIPickerView weightpicker, costPicker;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            TicketPrice.EditingDidBegin += editBegin;
            TicketPrice.EditingDidEnd += editEnd;
            TicketPrice.ShouldReturn += shouldReturn;

			discount1.EditingDidBegin += editBegin;
			discount1.EditingDidEnd += editEnd;
			discount1.ShouldReturn += shouldReturn;

			discount2.EditingDidBegin += editBegin;
			discount2.EditingDidEnd += editEnd;
			discount2.ShouldReturn += shouldReturn;

			discount3.EditingDidBegin += editBegin;
			discount3.EditingDidEnd += editEnd;
			discount3.ShouldReturn += shouldReturn;

            Taxable.ValueChanged += (sender, e) =>
            {
                refreshAll();
            };

            DefaultExchangeRate.ValueChanged += (sender, e) =>
            {
                refreshAll();
            };

            ResetButton.TouchUpInside += (sender, e) =>
            {
                resetAll();
                refreshAll();
            };

            weightPickerModel = new myPickerViewModel(model.Weights);
            weightpicker = new UIPickerView();
            weightpicker.Model = weightPickerModel;
            weightpicker.ShowSelectionIndicator = true;

            costPickerModel = new myPickerViewModel(model.UnitCosts);
            costPicker = new UIPickerView();
            costPicker.Model = costPickerModel;
            costPicker.ShowSelectionIndicator = true;

            UIToolbar toolbar1 = new UIToolbar()
            {
                BarStyle = UIBarStyle.Default,
                Translucent = false
            };
            toolbar1.SizeToFit();

			UIToolbar toolbar2 = new UIToolbar()
			{
				BarStyle = UIBarStyle.Default,
				Translucent = false
			};
			toolbar2.SizeToFit();

            UIBarButtonItem doneButton1 = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (sender, e) => 
            {
                foreach (UIView view in this.View.Subviews)
                {
                    if (view.IsFirstResponder)
                    {
                        UITextField textview = (UITextField)view;
                        textview.Text = weightPickerModel.SelectedItem.ToString("N");
                        textview.ResignFirstResponder();
                    }
                }
                refreshAll();
            });

			UIBarButtonItem doneButton2 = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (sender, e) =>
			{
				foreach (UIView view in this.View.Subviews)
				{
					if (view.IsFirstResponder)
					{
						UITextField textview = (UITextField)view;
						textview.Text = costPickerModel.SelectedItem.ToString("N");
						textview.ResignFirstResponder();
					}
				}
				refreshAll();
			});

            toolbar1.SetItems(new UIBarButtonItem[] { doneButton1 }, true);
			toolbar2.SetItems(new UIBarButtonItem[] { doneButton2 }, true);

            Weight.InputView = weightpicker;
            Weight.InputAccessoryView = toolbar1;
            UnitCost.InputView = costPicker;
            UnitCost.InputAccessoryView = toolbar2;

            refreshAll();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        private void refreshAll()
        {
            if (model == null) model = new MainModel();
            model.TicketPrice = Convert.ToDouble(TicketPrice.Text);
            model.Discount1 = Convert.ToDouble(discount1.Text);
            model.Discount2 = Convert.ToDouble(discount2.Text);
            model.Discount3 = Convert.ToDouble(discount3.Text);
            model.Taxable = Taxable.On;
            model.DefaultRate = DefaultExchangeRate.On;
			
            Weight.Text = weightPickerModel.SelectedItem.ToString("N");
			UnitCost.Text = costPickerModel.SelectedItem.ToString("N");

			model.Weight = Convert.ToDouble(Weight.Text);
			model.CostPerWeightUnit = Convert.ToDouble(UnitCost.Text);
			this.CostDollar.Text = $"{model.CostDollar.ToString("C", new CultureInfo("en-US"))} / {model.CostCNY.ToString("C", new CultureInfo("zh-CN"))}";
			this.FinalCost.Text = $"{model.FinalPriceDollar.ToString("C", new CultureInfo("en-US"))} / {model.FinalPriceCNY.ToString("C", new CultureInfo("zh-CN"))}";
        }

        private void resetAll()
        {
            if (model == null) 
            {
				model = new MainModel();
            }
            else
            {
				model.Reset();
            }
            TicketPrice.Text = resetStr;
            discount1.Text = resetStr;
            discount2.Text = resetStr;
            discount3.Text = resetStr;
            if(!Taxable.On){
				Taxable.SetState(true, true);
            }

            weightpicker.Select(0, 0, true);
            costPicker.Select(0, 0, true);

        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            this.View.EndEditing(true);
        }

        private void editBegin(object sender, EventArgs e)
        {
            ((UITextField)sender).BecomeFirstResponder();
        }

        private void editEnd(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(((UITextField)sender).Text))
            {
                ((UITextField)sender).Text = "0.0";
            }
            ((UITextField)sender).ResignFirstResponder();
            refreshAll();
        }

        private bool shouldReturn(UITextField textfield)
        {
			textfield.ResignFirstResponder();
            return true;
        }
    }
}
