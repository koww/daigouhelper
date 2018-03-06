// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace PriceCalc
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CostDollar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField discount1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField discount2 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField discount3 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel exchangeRateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper exchangeRateStepper { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FinalCost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ResetButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch Taxable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TicketPrice { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UnitCost { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Weight { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CostDollar != null) {
                CostDollar.Dispose ();
                CostDollar = null;
            }

            if (discount1 != null) {
                discount1.Dispose ();
                discount1 = null;
            }

            if (discount2 != null) {
                discount2.Dispose ();
                discount2 = null;
            }

            if (discount3 != null) {
                discount3.Dispose ();
                discount3 = null;
            }

            if (exchangeRateLabel != null) {
                exchangeRateLabel.Dispose ();
                exchangeRateLabel = null;
            }

            if (exchangeRateStepper != null) {
                exchangeRateStepper.Dispose ();
                exchangeRateStepper = null;
            }

            if (FinalCost != null) {
                FinalCost.Dispose ();
                FinalCost = null;
            }

            if (ResetButton != null) {
                ResetButton.Dispose ();
                ResetButton = null;
            }

            if (Taxable != null) {
                Taxable.Dispose ();
                Taxable = null;
            }

            if (TicketPrice != null) {
                TicketPrice.Dispose ();
                TicketPrice = null;
            }

            if (UnitCost != null) {
                UnitCost.Dispose ();
                UnitCost = null;
            }

            if (Weight != null) {
                Weight.Dispose ();
                Weight = null;
            }
        }
    }
}