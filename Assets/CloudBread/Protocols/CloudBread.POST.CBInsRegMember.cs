using UnityEngine;
using System;


namespace CloudBread
{
    public partial class CBInsRegMember
    {
        const string _url = "api/CBInsRegMember";
        
        [Serializable]
        public struct Post
        {
            [SerializeField]
            public string MemberID_Members;
            [SerializeField]
            public string MemberPWD_Members;
            [SerializeField]
            public string EmailAddress_Members;
            [SerializeField]
            public string EmailConfirmedYN_Members;
            [SerializeField]
            public string PhoneNumber1_Members;
            [SerializeField]
            public string PhoneNumber2_Members;
            [SerializeField]
            public string PINumber_Members;
            [SerializeField]
            public string Name1_Members;
            [SerializeField]
            public string Name2_Members;
            [SerializeField]
            public string Name3_Members;
            [SerializeField]
            public string DOB_Members;
            [SerializeField]
            public string RecommenderID_Members;
            [SerializeField]
            public string MemberGroup_Members;
            [SerializeField]
            public string LastDeviceID_Members;
            [SerializeField]
            public string LastIPaddress_Members;
            [SerializeField]
            public string LastLoginDT_Members;
            [SerializeField]
            public string LastLogoutDT_Members;
            [SerializeField]
            public string LastMACAddress_Members;
            [SerializeField]
            public string AccountBlockYN_Members;
            [SerializeField]
            public string AccountBlockEndDT_Members;
            [SerializeField]
            public string AnonymousYN_Members;
            [SerializeField]
            public string _3rdAuthProvider_Members;
            [SerializeField]
            public string _3rdAuthID_Members;
            [SerializeField]
            public string _3rdAuthParam_Members;
            [SerializeField]
            public string PushNotificationID_Members;
            [SerializeField]
            public string PushNotificationProvider_Members;
            [SerializeField]
            public string PushNotificationGroup_Members;
            [SerializeField]
            public string sCol1_Members;
            [SerializeField]
            public string sCol2_Members;
            [SerializeField]
            public string sCol3_Members;
            [SerializeField]
            public string sCol4_Members;
            [SerializeField]
            public string sCol5_Members;
            [SerializeField]
            public string sCol6_Members;
            [SerializeField]
            public string sCol7_Members;
            [SerializeField]
            public string sCol8_Members;
            [SerializeField]
            public string sCol9_Members;
            [SerializeField]
            public string sCol10_Members;
            [SerializeField]
            public string TimeZoneID_Members;
            [SerializeField]
            public string Level_MemberGameInfoes;
            [SerializeField]
            public string Exps_MemberGameInfoes;
            [SerializeField]
            public string Points_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT1_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT2_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT3_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT4_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT5_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT6_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT7_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT8_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT9_MemberGameInfoes;
            [SerializeField]
            public string UserSTAT10_MemberGameInfoes;
            [SerializeField]
            public string sCol1_MemberGameInfoes;
            [SerializeField]
            public string sCol2_MemberGameInfoes;
            [SerializeField]
            public string sCol3_MemberGameInfoes;
            [SerializeField]
            public string sCol4_MemberGameInfoes;
            [SerializeField]
            public string sCol5_MemberGameInfoes;
            [SerializeField]
            public string sCol6_MemberGameInfoes;
            [SerializeField]
            public string sCol7_MemberGameInfoes;
            [SerializeField]
            public string sCol8_MemberGameInfoes;
            [SerializeField]
            public string sCol9_MemberGameInfoes;
            [SerializeField]
            public string sCol10_MemberGameInfoes;
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