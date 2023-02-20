using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Machine.States
{
    public class SelectCoordinatesState : State
    {
        public Coordinates SelectedCoordinates { get; private set; }

        public SelectCoordinatesState(IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;
        }

        public SelectCoordinatesState(IState state, IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;

            Credit = state.Credit;

            SelectedCoordinates = state.SelectedCoordinates;
        }

        public override void RaiseCredit(decimal value)
        {
            throw new NotImplementedException();
        }

        public override void SelectProduct(Coordinates coordinates)
        {
            CheckCredit();
        }

        public override void TryDeliverProduct()
        {
            throw new NotImplementedException();
        }
    }
}
