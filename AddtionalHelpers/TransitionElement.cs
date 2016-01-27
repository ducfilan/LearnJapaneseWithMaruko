﻿using System.Windows;
using Microsoft.Phone.Controls;

namespace Hoc_tieng_Nhat_cung_Maruko.AddtionalHelpers
{
    /// <summary>
    /// Transition factory for a particular transition family.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public abstract class TransitionElement : DependencyObject
    {
        /// <summary>
        /// Creates a new
        /// <see cref="T:Microsoft.Phone.Controls.ITransition"/>
        /// for a
        /// <see cref="T:System.Windows.UIElement"/>.
        /// Existing
        /// <see cref="F:System.Windows.UIElement.RenderTransformProperty"/>
        /// or
        /// <see cref="F:System.Windows.UIElement.ProjectionProperty"/>
        /// values may be saved and cleared before the start of the transition, then restored it after it is stopped or completed.
        /// </summary>
        /// <param name="element">The <see cref="T:System.Windows.UIElement"/>.</param>
        /// <returns>The <see cref="T:Microsoft.Phone.Controls.ITransition"/>.</returns>
        public abstract ITransition GetTransition(UIElement element);
    }
}
