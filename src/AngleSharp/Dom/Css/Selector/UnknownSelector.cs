﻿namespace AngleSharp.Dom.Css
{
    using AngleSharp.Css;
    using System;
    using System.IO;

    /// <summary>
    /// Represents an unknown / invalid selector.
    /// </summary>
    sealed class UnknownSelector : ISelector
    {
        public Priority Specifity
        {
            get { return Priority.Zero; }
        }

        public Boolean Match(IElement element)
        {
            return false;
        }

        public String Text
        {
            get;
            set;
        }

        public void ToCss(TextWriter writer, IStyleFormatter formatter)
        {
            writer.Write(Text ?? String.Empty);
        }
    }
}
