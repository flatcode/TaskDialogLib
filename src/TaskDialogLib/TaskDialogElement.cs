﻿/***************************************************************************************************
 *
 *  Flatcode Task Dialog Library
 *  Copyright © 2014 Flatcode.net. All Rights Reserved.
 *
 *  File:
 *    TaskDialogElement.cs
 *  Purpose:
 *    Task dialog element dependency object.
 *  Authors:
 *    Florian Schneidereit <florian.schneidereit@outlook.com>
 *
 *  This library is free software; you can redistribute it and/or modify it under the terms of
 *  the GNU Lesser General Public License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public License along with this
 *  library; if not, write to the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
 *  Boston, MA  02110-1301  USA
 *
 **************************************************************************************************/

#region Using Directives

using System;
using System.Windows;
using System.Windows.Markup;

#endregion

namespace Flatcode.Presentation
{
	/// <summary>
	/// Represents the base class for all task dialog elements.
	/// </summary>
    [RuntimeNameProperty(nameof(Name))]
	public abstract class TaskDialogElement : DependencyObject
	{
		#region Fields

		WeakReference ownerReference;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="TaskDialogElement"/> class.
		/// </summary>
		protected TaskDialogElement()
		{
		}

		#endregion

		#region Properties


        private static readonly DependencyProperty NameProperty =
            DependencyProperty.Register(nameof(Name), typeof(string), typeof(TaskDialogElement));

        /// <summary>
        /// The name of this <see cref="TaskDialogElement"/>.
        /// </summary>        
        public string Name
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }

        /// <summary>
        /// Gets or sets the owner <see cref="TaskDialog"/> of this <see cref="TaskDialogElement"/>.
        /// </summary>
        protected internal TaskDialog Owner {
			get {
				if (ownerReference != null) {
					if (ownerReference.IsAlive) {
						return ownerReference.Target as TaskDialog;
					}
				}

				return null;
			}
			set {
				if (ownerReference == null) {
					ownerReference = new WeakReference(value);
				} else {
					ownerReference.Target = value;
				}
			}
		}

		#endregion
	}
}
