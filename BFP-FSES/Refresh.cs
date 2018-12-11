using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace BFP_FSES
{
    class Refresh
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BFP-FSES\\Database11.accdb;Persist Security Info=False;");
        public void RefreshGrid()
        {
            ucMASTERLIST ucm = new ucMASTERLIST();
            ucm.showData();
        }
    }
}
