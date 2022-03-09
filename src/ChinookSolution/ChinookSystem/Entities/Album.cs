﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChinookSystem.Entities
{
    [Index(nameof(ArtistId), Name = "IFK_AlbumsArtistId")]
    internal partial class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        [Key]
        public int AlbumId { get; set; }
        [Required(ErrorMessage ="Album title is required")]
        //[StringLength(160,MinimumLength =6)]
        [StringLength(160, ErrorMessage ="Album title is limited to 160 characters")]
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }
        [StringLength(50, ErrorMessage = "Album title is limited to 50 characters")]
        [Unicode(false)]
        public string ReleaseLabel { get; set; }



        //these properties are your navigational properties
        //these properties do not hold"real" data
        //these properties are only in "context " during the execution of your query

        [ForeignKey(nameof(ArtistId))]
        [InverseProperty("Albums")]
        public virtual Artist Artist { get; set; }
        [InverseProperty(nameof(Track.Album))]
        public virtual ICollection<Track> Tracks { get; set; }
    }
}