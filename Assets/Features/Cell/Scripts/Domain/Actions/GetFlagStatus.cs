using System;
using UniRx;

namespace Features.Cell.Scripts.Domain.Actions
{
    public class GetFlagStatus : IGetFlagStatus
    {
        public IObservable<FlagStatus> Execute()
        {
            return Observable.Return(FlagStatus.Removed);
        }
    }
}