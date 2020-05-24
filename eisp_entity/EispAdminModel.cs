using System;


namespace Eisp.Entity
{
  public  class AdminModel
    {
      public AdminModel() { }

      private string _name;
      private int _uid;
      private string _pass;
      private DateTime _date;
      private int _authority;


      public string Name
      {
          get { return _name; }
          set { _name = value; }
      }

      public int UID
      {
          get { return _uid; }
          set { _uid = value; }
      }

      public string Pass
      {
          get { return _pass; }
          set { _pass = value; }
      }

      public DateTime Date
      {
          get { return _date; }
          set { _date = value; }
      }

      public int Authority
      {
          get { return _authority; }
          set { _authority = value; }
      }
    }
}
