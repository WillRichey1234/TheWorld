using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld
{
    public class Area
    {
        /// <summary>
        /// Areas that are connected to this Area linked by their relationship
        /// E.g.    "north" -> an area located to the north
        ///         "down-stairs" -> the room downstairs...
        /// </summary>
        protected Dictionary<string, Area> Neighbors { get; set; }

        /// <summary>
        /// The name of this Area.
        /// </summary>
        public String Name
        {
            get; protected set;
        }

        /// <summary>
        /// The description of this Area that is printed when the area is INSPECTed
        /// </summary>
        public String LongDescription { get; protected set; }

        /// <summary>
        /// The quick description of this Area that is printed when you enter.
        /// </summary>
        public String ShortDescription { get; protected set; }

        /// <summary>
        /// Initialize an area with no connections to other areas.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="longDescription"></param>
        /// <param name="shortDescription"></param>
        public Area(String name, String longDescription, String shortDescription)
        {
            this.Name = name;
            this.LongDescription = longDescription;
            this.ShortDescription = shortDescription;
            // set the Neighbors collection to an empty dictionary.
            this.Neighbors = new Dictionary<string, Area>();
        }

        /// <summary>
        /// Add a neighbor with the given relationship.
        /// If that relation is already used, throws a WorldException.
        /// </summary>
        /// <param name="relation"></param>
        /// <param name="neighbor"></param>
        public void AddNeighbor(String relation, Area neighbor)
        {
            if (this.Neighbors.ContainsKey(relation))
                throw new WorldException("Already have a neighbor at that location.", this);

            this.Neighbors.Add(relation, neighbor);
        }

        /// <summary>
        /// Get the neighbor associated with the given relation.
        /// if no such relation is defined, throws a WorldException
        /// </summary>
        /// <param name="relation"></param>
        /// <returns></returns>
        public Area GetNeighbor(String relation)
        {
            if (this.Neighbors.ContainsKey(relation))
                return this.Neighbors[relation];
            else
                throw new WorldException(String.Format("There is nothing {0} of {1}", relation, this.Name), this);
        }
    }
}
