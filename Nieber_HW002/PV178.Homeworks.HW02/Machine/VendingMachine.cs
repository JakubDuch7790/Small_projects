using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Machine.States;
using PV178.Homeworks.HW02.Model;
using System.Collections.Generic;
using System.Linq;


namespace PV178.Homeworks.HW02.Machine
{
    public class VendingMachine : IVendingMachine
    {
        public IControlUnit ControlUnit { get; private set; }

        public VendingMachine(IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;
        }

        public void ConfirmOrder()
        {
            ControlUnit.State.TryDeliverProduct();
        }

        //public IEnumerable<string> GetCurrentOffer()
        //{
        //    List<string> offer = new List<string>();

        //    foreach (var keyValuePair in ControlUnit.GetStocksDictionary())
        //    {
        //        string dictElement = $"{keyValuePair.Key} {keyValuePair.Value}";

        //        offer.Add(dictElement);
        //    }

        //    return offer;
        //}

        public IEnumerable<string> GetCurrentOffer()
        {
            return ControlUnit.GetStocksDictionary().Select(kvp => $"{kvp.Key.ToString()} {kvp.Value.ToString()}");
        }


        public void InsertCoin(decimal value)
        {
            ControlUnit.State.RaiseCredit(value);
        }

        public void SelectCoordinates(Coordinates coordinates)
        {
            ControlUnit.State.SelectProduct(coordinates);
        }
    }
}
