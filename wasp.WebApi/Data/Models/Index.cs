﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

using wasp.WebApi.Data.Entity;

namespace wasp.WebApi.Data.Models
{
    public enum IndexType : byte
    {
        Unique = 1,
        PrimaryKey = 2,
        Relation = 3,
        RecursiveRelation = 4
    }
    
    [Table("Index")]
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global", Justification = "Used by EF")]
    public class Index : IEntity<string>
    {
        [Column("Id", Order = 0, TypeName = "nvarchar(300)"), Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = null!;
        
        [Column("Type", Order = 1, TypeName = "tinyint")]
        public IndexType Type { get; set; }

        public ICollection<Relation> Relations { get; set; } = new List<Relation>();
    }
    
    
    
    
    /*
     
Musician            -> PK: MusicianId
        
Band                -> PK: BandId
        
BandMember          -> PK: MusicianId, BandId
                    -> FK: BandId               -> Band.BandId
                    -> FK: MusicianId           -> Musician.MusicianId

MembershipPeriod    -> PK: MembershipPeriodId
                    -> FK: MusicianId, BandId   -> BandMember.MusicianId/BandId
                    
                         
IndexId                                     IndexType
    
PK_Musician                                 PrimaryKey
PK_Band                                     PrimaryKey
PK_BandMember                               PrimaryKey
FK_BandMember_BandId                        ForeignKey
FK_BandMember_MusicianId                    ForeignKey
PK_MembershipPeriod                         PrimaryKey
FK_MembershipPeriod_BandIdMusicianId        ForeignKey
FK_Project_ParentProjectId                  Recursive

                    
IndexId                                 Table                   KeyDataItem             References
                                            
PK_Musician                             Musician                MusicianId  
PK_Band                                 Band                    BandId  
PK_BandMember                           BandMember              MusicianId  
PK_BandMember                           BandMember              BandId  
FK_BandMember_BandId                    BandMember              BandId                  Band.BandId
FK_BandMember_MusicianId                BandMember              MusicianId              Musician.MusicianId
PK_MembershipPeriod                     MembershipPeriod        MembershipPeriodId
FK_MembershipPeriod_BandIdMusicianId    MembershipPeriod        MusicianId              BandMember.MusicianId
FK_MembershipPeriod_BandIdMusicianId    MembershipPeriod        BandId                  BandMember.BandId
     
PK_Project                              Project                 ProjectId
FK_Project_ParentProjectId              Project                 ParentProjectId         Project.ProjectId

     */
}