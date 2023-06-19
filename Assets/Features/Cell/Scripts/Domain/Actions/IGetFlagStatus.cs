using System;

namespace Features.Cell.Scripts.Domain.Actions
{
    public interface IGetFlagStatus
    {
        IObservable<FlagStatus> Execute();
    }
}