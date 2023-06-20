using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Features.Cell.Scripts.Domain.Actions
{
    [CreateAssetMenu(menuName = "Create CellDisplayColorByBombsNearby", fileName = "Default CellDisplayColorByBombsNearby", order = 0)]
    public class CellDisplayColorByBombsNearby : ScriptableObject
    {
        public List<Color> ColorByBombsNearby = new()
        {
            Color.clear,
            Color.blue,
            Color.green,
            Color.red,
            Color.magenta,
            Color.yellow,
            Color.black,
            Color.cyan,
            Color.white,
            Color.gray
        };
    }
}