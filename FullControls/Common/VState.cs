using System;
using System.Collections.Generic;

namespace FullControls.Common
{
    /// <summary>
    /// Represents a v-state that a control can be in.
    /// </summary>
    public class VState : IEquatable<VState?>
    {
        /// <summary>
        /// Unset <see cref="VState"/>.
        /// </summary>
        public static readonly VState UNSET = new(nameof(UNSET), typeof(VState));

        /// <summary>
        /// A string identifying the <see cref="VState"/>.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Owner of the <see cref="VState"/>.
        /// </summary>
        public string Owner { get; }

        /// <summary>
        /// Name of the owner of the <see cref="VState"/>.
        /// </summary>
        public string OwnerName { get; }


        /// <summary>
        /// Creates a new instance of <see cref="VState"/>.
        /// </summary>
        /// <param name="name">A string identifying the <see cref="VState"/>.</param>
        /// <param name="owner">Owner of the <see cref="VState"/>.</param>
        public VState(string? name, Type? owner)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (owner == null) throw new ArgumentNullException(nameof(owner));
            Name = name;
            Owner = owner.FullName ?? owner.Name;
            OwnerName = owner.Name;
        }

        /// <summary>
        /// Indicates whether the current instance is equal to a specified <see cref="object"/>.
        /// </summary>
        /// <param name="obj">An <see cref="object"/> to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the specified <see cref="object"/>; otherwise, <see langword="false"/>.</returns>
        public override bool Equals(object? obj) => Equals(obj as VState);

        /// <summary>
        /// Indicates whether the current instance is equal to a specified <see cref="VState"/>.
        /// </summary>
        /// <param name="other">A <see cref="VState"/> to compare with this instance.</param>
        /// <returns><see langword="true"/> if the current instance is equal to the specified <see cref="VState"/>; otherwise, <see langword="false"/>.</returns>
        public bool Equals(VState? other) => other is not null && Owner == other.Owner && Name == other.Name;

        /// <inheritdoc/>
        public override int GetHashCode() => HashCode.Combine(Name, Owner);

        /// <inheritdoc/>
        public override string? ToString() => OwnerName + "." + Name;

        /// <summary>
        /// Compares two <see cref="VState"/> instances to check if they are equal.
        /// </summary>
        /// <param name="left">The first <see cref="VState"/> to compare.</param>
        /// <param name="right">The second <see cref="VState"/> to compare with the first.</param>
        /// <returns><see langword="true"/> if the two instances are equal; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(VState? left, VState? right)
        {
            return EqualityComparer<VState>.Default.Equals(left, right);
        }

        /// <summary>
        /// Compares two <see cref="VState"/> instances to check if they are different.
        /// </summary>
        /// <param name="left">The first <see cref="VState"/> to compare.</param>
        /// <param name="right">The second <see cref="VState"/> to compare with the first.</param>
        /// <returns><see langword="true"/> if the two instances are different; otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(VState? left, VState? right)
        {
            return !(left == right);
        }
    }
}
