﻿namespace ERP_WEB_API.Models
{
    public class Userinf
    {
        public long row_num { get; set; }
        public string comcod { get; set; }
        public string usrid { get; set; }
        public string usrsname { get; set; }
        public string usrname { get; set; }
        public string usrdesig { get; set; }
        public bool usractive { get; set; }
        public string usrpass { get; set; }
        public string mailid { get; set; }
        public string? empid { get; set; }
        public int userrole { get; set; }
    }
}
