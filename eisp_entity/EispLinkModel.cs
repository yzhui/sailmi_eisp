/******************************************************************************************
 			copyright (c) 2007 -  LeadNT.COM 

  class name: ColoLinkModel.cs
  Description: This entity class is crate by LeadNT DBTable2EC.

 *****************************************************************************************/

using System;

namespace Eisp.Entity
{

  public class LinkModel
  {
     private Int32 _ID;
     private String _F_LinkName;
     private String _F_LinkUrl;
     private Int32 _F_Lang;

     public LinkModel()
     {}


     public Int32 ID
     {
         get{return this._ID;}
         set{this._ID = value;}
     }

     public String F_LinkName
     {
         get{return this._F_LinkName;}
         set{this._F_LinkName = value;}
     }

     public String F_LinkUrl
     {
         get{return this._F_LinkUrl;}
         set{this._F_LinkUrl = value;}
     }

     public Int32 F_Lang
     {
         get { return this._F_Lang; }
         set { this._F_Lang = value; }
     }
  }
}