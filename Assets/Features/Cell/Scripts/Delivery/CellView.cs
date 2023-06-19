using System;
using Features.Cell.Scripts.Domain;
using UnityEngine;

namespace Features.Cell.Scripts.Delivery
{
    public class CellView : MonoBehaviour, ICellView
    {
        public Action OnPressed { get; set; }
    }
}