﻿namespace Simulator.Maps
{
    public interface IMappable
    {

        /// <summary>
        /// Assigns the creature to a specific map and position.
        /// </summary>
        /// <param name="map">The map to assign.</param>
        /// <param name="point">The point on the map.</param>
        void AssignToMap(Map map, Point point);

        /// <summary>
        /// Moves the creature in the given direction.
        /// </summary>
        /// <param name="direction">Direction to move in.</param>
        /// <returns>Status or result of the move.</returns>
        string Go(Direction direction);

        /// <summary>
        /// Returns the current position of the creature.
        /// </summary>
        /// <returns>Current position as a Point.</returns>
        Point GetPosition();
        Point CurrentPosition { get; set; }

        /// <summary>
        /// Symbol representation for visualization.
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Returns the name or description of the creature.
        /// </summary>
        /// <returns>String representation of the creature.</returns>
        string ToString();
    }
}