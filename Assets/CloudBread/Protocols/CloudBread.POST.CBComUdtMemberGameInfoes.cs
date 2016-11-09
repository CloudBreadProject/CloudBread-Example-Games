using UnityEngine;
using System;


namespace CloudBread
{
    public partial class CBComUdtMemberGameInfoes
    {
        const string _url = "api/CBComUdtMemberGameInfoes";
        
        [Serializable]
        public struct Post
        {
            [SerializeField]
            public string MemberID;
            [SerializeField]
            public string Level;
            [SerializeField]
            public string Exps;
            [SerializeField]
            public string Points;
            [SerializeField]
            public string UserSTAT1;
            [SerializeField]
            public string UserSTAT2;
            [SerializeField]
            public string UserSTAT3;
            [SerializeField]
            public string UserSTAT4;
            [SerializeField]
            public string UserSTAT5;
            [SerializeField]
            public string UserSTAT6;
            [SerializeField]
            public string UserSTAT7;
            [SerializeField]
            public string UserSTAT8;
            [SerializeField]
            public string UserSTAT9;
            [SerializeField]
            public string UserSTAT10;
            [SerializeField]
            public string sCol1;
            [SerializeField]
            public string sCol2;
            [SerializeField]
            public string sCol3;
            [SerializeField]
            public string sCol4;
            [SerializeField]
            public string sCol5;
            [SerializeField]
            public string sCol6;
            [SerializeField]
            public string sCol7;
            [SerializeField]
            public string sCol8;
            [SerializeField]
            public string sCol9;
            [SerializeField]
            public string sCol10;
        }
		
        [Serializable]
        public struct Receive
        {
            [SerializeField]
            public string result;
        }

        static public void Request(Post postData_, System.Action<Receive> callback_, System.Action<string> errorCallback_ = null)
        {
            CloudBread.Request(CloudBread.MakeFullUrl(_url), JsonUtility.ToJson(postData_), callback_, errorCallback_);
        }
    }
}