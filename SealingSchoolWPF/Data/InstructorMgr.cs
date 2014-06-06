using SealingSchoolWPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealingSchoolWPF.Data
{
  public class InstructorMgr : IPersistenceMgr<Instructor>
  {
    public IList<Instructor> Instructors { get; set; }

    public IList<Instructor> GetAll()
    {
      Instructors = new List<Instructor>();

      using ( var ctx = new SchoolDataContext() )
      {
        foreach ( Instructor instructor in ctx.Instructors )
        {
          ctx.Entry( instructor ).Reference( s => s.Adress ).Load();
          ctx.Entry( instructor ).Reference( s => s.Bank ).Load();
          ctx.Entry( instructor ).Reference( s => s.Contact ).Load();

          if ( instructor.Qualifications != null )
          {
            foreach ( Qualification q in instructor.Qualifications )
              ctx.Qualifications.Attach( q );
          }

          Instructors.Add( instructor );
        }
      }
      return Instructors;
    }

    public void Delete( Instructor entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        ctx.Instructors.Remove( entity );
        ctx.SaveChanges();
      }
    }

    public void Create( Instructor entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        List<Qualification> qualies = new List<Qualification>();

        if ( entity.Qualifications != null )
        {
          foreach ( Qualification q in entity.Qualifications )
          {
            Qualification dummy = ctx.Qualifications.Find( q.QualificationId );
            ctx.Qualifications.Attach( dummy );
            ctx.Entry( dummy ).State = EntityState.Unchanged;
            qualies.Add( dummy );
          }

          entity.Qualifications.Clear();
          entity.Qualifications = qualies;
        }

        ctx.Instructors.Add( entity );
        ctx.SaveChanges();
      }
    }

    public void Update( Instructor entity )
    {
      using ( var ctx = new SchoolDataContext() )
      {
        List<Qualification> dummy = new List<Qualification>();

        if ( entity.Qualifications != null )
        {
          foreach ( Qualification q in entity.Qualifications )
          {
            Qualification quali = ctx.Qualifications.Find( q.QualificationId );
            ctx.Entry( quali ).State = EntityState.Unchanged;
            dummy.Add( quali );
          }
        }

        entity.Qualifications.Clear();

        foreach ( Qualification q in dummy )
        {
          entity.Qualifications.Add( q );
        }

        Instructor original = ctx.Instructors.Find( entity.InstructorId );
        ctx.Entry( original ).Reference( s => s.Adress ).Load();
        ctx.Entry( original ).Reference( s => s.Bank ).Load();
        ctx.Entry( original ).Reference( s => s.Contact ).Load();

        original.FirstName = entity.FirstName;
        original.LastName = entity.LastName;
        original.Label = entity.FirstName + " " + entity.LastName;
        original.FeeValueDay = entity.FeeValueDay;
        original.FeeValueStd = entity.FeeValueStd;

        if ( original.Adress != null )
        {
          if ( entity.Adress != null )
          {
            original.Adress.City = entity.Adress.City;
            original.Adress.Country = entity.Adress.Country;
            original.Adress.State = entity.Adress.State;
            original.Adress.ZipCode = entity.Adress.ZipCode;
            original.Adress.Street = entity.Adress.Street;
            original.Adress.AddressLine1 = entity.Adress.Street + ", " + entity.Adress.ZipCode + " " + entity.Adress.City;
          }
        }

        if ( original.Bank != null )
        {
          if ( entity.Bank != null )
          {
            original.Bank.AccountNo = entity.Bank.AccountNo;
            original.Bank.BankName = entity.Bank.BankName;
            original.Bank.BankNo = entity.Bank.BankNo;
            original.Bank.Bic = entity.Bank.Bic;
            original.Bank.Iban = entity.Bank.Iban;
            original.Bank.Sepa = entity.Bank.Sepa;
          }
        }

        if ( original.Contact != null )
        {
          if ( entity.Contact != null )
          {
            original.Contact.Email = entity.Contact.Email;
            original.Contact.Fax1 = entity.Contact.Fax1;
            original.Contact.Fax2 = entity.Contact.Fax2;
            original.Contact.Tel1 = entity.Contact.Tel1;
            original.Contact.Tel2 = entity.Contact.Tel2;
            original.Contact.Tel3 = entity.Contact.Tel3;
            original.Contact.WebSite = entity.Contact.WebSite;
            original.Contact.WantsEmailNotification = entity.Contact.WantsEmailNotification;
            original.Contact.WantsTelNotification = entity.Contact.WantsTelNotification;
          }
        }

        original.AdditionalInfo = entity.AdditionalInfo;
        original.CreatedOn = entity.CreatedOn;
        original.ModifiedOn = DateTime.Now;
        original.Label = entity.FirstName + " " + entity.LastName;

        if ( original != null )
        {
          original.Qualifications.Clear();
          foreach ( Qualification q in entity.Qualifications )
          {
            ctx.Qualifications.Attach( q );
            ctx.Entry( q ).State = EntityState.Unchanged;
            original.Qualifications.Add( q );
          }

          ctx.Entry( original ).CurrentValues.SetValues( entity );
          ctx.SaveChanges();

        }
      }
    }

    public Instructor GetById( int id )
    {
      Instructor instructor;
      using ( var ctx = new SchoolDataContext() )
      {
        instructor = (Instructor) ctx.Instructors.Find( id );
        ctx.Entry( instructor ).Reference( s => s.Adress ).Load();
        ctx.Entry( instructor ).Reference( s => s.Bank ).Load();
        ctx.Entry( instructor ).Reference( s => s.Contact ).Load();
      }
      return instructor;
    }

    public void Create( Instructor Model, IList<BlockedTimeSpan> blockedDummyList )
    {
      try
      {
        this.Create( Model );
      }
      catch ( Exception e )
      {

      }
      BlockedTimesMgr blockedMgr = new BlockedTimesMgr();
      Instructor instr = this.GetById( Model.InstructorId );

      foreach ( BlockedTimeSpan blocked in blockedDummyList )
      {
        blocked.Instructor = instr;
        blockedMgr.Create( blocked );
      }

    }
  }
}