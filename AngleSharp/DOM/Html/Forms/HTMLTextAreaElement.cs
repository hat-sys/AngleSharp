﻿namespace AngleSharp.DOM.Html
{
    using System;

    /// <summary>
    /// Represents a HTML textarea element.
    /// </summary>
    sealed class HTMLTextAreaElement : HTMLTextFormControlElement, IHtmlTextAreaElement
    {
        #region ctor

        /// <summary>
        /// Creates a new HTML textarea element.
        /// </summary>
        internal HTMLTextAreaElement()
        {
            _name = Tags.Textarea;
            WillValidate = true;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the wrap HTML attribute, indicating how the control wraps text.
        /// </summary>
        public String Wrap
        {
            get { return GetAttribute(AttributeNames.Wrap); }
            set { SetAttribute(AttributeNames.Wrap, value); }
        }

        /// <summary>
        /// Gets or sets the default value of the input field.
        /// </summary>
        public override String DefaultValue
        {
            get { return TextContent; }
            set { TextContent = value; }
        }

        /// <summary>
        /// Gets the codepoint length of the control's value.
        /// </summary>
        public Int32 TextLength
        {
            get { return Value.Length; }
        }

        /// <summary>
        /// Gets or sets the rows HTML attribute, indicating
        /// the number of visible text lines for the control.
        /// </summary>
        public Int32 Rows
        {
            get { return GetAttribute(AttributeNames.Rows).ToInteger(2); }
            set { SetAttribute(AttributeNames.Rows, value.ToString()); }
        }

        /// <summary>
        /// Gets or sets the cols HTML attribute, indicating
        /// the visible width of the text area.
        /// </summary>
        public Int32 Columns
        {
            get { return GetAttribute(AttributeNames.Cols).ToInteger(20); }
            set { SetAttribute(AttributeNames.Cols, value.ToString()); }
        }

        /// <summary>
        /// Gets the type of input control (texarea).
        /// </summary>
        public String Type
        {
            get { return _name; }
        }

        #endregion

        #region Internal properties

        /// <summary>
        /// Gets if the node is in the special category.
        /// </summary>
        protected internal override Boolean IsSpecial
        {
            get { return true; }
        }

        internal Boolean IsMutable
        {
            get { return !IsDisabled && !IsReadOnly; }
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Constucts the data set (called from a form).
        /// </summary>
        /// <param name="dataSet">The dataset to construct.</param>
        /// <param name="submitter">The given submitter.</param>
        internal override void ConstructDataSet(FormDataSet dataSet, HTMLElement submitter)
        {
            dataSet.Append(Name, Value, Type.ToString());

            if (HasAttribute(AttributeNames.DirName))
            {
                var dirname = GetAttribute(AttributeNames.DirName);

                if (String.IsNullOrEmpty(dirname))
                    return;

                dataSet.Append(dirname, Direction.ToString().ToLower(), "Direction");
            }
        }

        /// <summary>
        /// Checks the form control for validity.
        /// </summary>
        /// <param name="state">The element's validity state tracker.</param>
        protected override void Check(IValidityState state)
        {
            //TODO
        }

        #endregion

        #region Enumeration
        
        /// <summary>
        /// An enumeration with possible wrap types.
        /// </summary>
        public enum WrapType : ushort
        {
            /// <summary>
            /// The text will be wrapped with tolerance.
            /// </summary>
            Soft,
            /// <summary>
            /// The text will be wrapped without tolerance.
            /// </summary>
            Hard
        }

        #endregion
    }
}
