/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: ColoProColorModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class ProColorModel
  {
     private Int32 _ColorID;
     private String _F_ColorName;
     private String _F_ColorIco;
     private Int32 _F_ProID;
     private Int32 _F_Lang;


     public ProColorModel()
     {}


     public Int32 ColorID
     {
         get{return this._ColorID;}
         set{this._ColorID = value;}
     }

     public String F_ColorName
     {
         get{return this._F_ColorName;}
         set{this._F_ColorName = value;}
     }

     public String F_ColorIco
     {
         get{return this._F_ColorIco;}
         set{this._F_ColorIco = value;}
     }

     public Int32 F_ProID
     {
         get{return this._F_ProID;}
         set{this._F_ProID = value;}
     }

     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }
  }
}