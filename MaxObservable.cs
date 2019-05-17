using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SolutionProblem {
    public class MaxObservable {
        
        ArrayList observers = new ArrayList();
        
        public void Emit<T>(T data) {
            foreach (var obs in observers) {
                Type[] genericTypes = obs.GetType().GetTypeInfo().GenericTypeArguments;
                if (genericTypes.Length == 0) 
                    throw new Exception("An observer seems not to have a generic type");
                Type observerType = genericTypes[0];

                if (typeof(T) == observerType) {
                    IObserver<T> castObserver = (IObserver<T>) obs;
                    castObserver.Notify(data);
                }
            }
        }

        public void Subscribe<T>(IObserver<T> observer) {
            observers.Add(observer);
        }

        public void Unsubscribe<T>(IObserver<T> observer) {
            observers.Remove(observer);
        }
    }

    public interface IObserver<T>
    {
        void Notify(T data);
    }
    
    public class FakeObserver<T> : IObserver<T>
    {
        private HashSet<T> notifications = new HashSet<T>();

        public void Notify(T data)
        {
            notifications.Add(data);
        }

        public bool WasNotifiedWith(T data)
        {
            return notifications.Contains(data);
        }

        public bool WasNotified()
        {
            return notifications.Any();
        }
    }
}