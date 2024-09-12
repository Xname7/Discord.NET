using System;

namespace Discord
{
    /// <summary>
    ///     Represents a modal interaction.
    /// </summary>
    public class Modal : IMessageComponent
    {
        /// <inheritdoc/>
        public ComponentType Type => throw new NotSupportedException("Modals do not have a component type.");

        /// <summary>
        ///     Gets the title of the modal.
        /// </summary>
        public string Title { get; set; }

        /// <inheritdoc/>
        public string CustomId { get; set; }

        /// <summary>
        ///     Gets the components in the modal.
        /// </summary>
        public ModalComponent Component { get; set; }

        internal Modal(string title, string customId, ModalComponent components)
        {
            Title = title;
            CustomId = customId;
            Component = components;
        }
    }
}
