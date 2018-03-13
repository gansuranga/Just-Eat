// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuisineType.cs" company="Chandler Fang">
//   Chandler Fang
// </copyright>
// <summary>
//   The cuisine type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace JustEat.Objects
{
    using System.Runtime.Serialization;

    /// <summary>
    /// The cuisine type.
    /// </summary>
    public class CuisineType : IMappable
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember(Name = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the seo name.
        /// </summary>
        [DataMember(Name = "SeoName")]
        public string SeoName { get; set; }
    }
}
