// <copyright file="EventExtensions.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System.Collections.Specialized;
using System.ComponentModel;

namespace System
{
    public static class EventExtensions
    {
        public static void RaiseEvent<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object source, TEventArgs args)
            where TEventArgs : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        public static void RaiseEvent(this EventHandler eventHandler, object source)
        {
            eventHandler.RaiseEvent(source, EventArgs.Empty);
        }

        public static void RaiseEvent(this EventHandler eventHandler, object source, EventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        public static void RaiseEvent(this CancelEventHandler eventHandler, object source, CancelEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        public static void RaiseEvent(this PropertyChangedEventHandler eventHandler, object source, PropertyChangedEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        public static void RaiseEvent(this PropertyChangingEventHandler eventHandler, object source, PropertyChangingEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        public static void RaiseEvent(this NotifyCollectionChangedEventHandler eventHandler, object source, NotifyCollectionChangedEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }
    }
}
