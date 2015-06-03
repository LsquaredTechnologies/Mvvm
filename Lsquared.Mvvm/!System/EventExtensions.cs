// <copyright file="EventExtensions.cs" company="LSQUARED">
// Copyright © 2008-2015
// </copyright>

using System.Collections.Specialized;
using System.ComponentModel;

namespace System
{
    /// <summary>
    /// Provides extensions method to <see cref="EventHandler"/> and derived delegates.
    /// </summary>
    public static class EventExtensions
    {
        /// <summary>
        /// Raises the event with the specified source and arguments.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event arguments.</typeparam>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="TEventArgs"/> instance containing the event data.</param>
        public static void RaiseEvent<TEventArgs>(this EventHandler<TEventArgs> eventHandler, object source, TEventArgs args)
            where TEventArgs : EventArgs
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        /// <summary>
        /// Raises the event with the specified source.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="source">The source.</param>
        public static void RaiseEvent(this EventHandler eventHandler, object source)
        {
            eventHandler.RaiseEvent(source, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the event with the specified source and arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="EventArgs"/> instance containing the event data.</param>
        public static void RaiseEvent(this EventHandler eventHandler, object source, EventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        /// <summary>
        /// Raises the event with the specified source and arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        public static void RaiseEvent(this CancelEventHandler eventHandler, object source, CancelEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        /// <summary>
        /// Raises the event with the specified source and arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void RaiseEvent(this PropertyChangedEventHandler eventHandler, object source, PropertyChangedEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        /// <summary>
        /// Raises the event with the specified source and arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="PropertyChangingEventArgs"/> instance containing the event data.</param>
        public static void RaiseEvent(this PropertyChangingEventHandler eventHandler, object source, PropertyChangingEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }

        /// <summary>
        /// Raises the event with the specified source and arguments.
        /// </summary>
        /// <param name="eventHandler">The event handler.</param>
        /// <param name="source">The source.</param>
        /// <param name="args">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        public static void RaiseEvent(this NotifyCollectionChangedEventHandler eventHandler, object source, NotifyCollectionChangedEventArgs args)
        {
            if (eventHandler != null)
            {
                eventHandler(source, args);
            }
        }
    }
}
