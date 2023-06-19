﻿using System;

namespace Features.Cell.Scripts.Domain.Actions
{
    public interface IGetCellType
    {
        IObservable<CellType> Execute();
    }
}