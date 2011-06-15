using System;
using System.ComponentModel.DataAnnotations;
using Lifebyte.Web.Models.Core.Interfaces;

namespace Lifebyte.Web.Models.Core.Entities
{  /* TODO Some how the relationship to entities that have not (I guessed at an approach below seems to work)
    * been created yet:
        * Recipient
        * Computer Status
                   Or will we do something like use an enumerated type to handle it?
                   K Knight, I'd support either way.  If by an enumerated type, though
                   I'd want to but a constraint at the database level 
        *          as to the values it would accept (since it wouldn't be constrained by an FK value 
        * Licence Type 
        * Volunteer Created by and Modified by relationship
        *
        * My approach generated FK in DDL.sql
    * 
    *  Active.  At the database level we can default it to True. Is there a way
    *  via scaffolding, or something where we define what the defaults are to be
    *  examples: we'd want the default of created Date to ge DateTime.Now (or getdate() sqlsever, and active to be true.
    *  
    * TODO foreign key constraints get generated, but I HATE the FK constraint name.  Can we override that, or does that need to
    * be done by the dba (kumar)
    * */

    public class Computer : ICoreEntity
    {
        [ScaffoldColumn(false)]
        public virtual Guid Id { get; set; }

        // TODO , when DDL gets generated it places it at the bottom of the ddl.sql script
        // gets the correct type in there
        // how do we circumvent that
        [Required]
        public virtual ComputerStatus ComputerStatus { get; set; }

        [Display(Name = "Lifebyte Number")]
        public virtual string LifebyteNumber { get; set; }

        public virtual string Notes { get; set; }

        public virtual string ManifestHtml { get; set; }

        public virtual string License { get; set; }

        public virtual LicenceType LicenceType { get; set; }

        [ScaffoldColumn(false)]
        public virtual Volunteer CreateByVolunteer { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public virtual Volunteer LastModByVolunteer { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime LastModDate { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.  how do we default it to true
        /// </summary>        
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }

    public class ComputerStatus : ICoreEntity
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [Required]      
        public virtual string Name { get; set; }

        [Required]  
        public virtual string Description { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>        
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }

    // explain again what determines if a property
    // uses the scaffolding attribute
    public class LicenceType : ICoreEntity
    {
        // this is the primary key, how do i designate it as such?

        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Code { get; set; }
        
        [Required]
        public virtual string FullName { get; set; }

        public virtual int? SortOrder { get; set; }

        [ScaffoldColumn(false)]
        public virtual Volunteer CreateByVolunteer { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public virtual DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        public virtual Volunteer LastModByVolunteer { get; set; }

        [ScaffoldColumn(false)]
        public virtual DateTime LastModDate { get; set; }

        /// <summary>
        /// We do not delete from the website. We only set records to be inactive and 
        /// filter them out of search results.
        /// </summary>        
        [ScaffoldColumn(false)]
        public virtual bool Active { get; set; }
    }
}