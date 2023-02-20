using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Machine.States
{
    public class ConfirmOrderState : IState
    {
        public IControlUnit ControlUnit => throw new NotImplementedException();

        public decimal Credit => throw new NotImplementedException();

        public Coordinates SelectedCoordinates => throw new NotImplementedException();

        public void RaiseCredit(decimal value)
        {
            throw new NotImplementedException();
        }

        public void SelectProduct(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }

        public void TryDeliverProduct()
        {
            throw new NotImplementedException();
        }
    }
}
