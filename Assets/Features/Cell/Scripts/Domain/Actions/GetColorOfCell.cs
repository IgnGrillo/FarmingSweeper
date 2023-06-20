using UnityEngine;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class GetColorOfCell : IGetColorOfCell
    {
        private readonly CellDisplayColorByBombsNearby _cellDisplayColorByBombsNearby;

        public GetColorOfCell(CellDisplayColorByBombsNearby cellDisplayColorByBombsNearby) => 
                _cellDisplayColorByBombsNearby = cellDisplayColorByBombsNearby;

        public Color Execute(int bombsNearby) => 
                _cellDisplayColorByBombsNearby.ColorByBombsNearby[bombsNearby];
    }
}